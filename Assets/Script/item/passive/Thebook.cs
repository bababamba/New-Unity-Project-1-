using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thebook : passive_base
{
    // Start is called before the first frame update
    private void Awake()
    {
        itemNum = 5;

    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ap = 100;
        armor = 1;
       
        itemName = "������";

        itemCaption = "������ ���ϰ� �÷��ش�.����:100";
    }
    public override void levelUp()
    {
        base.levelUp();
        ap += 30;
    }
}
