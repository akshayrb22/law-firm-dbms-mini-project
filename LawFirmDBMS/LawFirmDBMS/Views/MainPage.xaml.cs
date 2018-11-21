using System;
using LawFirmDBMS.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Template10.Services.NavigationService;

namespace LawFirmDBMS.Views
{
	public sealed partial class MainPage : Page
	{

		//private NavigationService navServ = this.GetNavigationService();/* = new NavigationService();*/
		public MainPage()
		{
			InitializeComponent();
			NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
			
		}

		private void SignUpButtonClick(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(LawyerEntryPage));
		}

		private void LogInButtonClick(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(LoginPage));
		}
	}
}