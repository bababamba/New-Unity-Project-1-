using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creture
{
    private CharacterController CC;
    public VirtualJoystick VJ;
    public GameObject iManager;
    private itemManager imanager;

    int armor;
    int ad;
    int ap;
    int move;
    int armorP;
    int magicP;
    float critical;
    private void Awake()
    {
        iManager = GameObject.Find("itemManager");
        imanager = iManager.GetComponent<itemManager>();
        this.init(100, 10, 1);
        VJ.speed = this.speed;
        CC = GetComponent<CharacterController>();
        gameObject.tag = "Player";
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
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
