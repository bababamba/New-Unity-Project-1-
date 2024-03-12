using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber2_Unit : Bomber_Base
{
    public GameObject ExplodeArea;
    protected override void Start()
    {
        base.Start();
        this.init(70, 3, 2);

        initSpecialEnemy(true, 2f);
        GameObject Area = Instantiate(ExplodeArea, this.transform.position, Quaternion.identity);
        Area.transform.SetParent(this.transform);

    }

    protected override void gimick()
    {
        base.gimick();


    }

    // Start is called before the first frame update

}