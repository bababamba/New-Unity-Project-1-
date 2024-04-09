using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_base : item_base
{
    protected float basic_attack;
    protected float baseDmg;
    protected float dpl;
    protected float dmg;
    protected Transform here;
    protected bool isMelee = false;

    public int weaponLevel = 1;

    private void Awake()
    {
        isPassive = false;
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        itemType = 1;
       

    }

    public virtual void Init() { }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        

    }
    protected float calcDmg()
    {
        dmg = 0f;
        dmg += baseDmg;
        dmg += dpl * (weaponLevel - 1);
        return dmg;
    }
    
}
