using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    private float curHP;
    private float maxHP;
    public GameObject owner;
    
    // Start is called before the first frame update
    private void Start()
    {
    }

    public float getCurHP()
    {

        return this.curHP;
    }
    public float getCurHPPercent()
    {

        return this.curHP;
    }
    public float getMaxHP()
    {

        return this.maxHP;
    }
    public void addCurHP(float value)
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
    public void setCurHP(float value)
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
    public void addMaxHP(float value)
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
    public void setMaxHP(float value)
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
