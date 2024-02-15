using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialEnemy3 : specialEnemyBase
{
    public GameObject SpawnMob;

    protected override void Start()
    {
        base.Start();
        this.init(50, 1, 2);

        initSpecialEnemy(true, 2f);
    }

    protected override void gimick()
    {
        base.gimick();

    }
    public override void death()
    {
        GameObject Spawning1 = Instantiate(SpawnMob, new Vector3(this.transform.position.x + 1, this.transform.position.y), Quaternion.identity);
        GameObject Spawning2 = Instantiate(SpawnMob, new Vector3(this.transform.position.x - 1, this.transform.position.y), Quaternion.identity);
        base.death();
        
    }
    // Start is called before the first frame update

}
