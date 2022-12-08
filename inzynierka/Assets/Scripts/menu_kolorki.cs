using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_kolorki : MonoBehaviour
{
    public void Red()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
