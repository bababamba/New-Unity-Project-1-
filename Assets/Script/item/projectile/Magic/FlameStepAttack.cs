using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameStepAttack : AttackBase
{
    protected override void Start()
    {
        maxLifetime = 2f;
        dmg = 5f;
        type = Type.FIRE;
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

    // 지속딜 형태를 위해 피격 대상이 틱당 피해를 받도록 수정
    public new void OnTriggerEnter2D(Collider2D col)
    {
        enemy_base enemy = col.GetComponent<enemy_base>();
        if (col.CompareTag("Enemy"))
            enemyInRange.Add(enemy);

        if (enemy != null)
        {
            enemy.takeDamage(dmg);
        }
    }

}
