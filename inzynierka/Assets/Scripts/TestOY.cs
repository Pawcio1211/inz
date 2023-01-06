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

    public Transform scorLUp;
    public Transform scorLDown;

    public Transform scorRUp;
    public Transform scorRDown;

    float r = 6;

    bool chek = false;
    bool blokL = false;
    bool blokR = false;
    bool zapis = true;

    String L = "0";
    String R = "0";
    public String yL = "0";
    public String yR = "0";
    
    public bool Jump = false;
    public bool Submit = false;
    public bool Cancel = false;
    
    double y;


    private void Start()
    {
        Load();
        SetScor(Convert.ToDouble(yL), Convert.ToDouble(yR));

    }
    void LateUpdate()
    {
        Measurement();
        SaveBestScor();
        Jump = Input.GetButton("Jump");
        Submit = Input.GetButton("Submit");
        Cancel = Input.GetButton("Cancel");
        if (Cancel)
            blokada();

    }

    public void zaznaczenie() { chek = true; }
    public void odznacz() { chek = false; }
    public void blokada()
    {
      
        if (y > 0 && y < 180)
        {
            if (!blokR)
                blokR = true;
            else
            { blokR = false; zapis = true; }
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
                R = y.ToString();
            else
                L = Math.Abs(y - 360).ToString();


            if (R.IndexOf(',') > -1)
                R = R.Remove(R.IndexOf(','));
            else if (R.IndexOf('.') > -1)
                R = R.Remove(R.IndexOf('.'));

            if (L.IndexOf(',') > -1)
                L = L.Remove(L.IndexOf(','));
            else if (L.IndexOf('.') > -1)
                L = L.Remove(L.IndexOf('.'));

            if (!blokL)
                txtL.text = L;
            if (!blokR)
                txtP.text = R;
        }
    }
    void SaveBestScor()
    {
        if (chek && blokR && blokL && zapis)
        {
            Save(txtL.text.ToString(), txtP.text.ToString());
            zapis = false;
        }
    }
    void Load()
    {
        
        try
        {
            /*
            bool t = false;
            bool i = false;

            StreamReader sr = new StreamReader("WynikiOY.txt");
            //StreamReader sr = new StreamReader(Application.persistentDataPath + "/WynikiOY.txt");
            line = sr.ReadLine();

            while (line != null)
            {
                String[] words = line.Split(new[] { " " }, StringSplitOptions.None);

                foreach (String str in words)
                {
                    if (t && !i)
                    { yL = str; i = true; }

                    else if (t && i)
                    { yR = str; i = false; t = false; }

                    if (str == "OY:")
                        t = true;

                }
                line = sr.ReadLine();
            }

            sr.Close();
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
    void Save(String L, String R)
    {
        try
        {
            //tutaj dodać zapis w miejscu na komurcee
            StreamWriter sw = new StreamWriter("WynikiOY.txt");
            //StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/WynikiOY.txt");
            //sw.WriteLine("OY: " + L + " " + R);
            sw.WriteLine("\"yL\":\"" + L + "\",\"yR\":\"" + R + "\"");
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

        scorLUp.position = new Vector3(
            xL,
            scorLUp.position.y,
            zL);

        scorLDown.position = new Vector3(
            xL,
            scorLDown.position.y,
            zL);

        //________________________________
        scorRUp.position = new Vector3(
            xP,
            scorRUp.position.y,
            zP);

        scorRDown.position = new Vector3(
            xP,
            scorRDown.position.y,
            zP);


    }
    
}
