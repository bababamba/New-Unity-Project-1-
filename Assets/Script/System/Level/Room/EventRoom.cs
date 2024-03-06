using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EventRoom : Room
{
    public Random random = new Random();

    public EventRoom(int x, int y) : base(x, y)
    {
        this.type = RoomType.EVENT;
        Init();
    }

    public enum EventType
    {
        NONE = 0,

    }
    public EventType eventNum = EventType.NONE;

    public void Init()
    {
        // �̺�Ʈ ����
            // �̺�Ʈ Ǯ�� �����ؾ� �Ѵ�.
            // �̺�Ʈ Ǯ���� �������� �̺�Ʈ�� �̾Ƴ���.
            // �̾Ƴ� �̺�Ʈ�� �̺�Ʈ Ǯ���� �ӽ� ���ŵǾ�, �������� Ŭ���� �� �ʱ�ȭ�ȴ�.

        // UI ����
            // Monobehaviour�� ����� �ΰ��� ������Ʈ���� UI�� ����.
            // '�̺�Ʈ ����' ��Ʈ���� ������ �̺�Ʈ ����(JSON�̳� ��ųʸ� Ȱ���Ͽ� �̸�-���� ����־� ��) ���
    }

    public void Execute(int num)
    {
        // �̺�Ʈ ó��
            // UI ������ ���� UI���� ���� �̺�Ʈ �� ��ũ��Ʈ�� ���� �����ϴ�.
            // UI���� ��ư�� ���� Execute(������ ��ȣ)�� �����Ѵ�.
            // �̺�Ʈ�� �ش� ��ȣ�� ���� ������ ����� �����Ѵ�.
    }
}
