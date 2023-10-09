using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPro_1 : enemyProjectileBase
{
    //maxLifetime, maxLifePen,dmg
    // Start is called before the first frame update
    protected override void Start()
    {
        maxLifetime = 5;
        maxLifePen = 1;
        dmg = 10;
        base.Start();
    }

    // Update is called once per frame
    protected override void die()
    {
        base.die();
    }
    // Start is called before the first frame update

}
