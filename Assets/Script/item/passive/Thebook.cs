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
        ap = 30;
        
       
        itemName = "������";
        itemText = "����:30";
        itemCaption = "������ ���ϰ� �÷��ش�.";
    }
    public override void levelUp()
    {
        base.levelUp();
        itemName = "������+" + (level - 1).ToString();
        ap += 10;
        itemText = "����:" + ap.ToString();
        
    }
}
