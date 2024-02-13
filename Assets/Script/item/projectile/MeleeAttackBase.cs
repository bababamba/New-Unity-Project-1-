using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackBase : projectile_base
{
    List<Collider2D> enemyInRange;
    List<Collider2D> enemyAttacked;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (lifeTime > 0f)
        {
            lifeTime -= Time.deltaTime;
        }
        else
            die();
        Vector2 bulletPosition = transform.position;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
            enemyInRange.Add(col);
        enemy_base enemy = col.GetComponent<enemy_base>();
        if(enemy != null && !enemyAttacked.Contains(col))
        {
            enemy.takeDamage(dmg);
            enemyAttacked.Add(col);
        }
    }

    protected override void die()
    {
        base.die();
    }
}
