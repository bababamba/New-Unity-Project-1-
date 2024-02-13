using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    public int shieldquantity;
    projectile_base bulletScript;
    // Start is called before the first frame update
    protected override void Start()
    {
        basic_attack = 10;
        add = 0.1f;
        base.Start();
        itemNum = 0;
        Maxcooldown = 10;
        shieldquantity = 3;

        itemName = "����";

        itemCaption = "�� �ű��� ���д� �˾Ƽ� ���鼭 ���� �ķ�Ĩ�ϴ�!";
    }

    // Update is called once per frame
    protected override void Update()
    {
        itemText = "�÷��̾� ������ ����" + basic_attack + " + " + add * playerScript.ad + "��ŭ�� ���ظ� ������ ���и� ��ȯ�Ѵ�.";
        base.Update();
    }
    protected override void itemTrigger()
    {
        for (int i = 0; i < shieldquantity; i++)
        {
            GameObject shield = Instantiate(bullet, player.transform.position, Quaternion.identity);
            bulletScript = shield.GetComponent<ShieldAttack>();
            bulletScript.init(calcDmg(), 5, 1);
            shield.transform.SetParent(player.transform, false);
        }
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 5;
        add += 0.05f;
    }


}
