using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunFlower : passive_base
{
    private void Awake()
    {
        itemNum = 2;
        
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hp = 10;
        armor = 1;
        Maxcooldown = 0.5f;
        itemName = "해바라기";
        
        itemCaption = "햇빛을 받아 그 힘으로 사용자의 체력을 회복시킨다.hp:10";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        itemText = "체력을 " + level + "씩 채워준다.";

    }
    protected override void itemTrigger(int itemLevel)
    {
        playerScript.addCurHP(itemLevel);
    }
}
