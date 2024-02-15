using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    MeleeAttackBase bulletScript;
    // Start is called before the first frame update
    protected override void Start()
    {
        basic_attack = 10;
        add = 0.1f;
        base.Start();
        itemNum = 0;
        Maxcooldown = 0.5f;
        itemName = "단검";

        itemCaption = "";
    }

    // Update is called once per frame
    protected override void Update()
    {
        itemText = "진행 방향으로 단검을 찔러 " + basic_attack + " + " + add * playerScript.ad + "만큼의 피해를 준다.";
        base.Update();
    }
    protected override void itemTrigger()
    {
        Vector2 position = new Vector2(playerScript.playerDirection.x, playerScript.playerDirection.y) * 1f;
        GameObject daggerEffect = Instantiate(bullet, player.transform.position + new Vector3(playerScript.playerDirection.x, 
            playerScript.playerDirection.y) * 1f, Quaternion.LookRotation(Vector3.forward, playerScript.playerDirection));
        bulletScript = daggerEffect.GetComponent<DaggerAttack>();
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
