using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber0_Unit : Bomber_Base
{
    
    protected override void Start()
    {
        base.Start();
        this.init(70, 2, 2);

        initSpecialEnemy(true, 2f);
    }

    protected override void gimick()
    {
        base.gimick();
        
    }
}
