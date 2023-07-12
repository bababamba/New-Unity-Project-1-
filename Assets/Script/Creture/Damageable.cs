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

    public int getCurHP()
    {

        return this.curHP;
    }
    public int getCurHPPercent()
    {

        return this.curHP;
    }
    public int getMaxHP()
    {

        return this.maxHP;
    }
    public void addCurHP(int value)
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
    public void setCurHP(int value)
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
    public void addMaxHP(int value)
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
            if (this.curHP <= 0)
                death();
        }
    }
    public void setMaxHP(int value)
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
            if (this.curHP <= 0)
                death();
        }
    }
    public virtual void death() 
    {
        
        Destroy(gameObject);

     }
}
