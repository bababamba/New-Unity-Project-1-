using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granade : weapon_base
{
    public GameObject bullet;
    public float shootForce = 5f;
    projectile_base bulletScript;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        basic_attack = 40;
        itemNum = 3;
        Maxcooldown = 2;
        
        itemName = "���� ��ź";
        itemText = "������ ������ ������" + basic_attack + "��ŭ�� ���ظ� ������ ��ź�� ������.";
        itemCaption = "���������� �̾߱⿡ ������ �� ���� ���� ū ��ź ������ ������ ����ߴٰ� �Ѵ�. ��ֵ� ���� ���� �̾߱��. �ʹ� �Ų��ؼ� �����Ⱑ �����.";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        itemText = "������ ������ ������" + basic_attack + "��ŭ�� ���ظ� ������ ��ź�� ������.";
    }
    protected override void itemTrigger(int itemLevel)
    {
        Transform temp = gameManager.randomEnemy(playerNumber);
        if (temp != player.transform)
        {
            GameObject whiteBox = Instantiate(bullet, player.transform.position, Quaternion.identity);
            bulletScript = whiteBox.GetComponent<projectile_base>();
            bulletScript.init(calcDmg(), 2+itemLevel,1);
            Rigidbody2D whiteBoxRigidbody = whiteBox.GetComponent<Rigidbody2D>();
            Vector2 shootDirection = (temp.position - player.transform.position).normalized; // ���������� �߻� ���������� ���� ������ ����
            whiteBoxRigidbody.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 15;
        
    }
}
