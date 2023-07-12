using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_base : MonoBehaviour
{
    protected float lifeTime;
    protected int lifePen;

    //maxLifetime, maxLifePen,dmg
    protected float maxLifetime = 5;
    protected int maxLifePen = 1;
    protected int dmg = 10;
    protected private List<enemy_base> attackedEnemies = new List<enemy_base>(); // 공격한 적을 저장하는 리스트
    void Awake()
    {
        gameObject.tag = "Projectile";
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        lifeTime = maxLifetime;
        lifePen = maxLifePen;

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (lifeTime > 0f)
        {
            lifeTime -= Time.deltaTime;
        }
        else
            Destroy(gameObject);
        Vector2 bulletPosition = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(bulletPosition, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                enemy_base enemy = collider.GetComponent<enemy_base>();
                if (enemy != null && !attackedEnemies.Contains(enemy))
                {
                    enemy.takeDamage(dmg);
                    lifePen--;
                    attackedEnemies.Add(enemy);
                }
                if (lifePen <= 0)
                {
                    die();
                }


                break;
            }
        }
        for (int i = attackedEnemies.Count - 1; i >= 0; i--)
        {
            enemy_base enemy = attackedEnemies[i];
            if (!IsEnemyColliderInColliders(enemy, colliders))
            {
                attackedEnemies.RemoveAt(i);
            }
        }





    }
    public virtual void init(int iDmg, float iMaxLifetime,  int iMaxLifePen)
    {
        dmg = iDmg;
        maxLifePen = iMaxLifePen;
        maxLifetime = iMaxLifetime;

    }
    bool IsEnemyAttacked(enemy_base enemy)
    {
        return attackedEnemies.Contains(enemy);
    }

    bool IsEnemyColliderInColliders(enemy_base enemy, Collider2D[] colliders)
    {
        foreach (Collider2D collider in colliders)
        {
            if (enemy)
            {
                if (collider == enemy.GetComponent<Collider2D>())
                {
                    return true;
                }
            }
        }
        return false;
    }
    protected virtual void die()
    {
        Destroy(this.gameObject);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Item") || collision.gameObject.CompareTag("ItemObject"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }

    }
}