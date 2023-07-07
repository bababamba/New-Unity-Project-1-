using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_base : MonoBehaviour
{
    float lifeTime=5;
    int lifePen =1;

    float maxLifetime=5;
    int maxLifePen=2;
    int dmg = 10;
    private List<enemy_base> attackedEnemies = new List<enemy_base>(); // 공격한 적을 저장하는 리스트
    void Awake()
    {
        gameObject.tag = "Projectile";
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        init();
        
        
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
                    Destroy(gameObject);
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
    void init()
    {
        lifeTime = maxLifetime;
        lifePen = maxLifePen;
    }
    /* void OnCollisionEnter2D(Collider2D collision)
     {
         Debug.Log("!1");
         if (collision.gameObject.CompareTag("Enemy"))
         {
             Debug.Log("!");
             enemy_base enemy = collision.gameObject.GetComponent<enemy_base>();
             if (enemy != null)
             {
                 enemy.takeDamage(dmg);
                 Debug.Log("!");
             }

             lifePen--;
             if (lifePen <= 0)
             {
                 Debug.Log("총알의 내구도가 0이 되었습니다!");
                 Destroy(gameObject);
             }
         }
     }*/
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
}
