using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber1_Unit : Bomber_Base
{
    public GameObject bullet;
    public float shootForce = 11f;
    enemyProjectileBase bulletScript;
    protected override void Start()
    {
        base.Start();
        this.init(70, 2, 2);

        initSpecialEnemy(true, 2f);
    }

    protected override void gimick()
    {
        base.gimick();
        Transform temp = gameManager.getPlayerTransform(this.transform);
        if (temp != this.transform && 10 > Vector2.Distance(temp.position, this.transform.position)) ;
        {
            stopSeconds(0.5f);
            GameObject whiteBox = Instantiate(bullet, this.transform.position, Quaternion.identity);
            bulletScript = whiteBox.GetComponent<enemyProjectileBase>();
            bulletScript.init(10, 5, 1);
            Rigidbody2D whiteBoxRigidbody = whiteBox.GetComponent<Rigidbody2D>();
            Vector2 shootDirection = (temp.position - this.transform.position).normalized; // 시작점에서 발사 지점까지의 벡터 방향을 구함
            whiteBoxRigidbody.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }

    }
}
