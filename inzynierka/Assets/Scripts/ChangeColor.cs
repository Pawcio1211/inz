using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ChangeColor : MonoBehaviour
{
    public void Red()
    {
        if (GetComponent<Renderer>().material.color == Color.blue)
            GetComponent<Renderer>().material.color = Color.red;
    }
    public void Blue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
    public void Black()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
