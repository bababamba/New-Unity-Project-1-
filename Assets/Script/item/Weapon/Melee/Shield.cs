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

        itemName = "방패";

        itemCaption = "이 신기한 방패는 알아서 돌면서 적을 후려칩니다!";
    }

    // Update is called once per frame
    protected override void Update()
    {
        itemText = "플레이어 주위를 돌며" + basic_attack + " + "   + "만큼의 피해를 입히는 방패를 소환한다.";
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
