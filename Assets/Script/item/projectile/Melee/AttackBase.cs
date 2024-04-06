using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : projectile_base
{
    protected GameObject Manager;
    protected GameManager gameManager;
    protected int playerNumber = 0;
    protected List<enemy_base> enemyInRange;
    protected List<enemy_base> enemyAttacked;

    public GameObject player;
    public Vector2 position;
    protected float knockbackForce;
    public int addDmg;

    public enum Type
    {
        FIRE = 0,
        ICE = 1,
        ELEC = 2,
        MELEE = 3
    }
    public Type type;


    protected override void Start()
    {
        base.Start();
                Manager = GameObject.Find("GameManager");
        gameManager = Manager.GetComponent<GameManager>();
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
        for(int i = enemyInRange.Count - 1; i >= 0; i--)
        {
            if (enemyInRange[i] == null)
                enemyInRange.RemoveAt(i);
        }

        Vector2 bulletPosition = transform.position;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        enemy_base enemy = col.GetComponent<enemy_base>();
        if (col.CompareTag("Enemy"))
            enemyInRange.Add(enemy);
 
        if(enemy != null && !enemyAttacked.Contains(enemy))
        {
            enemy.takeDamage(dmg + addDmg);
            if(enemy != null && type == Type.MELEE)
                KnockBack(enemy.transform);
            if (enemy != null && type == Type.ICE)
                enemy.frozen = true;
            enemyAttacked.Add(enemy);
        }
    }

    protected override void die()
    {
        base.die();
    }

    public void KnockBack(Transform target)
    {
        Vector2 direction = (target.position - player.transform.position).normalized;
        target.GetComponent<enemy_base>().Knockback(direction, knockbackForce);
    }

}
