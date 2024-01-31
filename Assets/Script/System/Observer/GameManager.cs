using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public bool isGaming = false;
    public int killCount;
    public int goldEarned;
    public float exp;
    public float maxExp;
    public bool isPlayerActive = false;
    public GameObject[] enemies;
    public GameObject enemy;
    public GameObject UIManagerObject;
    public GameObject itemManagerObject;



    private UIManager UIM;
    private itemManager itemM;

    public float minDistance = 13f;
    public float maxDistance = 16f;
    public float spawnRate = 3f;
    public float currentSpawnRate = 1f;

    public GameObject[] player;

    bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        init();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart)
        {
            ReadyToStart();
            GameStart();

            isStart = true;
        }
        if (isGaming)
        {
            currentSpawnRate -= Time.deltaTime;
            if (currentSpawnRate <= 0f)
            {
                currentSpawnRate += spawnRate;
                for (int i = 0; i < player.Length; i++)
                {
                    SpawnMonster(i);

                }
                if (spawnRate > 0.2f)
                    spawnRate -= 0.001f;

            }
        }
        else
            GameStart();

    }

    void ReadyToStart()
    {
        UIM.inventoryObject.GetComponent<inventory>().AcquireItem(itemM.items[0]);
        //Audio_Manager.Instance.BGM_Title();
    }
    void init()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        UIM = UIManagerObject.GetComponent<UIManager>();
        itemM = itemManagerObject.GetComponent<itemManager>();

        killCount = 0;
        goldEarned = 0;
        isGaming = true;
        exp = 0;
        maxExp = 100f;
    }

    public void GameStart()
    {
        isGaming = true;
    }


    public void expUp(float earned)
    {
        exp += earned;
        while (exp >= maxExp)
        {

            UIM.LevelUpStart();
            exp -= maxExp;
            maxExp += (float)0.3 * maxExp;
        }
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
    public Transform closestEnemy(int playerNumber, float range)
    {
        GameObject cEnemy = null;
        float closestDistance = Mathf.Infinity;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");



        foreach (GameObject enemy in enemies)
        {


            float distanceToPlayer = Vector2.Distance(enemy.transform.position, player[playerNumber].transform.position);

            // 현재 적과 플레이어 사이의 거리가 가장 가까운 거리라면 갱신
            if (distanceToPlayer < closestDistance)
            {
                closestDistance = distanceToPlayer;
                if (closestDistance < range)
                    cEnemy = enemy;
            }

        }
        if (cEnemy)
            return cEnemy.transform;
        else
            return player[playerNumber].transform;
    }
    public Transform randomEnemy(int playerNumber)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int len = enemies.Length;
        if (len > 1)
        {
            int seed = Random.Range(0, len);
            if (enemies[seed])
                return enemies[seed].transform;
            else
                return player[playerNumber].transform;
        }
        else if (len == 1)
            return enemies[0].transform;
        else
            return player[playerNumber].transform;
    }

    private void SpawnMonster(int playerNumber)
    {
        Vector2 playerPosition = player[playerNumber].transform.position;
        Vector2 spawnPosition = GetRandomSpawnPosition(playerPosition);
        GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        while (IsOverlappingTree(spawnedEnemy))
        {
            spawnedEnemy.transform.position = GetRandomSpawnPosition(playerPosition);
        }

        spawnedEnemy.GetComponent<enemy_base>().initE(playerNumber);


    }

    private Vector2 GetRandomSpawnPosition(Vector2 playerPosition)
    {
        float distance = Random.Range(minDistance, maxDistance);
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = playerPosition + randomDirection * distance;

        return spawnPosition;
    }

    private bool IsOverlappingTree(GameObject enemyCollider)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemyCollider.transform.position, 1f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Structure"))
            {
                return true;
            }
        }

        return false;
    }
    public Transform getPlayerTransform(Transform self)
    {


        if (player[0])
            return player[0].transform;
        else return self;
    }





    
    public void FindAllPlayer()
    {
        
        player = GameObject.FindGameObjectsWithTag("Player");
    }
   public GameObject FindPlayerByNumber(int n)
    {
        

        return player[n];
    }
    
}
