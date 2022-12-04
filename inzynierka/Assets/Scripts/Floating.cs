using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float speed = 0.5f;
    public Vector3 startposition;
    public Transform centre;
    private bool lor;
    private float posX, posZ, angle = 0;
    float r = 6;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startposition;
        lor = true;
    }

    // Update is called once per frame
    void Update()
    {
        angle = angle + Time.deltaTime * speed;
        Debug.Log(angle); 
        if (lor)
        {
            posX = centre.position.x + Mathf.Sin(angle) * r;
            posZ = centre.position.z + Mathf.Cos(angle) * r;
            transform.position = new Vector3(posX, 0, posZ);
;
            if (angle >= 2.0)
            {
                lor = false;
            }
        }

        if(!lor)
        {
            posX = centre.position.x + Mathf.Cos(angle) * r;
            posZ = centre.position.z + Mathf.Sin(angle) * r;
            transform.position = new Vector3(posX, 0, posZ);

            if (posX >= 3.5)
            {
                lor = true;
            }
        }   

        if (angle > 360)
        {
            angle = 0;
        }        
    }
}