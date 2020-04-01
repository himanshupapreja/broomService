using Xamarin.Forms;

namespace BroomService.Views
{
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage()
        {
			try
			{
				InitializeComponent();
			}
			catch (System.Exception ex)
			{
			}
        }

		private void notificationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			notificationList.SelectedItem = null;
		}
	}
}
