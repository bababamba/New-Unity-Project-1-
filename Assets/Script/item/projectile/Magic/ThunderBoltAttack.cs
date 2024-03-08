using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBoltAttack : AttackBase
{
    public float totalDmg;
    public bool left;
    protected override void Start()
    {
        maxLifetime = 2f;
        dmg = 10;
        type = Type.ELEC;
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (left)
            this.transform.position = player.transform.position - new Vector3(5.25f, 0, 0);
        else
            this.transform.position = player.transform.position + new Vector3(5.25f, 0, 0);
    }

    // Update is called once per frame
    protected override void die()
    {
        base.die();
    }


    public new void OnTriggerEnter2D(Collider2D col)
    {
        enemy_base enemy = col.GetComponent<enemy_base>();
        if (col.CompareTag("Enemy"))
            enemyInRange.Add(enemy);

        if (enemy != null)
        {
            enemy.takeDamage(dmg / enemyInRange.Count);
        }
    }

}
