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
        itemName = "�عٶ��";
        
        itemCaption = "�޺��� �޾� �� ������ ������� ü���� ȸ����Ų��.hp:10";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        itemText = "ü���� " + level + "�� ä���ش�.";

    }
    protected override void itemTrigger(int itemLevel)
    {
        playerScript.addCurHP(itemLevel);
    }
}
