using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granade : weapon_base
{
    public GameObject bullet;
    public float shootForce = 5f;
    // Start is called before the first frame update
    protected override void Start()
    {
        itemNum = 3;
        Maxcooldown = 2;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    protected override void itemTrigger()
    {
        Transform temp = gameManager.randomEnemy();
        if (temp != player.transform)
        {
            GameObject whiteBox = Instantiate(bullet, player.transform.position, Quaternion.identity);
            Rigidbody2D whiteBoxRigidbody = whiteBox.GetComponent<Rigidbody2D>();
            Vector2 shootDirection = (temp.position - player.transform.position).normalized; // ���������� �߻� ���������� ���� ������ ����
            whiteBoxRigidbody.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }
    }
}
