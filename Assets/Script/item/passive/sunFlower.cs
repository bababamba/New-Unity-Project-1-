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
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();


    }
    protected override void itemTrigger()
    {
        playerScript.addCurHP(1);
    }
}
