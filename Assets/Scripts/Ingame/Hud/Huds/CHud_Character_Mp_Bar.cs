﻿using UnityEngine;
using System.Collections;

public class CHud_Character_Mp_Bar : CHud
{
    GameObject player;
    UISlider me;
    float value;
    bool check;

    private PlayerManager playerManager;
    // Use this for initialization
    void Start()
    {
        player = null;
        me = gameObject.GetComponent<UISlider>();
        value = 0.0f;
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && playerManager != null)
        {
            if ((me.value != (playerManager.MP_current) / (playerManager.MP_max)) && !check)
           {
               check = true;
               StartCoroutine("gaugechange");
           }
           
            me.value = value;
        }
    }
    public override void Init()
    {
        original_pos = gameObject.transform.position;
        disappear_pos = original_pos;
        // disappear_pos.x = -0.7f;
        disappear_pos.y -= 0.17f;
        player = GameObject.Find("PlayerManager");
        if (player != null)
        {
            playerManager = player.GetComponent<PlayerManager>();
        }

    }

    IEnumerator gaugechange()
    {
        if (playerManager != null)
        {
            iTween.ValueTo(gameObject, iTween.Hash("from", me.value,
                "to", (playerManager.MP_current) / (playerManager.MP_max),
                "time", 0.2f, "onupdate", "valuechange", "ignoretimescale", true));
        }
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.2f));
        check = false;
    }

    void valuechange(float t_value)
    {
        value = t_value;
    }
    public override void appear()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", original_pos, "easeType", "easeInOutCubic", "time", 0.2f, "ignoretimescale", true));
    }
    public override void disappear()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", disappear_pos, "easeType", "easeInOutCubic", "time", 0.2f, "ignoretimescale", true));
    }
}
