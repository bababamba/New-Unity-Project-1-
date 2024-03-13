using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionLine : MonoBehaviour
{
    public Room room;
    public Sprite LineImage;

    
    // Start is called before the first frame update
    void Start()
    {
        //Init();
        //Debug.Log(this.transform.position);
    }

    public void Connect(GameObject target)
    {
        GameObject line = new GameObject();
        line.AddComponent<Image>();
        RectTransform rect = line.GetComponent<RectTransform>();

        line.GetComponent<Image>().sprite = LineImage;
        float dir = (target.GetComponent<RectTransform>().anchoredPosition.x - this.GetComponent<RectTransform>().anchoredPosition.x);
        float angle;
        if (dir == 0)
            angle = 90;
        else if (dir > 0)
            angle = -45;
        else
            angle = 45;

        rect.SetParent(this.transform);

        rect.anchoredPosition = Vector3.zero;
        rect.rotation = Quaternion.Euler(0, 0, angle);
        rect.localScale = new Vector3(3, 0.5f, 1);

        
    }

    


}
