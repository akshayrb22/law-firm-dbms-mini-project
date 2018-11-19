using System;
using System.Collections.Generic;
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
using LawFirmDBMS.Views;
using LawFirmDBMS.ViewModels;
using Template10.Services.NavigationService; 
using Template10.Common;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LawFirmDBMS.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class LoginPage : Page
	{
		public LoginPage()
		{
			this.InitializeComponent();
			NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
			
		}
		string passwordEntered;
		string phoneEntered;
		public static bool loggedIn;
		Lawyer lawyer = new Lawyer();
		SqlDB db = new SqlDB();


		private void SubmitButtonClick(object sender, RoutedEventArgs e)
		{
			passwordEntered = password.Password;
			phoneEntered = phone.Text;
			loggedIn = true;
			Lawyer lawyer = db.GetLawyer(passwordEntered, phoneEntered);
			if (lawyer.Phone == "")
			{
				MessageDialog message = new MessageDialog("Invalid Phone Number or Password.");
			}
			else
			{
				PassingBag passingBag = new PassingBag(lawyer, db);
				GotoLawyerViewPage(passingBag);
			}

		}
		public void GotoLawyerViewPage(PassingBag passingBag)
		{
			this.Frame.Navigate(typeof(Views.LawyerViewPage), passingBag);
		}
	}
	public class PassingBag
	{
		public Lawyer Lawyer { get; set; }
		public SqlDB Db { get; set; }
		public Client Client { get; set; }
		public Case _case { get; set; }
		public PassingBag(Lawyer lawyer, SqlDB db)
		{
			this.Lawyer = lawyer;
			this.Db = db;
		}
		public PassingBag(Client client)
		{
			this.Client = client;
		}
		public PassingBag(Case _case)
		{
			this._case = _case;
		}

	}
}
