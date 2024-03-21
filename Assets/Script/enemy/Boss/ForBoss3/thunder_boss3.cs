using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunder_boss3 : enemyExplosionBase
{
    protected override void Start()
    {
        dmg = 5;
        maxLifeTime = 10;
        maxDmgDuration = 0.3f;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
