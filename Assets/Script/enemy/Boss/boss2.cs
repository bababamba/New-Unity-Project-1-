using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2 : BossEnemy_Base
{
    public int phase = 1;
    public GameObject wallPrefab;
    public int wallCount = 20; 
    public float radius = 10f;

    public GameObject Bomber;
    [SerializeField] float spawnRadius = 5f;
    
    public GameObject Slicer;
    float minRotation = 0f; 
    float maxRotation = 180f;
    
     

    bool haveWall = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.init(4000, 2, 2);
        numberOfGimick = 2;
        mustGimick = 8;
        initBossEnemy(false, 3);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
    protected override void gimick1()
    {
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;

        Vector3 spawnPosition = new Vector3(player.transform.position.x + randomOffset.x, player.transform.position.y + randomOffset.y, player.transform.position.z);

        GameObject bomber = Instantiate(Bomber, spawnPosition, Quaternion.identity);
        bomber.GetComponent<Bomb_ForBoss2>().typeOfBomber = 0;
        bomber.GetComponent<Bomb_ForBoss2>().Boss = this.gameObject;
        base.gimick1();
    }
    protected override void gimick2()
    {
        float randomRotation = Random.Range(minRotation, maxRotation);
        Vector3 spawnPosition = new Vector3(player.transform.position.x , player.transform.position.y , player.transform.position.z);

        Instantiate(Slicer, spawnPosition, Quaternion.Euler(0, 0, randomRotation));
     
        base.gimick2();
    }
    protected override void gimick3()
    {
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;

        Vector3 spawnPosition = new Vector3(player.transform.position.x + randomOffset.x, player.transform.position.y + randomOffset.y, player.transform.position.z);

        GameObject bomber = Instantiate(Bomber, spawnPosition, Quaternion.identity);
        bomber.GetComponent<Bomb_ForBoss2>().typeOfBomber = 1;
        bomber.GetComponent<Bomb_ForBoss2>().Boss = this.gameObject;
        base.gimick3();
    }
    protected override void gimick4()
    {
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;

        Vector3 spawnPosition = new Vector3(player.transform.position.x + randomOffset.x, player.transform.position.y + randomOffset.y, player.transform.position.z);

        GameObject bomber = Instantiate(Bomber, spawnPosition, Quaternion.identity);
        bomber.GetComponent<Bomb_ForBoss2>().typeOfBomber = 2;
        bomber.GetComponent<Bomb_ForBoss2>().Boss = this.gameObject;
        base.gimick4();
    }
    protected override void gimick8()
    {
        if (!haveWall)
        {
            for (int i = 0; i < wallCount; i++)
            {
                float angle = i * 360f / wallCount;
                Vector3 spawnPosition = player.transform.position + Quaternion.Euler(0f, 0f, angle) * Vector3.right * radius;

                GameObject wall = Instantiate(wallPrefab, spawnPosition, Quaternion.identity);
                wall.transform.SetParent(transform);
                wall.GetComponent<Wall_Unit>().Point = player.transform;
            }
            haveWall = true;
        }
        else
        {
            for (int i = 0; i < this.transform.childCount; i++)
                if (this.transform.GetChild(i).GetComponent<Wall_Unit>())
                    this.transform.GetChild(i).GetComponent<Wall_Unit>().OnActive();
        }
        base.gimick4();
    }
    public override void takeDamage(float dmg)
    {
        base.takeDamage(dmg);
        if (phase < 2 && this.getCurHP() <= this.getMaxHP() / 2)
        {
            phase = 2;
            timerMax = 0.75f;
            mustGimick = 8;
            numberOfGimick = 3;


        }
        if (phase < 3 && this.getCurHP() <= this.getMaxHP() / 4)
        {
            phase = 3;
            timerMax = 0.5f;
            mustGimick = 8;
            numberOfGimick = 4;
        }

    }

}
