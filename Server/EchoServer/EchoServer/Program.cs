using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 8080);
        server.Start();
        Console.WriteLine("Server in ascolto sulla porta 8080...");

        // Attesa bloccante del client
        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Client connesso!");

        NetworkStream stream = client.GetStream();

        // Lettura dati
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine($"Ricevuto: {msg}");

        // Risposta (Echo)
        byte[] reply = Encoding.UTF8.GetBytes("Echo: " + msg);
        stream.Write(reply, 0, reply.Length);

        client.Close();
        server.Stop();
    }
}
