using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice_ForBoss2 : enemyExplosionBase
{
    bool isTriggered = false;
    public float timeLimit = 1f;
    // Start is called before the first frame update
    protected override void Start()
    {
       
        dmg = 20;
        forEffect = true;
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