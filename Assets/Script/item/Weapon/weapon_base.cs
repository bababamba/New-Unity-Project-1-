using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_base : item_base
{
    protected int basic_attack;
    protected int add;
    protected int apd;
    protected int dmg;
    protected Transform here;
    private void Awake()
    {
        isPassive = false;
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        dmg += playerScript.ad * add;
        dmg += playerScript.ap * apd;
        dmg += basic_attack;

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        

    }
    
}
