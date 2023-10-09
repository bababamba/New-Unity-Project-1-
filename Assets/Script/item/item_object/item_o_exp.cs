using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_o_exp : item_object
{
    public override void Triggerd()
    {
        base.Triggerd();
        GameObject.Find("GameManager").GetComponent<GameManager>().expUp(value);
        Destroy(gameObject);


    }
}
