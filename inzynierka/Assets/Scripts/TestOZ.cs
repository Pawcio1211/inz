using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class TestOZ : MonoBehaviour
{
    public Text txtL;
    public Text txtP;

    public Transform target;

    public Transform scorL;
    public Transform scorR;

    float r = 0.1f;

    bool chek = false;
    bool blokL = false;
    bool blokR = false;
    bool zapis = true;

    String L = "0";
    String P = "0";
    public String zL = "0";
    public String zR = "0";

    double z;
    private void Start()
    {
        Load();
        SetScor(Convert.ToDouble(zL), Convert.ToDouble(zR));
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
        if (z > 0 && z < 180)
        {
            if (!blokR)
                blokR = true;
            else
                blokR = false;
        }
        else
        {
            if (!blokL)
                blokL = true;
            else
                blokL = false;
        }


    }
    void Measurement()
    {
        if (chek)
        {
            z = target.rotation.eulerAngles.z;
            if (z > 0 && z < 180)
                P = z.ToString();
            else
                L = Math.Abs(z - 360).ToString();


            if (P.IndexOf(',') > -1)
                P = P.Remove(P.IndexOf(','));
            else if (P.IndexOf('.') > -1)
                P = P.Remove(P.IndexOf('.'));

            if (L.IndexOf(',') > -1)
                L = L.Remove(L.IndexOf(','));
            else if (L.IndexOf('.') > -1)
                L = L.Remove(L.IndexOf('.'));

            if (!blokL)
                txtL.text = L;
            if (!blokR)
                txtP.text = P;
        }
    }

    void Save(String L, String R)
    {
        try
        {
            //tutaj dodać zapis w miejscu na komurcee
            StreamWriter sw = new StreamWriter("WynikiOZ.txt");
            //StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/WynikiOY.txt");
            //sw.WriteLine("OZ: " + L + " " + R);
            sw.WriteLine("\"zL\":" + L + ",\"zR\":" + R);
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
    void SetScor(double a, double b)
    {
        b = 360 - b;
        //b -= 90.0;
        a = 0;
        float xL = (float)Math.Sin(a * (Math.PI) / 180) * r;
        float yL = (float)Math.Cos(a * (Math.PI) / 180) * r;
        float xP = (float)Math.Sin(b * (Math.PI) / 180) * r;
        float yP = (float)Math.Cos(b * (Math.PI) / 180) * r;

        scorL.localPosition = new Vector3(
            xL,
            yL,
            scorL.localPosition.z);
        //________________________________
        scorR.localPosition = new Vector3(
            xP,
            yP,
            scorR.localPosition.z);



    }
}
