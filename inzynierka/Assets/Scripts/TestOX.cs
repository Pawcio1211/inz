﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class TestOX : MonoBehaviour
{
    public Text txtUp;
    public Text txtD;
    public Transform target;
    public Transform scorRUp;
    public Transform scorLUp;
    public Transform scorRD;
    public Transform scorLD;

    float r = 5;

    bool chek = false;
    bool blokUp = false;
    bool blokD = false;
    bool zapis = true;

    string up = "0";
    string down = "0";
    string sUp = "0";
    string sD = "0";
    //string savePath = Application.persistentDataPath + "/WynikiOX.txt";
    string savePath = "WynikiOX.txt"; // do testowania


    double x;

    private void Start()
    {
        Load();
        SetScor(Convert.ToDouble(sUp), Convert.ToDouble(sD));
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
    void Measurement()
    {
        if (chek)
        {

            x = target.rotation.eulerAngles.x;
            if (x > 0 && x < 180)
                down = x.ToString();
            else
                up = Math.Abs(x - 360).ToString();


            if (down.IndexOf(',') > -1)
                down = down.Remove(down.IndexOf(','));
            else if (down.IndexOf('.') > -1)
                down = down.Remove(down.IndexOf('.'));


            if (up.IndexOf(',') > -1)
                up = up.Remove(up.IndexOf(','));
            else if (up.IndexOf('.') > -1)
                up = up.Remove(up.IndexOf('.'));


            if (!blokUp)
                txtUp.text = up;
            //txtUp.text = "Oś X Up: " + up + "°";

            if (!blokD)
                txtD.text = down;
            //txtD.text = "Oś XD: " + down + "°";
        }
    }

    void SaveBestScor()
    {
        if (chek && blokD && blokUp && zapis)
        {
            Save(txtUp.text.ToString(), txtD.text.ToString());
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

<<<<<<< HEAD
            //StreamReader sr = new StreamReader("WynikiOX.txt");
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/WynikiOX.txt");

=======
            StreamReader sr = new StreamReader(savePath);
>>>>>>> 4e6bd5a2d4ee05f7b4a61ac8b75207bc6e4c7736
            line = sr.ReadLine();

            while (line != null)
            {
                String[] words = line.Split(new[] { " " }, StringSplitOptions.None);

                foreach (String str in words)
                {
                    if (t && !i)
                    { sUp = str; i = true; }

                    else if (t && i)
                    { sD = str; i = false; t = false; }

                    if (str == "OX:")
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
    void Save(string Up, string D)
    {
        try
        {
<<<<<<< HEAD
            //StreamWriter sw = new StreamWriter("WynikiOX.txt");
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/WynikiOX.txt");
=======
            StreamWriter sw = new StreamWriter(savePath);
>>>>>>> 4e6bd5a2d4ee05f7b4a61ac8b75207bc6e4c7736
            sw.WriteLine("OX: " + Up + " " + D);
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
        b = 360 - b;
        float yUp = (float)Math.Sin(a * Math.PI / 180) * r;
        float zUp = (float)Math.Cos(a * Math.PI / 180) * r;
        float yD = (float)Math.Sin(b * Math.PI / 180) * r;
        float zD = (float)Math.Cos(b * Math.PI / 180) * r;

        scorRUp.localPosition = new Vector3(
            scorRUp.localPosition.x,
            yUp,
            zUp);
        scorLUp.localPosition = new Vector3(
            scorLUp.localPosition.x,
            yUp,
            zUp);



        scorRD.localPosition = new Vector3(
            scorRD.localPosition.x,
            yD,
            zD);


        scorLD.localPosition = new Vector3(
            scorLD.localPosition.x,
            yD,
            zD);

    }

}
