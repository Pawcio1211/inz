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

    string L = "";
    string R = "";

    public string zL = "";
    public string zR = "";

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
                R = z.ToString();
            else
                L = Math.Abs(z - 360).ToString();


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
    void Save(String L, String R)
    {
        try
        {
            //StreamWriter sw = new StreamWriter("WynikiOZ.txt");
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/WynikiOZ.txt");
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
            //StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/WynikiOY.txt");
            //String pacjent = System.IO.File.ReadAllText("Pacjent.json").ToString();
            String pacjent = System.IO.File.ReadAllText(Application.persistentDataPath + "/Pacjent.json").ToString();

            pacjent = pacjent.Trim('[');
            pacjent = pacjent.Trim(']');

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
        //a = 0;
        float xL = (float)Math.Sin(b * (Math.PI) / 180) * r;
        float yL = (float)Math.Cos(b * (Math.PI) / 180) * r;
        float xR = (float)Math.Sin(a * (Math.PI) / 180) * r;
        float yR = (float)Math.Cos(a * (Math.PI) / 180) * r;

        scorL.localPosition = new Vector3(
            xL,
            yL,
            scorL.localPosition.z);
        //________________________________
        scorR.localPosition = new Vector3(
            xR,
            yR,
            scorR.localPosition.z);

    }

}
