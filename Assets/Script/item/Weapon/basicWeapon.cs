using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicWeapon : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    projectile_base bulletScript;
    // Start is called before the first frame update
    protected override void Start()
    {
        basic_attack = 10;
        add = 0.1f;
        base.Start();
        itemNum = 0;
        Maxcooldown = 1;
        itemName = "ȣ�ſ� ����";
        
        itemCaption = "�������� ���⵵ ���ٸ� �̰����� ��Ƴ��� �� ����.";
    }

    // Update is called once per frame
    protected override void Update()
    {
        itemText = "���� ����� ������" + basic_attack + " + " + add * playerScript.ad + "��ŭ�� ���ظ� ������ ����ü�� �߻��Ѵ�.";
        base.Update();
    }
    protected override void itemTrigger(int itemLevel)
    {
        Transform temp = gameManager.closestEnemy(playerNumber,100f);
        if (temp != player.transform)
        {
            GameObject whiteBox = Instantiate(bullet, player.transform.position, Quaternion.identity);
            bulletScript = whiteBox.GetComponent<projectile_base>();
            bulletScript.init(calcDmg(), 5, 4);
            Rigidbody2D whiteBoxRigidbody = whiteBox.GetComponent<Rigidbody2D>();
            Vector2 shootDirection = (temp.position - player.transform.position).normalized; // ���������� �߻� ���������� ���� ������ ����
            whiteBoxRigidbody.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 5;
        add += 0.05f;
    }
    
    
}
