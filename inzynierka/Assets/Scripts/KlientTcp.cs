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
        public string yL{ get; set; }
        public string yR{ get; set; }
        public string zL{ get; set; }
        public string zR{ get; set; }

    }
    public void KlientTCP()
    {
        try
        {
            TcpClient tcpclnt = new TcpClient();
            Console.WriteLine("Oczekiwanie na połączenie...");
            tcpclnt.Connect("192.168.110.151", 8080);
            Console.WriteLine("Conected");
            Console.Write("Enter the string to be transmited: ");

            //orzesłanie jsona pacjenta obecnego do serwera 
            //String str = Console.ReadLine();
            String str = System.IO.File.ReadAllText(@"C:\Users\pawel\Downloads\zosia_drwalska.json");
            String OX = System.IO.File.ReadAllText("WynikiOX.txt").ToString();
            String OY = System.IO.File.ReadAllText("WynikiOY.txt").ToString();
            String OZ = System.IO.File.ReadAllText("WynikiOZ.txt").ToString();
            str = str.Trim('[', ']');
            Console.WriteLine(str);

            //konwersja stringa na bity
            Stream stm = tcpclnt.GetStream();
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Nadawanie....");
            stm.Write(ba, 0, ba.Length);


            //otrzymanie wiadomości od serwera
            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);
            String zs = "";
            for (int i = 0; i < k; i++)
            {
                zs += Convert.ToChar(bb[i]);
            }

            Console.WriteLine("Otrzymane:" + zs);


            System.IO.File.WriteAllText("Pacjent.json", zs);


            tcpclnt.Close();
            Console.ReadKey();

        }
        catch (Exception e)
        {
            Console.WriteLine("Error....." + e.StackTrace);
            Console.ReadKey();
        }
    }
}
