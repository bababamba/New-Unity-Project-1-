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

    // ���ӵ� ���¸� ���� �ǰ� ����� ƽ�� ���ظ� �޵��� ����
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
