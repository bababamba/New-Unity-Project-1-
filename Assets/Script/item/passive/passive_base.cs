using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passive_base : item_base
{
    protected int hp;
    protected int armor;
    protected int ad;
    protected int ap;
    protected float move;
    protected int armorP;
    protected int magicP;
    protected float critical;

    bool actived = false;
    private void Awake()
    {
        isPassive = true;
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        itemType = 2;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (active && !actived)
        {
            playerScript.playerStatusChange(hp,armor,ad,ap,move,armorP,magicP,critical,true);
            actived = true;
        }
        if (!active && actived)
        {
            playerScript.playerStatusChange(hp, armor, ad, ap, move, armorP, magicP, critical, false);
            actived = false;
        }
    }
    public virtual int getHp()
    {
        return hp;
    }
    public virtual int getArmor()
    {
        return armor;
    }
    public virtual int getAd()
    {
        return ad;
    }
    public virtual int getAp()
    {
        return ap;
    }
    public virtual float getMove()
    {
        return move;
    }
    public virtual int getArmopP()
    {
        return armorP;
    }
    public virtual int getMagicP()
    {
        return magicP;
    }
    public virtual float getCritacal()
    {
        return critical;
    }
}
