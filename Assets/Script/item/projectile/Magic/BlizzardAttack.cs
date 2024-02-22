using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlizzardAttack : AttackBase
{
    protected override void Start()
    {
        maxLifetime = 3f;
        dmg = 10;
        type = Type.ICE;
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

    }

    // Update is called once per frame
    protected override void die()
    {
        base.die();
    }

}
