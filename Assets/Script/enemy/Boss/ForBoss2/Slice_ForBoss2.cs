using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice_ForBoss2 : enemyExplosionBase
{

    public float timeLimit = 0.5f;
    // Start is called before the first frame update
    protected override void Start()
    {
       
        dmg = 20;
        forEffect = true;
        maxLifeTime = 0;
        StartCoroutine(timer());
        this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
        base.Start();
    }
    protected override void Update()
    {
        if (!forEffect)
        {
            base.Update();
        }


    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(timeLimit);
        forEffect = false;
        
    }

}