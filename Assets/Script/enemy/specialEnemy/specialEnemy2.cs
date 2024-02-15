using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialEnemy2 : specialEnemyBase
{
    public GameObject ExplodeArea;
    protected override void Start()
    {
        base.Start();
        this.init(50, 1, 2);

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
