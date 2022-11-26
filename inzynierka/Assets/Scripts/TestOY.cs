using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;


public class TestOY : MonoBehaviour
{
    public Text txtL;
    public Text txtP;
    public Transform target;
    public Transform scorL;
    public Transform scorP;

    float r = 5;

    bool chek = false;
    bool blokL = false;
    bool blokP = false;
    bool zapis = true;

    string l = "0";
    string p = "0";
    string sl = "0";
    string sp = "0";

    double y;


    private void Start()
    {
        Load();
        SetScor(Convert.ToDouble(sl), Convert.ToDouble(sp));

    }
    void LateUpdate()
    {
        Measurement();
        SaveBestScor();

    }

    public void zaznaczenie() { chek = true; }
    public void odznacz() { chek = false; }
    public void blokada()
    {
        if (y > 0 && y < 180)
        {
            if (!blokP)
                blokP = true;
            else
            { blokP = false; zapis = true; }
        }
        else
        {
            if (!blokL)
                blokL = true;
            else
            { blokL = false; zapis = true; }
        }


    }
    void Measurement()
    {
        if (chek)
        {
            y = target.rotation.eulerAngles.y;
            if (y > 0 && y < 180)
                p = y.ToString();
            else
                l = Math.Abs(y - 360).ToString();


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
    void SaveBestScor()
    {
        if (chek && blokP && blokL && zapis)
        {
            Save(txtL.text.ToString(), txtP.text.ToString());
            zapis = false;
        }
    }
    void Load()
    {
        string line;
        try
        {
            bool t = false;
            bool i = false;

            StreamReader sr = new StreamReader("WynikiOY.txt");
            line = sr.ReadLine();

            while (line != null)
            {
                String[] words = line.Split(new[] { " " }, StringSplitOptions.None);

                foreach (String str in words)
                {
                    if (t && !i)
                    { sl = str; i = true; }

                    else if (t && i)
                    { sp = str; i = false; t = false; }

                    if (str == "OY:")
                        t = true;

                }
                line = sr.ReadLine();
            }

            sr.Close();
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }
    void Save(string L, string R)
    {
        try
        {
            StreamWriter sw = new StreamWriter("WynikiOY.txt");
            sw.WriteLine("OY: " + L + " " + R);
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }
    void SetScor(double a, double b)
    {
        a = 360 - a - 90.0;
        b -= 90.0;
        float xL = (float)Math.Cos(-a * (Math.PI) / 180) * r;
        float zL = (float)Math.Sin(-a * (Math.PI) / 180) * r;
        float xP = (float)Math.Cos(-b * (Math.PI) / 180) * r;
        float zP = (float)Math.Sin(-b * (Math.PI) / 180) * r;

        scorL.position = new Vector3(
            xL,
            scorL.position.y,
            zL);

        scorP.position = new Vector3(
            xP,
            scorP.position.y,
            zP);


    }

}
