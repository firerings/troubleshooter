﻿using UnityEngine;
using System.Collections;

public class IfritRightArm : CBoss {

	const int NUMBER_OF_ARM_IMAGES = 2;

	[SerializeField]
	Ifrit boss;
	[SerializeField]
	Transform right_shoulder;
	[SerializeField]
	IfritRightHand right_hand;
	
	Sprite[] sprites = new Sprite[NUMBER_OF_ARM_IMAGES];

	// Use this for initialization
	void Start () {
		tag = "boss_part";

        max_HP = GameObject.Find("Ifrit(Clone)").GetComponent<Ifrit>().max_HP * 0.5f;
		HP = max_HP;
		attribute = Attribute.FIRE;

		LoadSprites();
		transform.position = right_shoulder.position + new Vector3(boss.gameObject.transform.localScale.x * 32.5f, boss.gameObject.transform.localScale.y * -264f, -0.01f);
	}

	void LoadSprites()
	{
		sprites[0] = Resources.Load<Sprite>("Images/Enemy/Boss/Rarm");
		sprites[1] = Resources.Load<Sprite>("Images/Enemy/Boss/Rarmswing");
	}

	void OnEnable()
	{
		if (BossManager1.boss_state == Ifrit.BossState.ArmRegeneration_4 ||
		    BossManager1.boss_state == Ifrit.BossState.ArmRegeneration_5)

		{
			HP = max_HP;

			transform.rotation = Quaternion.identity;
			gameObject.GetComponent<Renderer>().material.color = Color.white;
			right_hand.gameObject.GetComponent<Renderer>().material.color = Color.white;

			Hashtable command = iTween.Hash("alpha", 0f, "time", 3f);
			iTween.FadeFrom(gameObject, command);
		}
		else if (BossManager1.boss_state == Ifrit.BossState.Diverge)
		{
			HP = max_HP;
			
			transform.rotation = Quaternion.identity;
			gameObject.GetComponent<Renderer>().material.color = Color.white;
			right_hand.gameObject.GetComponent<Renderer>().material.color = Color.white;
			
			Hashtable command = iTween.Hash("alpha", 0f, "time", 1f);
			iTween.FadeFrom(gameObject, command);
		}
	}

	// Update is called once per frame
	void Update () {
		if (BossManager1.boss_state != Ifrit.BossState.BothRocketPunch &&
		    BossManager1.boss_state != Ifrit.BossState.RocketPunch &&
		    BossManager1.boss_state != Ifrit.BossState.EnergyBall &&
		    BossManager1.boss_state != Ifrit.BossState.Laser)
			transform.position = right_shoulder.position + new Vector3(boss.gameObject.transform.localScale.x * 32.5f, boss.gameObject.transform.localScale.y * -264f, -0.01f);
	}

	void ApplyState(float[] state_DMG) // {applying_state, percent, duration}
	{
		if (BossManager1.boss_state == Ifrit.BossState.Intro ||
		    BossManager1.boss_state == Ifrit.BossState.Diverge ||
		    BossManager1.boss_state == Ifrit.BossState.EnergyBall || 
		    BossManager1.boss_state == Ifrit.BossState.ArmRegeneration_4 ||
		    BossManager1.boss_state == Ifrit.BossState.ArmRegeneration_5)
			return;
		
		boss.state_percentage[(int)state_DMG[0]] = state_DMG[1];
		
		if (boss.state[(int)state_DMG[0]])
			boss.state_overridden[(int)state_DMG[0]]++;
		
		StartCoroutine(StateApplier((State)(int)state_DMG[0], state_DMG[2]));
	}
	
	IEnumerator StateApplier(State applying_state, float duration)
	{
		boss.state[(int)applying_state] = true;
		
		yield return new WaitForSeconds(duration);
		
		if (boss.state_overridden[(int)applying_state] > 0)
			boss.state_overridden[(int)applying_state]--;
		else
			boss.state[(int)applying_state] = false;
	}
	
	void ApplyDamage(float[] damage) // {damage, attribute)
	{
		if (BossManager1.boss_state == Ifrit.BossState.Intro ||
		    BossManager1.boss_state == Ifrit.BossState.Diverge ||
		    BossManager1.boss_state == Ifrit.BossState.EnergyBall || 
		    BossManager1.boss_state == Ifrit.BossState.ArmRegeneration_4 ||
		    BossManager1.boss_state == Ifrit.BossState.ArmRegeneration_5)
			return;
		
		float bullet_damage = damage[0];
		Attribute bullet_attribute = (Attribute)damage[1];
		
		if (boss.state[(int)State.Amplification])
			bullet_damage *= 1f + boss.state_percentage[(int)State.Amplification];
		if (boss.state[(int)State.Shock])
			ApplyShock(damage[0]);
		
		if (attribute == Attribute.FIRE && bullet_attribute == Attribute.NATURE ||
		    attribute == Attribute.AQUA && bullet_attribute == Attribute.FIRE ||
		    attribute == Attribute.NATURE && bullet_attribute == Attribute.AQUA)
			bullet_damage *= 0.5f;
		else if (attribute == Attribute.FIRE && bullet_attribute == Attribute.AQUA ||
		         attribute == Attribute.AQUA && bullet_attribute == Attribute.NATURE ||
		         attribute == Attribute.NATURE && bullet_attribute == Attribute.FIRE)
			bullet_damage *= 2f;
		
		Hit(bullet_damage - CalculateEffectiveDefense());
	}
	
