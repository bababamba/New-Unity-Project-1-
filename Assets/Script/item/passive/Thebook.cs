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
        
       
        itemName = "마도서";
        itemText = "마력:30";
        itemCaption = "마력을 강하게 올려준다.";
    }
    public override void levelUp()
    {
        base.levelUp();
        itemName = "마도서+" + (level - 1).ToString();
        ap += 10;
        itemText = "마력:" + ap.ToString();
        
    }
}
