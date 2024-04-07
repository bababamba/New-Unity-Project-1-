using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    public int shieldquantity = 3;
    ShieldAttack bulletScript;
    // Start is called before the first frame update
    protected override void Start()
    {
        basic_attack = 10;
        dpl = 5;
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
        itemText = "�÷��̾� ������ ����" + basic_attack + " + "   + "��ŭ�� ���ظ� ������ ���и� ��ȯ�Ѵ�.";
        base.Update();
    }
    protected override void itemTrigger()
    {
        for (int i = 0; i < shieldquantity; i++)
        {
            float angle = ((2 * Mathf.PI) / shieldquantity) * i;
            GameObject shield = Instantiate(bullet, new Vector2(player.transform.position.x + Mathf.Cos(i), player.transform.position.y + Mathf.Sin(i)), Quaternion.identity);
            bulletScript = shield.GetComponent<ShieldAttack>();
            bulletScript.addDmg = (int)(level * dpl);
            bulletScript.angle = angle;
            bulletScript.init(calcDmg(), 5, 1);
            shield.transform.SetParent(player.transform, true);
            bulletScript.player = player;
        }
    }
    public override void levelUp()
    {
        base.levelUp();
    }


}
