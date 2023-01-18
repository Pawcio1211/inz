using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveY : MonoBehaviour
{
    private float speed;
    public Transform centre;
    private float posY, posZ, angle = 0;
    float r = 9;
    bool side, go, jump;

    // Start is called before the first frame update
    void Start()
    {
        side = false;
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        jump = Input.GetButton("Jump");

        if (jump)
        {
            SceneManager.LoadScene("Menu3D");
        }

        if (go)
        {
            angle = angle + Time.deltaTime * speed;

            posY = centre.position.x + Mathf.Sin(angle) * r;
            posZ = centre.position.x + Mathf.Cos(angle) * r;
            transform.position = new Vector3(0, posY, posZ);
        }
        
    }

    public void Set()
    {
        go = true;
        if (angle >= 0.8f)
        {
            side = true;
        }
        if (side == false)
        {
            speed = 0.1f;
        }

        if (angle <= -0.8f)
        {
            side = false;
        }
        if (side == true)
        {
            speed = -0.1f;
        }
    }
    public void Remove() { speed = 0f; }
}
