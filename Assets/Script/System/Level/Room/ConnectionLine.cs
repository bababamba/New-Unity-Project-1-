using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionLine : MonoBehaviour
{
    private float lineWidth = 0.1f;
    private LineRenderer lineRenderer = new LineRenderer();
    private Vector2[] linePosition = new Vector2[2];

    private ConnectionLine connectedObject;

    public Room room;
    
    // Start is called before the first frame update
    void Start()
    {
        //Init();
        //Debug.Log(this.transform.position);
    }

    public void Init()
    {
        lineRenderer = GetComponent<LineRenderer>();
        linePosition[0] = this.transform.position;

        lineRenderer.enabled = false;
        lineRenderer.material.color = Color.black;
        lineRenderer.widthMultiplier = lineWidth;
        lineRenderer.positionCount = linePosition.Length;
    }

    public void Connect(GameObject target)
    {
        Init();
        lineRenderer.enabled = true; 
        linePosition[1] = target.transform.position;

        lineRenderer.SetPosition(0, linePosition[0]);
        lineRenderer.SetPosition(1, linePosition[1]);
    }
}
