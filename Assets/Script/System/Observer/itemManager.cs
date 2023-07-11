using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class itemManager : MonoBehaviour
{
    bool isinit = false;
    GameObject[] itemObject;
    GameObject[] synergyObject;
    public item_base[] items;
    public item_base[] inventory;
    public synergy_base[] synergies;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new item_base[9];
    }

    // Update is called once per frame
    void Update()
    {
        if (!isinit)
        {
            init();
            isinit = !isinit;
        }
        
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            items[0].active = true;
            inventory[0] = items[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            items[1].active = true;
            inventory[1] = items[1];
        }

        if(items[0].active == true && items[1].active == true)
        {
            synergies[0].active = true;
        }

    }
    void init()
    {
        GameObject[] itemObject = GameObject.FindGameObjectsWithTag("Item");
        GameObject[] synergyObject = GameObject.FindGameObjectsWithTag("Synergy");
        items = new item_base[itemObject.Length];
        
        for(int i=0;i<itemObject.Length;i++)
        {
            items[i] = itemObject[i].GetComponent<item_base>(); 
        }
        synergies = new synergy_base[synergyObject.Length];
        for (int i = 0; i < synergyObject.Length; i++)
        {
            synergies[i] = synergyObject[i].GetComponent<synergy_base>();
        }

        Array.Sort(items, (x, y) => x.getItemNumber().CompareTo(y.getItemNumber()));
        Array.Sort(synergies, (x, y) => x.getItemNumber().CompareTo(y.getItemNumber()));
    }
    public void getInventory()
    {
        foreach(item_base item in inventory)
        {
            if (item)
                Debug.Log(item);
            else
                Debug.Log("ºó Ä­");
        }
    }
}
