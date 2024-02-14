using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAttack : MeleeAttackBase
{    //maxLifetime, maxLifePen,dmg
    // Start is called before the first frame update
    public float angle = 0;
    public float spinSpeed = 0.1f;
    protected override void Start()
    {
        maxLifetime = 5;
        dmg = 10;
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        angle += spinSpeed;
        this.transform.position = new Vector2(player.transform.position.x + Mathf.Cos(angle), player.transform.position.y + Mathf.Sin(angle));
    }

    // Update is called once per frame
    protected override void die()
    {
        base.die();
    }

}
