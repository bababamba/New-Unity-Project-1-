using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creture
{
    
    public VirtualJoystick VJ;
    public GameObject iManager;
    private itemManager imanager;
    public Vector2 playerDirection;

    public int armor;
    public int ad;
    public int ap;
    public int move;
    public int armorP;
    public int magicP;
    public float critical;
    private void Awake()
    {
        iManager = GameObject.Find("itemManager");
        imanager = iManager.GetComponent<itemManager>();
        this.init(100, 10, 1);
        VJ.speed = this.speed;
        
        gameObject.tag = "Player";
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // 이전 위치 갱신
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            imanager.getInventory();
            Debug.Log(getCurHP());
            Debug.Log(armor);
            
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            takeDamage(20);
        }
        //gameManager.closestEnemy().transform.position;
        
    }
    public override void death()
    {
        base.death();
        Debug.Log("GAME OVER");
    }
    public Transform playerTransform()
    {
        return this.transform;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ItemObject"))
        {
            Debug.Log(gameManager.exp);
            Debug.Log(gameManager.maxExp);
            gameManager.expUp(10f);
            Destroy(collision.gameObject);
        }
    }


    public void playerStatusChange(int cHp, int cArmor, int cAd, int cAp, float cMove, int cArmorP, int cMagicP, float cCritical, bool equip )
    {
        if (equip)
        {
            this.addMaxHP(cHp);
            this.armor += cArmor;
            this.ad += cAd;
            this.ap += cAp;
            this.speed += cMove;
            this.armorP += cArmorP;
            this.magicP += cMagicP;
            this.critical += cCritical;
        }
        else
        {
            this.addMaxHP(-cHp);
            this.armor -= cArmor;
            this.ad -= cAd;
            this.ap -= cAp;
            this.speed -= cMove;
            this.armorP -= cArmorP;
            this.magicP -= cMagicP;
            this.critical -= cCritical;
            
        }
    }
}
