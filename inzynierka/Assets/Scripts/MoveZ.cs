using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZ : MonoBehaviour
{
    public Transform target;
    public float speed;
    private float posZ;
    bool side, go;

    // Start is called before the first frame update
    void Start()
    {
        side = false;
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            transform.Rotate(new Vector3(0, 0, speed));
            posZ = target.rotation.z;
        }

        Debug.Log(posZ);
    }

    public void Set()
    {
        go = true;
        if (posZ >= 0.55f)
        {
            side = true;
        }
        if (side == false)
        {
            speed = 0.1f;
        }

        if (posZ <= 0.15f)
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
