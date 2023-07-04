using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGaming;
    int killCount;
    int goldEarned;
    bool isPlayerActive = false;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void init()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        killCount = 0;
        goldEarned = 0;
        isGaming = true;
    }
    public void killCountUp()
    {
        killCount++;
    }
    public void goldEarn(int gold)
    {
        goldEarned += gold;
    }
    public int getKillCount()
    {
        return killCount;
    }
    public int getGoldEarned()
    {
        return goldEarned;
    }
    public GameObject closestEnemy()
    {
        GameObject cEnemy = null;
        float closestDistance = Mathf.Infinity;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


        foreach (GameObject enemy in enemies)
        {
            float distanceToPlayer = Vector3.Distance(enemy.transform.position, player.transform.position);

            // 현재 적과 플레이어 사이의 거리가 가장 가까운 거리라면 갱신
            if (distanceToPlayer < closestDistance)
            {
                closestDistance = distanceToPlayer;
                cEnemy = enemy;
            }
        }
        return cEnemy;
    }
    
}
