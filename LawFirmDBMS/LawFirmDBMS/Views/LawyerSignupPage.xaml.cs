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
    public sealed partial class LawyerEntryPage : Page
    {
        public LawyerEntryPage()
        {
            this.InitializeComponent();
        }
		//TODO: Add verification for telephone numbers.
		//TODO: Add upload profile picture.
		Lawyer lawyer = new Lawyer();

		private void submitButton_Click(object sender, RoutedEventArgs e)
		{
			lawyer.LawyerID = Convert.ToInt32(lawyerID.Text);
			lawyer.Password = password.Password;
			lawyer.FirstName = firstName.Text;
			lawyer.LastName = lastName.Text;
			lawyer.Phone = phoneNumber.ToString();
			lawyer.Designation = designation.SelectedItem.ToString();

			//TODO: Define a method to send this lawyer object to the database.

	}

	public class Lawyer
	{
		public int LawyerID { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Designation { get; set; }

		public string Phone { get; set; }

		public string Password { get; set; }
	}
}
