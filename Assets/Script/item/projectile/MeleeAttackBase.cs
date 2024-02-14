using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackBase : projectile_base
{
    List<enemy_base> enemyInRange;
    List<enemy_base> enemyAttacked;

    protected override void Start()
    {
        base.Start();
        enemyInRange = new List<enemy_base>();
        enemyAttacked = new List<enemy_base>();
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
        enemy_base enemy = col.GetComponent<enemy_base>();
        if (col.CompareTag("Enemy"))
            enemyInRange.Add(enemy);
 
        if(enemy != null && !enemyAttacked.Contains(enemy))
        {
            enemy.takeDamage(dmg);
            enemyAttacked.Add(enemy);
        }
    }

    protected override void die()
    {
        base.die();
    }
}
