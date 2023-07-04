using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_base : item_base
{
    protected int basic_attack;
    protected int ad;
    protected int ap;
    protected Transform here;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        here = gameObject.transform;

    }
    
}
