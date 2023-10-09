using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wingOfAngel : passive_base
{
    // Start is called before the first frame update
    private void Awake()
    {
        itemNum = 9;

    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        move = 3f;

        itemName = "천사의 날개";
        itemText = "가속:3";
        itemCaption = "신화속에 나오는 천사의 날개라고 전해져오는 조향물이다. 가지고있으면 몸이 가벼워지는것 같다.";
    }
    public override void levelUp()
    {
        base.levelUp();
        itemName = "천사의 날개+" + (level - 1).ToString();
        move += 1f;
        itemText = "가속:" + ((int)move).ToString();
        
    }
}