	void ApplyShock(float damage)
	{
		damage *= boss.state_percentage[(int)State.Shock];
		
		Hit(damage - CalculateEffectiveDefense());
	}
	
	float CalculateEffectiveDefense()
	{
		float effective_defense = DEF;
		
		float defense_percentage = 0f;
		if (boss.state[(int)State.ShieldUp])
			defense_percentage += boss.state_percentage[(int)State.ShieldUp];
		if (boss.state[(int)State.ArmorBreak])
			defense_percentage -= boss.state_percentage[(int)State.ArmorBreak];
		
		effective_defense *= 1f + defense_percentage;
		
		return effective_defense;
	}
	
	void Hit(float damage)
	{
		if (damage < 0)
			damage = 1f;

		HP -= damage;
		
		if (HP <= 0)
		{
			BossDeadMotion();
			DropItem();
			iTween.Stop(gameObject);
			gameObject.SetActive(false);
		}
		else
			StartKiraring();
	}

	public void StartKiraring() 
	{
		StartCoroutine(Kiraring());
		
		right_hand.StartKiraring();
	}
	
	public void StartRocketPunch()
	{
		StartCoroutine(RocketPunch());
	}
	
	IEnumerator RocketPunch()
	{
		right_hand.StartRocketPunch();
		
		GameObject player = GameObject.FindWithTag("player");
		
		Vector3 target = (player != null)? player.transform.position : new Vector3(0f, -800f, 0f);
		Vector3 diff = target - transform.position;
		
		float angle = Vector3.Angle(Vector3.down, diff);
		
		angle *= (diff.x > 0)? 1 : -1;
		
		iTween.RotateTo(gameObject, Vector3.forward * angle, 0.8f);
		
		Hashtable command = iTween.Hash("position", target, "easetype", iTween.EaseType.easeInOutBack, "speed", 500f, "delay", 0.8f, "oncomplete", "Return");
		iTween.MoveTo(gameObject, command);

		yield return null;
	}
	
	void Return()
	{
		Hashtable rotate_command = iTween.Hash("rotation", Vector3.zero, "time", 0.8f, "oncomplete", "OnRocketPunchComplete", "delay", 2f);
		iTween.RotateTo(gameObject, rotate_command);
		
		Hashtable move_command = iTween.Hash("position", right_shoulder.position + new Vector3(32.5f, -264f, -0.01f), "easetype", iTween.EaseType.easeInOutQuad, "time", 2f);
		iTween.MoveTo(gameObject, move_command);
	}
	
	void OnRocketPunchComplete()
	{
		right_hand.StartReturn();

		transform.position = right_shoulder.position + new Vector3(32.5f, -264f, -0.01f);
	}

	public void StartPillKill()
	{
		StartCoroutine("PillKill");
	}
	
	IEnumerator PillKill()
	{
		right_hand.StopShooting();

		Guard();
		
		right_hand.StartPillKillGrab();
		yield return new WaitForSeconds(1f);
		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
		yield return new WaitForSeconds(0.3f);
		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
		yield return new WaitForSeconds(0.7f);
		right_hand.StartPillKillUnfold();
		yield return new WaitForSeconds(1f);
		Charge();
		yield return new WaitForSeconds(8.5f);

		OnPillKillComplete();
	}
	
	void Guard()
	{
		Hashtable move_command = iTween.Hash("amount", 50f * Vector3.up, "time", 1f, "easetype", iTween.EaseType.easeOutQuad);
		iTween.MoveBy(gameObject, move_command);
		
		Hashtable rotate_command = iTween.Hash("rotation", Vector3.forward * 90f, "delay", 1f, "time", 2f);
		iTween.RotateTo(gameObject, rotate_command);
	}
	
	void Charge()
	{
		Hashtable command = iTween.Hash("amount", 70f * Vector3.down, "time", 8f, "easetype", iTween.EaseType.linear);
		iTween.MoveBy(gameObject, command);
	}

	IEnumerator ReturnPillKill()
	{
		Hashtable move_command = iTween.Hash("position", right_shoulder.position + new Vector3(32.5f, -264f, -0.01f), "time", 2.5f);
		Hashtable rotate_command = iTween.Hash("rotation", Vector3.zero, "time", 2.5f);

		while (true)
		{
			iTween.MoveUpdate(gameObject, move_command);
			iTween.RotateUpdate(gameObject, rotate_command);

			yield return null;
		}
	}

	void OnPillKillComplete()
	{
		right_hand.StartPillKillReturn();

		StartCoroutine(CompletePillKill());
	}

	IEnumerator CompletePillKill()
	{
		StartCoroutine("ReturnPillKill");
		yield return new WaitForSeconds(4f);
		StopCoroutine("ReturnPillKill");

		transform.rotation = Quaternion.identity;
	}

	public void CancelPillKill()
	{
		StopCoroutine("PillKill");
		
		OnPillKillComplete();
	}
}
