using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class itemManager : MonoBehaviour
{
     public bool isinit = false;
     public GameObject[] itemObject;
    GameObject[] synergyObject;
    public  List<item_base> items;
    [SerializeField]
    public inventory inventory;
    public List<synergy_base> synergies;
    public GameObject player;
    
    List<int> tempItems = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isinit)
        {
            init(player);
            isinit = !isinit;
        }


        /*if(items[0].active == true && items[1].active == true)
        {
            synergies[0].active = true;
        }*/

    }
    public void init(GameObject p)
    {
        items.Clear();
        synergies.Clear();
        Transform[] childTransforms = p.GetComponentsInChildren<Transform>();
        for (int i = 0; i < childTransforms.Length; i++)
        {
            if (childTransforms[i].gameObject.GetComponent<synergy_base>())
            {
                synergies.Add(childTransforms[i].gameObject.GetComponent<synergy_base>());

            }
            else if (childTransforms[i].gameObject.GetComponent<item_base>())
            {
                items.Add(childTransforms[i].gameObject.GetComponent<item_base>());
                
            }
            
        }
        
        /*
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
        */
        items.Sort((x, y) => x.getItemNumber().CompareTo(y.getItemNumber()));
        synergies.Sort((x, y) => x.getItemNumber().CompareTo(y.getItemNumber()));
    }
    public void getInventory()
    {
        
    }
    public List<int> getUnactiveItems()
    {
        for (int i = 0; i < items.Count; i++)
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
        for (int i = 0; i < items.Count; i++)
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
