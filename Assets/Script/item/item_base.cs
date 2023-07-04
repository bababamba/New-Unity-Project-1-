using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_base : MonoBehaviour
{
    public bool active = false;
    protected int itemNum = -1;
    protected int invenNum = -1;
    protected GameObject player;
    protected float cooldown;
    protected float Maxcooldown;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        gameObject.tag = "item";
        this.transform.position = new Vector3(itemNum,0,0);
    }

    // Update is called once per frame
    void Update()
    {   if(active)
        cooldown--;
        if (cooldown == 0)
        {
            itemTrigger();
            cooldown = Maxcooldown;
        }
    }
    public float getCooldown()
    {
        return cooldown;
    }
    public int getItemNumber()
    {
        return itemNum;
    }
    public int getInvenNumber()
    {
        return invenNum;
    }
    protected void itemTrigger()
    {

    }
}
