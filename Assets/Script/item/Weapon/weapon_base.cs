using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_base : item_base
{
    protected float basic_attack;
    protected float add;
    protected float apd;
    protected float dmg;
    protected Transform here;
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

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        

    }
    protected float calcDmg()
    {
        dmg = 0f;
        dmg += playerScript.ad * add;
        dmg += playerScript.ap * apd;
        dmg += basic_attack;
        return dmg;
    }
    
}
