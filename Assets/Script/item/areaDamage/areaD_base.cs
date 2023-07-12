using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaD_base : MonoBehaviour
{
    float lifeTime;
    float dmgDuration = 0;
    // dmg, maxLifeTime, maxDmgDuration, effectTime
    protected int dmg=1;
    protected float maxLifeTime = 1;
    protected float maxDmgDuration = 1;
    protected float effectTime =1;
    protected bool forEffect = false;
    protected bool isBox = false;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        init();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!forEffect)
        {
            if (dmgDuration <= 0)
            {
                Vector2 bulletPosition = transform.position;
                //Collider2D[] colliders = Physics2D.OverlapCircleAll(bulletPosition, GetRadiusFromCollider(GetComponent<Collider2D>()));
                Collider2D[] colliders = Physics2D.OverlapAreaAll(transform.position - GetComponent<Collider2D>().bounds.extents,transform.position + GetComponent<Collider2D>().bounds.extents);
                foreach (Collider2D collider in colliders)
                {
                    Debug.Log(collider);
                    if (collider.CompareTag("Enemy"))
                    {
                        enemy_base enemy = collider.GetComponent<enemy_base>();
                        if (enemy != null)
                        {
                            enemy.takeDamage(dmg);
                        }
                        
                    }
                }
                dmgDuration = maxDmgDuration;
            }
            else
                dmgDuration -= Time.deltaTime;
            if (lifeTime > 0f)
            {
                lifeTime -= Time.deltaTime;
            }
            else
                die();
        }
        else if (effectTime > 0f)
            effectTime -= Time.deltaTime;
        else
            Destroy(this.gameObject);

    }
    void init()
    {
        lifeTime = maxLifeTime;
    }
    protected virtual void die()
    {
        Destroy(gameObject);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Item") || collision.gameObject.CompareTag("ItemObject"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }

    }
    float GetRadiusFromCollider(Collider2D collider)
    {
        float radius = 0f;
        if (collider is CircleCollider2D)
        {
            radius = ((CircleCollider2D)collider).radius;
        }
        else if (collider is BoxCollider2D)
        {
            Vector2 boxSize = ((BoxCollider2D)collider).size;
            radius = Mathf.Max(boxSize.x, boxSize.y) / 2f;
        }

        return radius;
    }
    public void init(int iDmg, float iMaxDmgDuration, float iMaxLifeTime, float iEffectTime)
    {
        maxDmgDuration = iMaxDmgDuration;
        maxLifeTime = iMaxLifeTime;
        dmg = iDmg;
        effectTime = iEffectTime;
    }
}

