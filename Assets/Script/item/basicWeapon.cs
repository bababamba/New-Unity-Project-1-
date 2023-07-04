using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicWeapon : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        invenNum = 0;
        itemNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    new void itemTrigger()
    {
        GameObject whiteBox = Instantiate(bullet, player.transform.position, player.transform.rotation);
        Rigidbody whiteBoxRigidbody = whiteBox.GetComponent<Rigidbody>();
        whiteBoxRigidbody.AddForce(player.transform.forward * shootForce, ForceMode.Impulse);
    }
    
}
