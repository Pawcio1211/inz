using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZ : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector3 startposition;
    private float posX, posZ, angle = 0;
    float r = 7;
    bool side;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startposition;
        side = false;
    }

    // Update is called once per frame
    void Update()
    { 
        transform.Rotate(new Vector3(0, 0, speed));
        posZ = target.rotation.z;

        Debug.Log(posZ);

        if (angle > 1.0f)
        {
            angle = 0;
        }
    }

    public void Set()
    {
        if (posZ >= 0.4f)
        {
            side = true;
        }
        if (side == false)
        {
            speed = 0.1f;
        }

        if (posZ <= -0.4f)
        {
            side = false;
        }
        if (side == true)
        {
            speed = -0.1f;
        }
    }
    public void Remove() { speed = 0; }
}
