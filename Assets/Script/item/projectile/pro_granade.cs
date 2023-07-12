using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pro_granade : projectile_base
{//maxLifetime, maxLifePen,dmg
    // Start is called before the first frame update
    public GameObject BOOM;
    areaD_base boomScript;
    int boomDmg;
    protected override void Start()
    {
        maxLifetime = 5;
        maxLifePen = 1;
        dmg = 1;
        base.Start();
    }

    // Update is called once per frame
    protected override void die()
    {
        GameObject kaboom = Instantiate(BOOM, this.transform.position, Quaternion.identity);
        boomScript = kaboom.GetComponent<areaD_base>();
        boomScript.init(boomDmg, 1, 0, 0.5f);
        base.die();
    }
    public override void init(int iDmg, float iMaxLifetime, int iMaxLifePen)
    {
        base.init(1, iMaxLifetime, iMaxLifePen);
    }
}
