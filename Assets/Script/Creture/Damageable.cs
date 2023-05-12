using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    private int curHP;
    private int maxHP;
    public GameObject owner;
    
    // Start is called before the first frame update
    private void Start()
    {
    }

    protected int getCurHP()
    {

        return this.curHP;
    }
    protected int getCurHPPercent()
    {

        return this.curHP;
    }
    protected int getMaxHP()
    {

        return this.maxHP;
    }
    protected void addCurHP(int value)
    {
        if(value > 0)
        {
            this.curHP += value;
            if (this.curHP > this.maxHP)
                this.curHP = this.maxHP;
        }
        else
        {
            this.curHP += value;
            if (this.curHP <= 0)
                death();

        }
    }
    protected void setCurHP(int value)
    {
        if (value > 0)
        {
            this.curHP = value;
            if (this.curHP > this.maxHP)
                this.curHP = this.maxHP;
        }
        else
        {
            this.curHP = value;
            if (this.curHP <= 0)
                death();

        }
    }
    protected void addMaxHP(int value)
    {
        if (value > 0)
        {
            this.maxHP += value;

        }
        else
        {
            this.maxHP += value;
            if (this.maxHP < this.curHP)
            {
                this.curHP = this.maxHP;
            }
        }
    }
    protected void setMaxHP(int value)
    {
        if (value > 0)
        {
            this.maxHP = value;

        }
        else
        {
            this.maxHP = value;
            if (this.maxHP < this.curHP)
            {
                this.curHP = this.maxHP;
            }
        }
    }
    protected virtual void death() 
    {
        Debug.Log("die,potato,die");
        Destroy(owner);

     }
}
