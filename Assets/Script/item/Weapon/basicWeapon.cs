using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicWeapon : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        invenNum = 0;
        itemNum = 1;
        Maxcooldown = 400;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    protected override void itemTrigger()
    {
        Transform temp = gameManager.closestEnemy();
        if (temp != player.transform)
        {
            GameObject whiteBox = Instantiate(bullet, player.transform.position, Quaternion.identity);
            Rigidbody2D whiteBoxRigidbody = whiteBox.GetComponent<Rigidbody2D>();
            Vector2 shootDirection = (temp.position - player.transform.position).normalized; // 시작점에서 발사 지점까지의 벡터 방향을 구함
            whiteBoxRigidbody.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }
    }
    
}
