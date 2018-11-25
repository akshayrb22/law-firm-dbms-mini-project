using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
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
using Template10.Services.NavigationService;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LawFirmDBMS.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class LawyerEntryPage : Page
	{
		public string connectionString;
		public LawyerEntryPage()
		{
			this.InitializeComponent();
			Debug.WriteLine("Reached here");
			
		}
		//TODO: Add verification for telephone numbers.
		//TODO: Add upload profile picture.
		Lawyer lawyer = new Lawyer();
		SqlDB db = new SqlDB();
		Frame frame = Window.Current.Content as Frame;


		private void SubmitButtonClick(object sender, RoutedEventArgs e)
		{
			lawyer.Password = password.Password;
			lawyer.FullName = fullName.Text;
			lawyer.Phone = phoneNumber.Text;
			lawyer.Designation = designation.SelectedItem.ToString();
			db.InsertIntoLawyer(lawyer);
			PassingBag passingBag = new PassingBag(lawyer, db);
			try
			{
				Frame.Navigate(typeof(Views.MainPage), passingBag);
				
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Exception thrown is: " + ex.ToString());
				throw;
			}
		}
		
	}
	
}
