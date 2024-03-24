using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class item_base : MonoBehaviour
{
    public bool active = false;
    protected int itemNum = -1;
    protected int invenNum = -1;
    protected GameObject player;
    protected int playerNumber = 0;
    protected Player playerScript;
    protected float cooldown =1;
    protected float Maxcooldown;
    protected bool isinit = false;
    protected GameObject Manager;
    protected GameManager gameManager;
    protected bool isPassive;
    public int level = 1;
    [SerializeField]
    protected bool CooldownOff = false;
    public Sprite itemImage;
    public int itemType;

    protected string itemName;
    protected string itemText;
    protected string itemCaption;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = transform.parent.parent.gameObject;
        playerScript = player.GetComponent<Player>();
        
        gameObject.tag = "Item";
        //this.transform.position = new Vector3(itemNum,0,0);
        Manager = GameObject.Find("GameManager");
        gameManager = Manager.GetComponent<GameManager>();
      
        itemType = 0;

    }

    // Update is called once per frame
    protected virtual void Update()
    {
       
        



        if (active&&!CooldownOff)
        {
            cooldown -= Time.deltaTime;
            
        }
        if (cooldown <= 0)
        {
            
            
            cooldown = Maxcooldown;
            itemTrigger();
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
    protected virtual void itemTrigger()
    {

    }
    public virtual void levelUp()
    {
        this.level++;
    }
    public string getItemName()
    {
        return itemName;
    }
    public string getItemText()
    {
        return itemText;
    }
    public string getItemCaption()
    {
        return itemCaption;
    }

}
