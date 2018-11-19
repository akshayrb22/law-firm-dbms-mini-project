﻿using System;
using System.Collections.Generic;
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
	public sealed partial class CaseRecordParalegalEntryPage : Page
	{
		public CaseRecordParalegalEntryPage()
		{
			this.InitializeComponent();
		}
		Frame frame = Window.Current.Content as Frame;
		CaseRecord caseRecord = new CaseRecord();
		Paralegal paralegal = new Paralegal();
		SqlDB db = new SqlDB();
		private void SubmitClick(object sender, RoutedEventArgs e)
		{
			caseRecord.CaseID = Convert.ToInt32(case_id.Text);
			caseRecord.DocID = Convert.ToInt32(doc_id.Text);
			caseRecord.PID = Convert.ToInt32(p_id.Text);
			paralegal.Phone = phone.Text;
			paralegal.PID = Convert.ToInt32(p_id.Text);
			paralegal.FullName = name.Text;

			db.InsertIntoCaseRecords(caseRecord);
			db.InsertIntoParalegal(paralegal);
			PassingBag passingBag = new PassingBag(caseRecord, paralegal);
			frame = new Frame();
			frame.Navigate(typeof(Views.CaseRecordParalegalDisplayPage), passingBag);
		}
	}
}
