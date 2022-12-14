using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;




public class TestOX : MonoBehaviour
{
    public Text txtUp;
    public Text txtD;

    public Transform target;

    public Transform scorUpR;
    public Transform scorUpL;

    public Transform scorDR;
    public Transform scorDL;

    float r = 6;

    bool chek = false;
    bool blokUp = false;
    bool blokD = false;
    bool zapis = true;

    String up = "0";
    String down = "0";
    public String xUp = "0";
    public String xD = "0";
    

    double x;

    private void Start()
    {
        Load();
        SetScor(Convert.ToDouble(xUp), Convert.ToDouble(xD));
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
        {/*
            bool t = false;
            bool i = false;

            StreamReader sr = new StreamReader("WynikiOX.txt");
            line = sr.ReadLine();

            while (line != null)
            {
                line.Trim('\"',' ',':');
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
          */
            String pacjent = System.IO.File.ReadAllText("Pacjent.json");
            pacjent = pacjent.Trim('[', ']');
            JsonUtility.FromJsonOverwrite(pacjent, this);

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
            StreamWriter sw = new StreamWriter("WynikiOX.txt");
            sw.WriteLine("\"xUp\":\"" + Up + "\",\"xD\":\"" + D+"\"");
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

        scorUpR.localPosition = new Vector3(
            scorUpR.localPosition.x,
            yUp,
            zUp);

        scorUpL.localPosition = new Vector3(
            scorUpL.localPosition.x,
            yUp,
            zUp);

        scorDR.localPosition = new Vector3(
            scorUpR.localPosition.x,
            yD,
            zD);

        scorDL.localPosition = new Vector3(
            scorUpL.localPosition.x,
            yD,
            zD);

    }

}
