using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class SerwerTcp : MonoBehaviour
{
    public static void Serwer(string[] args)
    {
        try
        {

            IPAddress ipAd = IPAddress.Parse("150.254.137.80");

            TcpListener myList = new TcpListener(ipAd, 8001);

            myList.Start();
            Console.WriteLine("Serwer uruchomiony na porcie 8001...");
            Console.WriteLine("The local End point is: " +
                myList.LocalEndpoint);
            Console.WriteLine("Oczekuje na połączenie....");

            Socket s = myList.AcceptSocket();
            Console.WriteLine("Połączenie zaakceptowane " + s.RemoteEndPoint);

            byte[] b = new byte[100];
            int k = s.Receive(b);
            Console.WriteLine("Odebrano...");
            for (int i = 0; i < k; i++)
            {
                Console.Write(Convert.ToChar(b[i]));

            }
            ASCIIEncoding asen = new ASCIIEncoding();
            // tym wysyłamy wiadomość ;)
            s.Send(asen.GetBytes("Ciąg znaków otrzymany z serwera"));
            Console.WriteLine("\nOdebranie potwierdzone");

            s.Close();
            myList.Stop();
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error...." + e.StackTrace);
            Console.ReadKey();
        }
    }
}
