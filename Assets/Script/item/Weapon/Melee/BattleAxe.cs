using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAxe : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    AttackBase bulletScript;
    // Start is called before the first frame update
    protected override void Start()
    {
        basic_attack = 10;
        add = 0.1f;
        base.Start();
        itemNum = 0;
        Maxcooldown = 6;
        itemName = "전투 도끼";

        itemCaption = "뿔 달린 모자만 있으면 당신도 이제 바이킹!";
    }

    // Update is called once per frame
    protected override void Update()
    {
        itemText = "주변 원형 범위에 도끼를 휘둘러" + basic_attack + " + " + add * playerScript.ad + "만큼의 피해를 준다.";
        base.Update();
    }
    protected override void itemTrigger()
    {
        Vector2 position = new Vector2(playerScript.playerDirection.x, playerScript.playerDirection.y) * 1f;
        GameObject axeEffect = Instantiate(bullet, player.transform.position + new Vector3(playerScript.playerDirection.x, 
            playerScript.playerDirection.y) * 0.5f, Quaternion.LookRotation(Vector3.forward, playerScript.playerDirection));
        bulletScript = axeEffect.GetComponent<BattleAxeAttack>();
        bulletScript.player = player;
        bulletScript.position = position;
        bulletScript.init(calcDmg(), 5, 1);
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 5;
        add += 0.05f;
    }


}
