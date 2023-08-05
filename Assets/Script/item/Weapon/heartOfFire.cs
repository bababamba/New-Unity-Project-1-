using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class heartOfFire : weapon_base
{
    public GameObject bullet;
   
    
    protected override void Start()
    {
        base.Start();
        basic_attack = 2;
        apd = 0.01f;
        itemNum = 1;
        itemName = "불의 심장";
        itemText = "주위에" + basic_attack + " + " + apd*playerScript.ap + "만큼의 피해를 틱마다 입힌다.";
        itemCaption = "불의 심장이 주위 모든것을 불태운다. 3분카레도 1분만에 익을 정도의 화력이다.";
        
        
        Maxcooldown = 1;

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        itemText = "주위에" + basic_attack + " + " + apd * playerScript.ap + "만큼의 피해를 틱마다 입힌다.";

    }
    protected override void itemTrigger(int itemLevel)
    {
        PhotonNetwork.Instantiate(bullet.name, player.transform.position, Quaternion.identity).GetComponent<fireOfHeart>().init(calcDmg(), 0.2f, 1, 0);
        
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack = 2 + (0.5f * (level-1));
        apd = 0.01f +(0.005f * (level-1));
    }
}
