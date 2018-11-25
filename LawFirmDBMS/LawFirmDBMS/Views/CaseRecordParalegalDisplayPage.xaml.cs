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
		public List<CaseRecord> CaseRecordList { get; set; }
		public List<Paralegal> ParalegalList { get; set; }
		public List<MixedBag> MixedBagList { get; set; }

		public List<CaseRecord> EditedCaseRecords { get; set; }
		public List<Paralegal> EditedParalegals { get; set; }
		public List<MixedBag> EditedMixedBags { get; set; }

		public List<MixedBag> InitialMixedBag { get; set; }
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			MixedBagList = db.GetDocDetails();
			InitialMixedBag = MixedBagList;
		}

		private void SaveButtonClick(object sender, RoutedEventArgs e)
		{
			bool edited = clientDataGrid.CommitEdit();
			if (edited && InitialMixedBag != MixedBagList)
			{
				EditedMixedBags = MixedBagList.Except(InitialMixedBag).ToList();
				foreach (var item in EditedMixedBags)
				{
					db.UpdateParalegals(item.Paralegal);
					db.UpdateCaseRecord(item.CaseRecord);
				}
			}
			this.Refresh();
			
		}


		private void DeleteButtonClick(object sender, RoutedEventArgs e)
		{
			List<MixedBag> indices = (List<MixedBag>)clientDataGrid.SelectedItems;
			foreach (var item in indices)
			{
				db.DeleteFromParalegal(item.PID);
				db.DeleteFromCaseRecord(item.DocID);
			}
		}
	}
}
