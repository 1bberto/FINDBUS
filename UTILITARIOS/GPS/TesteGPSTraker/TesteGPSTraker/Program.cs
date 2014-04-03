using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace TesteGPSTraker
{
    class Program
    {
        static string serialBuffer = "";
        static string expectedEcho = null;
        static object expectedEchoLock = new object();
        static void Main(string[] args)
        {
            string porta;
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Portas Disponiveis");
            foreach (string port in ports)
                Console.WriteLine(port);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Digite a Porta de Comunicação: ");
            porta = Console.ReadLine();
            SerialPort _serialPort = new SerialPort(porta, 9600, Parity.Mark, 8, StopBits.One);
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.WriteTimeout = 500;
            _serialPort.Open();
            Console.WriteLine("Para interromper o processo aperte esq");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                if (Console.ReadKey().Key == ConsoleKey.L)
                {
                    Console.Clear();
                    Console.WriteLine("Para interromper o processo aperte esq");
                }
                else
                    _serialPort.WriteLine("a");
            }
            _serialPort.Close();
        }

        private static void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort _serialPort = (SerialPort)sender;
            Console.WriteLine(String.Format("Retorno as {0}", DateTime.Now));
            while (_serialPort.BytesToRead > 0)
            {
                byte[] buffer = new byte[_serialPort.BytesToRead];
                int bytesRead = _serialPort.Read(buffer, 0, buffer.Length);
                if (bytesRead <= 0) return;
                serialBuffer += Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string[] lines = serialBuffer.Split('\r', '\n');
                // Don't process the last part, because it's not terminated yet
                foreach (string responta in lines)
                {
                    if (!string.IsNullOrEmpty(responta))
                        Console.WriteLine(responta);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
