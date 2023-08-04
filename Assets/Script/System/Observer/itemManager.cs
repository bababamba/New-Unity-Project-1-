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
    [SerializeField]
    private inventory inventory;
    public synergy_base[] synergies;
    public Player player;
    
    List<int> tempItems = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
       
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
            for(int i = 0;i<items.Length; i++)
            {
                print(items[i] + " " + i);
            }
           
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
        
    }
    public List<int> getUnactiveItems()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].active == false)
            {
                tempItems.Add(i);
            }
        }
        return tempItems;

    }
    public List<int> getActiveItems()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].active == true)
            {
                tempItems.Add(i);
            }
        }
        return tempItems;

    }
    public List<item_base> forLevelUP()
    {
        List<int> DropPool = getActiveItems();
        List<int> selected = new List<int>();
        List<item_base> item_s = new List<item_base>();
        if(DropPool.Count > 1)
        {
            selected.AddRange(PickRandomNumbers(DropPool, 1));
            selected.AddRange(PickRandomNumbers(getUnactiveItems(), 2));

        }
        else
        {
            selected.AddRange(PickRandomNumbers(getUnactiveItems(), 3));
        }
        item_s.Add(items[selected[0]]);
        item_s.Add(items[selected[1]]);
        item_s.Add(items[selected[2]]);
        return item_s;
    }
    private List<int> PickRandomNumbers(List<int> sourceList, int count)
    {
        List<int> randomNumbers = new List<int>();

        if (count > sourceList.Count)
        {
            Debug.LogWarning("Count exceeds list size.");
            return randomNumbers;
        }

        System.Random random = new System.Random();

        for (int i = 0; i < count; i++)
        {
            int randomIndex = random.Next(sourceList.Count);
            int randomNumber = sourceList[randomIndex];
            randomNumbers.Add(randomNumber);
            sourceList.RemoveAt(randomIndex);
        }

        return randomNumbers;
    }



}
