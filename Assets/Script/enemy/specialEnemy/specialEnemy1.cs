using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialEnemy1 : specialEnemyBase
{
    public GameObject bullet;
    public float shootForce = 10f;
    enemyProjectileBase bulletScript;
    protected override void Start()
    {
        base.Start();
        this.init(50, 1, 2);
        
        initSpecialEnemy(true, 2f);
    }

    protected override void gimick()
    {
        base.gimick();
        Transform temp = gameManager.getPlayerTransform(this.transform);
        if (temp != this.transform)
        {
            stopSeconds(0.5f);
            GameObject whiteBox = Instantiate(bullet, this.transform.position, Quaternion.identity);
            bulletScript = whiteBox.GetComponent<enemyProjectileBase>();
            bulletScript.init(5, 5, 1);
            Rigidbody2D whiteBoxRigidbody = whiteBox.GetComponent<Rigidbody2D>();
            Vector2 shootDirection = (temp.position - this.transform.position).normalized; // 시작점에서 발사 지점까지의 벡터 방향을 구함
            whiteBoxRigidbody.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }

    }
    // Start is called before the first frame update

}
