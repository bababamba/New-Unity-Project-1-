using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Level : MonoBehaviour
{
    public Room[,] rooms;
    public int width;
    public int height;  
    
    public Random random = new Random();
    public GameObject roomObject;
    public Image LineImage;

    public Canvas[] floor;

    // Start is called before the first frame update
    void Start()
    {
        floor = GetComponentsInChildren<Canvas>();

        //���� ������ ǥ�õ� ��(���� �ִ� �� ��), ����(�� ��)�� �Է�
        width = 5;
        height = 15;

        rooms = new Room[width, height];
        GenerateLevel();
        //PrintLevel();
    }


    public void GenerateLevel()
    {
        //1. �ӽ� �� �����
        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                rooms[i, j] = new Room(i, j);
            }
        }

        //2. ���� ���� �����
        ConnectRooms();

        //3. ������ �°� �� ���� �Ҵ��ϱ�

        //3-1. ��ȿ�� ��(�ٸ� ��� ����Ǿ� �ְ�, 0��(���� �̻��) �� ������(��ں� ����)�� ������ ���� �ش��ϴ� ��)�� �� ����
        int available = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (!rooms[i, j].isAlone())
                {
                    rooms[i, j].type = Room.RoomType.COMBAT;
                    if (j != 0 || j != height)
                        available++;
                }
            }
        }

    }

    public void ConnectRooms()
    {
        
        for (int i = 0; i < width; i++)
        {
            int temp_i = i;
            int j = 0;
            Room room = rooms[i, j];
            while (j < height - 1)
            {
                //�ִ� �¿� 1ĭ ���� ���� ���� �� ���� 1�� ����
                int num;
                if (temp_i == 0)//���� ������ ��� ���� ��Ʈ �Ұ�
                    num = random.Next(0, 2);
                else if (temp_i >= width - 1)//���� �������� ��� ������ ��Ʈ �Ұ�
                    if (rooms[temp_i, j + 1].prevRooms.Count > 0)//X�� ����
                        num = 0;
                    else
                        num = random.Next(-1, 1);
                else if (rooms[temp_i, j + 1].prevRooms.Count > 0)//X�� ����
                    num = 0;
                else//��� ���ǿ� �ش����� ������ ��, ��, �߾� �� �����Ӱ� ����
                    num = random.Next(-1, 2);
                room.Connect(room, rooms[temp_i + num, j + 1]);
                //Debug.Log("floor " + j + " room " + temp_i + " is Connected with floor " + (j + 1) + " room " + (temp_i + num) + ".");
                j++;
                temp_i += num;
                room = rooms[temp_i, j];
            }
            //Debug.Log("Line " + i + "complete.");
        }
        
        GameObject[] prevFloor = new GameObject[width];
        GameObject[] curFloor = new GameObject[width];

        for(int j = 1; j < height; j++)
        {
            for(int i = 0; i < width; i++)
            {
                if (!rooms[i, j].isAlone())
                {
                    //���� ǥ���ϴ� ������Ʈ�� ������ 3����(��, ��, �߾�)�� ���� ����� ������Ʈ ����
                    GameObject room = Instantiate(roomObject);
                    room.transform.SetParent(floor[height - j].transform);
                    room.GetComponent<RectTransform>().anchoredPosition = new Vector2((i - 2) * 200, 0);
                    curFloor[i] = room;
                    ConnectionLine[] lines = curFloor[i].GetComponentsInChildren<ConnectionLine>();
                    for(int k = 0; k < lines.Length; k++)
                    {
                        lines[k].room = rooms[i, j];
                    }
                }
            }
            if(j > 1)
            {
                //prevFloor���� curFloor�� ���ϴ� ���� ����
                for(int n = 0; n < prevFloor.Length; n++)
                {
                    if (prevFloor[n] != null)
                    {
                        ConnectionLine[] lines = prevFloor[n].GetComponentsInChildren<ConnectionLine>();
                        foreach (Room r in lines[0].room.nextRooms)
                        {
                            if (r != null)
                            {
                                if (r.x < lines[0].room.x)
                                    lines[0].Connect(curFloor[r.x]);
                                else if (r.x == lines[0].room.x)
                                    lines[1].Connect(curFloor[r.x]);
                                else if (r.x > lines[0].room.x)
                                    lines[2].Connect(curFloor[r.x]);
                            } 
                        }
                    }
                }
            }

            prevFloor = curFloor;
            curFloor = new GameObject[width];
        }

    }

    public void PrintLevel()
    {
        for (int j = height - 1; j >= 0; j--)
        {
            string connectionText = "";
            if (j != height - 1)
            {
                for (int i = 0; i < width; i++)
                {
                    if (rooms[i, j].type != Room.RoomType.COMBAT)
                    {
                        connectionText += "       ";
                        continue;
                    }
                    bool left = false;
                    bool mid = false;
                    bool right = false;

                    foreach (Room r in rooms[i, j].nextRooms)
                    {
                        if (rooms[i, j].x > r.x)
                            left = true;
                        else if (rooms[i, j].x == r.x)
                            mid = true;
                        else if (rooms[i, j].x < r.x)
                            right = true;
                    }
                    string temp = "";
                    if (left)
                        temp += "\\";
                    if (mid)
                        temp += "|";
                    if (right)
                        temp += "/";
                    connectionText += temp;

                    if (i != width)
                    {
                        for (int n = temp.Length; n <= 7; n++)
                            connectionText += " ";
                    }
                }
                Debug.Log(connectionText);
            }

            string roomText = "";
            for (int i = 0; i < width; i++)
            {
                if (rooms[i, j].type == Room.RoomType.COMBAT)
                    roomText += "C";
                else
                    roomText += "X";
                if (i != width)
                    roomText += "     ";
            }
            Debug.Log(roomText);
        }
    }

}
