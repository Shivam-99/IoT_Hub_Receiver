using System;
using System.Text;
using Microsoft.Azure.Devices.Client;

namespace IOT_Hub_Receiver
{
    class Program
    {
        static DeviceClient deviceClient;
        static string connectionstring = "HostName=DemoIoTHubApp.azure-devices.net;DeviceId=IotDeviceDemo;SharedAccessKey=f103jW1XArqRi4ZILkQ0/Zx7mqXBxbsmBBU/yopRMaY=";
        static void Main(string[] args)
        {
            deviceClient = DeviceClient.CreateFromConnectionString(connectionstring);
            ReceiveC2dAsync();
            Console.ReadLine();
        }
        private static async void ReceiveC2dAsync()
        {
            Console.WriteLine("Receiving message from Cloud to Device");
            while (true)
            {
                Message recievedmessage = await deviceClient.ReceiveAsync();

                Console.WriteLine("Received message: {0}",
                    Encoding.ASCII.GetString(recievedmessage.GetBytes()));

                await deviceClient.CompleteAsync(recievedmessage);
            }
        }
    }
}