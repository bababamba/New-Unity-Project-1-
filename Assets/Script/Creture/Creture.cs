using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creture : Damageable
{
    protected float speed;
    protected int type;
    protected GameObject Manager;
    protected void init(int max, float speed, int type)
    {
        Manager = GameObject.Find("GameManager");
        this.setMaxHP(max);
        this.setCurHP(max);
        this.speed = speed;
        this.type = type;
    }
    protected virtual void takeDamage(int dmg)
    {
        this.addCurHP(-dmg);
    }
    protected virtual void attack()
    {
    }
    protected override void death()
    {
        base.death();
        Debug.Log("Cre death!");
    }
}
