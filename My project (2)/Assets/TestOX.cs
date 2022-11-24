using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TestOX : MonoBehaviour
{
    public Text txtUp;
    public Text txtD;
    public Transform target;
    
    bool chek = false;
    bool blokUp = false;
    bool blokD = false;

    string up = "";
    string down = "";

    double x;
    
    void LateUpdate()
    {
        
        if (chek)
        {
            
            x = target.rotation.eulerAngles.x;
            if (x > 0 && x < 180)
                down = x.ToString();
            else
                up = Math.Abs(x-360).ToString();
            
            
            if(down.IndexOf(',')>-1)
                down = down.Remove(down.IndexOf(','));
            else if (down.IndexOf('.') > -1)
                down = down.Remove(down.IndexOf('.'));


            if (up.IndexOf(',') > -1)
                up = up.Remove(up.IndexOf(','));
            else if (up.IndexOf('.') > -1)
                up = up.Remove(up.IndexOf('.'));


            if (!blokUp)
                txtUp.text = "Oś X Up: " + up + "°";
                  
            if (!blokD)
                txtD.text = "Oś XD: "+ down + "°";
        }
    }
    public void zaznaczenie() { chek = true; }
    public void odznacz() {chek = false; }
    public void blokada() {
        if (x > 0 && x < 180)
        {
            if (!blokD)
                blokD = true;
            else
                blokD = false;
        }
        else
        {
            if (!blokUp)
                blokUp = true;
            else
                blokUp = false;
        }

           
    }
}
