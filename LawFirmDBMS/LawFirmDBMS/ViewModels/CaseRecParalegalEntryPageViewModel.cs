using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace LawFirmDBMS.ViewModels
{
	class CaseRecParalegalEntryPageViewModel : ViewModelBase
	{
		public void GotoDetailsPage() =>
			NavigationService.Navigate(typeof(Views.DetailPage));

		public void GotoSettings() =>
			NavigationService.Navigate(typeof(Views.SettingsPage), 0);

		public void GotoPrivacy() =>
			NavigationService.Navigate(typeof(Views.SettingsPage), 1);

		public void GotoAbout() =>
			NavigationService.Navigate(typeof(Views.SettingsPage), 2);

		public void GotoLawyerViewPage() =>
			NavigationService.Navigate(typeof(Views.LawyerViewPage), 3);

		public void GotoClientEntryPage() =>
			NavigationService.Navigate(typeof(Views.ClientEntryPage), 4);

		public void GotoCaseEntryPage() =>
			NavigationService.Navigate(typeof(Views.CaseEntryPage), 5);
	}
}
