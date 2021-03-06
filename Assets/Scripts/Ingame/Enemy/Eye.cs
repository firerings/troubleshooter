﻿using UnityEngine;
using System.Collections;

public class Eye : CEnemy
{
    enemyShooter shooter1;

    public override void SetMonsterType()
    {
        switch (gameObject.name)
        {
            case "Eye_F(Clone)":
                attribute = Attribute.FIRE;
                break;
            case "Eye_A(Clone)":
                attribute = Attribute.AQUA;
                break;
            case "Eye_N(Clone)":
                attribute = Attribute.NATURE;
                break;
            default:
                ////Debug.log("Enemy : Eye - Wrong Name");
                break;
        }
    }

    public override void SetItemDropRate()
    {
        heal_amount = 0;
        mana_amount = 0;
    }

    public override bool SetShooter()
    {
        shooter1 = gameObject.GetComponentInChildren<enemyShooter>();
        if (shooter1 == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public override void SetBulletInfo(int num_, Attribute attribute_, HitType hit_type_, float SPD_, float ATK_, State state_, float size_)
    {
        shooter1.SetBulletInfo(num_, attribute_, hit_type_, SPD_, ATK_, state_, size_);
    }

    public override void SetShooitngInfo(int way_, int amount_, int reapeat_, float period_, float delay_, float angle_)
    {
        shooter1.SetShooitngInfo(way_, amount_, reapeat_, period_, delay_, angle_);
    }


    public override void ShootOnce()
    {
        shooter1.ShootOnce();
    }

    public override void StartShooting()
    {
        shooter1.StartShooting();
    }

    public override void StopShooting()
    {
        shooter1.StartShooting();
    }

    public override void StartAiming()
    {
        shooter1.StartAiming();
    }
}
