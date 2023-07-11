using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pro_granade : projectile_base
{//maxLifetime, maxLifePen,dmg
    // Start is called before the first frame update
    public GameObject BOOM;
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
        base.die();
    }
}
