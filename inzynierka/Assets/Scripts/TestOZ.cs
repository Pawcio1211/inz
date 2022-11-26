using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TestOZ : MonoBehaviour
{
    public Text txtL;
    public Text txtP;
    public Transform target;

    bool chek = false;
    bool blokL = false;
    bool blokP = false;

    string l = "";
    string p = "";

    double z;
    
    void LateUpdate()
    {

        if (chek)
        {
            z = target.rotation.eulerAngles.z;
            if (z > 0 && z < 180)
                p = z.ToString();
            else
                l = Math.Abs(z - 360).ToString();


            if (p.IndexOf(',') > -1)
                p = p.Remove(p.IndexOf(','));
            else if (p.IndexOf('.') > -1)
                p = p.Remove(p.IndexOf('.'));

            if (l.IndexOf(',') > -1)
                l = l.Remove(l.IndexOf(','));
            else if (l.IndexOf('.') > -1)
                l = l.Remove(l.IndexOf('.'));

            if (!blokL)
                txtL.text = l;
            if (!blokP)
                txtP.text = p;
        }
    }
    public void zaznaczenie() { chek = true; }
    public void odznacz() { chek = false; }
    public void blokada()
    {
        if (z > 0 && z < 180)
        {
            if (!blokP)
                blokP = true;
            else
                blokP = false;
        }
        else
        {
            if (!blokL)
                blokL = true;
            else
                blokL = false;
        }


    }
}
