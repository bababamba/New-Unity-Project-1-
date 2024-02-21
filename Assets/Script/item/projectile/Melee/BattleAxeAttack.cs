using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAxeAttack : AttackBase
{    //maxLifetime, maxLifePen,dmg
    // Start is called before the first frame update
    protected override void Start()
    {
        maxLifetime = 0.25f;
        dmg = 10;
        isMelee = true;
        knockbackForce = 0.1f;
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        this.transform.position = new Vector3(player.transform.position.x + position.x, player.transform.position.y + position.y);
    }

    // Update is called once per frame
    protected override void die()
    {
        base.die();
    }

}