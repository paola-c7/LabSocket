using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        TcpClient client = new TcpClient("127.0.0.1", 8080);
        Console.WriteLine("Connesso al server!");

        NetworkStream stream = client.GetStream();

        // Invio messaggio
        string message = "Ciao server!";
        byte[] data = Encoding.UTF8.GetBytes(message);
        stream.Write(data, 0, data.Length);
        Console.WriteLine($"Inviato: {message}");

        // Ricezione risposta
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string reply = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine($"Risposta: {reply}");

        client.Close();
    }
}
