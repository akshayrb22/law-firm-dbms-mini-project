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
			SqlDB db = new SqlDB();
			db.InsertIntoCases(_case);
			PassingBag passingBag = new PassingBag(_case);
			Frame frame = Window.Current.Content as Frame;
			try
			{
				Frame.Navigate(typeof(Views.CaseViewUpdatePage), passingBag);
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
		}
	}
}
