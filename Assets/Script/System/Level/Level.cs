using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Level : MonoBehaviour
{
    public static Level level;

    public Room[,] rooms;
    public int[] lastRoom = new int[2];
    public int width;
    public int height;  
    
    public Random random = new Random();
    public GameObject roomObject;
    public Image LineImage;

    public Canvas[] floor;
    public int curFloor = 1;

    public const float EVENT = 0.2f;
    public const float ELITE = 0.1f;
    public const float SHOP = 0.05f;
    public const float FIREPLACE = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        if (level == null)
            level = this;
        else if (level != this)
            Destroy(this);

        floor = GetComponentsInChildren<Canvas>();

        //���� ������ ǥ�õ� ��(���� �ִ� �� ��), ����(�� ��)�� �Է�
        width = 5;
        height = 15;

        rooms = new Room[width, height];
        if (PlayerData.data.savedLevelData == false)
        {
            Debug.Log("1st Map Gen");
            GenerateLevel();
        }
        PlayerData.data.UpdateMapData();

        this.GetComponent<RectTransform>().SetAsLastSibling();

        if (lastRoom != null)
        {
            foreach (Room r in rooms)
            {
                foreach (Room r2 in rooms[lastRoom[0], lastRoom[1]].nextRooms)
                {
                    if (r.Equals(r2))
                        r.accessible = true;
                }
            }
        }
        if(curFloor == 1)
        {
            for (int i = 0; i < width; i++)
            {
                rooms[i, 1].accessible = true;
                Debug.Log(i);
            }
        }

        for (int i = 0; i < floor.Length; i++)
        {
            if (floor.Length - i == curFloor)
                floor[i].GetComponent<CanvasGroup>().interactable = true;
            else
                floor[i].GetComponent<CanvasGroup>().interactable = false;
        }









        PrintRooms();
        //PrintLevel();
    }

    void Update()
    {

    }

    public void Disable()
    {
        foreach(Canvas c in floor)
        {
            c.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        GetComponentInChildren<Scrollbar>().interactable = false;
        GetComponent<Image>().raycastTarget = false;
    }

    public void Enable()
    {
        foreach (Canvas c in floor)
        {
            c.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        GetComponentInChildren<Scrollbar>().interactable = true;
        GetComponent<Image>().raycastTarget = true;
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
        ConnectRooms();

        SetRooms();

        //PrintRooms();
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
    }

    public void SetRooms()
    {
        // 0���� ���� �̻��, 1���� �Ϲ� ���� ����
        // 14���� ���� ���� ��ں�, 15���� ���� ����
        // �߰� ���� �� 8���� �������� ��ġ ����
        int available = 0;
        List<Room> availableRooms = new List<Room>();
        for (int i = 0; i < width; i++)
        {
            for (int j = 1; j < height; j++)
            {
                if (!rooms[i, j].isAlone())
                {
                    if (j == 1)
                        rooms[i, j].type = Room.RoomType.COMBAT;
                    else if (j == 8)
                        rooms[i, j].type = Room.RoomType.CHEST;
                    else if (j == 14)
                        rooms[i, j].type = Room.RoomType.FIREPLACE;
                    else
                    {
                        rooms[i, j].type = Room.RoomType.COMBAT;
                        availableRooms.Add(rooms[i, j]);
                        available++;
                    }
                }
            }
        }

        //�̺�Ʈ, ����Ʈ, ����, �� ������ ����
        int eventRooms = (int)(available * EVENT);
        int eliteRooms = (int)(available * ELITE);
        int shopRooms = (int)(available * SHOP);
        int fireplaceRooms = (int)(available * FIREPLACE);

        /*Debug.Log("Event Rooms : " + eventRooms);
        Debug.Log("Elite Rooms : " + eliteRooms);
        Debug.Log("Shop Rooms : " + shopRooms);
        Debug.Log("Fireplace Rooms : " + fireplaceRooms);*/

        for (int i = 0; i < eventRooms; i++)
        {
            Room room = availableRooms[random.Next(0, availableRooms.Count)];
            room.type = Room.RoomType.EVENT;
            availableRooms.Remove(room);
        }
        for (int i = 0; i < eliteRooms; i++)
        {
            Room room = availableRooms[random.Next(0, availableRooms.Count)];
            room.type = Room.RoomType.ELITE;
            availableRooms.Remove(room);
        }
        for (int i = 0; i < shopRooms; i++)
        {
            Room room = availableRooms[random.Next(0, availableRooms.Count)];
            room.type = Room.RoomType.MERCHANT;
            availableRooms.Remove(room);
        }
        for (int i = 0; i < fireplaceRooms; i++)
        {
            Room room = availableRooms[random.Next(0, availableRooms.Count)];
            room.type = Room.RoomType.FIREPLACE;
            availableRooms.Remove(room);
        }

    }

    public void PrintRooms()
    {
        GameObject[] prevFloor = new GameObject[width];
        GameObject[] curFloor = new GameObject[width];

        for (int j = 1; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                if (!rooms[i, j].isAlone())
                {
                    //���� ǥ���ϴ� ������Ʈ�� ������ 3����(��, ��, �߾�)�� ���� ����� ������Ʈ ����
                    GameObject room = Instantiate(roomObject);
                    room.transform.SetParent(floor[height - j].transform);
                    room.GetComponent<RoomObject>().position[0] = i;
                    room.GetComponent<RoomObject>().position[1] = j;
                    switch (rooms[i, j].type)
                    {
                        case Room.RoomType.COMBAT:
                            room.GetComponent<RoomObject>().SetImage(0);
                            break;
                        case Room.RoomType.EVENT:
                            room.GetComponent<RoomObject>().SetImage(1);
                            break;
                        case Room.RoomType.ELITE:
                            room.GetComponent<RoomObject>().SetImage(2);
                            break;
                        case Room.RoomType.CHEST:
                            room.GetComponent<RoomObject>().SetImage(3);
                            break;
                        case Room.RoomType.MERCHANT:
                            room.GetComponent<RoomObject>().SetImage(3);
                            break;
                        case Room.RoomType.FIREPLACE:
                            room.GetComponent<RoomObject>().SetImage(4);
                            break;
                        default:
                            break;
                    }
                    room.GetComponent<RoomObject>().roomType = rooms[i, j].type;

                    room.GetComponent<RectTransform>().anchoredPosition = new Vector2((i - 2) * 200, 0);
                    curFloor[i] = room;
                    ConnectionLine[] lines = curFloor[i].GetComponentsInChildren<ConnectionLine>();
                    room.GetComponent<RectTransform>().SetAsLastSibling();
                    for (int k = 0; k < lines.Length; k++)
                    {
                        lines[k].room = rooms[i, j];
                    }
                    if (rooms[i, j].accessible == false)
                    {
                        room.GetComponent<Button>().interactable = false;
                        if (j == 1)
                            Debug.Log(".");
                    }
                }
            }
            if (j > 1)
            {
                //prevFloor���� curFloor�� ���ϴ� ���� ����
                for (int n = 0; n < prevFloor.Length; n++)
                {
                    if (prevFloor[n] != null)
                    {
                        ConnectionLine[] lines = prevFloor[n].GetComponentsInChildren<ConnectionLine>();
                        foreach (Room r in lines[0].room.nextRooms)
                        {
                            if (r != null)
                            {
                                if (r.x < lines[0].room.x)
                                    lines[0].Connect(curFloor[r.x], -1);
                                else if (r.x == lines[0].room.x)
                                    lines[1].Connect(curFloor[r.x], 0);
                                else if (r.x > lines[0].room.x)
                                    lines[2].Connect(curFloor[r.x], 1);
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
