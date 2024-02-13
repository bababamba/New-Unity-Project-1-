using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwingKnife : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    projectile_base bulletScript;
    // Start is called before the first frame update
    protected override void Start()
    {
        basic_attack = 5;
        add = 0.4f;
        base.Start();
        itemNum = 8;
        Maxcooldown = 0.8f;
        itemName = "��ô�� �ܰ�";

        itemCaption = "�������� ���⵵ ���ٸ� �̰����� ��Ƴ��� �� ����.";
    }

    // Update is called once per frame
    protected override void Update()
    {
        itemText = "�����ִ� �������� " + basic_attack + " + " + add * playerScript.ad + "��ŭ�� ���ظ� ������ ����ü�� �߻��Ѵ�.";
        base.Update();
    }
    protected override void itemTrigger()
    {
        Transform temp = gameManager.closestEnemy(playerNumber, 100f);
        if (temp != player.transform)
        {
            GameObject whiteBox = Instantiate(bullet, player.transform.position, Quaternion.identity);
            bulletScript = whiteBox.GetComponent<projectile_base>();
            bulletScript.init(calcDmg(), 5, 1);
            Rigidbody2D whiteBoxRigidbody = whiteBox.GetComponent<Rigidbody2D>();
            Vector2 shootDirection = playerScript.playerDirection.normalized; // ���������� �߻� ���������� ���� ������ ����
            whiteBoxRigidbody.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            whiteBoxRigidbody.rotation = angle-45;
        }
    }
    public override void levelUp()
    {
        base.levelUp();
        Maxcooldown -= 0.05f;
        add += 0.1f;
    }


}