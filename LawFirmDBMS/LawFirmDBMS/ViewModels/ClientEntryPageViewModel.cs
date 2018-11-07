using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace LawFirmDBMS.ViewModels
{
	class ClientEntryPageViewModel : ViewModelBase
	{
		public void GotoDetailsPage() =>
			NavigationService.Navigate(typeof(Views.DetailPage), Value);

		public void GotoSettings() =>
			NavigationService.Navigate(typeof(Views.SettingsPage), 0);

		public void GotoPrivacy() =>
			NavigationService.Navigate(typeof(Views.SettingsPage), 1);

		public void GotoAbout() =>
			NavigationService.Navigate(typeof(Views.SettingsPage), 2);

		public void GotoLawyerViewPage() =>
			NavigationService.Navigate(typeof(Views.LawyerViewPage));
	}
}
