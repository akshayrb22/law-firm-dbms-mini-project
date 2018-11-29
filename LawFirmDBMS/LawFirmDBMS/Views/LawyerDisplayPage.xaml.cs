using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class LawyerDisplayPage : Page
    {
		public Lawyer Lawyer { get; set; }
		//Lawyer lawyer = new Lawyer();
		//SqlDB db = new SqlDB();
		public SqlDB Db { get; set; }
		public LawyerDisplayPage()
        {
            this.InitializeComponent();
			Debug.WriteLine("Reached Lawyer Display page.");
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			if (LoggedInLawyer.LoggedIn)
			{
				Lawyer = LoggedInLawyer.Lawyer;
				MessageDialog message = new MessageDialog("Welcome" + Lawyer.FullName);
			}
			else
			{
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
			Frame.Navigate(typeof(Views.MainPage));
		}
	}
}
