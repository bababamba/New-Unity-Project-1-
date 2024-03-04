using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1 : BossEnemy_Base
{
    [SerializeField] GameObject Pawn;
    [SerializeField] float spawnRadius = 5f;

    Vector3 centerPosition;
    // Start is called before the first frame update
    protected override void Start()
    {
        centerPosition = transform.position;
        base.Start();
        this.init(1000, 2, 2);
        numberOfGimick = 2;
        mustGimick = 2;
        initBossEnemy(false, 3);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
    }
    protected override void gimick1()
    {
        for(int i=0;i<this.transform.childCount;i++)
            if(this.transform.GetChild(i).GetComponent<Chess_Unit>())
                this.transform.GetChild(i).GetComponent<Chess_Unit>().OnActive();
        base.gimick1();
        isGimickEnd = true;
        //Debug.Log("1 End");
    }
    protected override void gimick2()
    {
       

        // 반경 내에서 랜덤한 위치 생성
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;

        // 생성할 위치 계산
        Vector3 spawnPosition = new Vector3(centerPosition.x + randomOffset.x, centerPosition.y + randomOffset.y, centerPosition.z);

        // Pawn 생성
        GameObject pawn =  Instantiate(Pawn, spawnPosition, Quaternion.identity);

        pawn.transform.SetParent(this.transform);

       // timer = 1f;
        base.gimick2();
        isGimickEnd = true;
       // Debug.Log("2 End");
    }

}
