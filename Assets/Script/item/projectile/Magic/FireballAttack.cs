using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAttack : AttackBase
{
    public GameObject target;
    public GameObject explosion;
    public float moveSpeed;
    public FireballExplosion explosionScript;

    public bool exploded = false;

    protected override void Start()
    {
        maxLifetime = 3f;
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
        if (!exploded)
        {
            GameObject explosionEffect = Instantiate(explosion, this.transform.position, Quaternion.identity);
            explosionScript = explosionEffect.GetComponent<FireballExplosion>();
        }
        base.die();
    }

    public new void OnTriggerEnter2D(Collider2D col)
    {
        enemy_base enemy = col.GetComponent<enemy_base>();
        if (col.CompareTag("Enemy"))
            enemyInRange.Add(enemy);

        if (enemy != null && !enemyAttacked.Contains(enemy))
        {
            GameObject explosionEffect = Instantiate(explosion, this.transform.position, Quaternion.identity);
            explosionScript = explosionEffect.GetComponent<FireballExplosion>();

            exploded = true;
            this.die();
        }
    }

}
