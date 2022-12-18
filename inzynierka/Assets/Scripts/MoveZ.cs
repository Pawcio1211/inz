using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZ : MonoBehaviour
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
        transform.Rotate(new Vector3(0, 0, angle) * speed);

        Debug.Log(angle);
    }

    public void Set()
    {
        if (angle >= 1.0f)
        {
            side = true;
        }
        if (side == false)
        {
            speed = -speed;
        }

        if (angle <= -1.0f)
        {
            side = false;
        }
        if (side == true)
        {
            speed = -speed;
        }
    }
    public void Remove() { transform.Rotate(new Vector3(0, 0, 0) * speed); }
}
