using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Microsoft.Azure.Devices.Client;

//using Microsoft.ServiceBus.Messaging;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FirstAppUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        //static string connectionString = "HostName=SajanIOTDemo.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=J01uItCGSGNfQcl7wxVvQOJHJQn7QqlgJ9CmyalBSQQ=";
        //static string iotHubD2cEndpoint = "messages/events";
       // static EventHubClient eventHubClient;

        //static DeviceClient deviceClient;
        //static string iotHubUri = "SajanIOTDemo.azure-devices.net";
        //static string deviceKey = "wmwK84I8nQJeajjvi2ZMXEDsyKDxTfL50h3PM81lOfc=";

        public MainPage()
        {
            this.InitializeComponent();
            // AzureIoTHub.SendDeviceToCloudMessageAsync();
            // deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey("myFirstDevice", deviceKey));
            sendMessage();

        }

        private void ClickMe_Click(object sender, RoutedEventArgs e)
        {
            this.HelloMessage.Text = "Hello, Windows 10 IoT Core!";


            sendMessage();


           

          // RecieveMessageFromDevice();

            //AzureIoTHub.SendDeviceToCloudMessageAsync();


            // SendDeviceToCloudMessageAsync();



            // SendDeviceToCloudInteractiveMessagesAsync();

            //  SendDeviceToCloudMessagesAsync();

        }

        private static async void sendMessage()
        {
            double avgWindSpeed = 10; // m/s
            Random rand = new Random();

            while (true)
            {
                double currentWindSpeed = avgWindSpeed + rand.NextDouble() * 4 - 2;

                var telemetryDataPoint = new
                {
                    deviceId = "myFirstDevice",
                    windSpeed = currentWindSpeed
                };
                var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                //var message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageString));



                await AzureIoTHub.SendDeviceToCloudMessageAsync(messageString);

                // HelloMessage.Text = String.Format("{0} > Sending message: {1}", DateTime.Now, messageString);
                // Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);

                Task.Delay(1000).Wait();
            }
           // await AzureIoTHub.SendDeviceToCloudMessageAsync();
        }


        private static async void RecieveMessageFromDevice()
        {
            await AzureIoTHub.ReceiveCloudToDeviceMessageAsync();
           // var tasks = new List<Task>();
           // //foreach (string partition in d2cPartitions)
           // //{
           //     tasks.Add(AzureIoTHub.ReceiveCloudToDeviceMessageAsync());
           //// }
           // Task.WaitAll(tasks.ToArray());
            //await AzureIoTHub.ReceiveCloudToDeviceMessageAsync();
        }

        public void DisplayMessage(string str)
        {
            this.HelloMessage.Text = str;
        }

        private void ReadMessage_Click(object sender, RoutedEventArgs e)
        {
            RecieveMessageFromDevice();
        }

        //private static async Task ReceiveMessagesFromDeviceAsync(string partition, CancellationToken ct)
        //{
        //    var eventHubReceiver = eventHubClient.GetDefaultConsumerGroup().CreateReceiver(partition, DateTime.UtcNow);
        //    while (true)
        //    {
        //        if (ct.IsCancellationRequested) break;
        //        EventData eventData = await eventHubReceiver.ReceiveAsync();
        //        if (eventData == null) continue;

        //        string data = Encoding.UTF8.GetString(eventData.GetBytes());
        //        Console.WriteLine("Message received. Partition: {0} Data: '{1}'", partition, data);
        //    }
        //}

        //private static async void SendDeviceToCloudMessagesAsync()
        //{
        //    double avgWindSpeed = 10; // m/s
        //    Random rand = new Random();

        //    while (true)
        //    {
        //        double currentWindSpeed = avgWindSpeed + rand.NextDouble() * 4 - 2;

        //        var telemetryDataPoint = new
        //        {
        //            deviceId = "myFirstDevice",
        //            windSpeed = currentWindSpeed
        //        };
        //        var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
        //        var message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageString));



        //        await deviceClient.SendEventAsync(message);

        //       // HelloMessage.Text = String.Format("{0} > Sending message: {1}", DateTime.Now, messageString);
        //       // Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);

        //        Task.Delay(1000).Wait();
        //    }
        // }
    }
}
