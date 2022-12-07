using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveX : MonoBehaviour
{
    public float speed;
    public Vector3 startposition;
    public Transform centre;
    private float posX, posZ, angle = 0;
    float r = 7;
    bool start = false, side;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startposition;
        side = false;
    }

    // Update is called once per frame
    void Update()
    {
        angle = angle + Time.deltaTime * speed;
        
        posX = centre.position.x + Mathf.Sin(angle) * r;
        posZ = centre.position.x + Mathf.Cos(angle) * r;
        transform.position = new Vector3(posX, 0, posZ);

        if (angle > 360)
        {
            angle = 0;
        }
    }

    public void Set() 
    { 
        if (angle >= 1.5f) 
        {
            side = true;
        }
        if (side == false)
        {
            speed = 0.3f;
        }

        if (angle <= -1.5f) 
        {
            side = false;
        }        
        if (side == true)
        {
            speed = -0.3f;
        }
    }
    public void Remove() { speed = 0f; }
}