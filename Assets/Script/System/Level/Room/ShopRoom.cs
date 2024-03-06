using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class ShopRoom : Room
{
    public Random random = new Random();

    public ShopRoom(int x, int y) : base(x, y)
    {
        this.type = RoomType.MERCHANT;
        Init();
    }

    public void Init()
    {
        //UI ����
            // Monobehaviour�� ����� �ΰ��� ������Ʈ���� UI�� ����.

        //�̺�Ʈ ó��
            // ��ǰ ����Ʈ���� ������ ������ŭ �������� ��ǰ�� �����Ѵ�.
            // ��ǰ(���� ������) ����Ʈ���� �̹� �ִ� ������ ����� ������ �����Ѵ�.

        //UI ǥ��
            // '�̺�Ʈ ó��'���� ������ ��ǰ���� UI �� �� ��ǰ ĭ�� ��ġ�Ѵ�.
    }

}
