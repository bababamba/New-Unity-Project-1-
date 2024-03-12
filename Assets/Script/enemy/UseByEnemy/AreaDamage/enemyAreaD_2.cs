using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAreaD_2 : enemyExplosionBase
{
    bool isTriggered = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        
        dmg = 40;
        forEffect = true;
        maxLifeTime = 0;
        base.Start();

    }
    protected override void Update()
    {
        if (!forEffect)
        {
            base.Update();
            this.transform.parent.GetComponent<enemy_base>().takeDamage(1000);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            StartCoroutine(timer());
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
        }
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(1.2f);
        forEffect = false;


    }

}