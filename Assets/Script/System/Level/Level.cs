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

        //실제 레벨에 표시될 폭(층당 최대 방 수), 높이(층 수)를 입력
        width = 5;
        height = 15;

        rooms = new Room[width, height];
        GenerateLevel();
        //PrintLevel();
    }


    public void GenerateLevel()
    {
        //1. 임시 방 만들기
        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                rooms[i, j] = new Room(i, j);
            }
        }

        //2. 랜덤 연결 만들기
        ConnectRooms();

        //3. 비율에 맞게 방 역할 할당하기

        //3-1. 유효한 방(다른 방과 연결되어 있고, 0층(실제 미사용) 및 최종층(모닥불 고정)을 제외한 층에 해당하는 방)의 수 산정
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
                //최대 좌우 1칸 범위 내의 다음 층 방을 1개 선정
                int num;
                if (temp_i == 0)//가장 왼쪽일 경우 왼쪽 루트 불가
                    num = random.Next(0, 2);
                else if (temp_i >= width - 1)//가장 오른쪽일 경우 오른쪽 루트 불가
                    if (rooms[temp_i, j + 1].prevRooms.Count > 0)//X자 방지
                        num = 0;
                    else
                        num = random.Next(-1, 1);
                else if (rooms[temp_i, j + 1].prevRooms.Count > 0)//X자 방지
                    num = 0;
                else//모든 조건에 해당하지 않으면 좌, 우, 중앙 중 자유롭게 선택
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
                    //방을 표시하는 오브젝트는 가능한 3방향(좌, 우, 중앙)에 대한 연결용 오브젝트 보유
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
                //prevFloor에서 curFloor로 향하는 연결 생성
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
