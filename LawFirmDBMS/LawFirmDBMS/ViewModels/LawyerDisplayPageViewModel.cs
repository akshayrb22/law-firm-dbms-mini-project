using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace LawFirmDBMS.ViewModels
{
	class LawyerDisplayPageViewModel : ViewModelBase
	{
		public void GotoDetailsPage() =>
			NavigationService.Navigate(typeof(Views.DetailPage));

		public void GotoSettings() =>
			NavigationService.Navigate(typeof(Views.SettingsPage));

		public void GotoPrivacy() =>
			NavigationService.Navigate(typeof(Views.SettingsPage));

		public void GotoAbout() =>
			NavigationService.Navigate(typeof(Views.SettingsPage));

		public void GotoLawyerViewPage() =>
			NavigationService.Navigate(typeof(Views.LawyerDisplayPage));

		public void GotoClientEntryPage() =>
			NavigationService.Navigate(typeof(Views.ClientEntryPage));

		public void GotoCaseEntryPage() =>
			NavigationService.Navigate(typeof(Views.CaseEntryPage));

		public void GotoMainPage() =>
			NavigationService.Navigate(typeof(Views.MainPage));
	}
}
