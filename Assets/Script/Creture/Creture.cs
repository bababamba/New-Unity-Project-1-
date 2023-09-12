using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creture : Damageable
{
    protected float speed;
    protected int type;
    protected GameObject Manager;
    protected GameManager gameManager;
    protected void init(int max, float speed, int type)
    {
        Manager = GameObject.Find("GameManager");
        gameManager = Manager.GetComponent<GameManager>();
        this.setMaxHP(max);
        this.setCurHP(max);
        this.speed = speed;
        this.type = type;
    }

    public virtual void takeDamage(float dmg)
    {
        this.addCurHP(-dmg);
    }
    protected virtual void attack()
    {
    }
    public override void death()
    {
        base.death();
    }
    public void SetManager()
    {
        Manager = GameObject.Find("GameManager");
        gameManager = Manager.GetComponent<GameManager>();
    }
}
