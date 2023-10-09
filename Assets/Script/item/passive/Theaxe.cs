using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theaxe : passive_base
{
    // Start is called before the first frame update
    private void Awake()
    {
        itemNum = 6;

    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ad = 30;
        armor = 1;

        itemName = "날카로운 도끼";
        itemText = "공격력:30";
        itemCaption = "공격력을 강하게 올려준다. 휘두르기에는 너무 작지만 힘이 강해지는 것 같다.";
    }
    public override void levelUp()
    {
        base.levelUp();
        itemName = "날카로운 도끼+" + (level-1).ToString();
              
        ad += 10;
        itemText = "공격력:" + ad.ToString();
    }
}
