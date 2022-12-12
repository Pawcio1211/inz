using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_kolorki : MonoBehaviour
{
    public void Kolor_podswietlenie()
    {
        GetComponent<Renderer>().material.color = new Color32(0,53,96,255);
    }

    public void Kolor()
    {
        GetComponent<Renderer>().material.color = new Color32(22,88,138,255);
    }
}
