﻿using UnityEngine;
using System.Collections;

public class EnemyManager1001 : MonoBehaviour
{
	EnemyStatus Eye_F = new EnemyStatus(Enemy.Eye_F, 30f, 80f, 0f, 600f, 1, 100);
	EnemyStatus BirdL_F = new EnemyStatus(Enemy.BirdL_F, 300f, 15f, 10000f, 400f, 3, 500);
	EnemyStatus BirdChain_F = new EnemyStatus(Enemy.BirdChain_F, 300f, 15f, 10000f, 400f, 3, 500);
	EnemyStatus ChampBird_F = new EnemyStatus(Enemy.ChampBird_F, 60f, 4000f, 10f, 400f, 5, 2000);
	EnemyStatus BirdR_F = new EnemyStatus(Enemy.BirdR_F, 300f, 15f, 10000f, 400f, 3, 500);
	EnemyStatus Bird_F = new EnemyStatus(Enemy.Bird_F, 30f, 15f, 10000f, 400f, 3, 500);
	EnemyStatus Shooter_F = new EnemyStatus(Enemy.Shooter_F, 15f, 400f, 0f, 350f, 2, 300);
	EnemyStatus ChampShooter_F = new EnemyStatus(Enemy.ChampShooter_F, 60f, 4000f, 10f, 300f, 5, 2000);
	EnemyStatus Bat_F = new EnemyStatus(Enemy.Bat_F, 15f, 350f, 0f, 800f, 2, 200);
	EnemyStatus ChampBat_F = new EnemyStatus(Enemy.ChampBat_F, 50f, 3000f, 10f, 800f, 5, 2000);
	EnemyStatus Gonyak_F = new EnemyStatus(Enemy.Gonyak_F, 300f, 15f, 10000f, 300f, 3, 500);

    // Use this for initialization
    void Start()
    {
        Debug.Log("Enter EnemyManager 1001-");
        ManageStage();
    }

