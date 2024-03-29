using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_ForBoss2 : enemyExplosionBase
{
    public float timeLimit = 1.5f;
    public GameObject[] Bomber;
    public int typeOfBomber = 0;
    public GameObject Boss;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        dmg = 30;
        forEffect = true;
        maxLifeTime = 0f;
        StartCoroutine(timer());
        this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
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
        GameObject bomber =  Instantiate(Bomber[typeOfBomber], this.transform.position, Quaternion.identity);
        bomber.GetComponent<Bomber_Base>().MyBoss = Boss;
    }

}