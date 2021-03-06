﻿using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;



static class AzureIoTHub
{
    //
    // Note: this connection string is specific to the device "myFirstDevice". To configure other devices,
    // see information on iothub-explorer at http://aka.ms/iothubgetstartedVSCS
    //
    const string deviceConnectionString = "HostName=SajanIOTDemo.azure-devices.net;DeviceId=myFirstDevice;SharedAccessKey=wmwK84I8nQJeajjvi2ZMXEDsyKDxTfL50h3PM81lOfc=";

    //
    // To monitor messages sent to device "myFirstDevice" use iothub-explorer as follows:
    //    iothub-explorer HostName=SajanIOTDemo.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=0ZU4nyQxRtE4AUrVvm1EnvSYo4cOPdqtQJglA0CAUWY= monitor-events "myFirstDevice"
    //

    // Refer to http://aka.ms/azure-iot-hub-vs-cs-wiki for more information on Connected Service for Azure IoT Hub

    public static async Task SendDeviceToCloudMessageAsync()
    {
        var deviceClient = DeviceClient.CreateFromConnectionString(deviceConnectionString, TransportType.Amqp);

#if WINDOWS_UWP
        var str = "Hello, Cloud from a UWP C# app!";
#else
        var str = "Hello, Cloud from a C# app!";
#endif
        var message = new Message(Encoding.ASCII.GetBytes(str));

        await deviceClient.SendEventAsync(message);
    }

    public static async Task SendDeviceToCloudMessageAsync(string str)
    {
        var deviceClient = DeviceClient.CreateFromConnectionString(deviceConnectionString, TransportType.Amqp);

//#if WINDOWS_UWP
//       // var str = "Hello, Cloud from a UWP C# app!";
//#else
//     //   var str = "Hello, Cloud from a C# app!";
//#endif
        var message = new Message(Encoding.ASCII.GetBytes(str));

        await deviceClient.SendEventAsync(message);

        // Azure service Push CreateCase -- CRM service call case create kar
        /* 
         
         
         
         */
    }

    public static async Task<string> ReceiveCloudToDeviceMessageAsync()
    {
        var deviceClient = DeviceClient.CreateFromConnectionString(deviceConnectionString, TransportType.Amqp);

        while (true)
        {
            var receivedMessage = await deviceClient.ReceiveAsync();

            if (receivedMessage != null)
            {
                var messageData = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                await deviceClient.CompleteAsync(receivedMessage);
               // FirstAppUniversal.MainPage.
                return messageData;
            }

            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }

   

}
