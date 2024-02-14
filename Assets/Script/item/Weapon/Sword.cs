using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword  : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    projectile_base bulletScript;
    public bool slash;
    // Start is called before the first frame update
    protected override void Start()
    {
        basic_attack = 10;
        add = 0.1f;
        base.Start();
        itemNum = 0;
        Maxcooldown = 2;
        itemName = "��";

        itemCaption = "���� ���. ���� �ƴ����� ���� �� �� �ֽ��ϴ�.";
        slash = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        itemText = "������ ����" + basic_attack + " + " + add * playerScript.ad + "��ŭ�� ���ظ� ������, ���� ������ ������ �� "
            + basic_attack + " + " + add * playerScript.ad + "��ŭ�� ���ظ� �ش�.";
        
        base.Update();
    }
    protected override void itemTrigger()
    {
        if(slash)//����
        {
            GameObject swordEffect = Instantiate(bullet, player.transform.position, Quaternion.identity);
            bulletScript = swordEffect.GetComponent<SwordAttack>();
            bulletScript.init(calcDmg(), 5, 1);
            swordEffect.transform.SetParent(player.transform, true);
        }
        else//���
        {
            GameObject swordEffect = Instantiate(bullet, player.transform.position, Quaternion.identity);
            bulletScript = swordEffect.GetComponent<SwordAttack>();
            bulletScript.init(calcDmg(), 5, 1);
            swordEffect.transform.SetParent(player.transform, true);
        }
        slash = !slash;
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 5;
        add += 0.05f;
    }


}
