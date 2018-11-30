using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	public sealed partial class CaseEntryPage : Page
	{
		public CaseEntryPage()
		{
			this.InitializeComponent();
		}
		SqlDB db = new SqlDB();
		private void ButtonClick(object sender, RoutedEventArgs e)
		{
			Case _case = new Case
			{
				Title = title.Text,
				Status = "Created",
				HoursBilled = 1, 
				ClientID = Convert.ToInt32(client_id.Text), 
				CourtroomNumber = courtroomNumber.Text				
			};
			
			db.InsertIntoCases(_case);
			_case = db.GetCase(_case);
			db.InsertIntoHandles(_case);
			try
			{
				Frame.Navigate(typeof(Views.CaseViewUpdatePage));
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Exception:" + ex.ToString());
				throw;
			}
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			Debug.WriteLine("Entered Case Entry Page.");
			if (LoggedInLawyer.LoggedIn == false)
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
