using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_kolorki : MonoBehaviour
{
    public void Kolor_podswietlenie()
    {
        GetComponent<Renderer>().material.color = new Color32(88,0,0,255);
    }

    public void Kolor()
    {
        GetComponent<Renderer>().material.color = new Color32(120,0,0,255);
    }
}
