using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IconPanel : MonoBehaviour
{
    public static IconPanel iconPanel;

    private TMP_Text levelText;
    private Image icon;
    private weapon_base weapon;

    void Awake()
    {
        if (levelText == null)
            Init();
    }

    public void Init()
    {
        icon = this.transform.Find("Icon").GetComponent<Image>();
        levelText = this.transform.Find("LevelPanel").GetComponentInChildren<TMP_Text>();
    }

    public void SetIcon(Sprite img)
    {
        this.icon.sprite = img;
    }

    public void SetText(int i)
    {
        if(levelText == null)
            Init();
        this.levelText.text = i + "";
    }

    public void SetWeapon(weapon_base w)
    {
        this.weapon = w;
        SetText(weapon.level);
        SetIcon(weapon.itemImage);
    }

    public weapon_base GetWeapon()
    {
        return this.weapon;
    }

    public void SetDescWeapon()
    {
        if (iconPanel != this)
            iconPanel.SetWeapon(this.weapon);
        else
            Debug.Log("err");
    }
}
