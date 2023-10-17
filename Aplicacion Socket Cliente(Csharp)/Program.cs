using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AplicaciondeSocketCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEp = new IPEndPoint(ipAddress, 11200);
            try
            {
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(remoteEp);

                Console.WriteLine("Conectando con el  servidor");
                Console.WriteLine("Ingrese un texto que quiere enviar");
                string texto = Console.ReadLine();

                byte[] msg = Encoding.ASCII.GetBytes(texto + "<EOF>");
                int byteSent = sender.Send(msg);

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.ToString()); }
        }


    }
}