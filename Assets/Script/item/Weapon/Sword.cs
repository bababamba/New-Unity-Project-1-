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
        itemName = "검";

        itemCaption = "베고 찌르기. 별거 아니지만 있을 건 다 있습니다.";
        slash = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        itemText = "전방을 베어" + basic_attack + " + " + add * playerScript.ad + "만큼의 피해를 입히고, 다음 공격은 전방을 찔러 "
            + basic_attack + " + " + add * playerScript.ad + "만큼의 피해를 준다.";
        
        base.Update();
    }
    protected override void itemTrigger()
    {
        if(slash)//베기
        {
            GameObject swordEffect = Instantiate(bullet, player.transform.position, Quaternion.identity);
            bulletScript = swordEffect.GetComponent<SwordAttack>();
            bulletScript.init(calcDmg(), 5, 1);
            swordEffect.transform.SetParent(player.transform, true);
        }
        else//찌르기
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
