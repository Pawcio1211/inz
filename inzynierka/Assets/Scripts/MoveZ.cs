using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveZ : MonoBehaviour
{
    public Transform target;
    public float speed;
    private float posZ;
    bool side, go, tri;

    // Start is called before the first frame update
    void Start()
    {
        side = false;
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        tri = Input.GetButton("trojkat");

        if (tri)
        {
            SceneManager.LoadScene("Menu3D");
        }

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
