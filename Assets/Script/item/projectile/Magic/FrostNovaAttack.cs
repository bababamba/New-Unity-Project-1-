using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostNovaAttack : AttackBase
{
    protected override void Start()
    {
        maxLifetime = 1f;
        dmg = 3;
        type = Type.ICE;
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y);
    }

    // Update is called once per frame
    protected override void die()
    {
        base.die();
    }


}
