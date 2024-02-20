using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballExplosion : AttackBase
{
    protected override void Start()
    {
        maxLifetime = 1f;
        dmg = 10;
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

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

        if (enemy != null && !enemyAttacked.Contains(enemy))
        {
            enemy.takeDamage(dmg);
        }
    }

}
