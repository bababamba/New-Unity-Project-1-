using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess_Unit : specialEnemyBase
{
    
    protected override void Start()
    {
        base.Start();
        initSpecialEnemy(false, 3f);
    }
    protected override void gimick()
    {

    }


    public virtual void OnActive()
    {
 

    }
   

}
