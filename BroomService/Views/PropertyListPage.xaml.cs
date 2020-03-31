using Xamarin.Forms;

namespace BroomService.Views
{
    public partial class PropertyListPage : ContentPage
    {
        public PropertyListPage()
        {
			try
			{
				InitializeComponent();
			}
			catch (System.Exception ex)
			{
			}
        }

		private void propertyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			propertyList.SelectedItem = null;
		}
	}
}
