using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppToRecieveMessage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //static string connectionString = "HostName=SajanIOTDemo.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=J01uItCGSGNfQcl7wxVvQOJHJQn7QqlgJ9CmyalBSQQ=";
        //static string iotHubD2cEndpoint = "messages/events";
        //static EventHubClient eventHubClient;

        public MainPage()
        {
            this.InitializeComponent();

            ReadMessage();
        }

        //private async void ReadMessage()
        //{
        //    /* 
        //     1. Read the message from the azure queue which sent by the Dibya from the CRM to the Queue so that i will turn off the device.
             
        //     */
        //   // await AzureIoTHub.ReceiveCloudToDeviceMessageAsync();
        //}
    }
}
