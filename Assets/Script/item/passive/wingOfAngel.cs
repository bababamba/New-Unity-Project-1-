using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wingOfAngel : passive_base
{
    // Start is called before the first frame update
    private void Awake()
    {
        itemNum = 9;

    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        move = 3f;

        itemName = "õ���� ����";
        itemText = "����:3";
        itemCaption = "��ȭ�ӿ� ������ õ���� ������� ���������� ���⹰�̴�. ������������ ���� ���������°� ����.";
    }
    public override void levelUp()
    {
        base.levelUp();
        itemName = "õ���� ����+" + (level - 1).ToString();
        move += 1f;
        itemText = "����:" + ((int)move).ToString();
        
    }
}
