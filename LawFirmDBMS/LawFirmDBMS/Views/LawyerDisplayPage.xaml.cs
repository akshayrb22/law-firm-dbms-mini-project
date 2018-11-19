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
		public List<Lawyer> Lawyers { get; set; }
		public LawyerViewPage()
        {
            this.InitializeComponent();
			Debug.WriteLine("Reached here as well");
			this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			try
			{
				var v = e.Parameter.GetType() == typeof(PassingBag);
				if (v)
				{
					PassingBag passingBag = (PassingBag)e.Parameter;
					Db = passingBag.Db;
					Lawyer = passingBag.Lawyer;
				}
				else if (LoginPage.loggedIn == true)
				{
					//Lawyer = Db.GetLawyer();
					// TODO: Send the current lawyer data to the memory to access it anytime
				}
			}
			catch (NullReferenceException nre)
			{

				Debug.WriteLine(nre);
				throw;
			}			
			//lawyer = db.GetLawyer(passingBag.lawyer.Password, passingBag.lawyer.Phone);
		}
    }
}
