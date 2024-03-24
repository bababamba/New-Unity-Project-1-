using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    public int KillGoal;
    // Start is called before the first frame update
    void Start()
    {
        init();
        KillGoal = 10;
        
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
            GameClearCheck(1);
        }
        

    }

    void ReadyToStart()
    {
        //UIM.inventoryObject.GetComponent<inventory>().AcquireItem(itemM.items[0]);
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
        killCountReset();
    }


    public void expUp(float earned)
    {
        goldEarn((int)earned);
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
    public void killCountReset()
    {
        killCount = 0;
    }
    public void goldEarn(int gold)
    {
        goldEarned += gold;
    }
    public bool goldLostCheck(int value)
    {
        if (goldEarned - value >= 0)
            return true;
        else
            return false;
    }
    public void goldLost(int value)
    {
        goldEarned -= value;
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
    public Transform StrongestEnemy(int playerNumber, float range, Transform notTarget = null)
    {
        GameObject cEnemy = null;
        float highestHP = 0f;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");



        foreach (GameObject enemy in enemies)
        {

            float distanceToPlayer = Vector2.Distance(enemy.transform.position, player[playerNumber].transform.position);
            float hp = enemy.GetComponent<enemy_base>().getCurHP();

            if (hp > highestHP && distanceToPlayer <= range && !(notTarget != null && notTarget == cEnemy))
            {
                highestHP = hp;
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
    public Transform randomEnemyInRange(int playerNumber, int range)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> EIR = new List<GameObject>();
        GameObject[] enemiesInRange;
        for(int i = 0; i < enemies.Length; i++)
        {
            float distanceToPlayer = Vector2.Distance(enemies[i].transform.position, player[playerNumber].transform.position);
            if(distanceToPlayer <= range)
            {
                EIR.Add(enemies[i]);
            }
        }
        enemiesInRange = EIR.ToArray();

        int len = enemiesInRange.Length;
        if (len > 1)
        {
            int seed = Random.Range(0, len);
            if (enemiesInRange[seed])
                return enemiesInRange[seed].transform;
            else
                return player[playerNumber].transform;
        }
        else if (len == 1)
            return enemiesInRange[0].transform;
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
    void GameClearCheck(int type)
    {
        switch (type)
        {
            case 1: if (killCount >= KillGoal) GameClear(); break;
            default:Debug.Log("GameCleaCheckFail_UnknownType"); break;
        }
    }

    public void GameClear()
    {
        isGaming = false;
        goldEarn(100);
        UIM.LevelUpStart();
        StartCoroutine(GotoMap());
    }
    IEnumerator GotoMap()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("IngameMapScreen");
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
