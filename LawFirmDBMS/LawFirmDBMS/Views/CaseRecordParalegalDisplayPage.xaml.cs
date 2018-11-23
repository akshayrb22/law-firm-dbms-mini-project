using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	public sealed partial class CaseRecordParalegalDisplayPage : Page
	{
		public CaseRecordParalegalDisplayPage()
		{
			this.InitializeComponent();

		}
		CaseRecord caseRecord = new CaseRecord();
		Paralegal paralegal = new Paralegal();
		Frame frame = Window.Current.Content as Frame;
		SqlDB db = new SqlDB();
		public ObservableCollection<CaseRecord> caseRecordList { get; set; }

		public ObservableCollection<Paralegal> paralegalList { get; private set; }
		public ObservableCollection<MixedBag> mixedBagList { get; set; }

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			try
			{
				if (e.Parameter.GetType() == typeof(PassingBag))
				{
					PassingBag passingBag = (PassingBag)e.Parameter;
					caseRecord = passingBag.CaseRecord;
					paralegal = passingBag.Paralegal;
				}
			}
			catch (NullReferenceException nre)
			{
				Debug.WriteLine(nre);
				if (e.Parameter is null)
				{
					mixedBagList = db.GetDocDetails();

				}
			}
			
			
		}

		private void SaveButtonClick(object sender, RoutedEventArgs e)
		{
			CaseRecord updatedCaseRecord = new CaseRecord();
			clientDataGrid.CommitEdit();
			//clientDataGrid.

			
			//db.UpdateCaseRecord(updatedCaseRecord);
		}

		private void DeleteButtonClick(object sender, RoutedEventArgs e)
		{

		}
	}
}
