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
    public sealed partial class LawyerViewPage : Page
    {
		public Lawyer Lawyer { get; set; }
		//Lawyer lawyer = new Lawyer();
		//SqlDB db = new SqlDB();
		public SqlDB Db { get; set; }
		public LawyerViewPage()
        {
            this.InitializeComponent();
			Debug.WriteLine("Reached Lawyer Display page.");
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			// Unless we get a PassingBag object with a Lawyer and loggedIn variable, don't allow to enter.
			try
			{
				PassingBag passingBag = (PassingBag)e.Parameter;
				if (passingBag.LoggedIn)
				{
					Lawyer = passingBag.Lawyer;
				}
			}
			catch (NullReferenceException nre)
			{

				Debug.WriteLine(nre);
				throw;
			}
			catch (Exception ex)			
			{
				Debug.WriteLine(ex);
			}
			//lawyer = db.GetLawyer(passingBag.lawyer.Password, passingBag.lawyer.Phone);
		}
    }
}
