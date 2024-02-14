using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MeleeAttackBase
{    //maxLifetime, maxLifePen,dmg
    // Start is called before the first frame update
    protected override void Start()
    {
        maxLifetime = 0.5f;
        dmg = 10;
        base.Start();
    }

    // Update is called once per frame
    protected override void die()
    {
        base.die();
    }

}