    void ManageStage()
    {
		StartCoroutine (SummonEnemy (2f, 3, Eye_F, CEnemy.AI.No_1_L_St, CEnemy.StartPosition.T1, 0.2f,7));		
		StartCoroutine (SummonEnemy (3f, 3, Eye_F, CEnemy.AI.No_1_R_St, CEnemy.StartPosition.T7, 0.2f,7));
		StartCoroutine (SummonEnemy (4f, 3, Eye_F, CEnemy.AI.No_2_L, CEnemy.StartPosition.L2, 0.2f,7));
		StartCoroutine (SummonEnemy (5f, 3, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine (SummonEnemy (5f, 3, Eye_F, CEnemy.AI.No_2_L, CEnemy.StartPosition.L4, 0.2f,7));
		StartCoroutine (SummonEnemy (7f, 3, Eye_F, CEnemy.AI.No_2_R, CEnemy.StartPosition.R4, 0.2f,7));
		StartCoroutine (SummonEnemy (7f, 3, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine (SummonEnemy (8f, 3, Eye_F, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine (SummonEnemy (9f, 3, Eye_F, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f,7));


		StartCoroutine (SummonEnemy (12f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T2, 0.2f,4));		
		StartCoroutine (SummonEnemy (12f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T4, 0.2f,4));
		StartCoroutine (SummonEnemy (12f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T6, 0.2f,4));
		StartCoroutine (SummonEnemy (12f, 1, Bat_F, CEnemy.AI.RE_T, CEnemy.StartPosition.T4, 0.2f));
		StartCoroutine (SummonEnemy (16f, 1, Bat_F, CEnemy.AI.RE_T, CEnemy.StartPosition.T4, 0.2f));

		StartCoroutine (SummonEnemy (22f, 1, Bat_F, CEnemy.AI.RE_L, CEnemy.StartPosition.T2, 0.2f));		
		StartCoroutine (SummonEnemy (22f, 1, Bat_F, CEnemy.AI.RE_R, CEnemy.StartPosition.T6, 0.2f));
		StartCoroutine (SummonEnemy (23f, 5, Gonyak_F, CEnemy.AI.SlL, CEnemy.StartPosition.TL, 1f));
		StartCoroutine (SummonEnemy (23f, 5, Gonyak_F, CEnemy.AI.SlR, CEnemy.StartPosition.TR, 1f));
		StartCoroutine (SummonEnemy (28f, 3, Eye_F, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine (SummonEnemy (28f, 3, Eye_F, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f,7));
		StartCoroutine (SummonEnemy (29f, 3, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));

 //Champ Start
		StartCoroutine (SummonEnemy (30f, 1, Bat_F, CEnemy.AI.RE_CL, CEnemy.StartPosition.T2, 0.2f));	
		StartCoroutine (SummonEnemy (30f, 1, ChampBat_F, CEnemy.AI.C_RE, CEnemy.StartPosition.T4, 0.2f,8)); // Champ	
		StartCoroutine (SummonEnemy (30f, 1, Bat_F, CEnemy.AI.RE_CR, CEnemy.StartPosition.T6, 0.2f));	
 //Champ End
		
		

		StartCoroutine (SummonEnemy (38f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));		
		StartCoroutine (SummonEnemy (38f, 1, BirdChain_F, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));
		StartCoroutine (SummonEnemy (38f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));
		StartCoroutine (SummonEnemy (39f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T2, 0.2f,5));
		StartCoroutine (SummonEnemy (41f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));
		StartCoroutine (SummonEnemy (41f, 1, BirdChain_F, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));
		StartCoroutine (SummonEnemy (41f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.2f));
		StartCoroutine (SummonEnemy (42f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T6, 0.2f,5));
		StartCoroutine (SummonEnemy (44f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));
		StartCoroutine (SummonEnemy (44f, 1, BirdChain_F, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));
		StartCoroutine (SummonEnemy (44f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));
		StartCoroutine (SummonEnemy (44f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T2, 0.2f,5));

		StartCoroutine (SummonEnemy (48f, 1, Gonyak_F, CEnemy.AI.Fo, CEnemy.StartPosition.T2, 0.2f));		
		StartCoroutine (SummonEnemy (48f, 1, Gonyak_F, CEnemy.AI.Fo, CEnemy.StartPosition.T6, 0.2f));
		StartCoroutine (SummonEnemy (48f, 1, Shooter_F, CEnemy.AI.Sho_L, CEnemy.StartPosition.L1, 0.2f,6));
		StartCoroutine (SummonEnemy (49f, 1, Shooter_F, CEnemy.AI.Sho_R, CEnemy.StartPosition.R1, 0.2f,6));
		StartCoroutine (SummonEnemy (49f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T3, 0.2f,6));
		StartCoroutine (SummonEnemy (49f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T5, 0.2f,6));
		StartCoroutine (SummonEnemy (50f, 1, Gonyak_F, CEnemy.AI.Fo, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine (SummonEnemy (50f, 1, Gonyak_F, CEnemy.AI.Fo, CEnemy.StartPosition.T6, 0.2f));
		StartCoroutine (SummonEnemy (51f, 1, Shooter_F, CEnemy.AI.Sho_L, CEnemy.StartPosition.L2, 0.2f,6));
		StartCoroutine (SummonEnemy (51f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T2, 0.2f,6));
		StartCoroutine (SummonEnemy (51f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T6, 0.2f,6));
		StartCoroutine (SummonEnemy (51f, 1, Shooter_F, CEnemy.AI.Sho_R, CEnemy.StartPosition.R2, 0.2f,6));

//Champ Start
		StartCoroutine (SummonEnemy (60f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T1, 0.2f,1));	
		StartCoroutine (SummonEnemy (60f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T2, 0.2f,6));	
		StartCoroutine (SummonEnemy (60f, 1, ChampShooter_F, CEnemy.AI.C_SHO, CEnemy.StartPosition.T4, 0.2f,9));	//Champ
		StartCoroutine (SummonEnemy (60f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T6, 0.2f,6));	
		StartCoroutine (SummonEnemy (60f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T7, 0.2f,1));	

 //Champ End
		

		StartCoroutine (SummonEnemy (68f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));		
		StartCoroutine (SummonEnemy (68f, 1, BirdChain_F, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));
		StartCoroutine (SummonEnemy (68f, 1, BirdChain_F, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));
		StartCoroutine (SummonEnemy (68f, 1, BirdChain_F, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));
		StartCoroutine (SummonEnemy (68f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));

		StartCoroutine (SummonEnemy (74f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));
		StartCoroutine (SummonEnemy (74f, 1, BirdChain_F, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));
		StartCoroutine (SummonEnemy (74f, 1, BirdChain_F, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));
		StartCoroutine (SummonEnemy (74f, 1, BirdChain_F, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));
		StartCoroutine (SummonEnemy (74f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.2f));

		StartCoroutine (SummonEnemy (77f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));		
		StartCoroutine (SummonEnemy (77f, 1, BirdChain_F, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));
		StartCoroutine (SummonEnemy (77f, 1, BirdChain_F, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));
		StartCoroutine (SummonEnemy (77f, 1, BirdChain_F, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));
		StartCoroutine (SummonEnemy (77f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));
		
		StartCoroutine (SummonEnemy (79f, 3, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.5f));		
		StartCoroutine (SummonEnemy (81f, 3, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.5f));
		StartCoroutine (SummonEnemy (81f, 3, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T6, 0.5f));
		StartCoroutine (SummonEnemy (79f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T1, 0.2f, 6));
		StartCoroutine (SummonEnemy (79f, 1, Shooter_F, CEnemy.AI.Wat, CEnemy.StartPosition.T7, 0.2f, 6));
		StartCoroutine (SummonEnemy (83f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.5f));
		StartCoroutine (SummonEnemy (83f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.5f));

//Champ Start
		StartCoroutine (SummonEnemy (90f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));
		StartCoroutine (SummonEnemy (90f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));	
		StartCoroutine (SummonEnemy (90f, 1, ChampBird_F, CEnemy.AI.C_BRD, CEnemy.StartPosition.T4, 0.2f,8));	//Champ
		StartCoroutine (SummonEnemy (90f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));	
		StartCoroutine (SummonEnemy (90f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.2f));

		StartCoroutine (SummonEnemy (92f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));
		StartCoroutine (SummonEnemy (92f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));	
		StartCoroutine (SummonEnemy (92f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));	
		StartCoroutine (SummonEnemy (92f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));

		StartCoroutine (SummonEnemy (94f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));
		StartCoroutine (SummonEnemy (94f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));	
		StartCoroutine (SummonEnemy (94f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));	
		StartCoroutine (SummonEnemy (94f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.2f));

		StartCoroutine (SummonEnemy (96f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));
		StartCoroutine (SummonEnemy (96f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));	
		StartCoroutine (SummonEnemy (96f, 1, BirdL_F, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));	
		StartCoroutine (SummonEnemy (96f, 1, BirdR_F, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.2f));
 //Champ End
		StartCoroutine (SummonEnemy (99f, 1, Bat_F, CEnemy.AI.RE_L, CEnemy.StartPosition.T2, 0.2f));		
		StartCoroutine (SummonEnemy (99f, 1, Bat_F, CEnemy.AI.RE_R, CEnemy.StartPosition.T6, 0.2f));
		StartCoroutine (SummonEnemy (99f, 5, Gonyak_F, CEnemy.AI.SlL, CEnemy.StartPosition.TL, 1f));
		StartCoroutine (SummonEnemy (100f, 1, Shooter_F, CEnemy.AI.Sho_R, CEnemy.StartPosition.TR, 0.2f,4));
		StartCoroutine (SummonEnemy (100f, 1, Shooter_F, CEnemy.AI.Sho_L, CEnemy.StartPosition.TL, 0.2f,4));
		StartCoroutine (SummonEnemy (101f, 5, Gonyak_F, CEnemy.AI.SlR, CEnemy.StartPosition.TR, 1f));
		StartCoroutine (SummonEnemy (100f, 3, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f));
		StartCoroutine (SummonEnemy (101f, 1, Shooter_F, CEnemy.AI.SlL, CEnemy.StartPosition.TL, 0.2f,4));
		StartCoroutine (SummonEnemy (102f, 1, Shooter_F, CEnemy.AI.SlR, CEnemy.StartPosition.TR, 0.2f,4));
		StartCoroutine (SummonEnemy (103f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine (SummonEnemy (103f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T6, 0.2f));

		StartCoroutine (SummonEnemy (107f, 1, Bat_F, CEnemy.AI.RE_L, CEnemy.StartPosition.T2, 0.2f));		
		StartCoroutine (SummonEnemy (107f, 1, Bat_F, CEnemy.AI.RE_R, CEnemy.StartPosition.T6, 0.2f));
		StartCoroutine (SummonEnemy (108f, 3, Eye_F, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T3, 0.2f));
		StartCoroutine (SummonEnemy (108f, 3, Eye_F, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T5, 0.2f));
		StartCoroutine (SummonEnemy (109f, 1, Shooter_F, CEnemy.AI.Sho_L, CEnemy.StartPosition.R2, 0.2f,4));
		StartCoroutine (SummonEnemy (119f, 1, Shooter_F, CEnemy.AI.Sho_R, CEnemy.StartPosition.L2, 0.2f,4));
		StartCoroutine (SummonEnemy (112f, 1, Shooter_F, CEnemy.AI.Sho_L, CEnemy.StartPosition.R1, 0.2f,6));
		StartCoroutine (SummonEnemy (112f, 1, Shooter_F, CEnemy.AI.Sho_R, CEnemy.StartPosition.L1, 0.2f,6));
		StartCoroutine (SummonEnemy (113f, 3, Eye_F, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine (SummonEnemy (113f, 3, Eye_F, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine (SummonEnemy (114f, 3, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));

        StartCoroutine(CallBossManager(120.0f, 1000));

    }

    IEnumerator CallEnemyManager(float time, int index)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Destroy EnemyManager 1000-");

        GameObject.Find("StageManager").SendMessage("CallEnemyManager", index);
    }
    IEnumerator CallBossManager(float time, int index)
    {
        yield return new WaitForSeconds(time);
        GameObject.Find("StageManager").SendMessage("CallBossManager", index);
    }
    IEnumerator DestroyBossManager(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Find("StageManager").SendMessage("DestroyBossManager");
    }

    IEnumerator SummonEnemy(float summon_time,
                            int number_of_summon,
                            EnemyStatus enemy_,
                            CEnemy.AI AI_type,
                            CEnemy.StartPosition start_position,
                            float delay = 0.5f,
                            int shooter_num = 0)
    {
        GameObject enemy;

        enemy = ResourceLoad.PickGameObject(enemy_.name.ToString());

        yield return new WaitForSeconds(summon_time);

        int InfinityCount = StageManager.InfinityModeCount;
        if (InfinityCount < 0)
        {
            InfinityCount = 1;
        }
        
        for (int formation = 0; formation < number_of_summon; formation++)
        {
            GameObject temp = (GameObject)Instantiate(enemy, CEnemy.GetStartPosition(start_position), Quaternion.identity);
            CEnemy temp_enemy = temp.GetComponent<CEnemy>();
            temp_enemy.Initialize(
				AI_type,
				enemy_.ATK + ((InfinityCount - 1) * enemy_.ATK * 0.18f),
				enemy_.HP + ((InfinityCount - 1) * enemy_.HP * 0.18f),
				enemy_.SPD,
				enemy_.DEF,
				shooter_num,
				enemy_.coin_amount,
				enemy_.score + ((InfinityCount - 1) / 2 * 100)
				);

            yield return new WaitForSeconds(delay);
        }
    }
}
