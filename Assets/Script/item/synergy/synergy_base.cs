using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class synergy_base : item_base
{
    // Start is called before the first frame update
    protected int basic_attack;
    protected int add;
    protected int apd;

    protected Transform here;
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
        gameObject.tag = "Synergy";

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (active && !actived)
        {
            playerScript.playerStatusChange(hp, armor, ad, ap, move, armorP, magicP, critical, true);
            actived = true;
        }
        if (!active && actived)
        {
            playerScript.playerStatusChange(hp, armor, ad, ap, move, armorP, magicP, critical, false);
            actived = false;
        }
    }
}
