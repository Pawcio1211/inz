using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
public class KlientTcp : MonoBehaviour
{
    class Pacjent
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string xUp { get; set; }
        public string xD { get; set; }
        public string yL { get; set; }
        public string yR { get; set; }
        public string zL { get; set; }
        public string zR { get; set; }

    }
    public void KlientTCP()
    {
        try
        {
            Console.WriteLine("Oczekiwanie na połączenie...");
            TcpClient tcpclnt = new TcpClient();
            tcpclnt.Connect("192.168.245.151", 8080);
            //tcpclnt.Connect("150.254.137.80", 8000);
            Console.WriteLine("Conected");
            Console.Write("Enter the string to be transmited: ");

            //orzesłanie jsona pacjenta obecnego do serwera 
            //String str = Console.ReadLine();
            String str = "";
            if (File.Exists(Application.persistentDataPath + @"\pacjent.json")
                )
            {
                str = System.IO.File.ReadAllText(Application.persistentDataPath + @"\pacjent.json");
                String OX = System.IO.File.ReadAllText(Application.persistentDataPath + @"\WynikiOX.txt");
                String OY = System.IO.File.ReadAllText(Application.persistentDataPath + @"\WynikiOY.txt");
                String OZ = System.IO.File.ReadAllText(Application.persistentDataPath + @"\WynikiOZ.txt");
                OX = OX.Remove(OX.Length - 3, 3);
                OY = OY.Remove(OY.Length - 3, 3);
                OZ = OZ.Remove(OZ.Length - 2, 2);
                char[] MyChar = { '[', ']', '\n' };
                str = str.TrimStart(MyChar);
                string[] podzielone = str.Split(',');
                str = podzielone[0] + "," + podzielone[1] + "," + OX + "," + OY + "," + OZ + "}";
                str = str.TrimStart(MyChar);
            }
            else {
                str = "{\"imie\":\"Nikt\"," +
                    "\"nazwisko\":\"Nikt\"," +
                    "\"xUp\":\"0\",\"xD\":\"0\"," +
                    "\"yL\":\"0\",\"yR\":\"0\"," +
                    "\"zL\":\"0\",\"zR\":\"0\"}";
            }

            Console.WriteLine("wysyłam");
            Console.WriteLine(str);
            //konwersja stringa na bity
            Stream stm = tcpclnt.GetStream();
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            stm.Write(ba, 0, ba.Length);
            Console.WriteLine("Nadawanie....");
            Console.WriteLine(ba.Length);
            //otrzymanie wiadomości od serwera
            byte[] bb = new byte[120];
            int k = stm.Read(bb, 0, 120);
            String zs = "";
            for (int i = 0; i < k; i++)
            {
                zs += Convert.ToChar(bb[i]);
            }

            System.IO.File.WriteAllText(Application.persistentDataPath + @"\pacjent.json", zs);
            tcpclnt.Close();
            Console.ReadKey();
            Console.WriteLine("Otrzymane:" + zs);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error....." + e.StackTrace);

        }
    }
}
