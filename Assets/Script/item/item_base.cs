using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class item_base : MonoBehaviourPunCallbacks
{
    public bool active = false;
    protected int itemNum = -1;
    protected int invenNum = -1;
    protected GameObject player;
    protected int playerNumber;
    protected Player playerScript;
    protected float cooldown =1;
    protected float Maxcooldown;
    protected bool isinit = false;
    protected GameObject Manager;
    protected GameManager gameManager;
    protected bool isPassive;
    protected int level = 1;
    public Sprite itemImage;
    public int itemType;

    protected string itemName;
    protected string itemText;
    protected string itemCaption;

    public PhotonView PV;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GameObject.Find("player");
        playerScript = player.GetComponent<Player>();
        
        gameObject.tag = "Item";
        //this.transform.position = new Vector3(itemNum,0,0);
        Manager = GameObject.Find("GameManager");
        gameManager = Manager.GetComponent<GameManager>();
        playerNumber = gameManager.getPlayerNumber(player);
        itemType = 0;

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!player)
            getMyOwner();
        


        if(photonView.IsMine)
        if (active)
        {
            cooldown -= Time.deltaTime;
            
        }
        if (cooldown <= 0)
        {
            
            
            cooldown = Maxcooldown;
            itemTrigger(level);
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
    protected virtual void itemTrigger(int itemLevel)
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
    protected void getMyOwner() {
        
        player = GameObject.Find("player");
        playerScript = player.GetComponent<Player>();
        if (player)
            playerNumber =  gameManager.getPlayerNumber(player);
    
    
    }
}
