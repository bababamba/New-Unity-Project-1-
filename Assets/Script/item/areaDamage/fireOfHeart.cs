using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireOfHeart : areaD_base
{ // dmg, maxLifeTime, maxDmgDuration, effectTime
 
    GameObject player;
    // Start is called before the first frame update
    protected override void Start()
    {
        player = GameObject.Find("player");
        dmg = 5;
        maxLifeTime = 1;
        maxDmgDuration = 0.2f;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (player)
        {
            this.transform.position = player.transform.position;
            base.Update();
        }

    }
    
}
