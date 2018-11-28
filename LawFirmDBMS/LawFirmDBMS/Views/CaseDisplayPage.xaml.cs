using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class CaseViewUpdatePage : Page
    {
        public CaseViewUpdatePage()
        {
            this.InitializeComponent();
			CaseList = db.GetCases();
			InitialCaseList = db.GetCases();
        }
		public List<Case> CaseList { get; set; }
		public List<Case> InitialCaseList { get; set; }
		public List<Case> EditedCaseList { get; set; }
		SqlDB db = new SqlDB();
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			
		}

		private void SaveButtonClick(object sender, RoutedEventArgs e)
		{
			bool edited = caseDataGrid.CommitEdit();
			if (edited && CaseList != InitialCaseList)
			{
				EditedCaseList = CaseList.Except(InitialCaseList).ToList();
				foreach (var item in EditedCaseList)
				{
					db.UpdateCases(item);
				}
			}
		}
		private void DeleteButtonClick(object sender, RoutedEventArgs e)
		{
			Case _case = (Case)caseDataGrid.SelectedItem;
			db.DeleteFromCases(_case.CaseID);
			
			// TODO: Refresh page here.
		}
	}
}
