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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LawFirmDBMS.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClientEntryPage : Page
    {
        public ClientEntryPage()
        {
            this.InitializeComponent();
        }
		Client client = new Client();
		SqlDB db = new SqlDB();
		private void SubmitClick(object sender, RoutedEventArgs e)
		{
			client.ClientID = Convert.ToInt32(clientID.Text);
			client.FullName = clientName.Text;
			client.Phone = clientPhone.Text;
			db.InsertIntoClient(client);

		}
		// TODO: Add check for phone number validation
		// TODO: Add an upload picture bitton to take in a picture of the client 
	}
	
}
