using BroomService.ViewModels;
using System;
using Xamarin.Forms;

namespace BroomService.Views
{
    public partial class AddJobRequest : ContentPage
    {
		public static DatePicker startDatePicker;
		public static TimePicker endTimePicker;

		DateTime selectedDateTime;
		AddJobRequestViewModel AddJobRequestViewModel;
		public AddJobRequest()
        {
			try
			{
				InitializeComponent();
			}
			catch (System.Exception ex)
			{
			}
			AddJobRequestViewModel = this.BindingContext as AddJobRequestViewModel;
			startDatePicker = startDate_picker;
			endTimePicker = endTime_picker;
        }

		private void startDate_picker_Unfocused(object sender, FocusEventArgs e)
		{
			selectedDateTime = ((DatePicker)sender).Date;
			AddJobRequestViewModel.StartDate = ((DatePicker)sender).Date.ToString("dd/MM/yyyy");
		}

		private void endTime_picker_Unfocused(object sender, FocusEventArgs e)
		{
			selectedDateTime = selectedDateTime.Add(((TimePicker)sender).Time);
			AddJobRequestViewModel.EndTime = selectedDateTime.ToString("hh:mm tt");
		}
	}
}
