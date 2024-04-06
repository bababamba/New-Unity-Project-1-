using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    public GameObject grassTile;
    public GameObject treeTile;
    public GameObject[] waterTiles;

    private GameObject[,] map;

    public GameObject player;
    private Vector2Int currentMap = new Vector2Int(0, 0);
    private List<Vector2> generatedMapList = new List<Vector2>();

    public int tileSize = 30; // 각 타일의 크기

    public Vector2Int currentTile; // 현재 플레이어가 위치한 타일의 좌표

    public GameObject bigTile;
    public GameObject BossTile;

    bool isBoss = false;

    void Start()
    {
        if (PlayerData.data.enemyPool == 100)
        {
            isBoss = true;
            GenerateBossMap(0, 0);
        }
        player = GameObject.Find("player");
        if (!isBoss) { 
            GenerateBigMap(0, 0);
            GenerateBigMap( 1, 0);
            GenerateBigMap( -1, 0);
            GenerateBigMap( 1, 1);
            GenerateBigMap( -1, 1);
            GenerateBigMap( 1, -1);
            GenerateBigMap( 0, 1);
            GenerateBigMap( 0, -1);
            GenerateBigMap( -1, -1);// 초기 맵 생성
        }

    }

    void GenerateMap(int mapCode, int mapX, int mapY)
    {
        Vector2 tempmap = new Vector2(mapX, mapY);
        if (!generatedMapList.Contains(tempmap))
        {
            string[,] mapData;
            if(mapCode == 0) 
            { 
            mapCode = Random.Range(1,5);
            }
            /*
                    { "W7", "W3", "W10"}

                    { "W4", "W1", "W6"}
                    { "W8", "W5", "W9"}
                    */
            // 선택된 맵 코드에 따라 맵 데이터를 설정
            if (mapCode == 1)
            {
                mapData = new string[,]
                {
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },

                };
            }
            else if (mapCode == 2)
            {
                mapData = new string[,]
                {
                { "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "T", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "T", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "W7", "W3", "W3", "W3", "W3", "W10", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "W4", "W1", "W1", "W1", "W1", "W6", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "W4", "W1", "W1", "W1", "W1", "W6", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "W4", "W1", "W1", "W1", "W1", "W6", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "W8", "W5", "W5", "W5", "W5", "W9", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "T", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "T", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "T", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "T", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },

                };
            }
            else if (mapCode == 3)
            {
                mapData = new string[,]
                {
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "W7", "W3", "W10", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "W4", "W1", "W6", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "W8", "W5", "W9", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "T", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","T", "G", "G", "G", "G", "G", "G", "G", "G", "G","T", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "T", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "T", "G", "G", "G", "G", "G", "G","G", "G", "G", "T", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "W7", "W10", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "W8", "W9", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "T", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","W7", "W10", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","W8", "W9", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "T", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "T", "G", "G", "G", "G", "G","G", "G", "T", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
                };
            }
            else if (mapCode == 4)
            {
                mapData = new string[,]
                {
                { "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "T", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "T", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "T", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "T", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "T", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","T", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "T", "G", "G", "G" },
{ "G", "G", "G", "G", "T", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "T", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "T", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "T", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "T", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "T", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "T", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "T", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "T", "G", "G", "G", "G", "G", "G","G", "G", "G", "T", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },
{ "G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G","G", "G", "G", "G", "G", "G", "G", "G", "G", "G" },

                };
            }
            else if (mapCode == 5)
            {
                mapData = new string[,]
                {

                };
            }
            else if (mapCode == 6)
            {
                mapData = new string[,]
                {

                };
            }
            else if (mapCode == 7)
            {
                mapData = new string[,]
                {

                };
            }
            else if (mapCode == 8)
            {
                mapData = new string[,]
                {

                };
            }
            else
            {
                return; // 잘못된 맵 코드인 경우 함수 종료
            }


            int width = mapData.GetLength(1);
            int height = mapData.GetLength(0);



            map = new GameObject[width, height];



            // 맵을 생성합니다
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    string tileCode = mapData[y, x];

                    if (tileCode == "G") // 잔디 타일
                    {
                        map[x, y] = Instantiate(grassTile, new Vector2(mapX * 30 + x, -mapY * 30 - y), Quaternion.identity);
                    }
                    else if (tileCode == "T") // 나무 타일
                    {
                        map[x, y] = Instantiate(grassTile, new Vector2(mapX * 30 + x, -mapY * 30 - y), Quaternion.identity);
                        map[x, y].transform.SetParent(this.gameObject.transform);
                        map[x, y].tag = "Structure";
                        map[x, y] = Instantiate(treeTile, new Vector2(mapX * 30 + x, -mapY * 30 - y), Quaternion.identity);
                    }
                    else if (tileCode.StartsWith("W")) // 물 타일
                    {
                        int direction = int.Parse(tileCode.Substring(1)); // 방향
                        if (direction >= 1 && direction <= 10)
                        {
                            map[x, y] = Instantiate(waterTiles[direction - 1], new Vector2(mapX * 30 + x, -mapY * 30 - y), Quaternion.identity);
                            map[x, y].tag = "Structure";
                        }
                    }
                    map[x, y].transform.SetParent(this.gameObject.transform);
                }
            }
            generatedMapList.Add(tempmap);
            //Debug.Log("Added unique vector: " + tempmap);
        }
    }
    void GenerateBigMap(int mapX, int mapY)
    {
        Vector2 tempmap = new Vector2(mapX, mapY);
        if (!generatedMapList.Contains(tempmap))
        {
            GameObject map = Instantiate(bigTile, new Vector2(mapX * 30, -mapY * 30), Quaternion.identity);
            map.transform.SetParent(this.gameObject.transform);
            generatedMapList.Add(tempmap);
        }

    }
    void GenerateBossMap(int mapX, int mapY)
    {
        Vector2 tempmap = new Vector2(mapX, mapY);
        if (!generatedMapList.Contains(tempmap))
        {
            GameObject map = Instantiate(BossTile, new Vector2(mapX * 30, -mapY * 30), Quaternion.identity);
            map.transform.SetParent(this.gameObject.transform);
            generatedMapList.Add(tempmap);
        }

    }

    void Update()
    {
        if (!isBoss)
        {
            //currentMap = new Vector2Int((int)(player.transform.position.x-15) / 30, (int)(player.transform.position.y - 15) / 30);
            Vector2 playerPosition = player.transform.position;
            currentTile = new Vector2Int(
                Mathf.FloorToInt(playerPosition.x / tileSize),
                Mathf.FloorToInt(playerPosition.y / -tileSize)
            );

            GenerateBigMap(currentTile.x + 1, currentTile.y);
            GenerateBigMap(currentTile.x - 1, currentTile.y);
            GenerateBigMap(currentTile.x + 1, currentTile.y + 1);
            GenerateBigMap(currentTile.x - 1, currentTile.y + 1);
            GenerateBigMap(currentTile.x + 1, currentTile.y - 1);
            GenerateBigMap(currentTile.x, currentTile.y + 1);
            GenerateBigMap(currentTile.x, currentTile.y - 1);
            GenerateBigMap(currentTile.x - 1, currentTile.y - 1);
            // 플레이어 위치 출력
        }
    }
}
/*
public class mapGenerator : MonoBehaviour
{
    public int mapWidth = 100;
    public int mapHeight = 100;

    public GameObject grassTile1;
    public GameObject grassTile2;
    public GameObject grassTile3;
    public GameObject tree1;
    public GameObject tree2;
    public GameObject waterTile;

    private string[,] map;

    void Start()
    {
        GenerateMap();
        InstantiateTiles();
    }

    void GenerateMap()
    {
        map = new string[mapWidth, mapHeight];

        // Fill map with grass symbols
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                map[x, y] = "G";
            }
        }

        // Randomly place water areas
        int waterWidth = Random.Range(1, 11);
        int waterHeight = Random.Range(1, 11);
        int waterX = Random.Range(0, mapWidth - waterWidth);
        int waterY = Random.Range(0, mapHeight - waterHeight);

        for (int x = waterX; x < waterX + waterWidth; x++)
        {
            for (int y = waterY; y < waterY + waterHeight; y++)
            {
                map[x, y] = "W";
            }
        }

        // Assign grass variations
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (map[x, y] == "G")
                {
                    int grassType = Random.Range(1, 1001);
                    if (grassType != 4)
                        grassType = Random.Range(1, 4);
                    map[x, y] = "G" + grassType.ToString();
                }
            }
        }
    }

    void InstantiateTiles()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                string tileType = map[x, y];

                if (tileType == "G1")
                {
                    Instantiate(grassTile1, new Vector2(x, y), Quaternion.identity);
                }
                else if (tileType == "G2")
                {
                    Instantiate(grassTile2, new Vector2(x, y), Quaternion.identity);
                }
                else if (tileType == "G3")
                {
                    Instantiate(grassTile3, new Vector2(x, y), Quaternion.identity);
                }
                else if (tileType == "G4")
                {
                    Instantiate(grassTile3, new Vector2(x, y), Quaternion.identity);
                    Instantiate(tree1, new Vector2(x, y), Quaternion.identity);
                }


                else if (tileType == "W")
                {
                    Instantiate(waterTile, new Vector2(x, y), Quaternion.identity);
                }
            }
        }
    }
}
*/