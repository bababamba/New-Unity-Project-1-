using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class itemManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("item");
        Array.Sort(items, (x, y) => x.GetComponent<item_base>.getItemNumber().CompareTo(y.getItemNumber()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
