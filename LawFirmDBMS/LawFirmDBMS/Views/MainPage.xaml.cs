using System;
using LawFirmDBMS.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace LawFirmDBMS.Views
{
	public sealed partial class MainPage : Page
	{
		Frame frame = Window.Current.Content as Frame;
		
		public MainPage()
		{
			InitializeComponent();
			NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
			
		}

		private void CaseEntryLinkClick(object sender, RoutedEventArgs e)
		{
			frame = new Frame();
			frame.Navigate(typeof(CaseEntryPage));
		}

		private void ClientEntryLinkClick(object sender, RoutedEventArgs e)
		{
			frame = new Frame();
			frame.Navigate(typeof(ClientEntryPage));
		}

		private void LawyerUpdateLinkClick(object sender, RoutedEventArgs e)
		{
			frame = new Frame();
			frame.Navigate(typeof(LawyerViewPage), 1);
		}

		private void ClientUpdateClick(object sender, RoutedEventArgs e)
		{
			frame = new Frame();
			frame.Navigate(typeof(ClientUpdatePage));
		}

		private void CaseUpdateLinkClick(object sender, RoutedEventArgs e)
		{
			frame = new Frame();
			frame.Navigate(typeof(CaseUpdatePage));
		}
	}
}