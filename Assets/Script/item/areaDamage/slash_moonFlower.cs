using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash_moonFlower : areaD_base
{// dmg, maxLifeTime, maxDmgDuration, effectTime
    // Start is called before the first frame update
    protected override void Start()
    {
        dmg = 40;
        maxLifeTime = 0;
        effectTime = 0.2f;
        base.Start();
    }

    // Update is called once per frame
    protected override void die()
    {
        forEffect = true;

    }
}