using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creture
{
    private CharacterController CC;
    public VirtualJoystick VJ;
    private void Awake()
    {
        this.init(100, 10, 1);
        VJ.speed = this.speed;
        CC = GetComponent<CharacterController>();
        gameObject.tag = "Player";
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //gameManager.closestEnemy().transform.position;
    }
    protected override void death()
    {
        base.death();
        Debug.Log("GAME OVER");
    }
    public Transform playerTransform()
    {
        return this.transform;
    }
}
