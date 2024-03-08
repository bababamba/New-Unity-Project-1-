using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAttack : AttackBase
{    //maxLifetime, maxLifePen,dmg
    // Start is called before the first frame update
    public float angle = 0;
    public float spinSpeed;
    public float radius;
    protected override void Start()
    {
        radius = 2;
        spinSpeed = 0.05f;
        maxLifetime = 5;
        dmg = 10;
        type = Type.MELEE;
        knockbackForce = 10f;
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        angle += this.spinSpeed;
        this.transform.position = new Vector2(player.transform.position.x + radius * Mathf.Cos(angle), player.transform.position.y + radius * Mathf.Sin(angle));
    }

    // Update is called once per frame
    protected override void die()
    {
        base.die();
    }

}
