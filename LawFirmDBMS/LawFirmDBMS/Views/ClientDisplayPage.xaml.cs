using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class ClientDisplayPage : Page
    {
        public ClientDisplayPage()
        {
            this.InitializeComponent();
			InitialClientList = db.GetClients();
			ClientList = db.GetClients();
		}
		SqlDB db = new SqlDB();
		public List<Client> ClientList { get; set; }
		public List<Client> InitialClientList { get; set; }
		public List<Client> EditedClientList { get; set; }
	

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			
			if (LoggedInLawyer.LoggedIn == false)
			{
				InitialClientList = null;
				ClientList = null;
				DisplayNotLoggedInDialog();
				Frame.Navigate(typeof(Views.MainPage));
			}
		}

		private async void DisplayNotLoggedInDialog()
		{
			ContentDialog notLoggedIn = new ContentDialog
			{
				Title = "Not Logged In",
				Content = "Please log in to continue",
				CloseButtonText = "Ok"
			};

			ContentDialogResult result = await notLoggedIn.ShowAsync();
			ViewModel.GotoMainPage();
		}

		private void SaveButtonClick(object sender, RoutedEventArgs e)
		{
			bool edited = clientDataGrid.CommitEdit();
			if (edited && ClientList != InitialClientList)
			{
				EditedClientList = ClientList.Except(InitialClientList).ToList();
				foreach (var item in EditedClientList)
				{
					db.UpdateClients(item);
				}

			}
		}

		private void DeleteButtonClick(object sender, RoutedEventArgs e)
		{
			Client client = (Client)clientDataGrid.SelectedItem;
			db.DeleteFromClient(client.ClientID);
			// Refresh page
		}
	}
}
