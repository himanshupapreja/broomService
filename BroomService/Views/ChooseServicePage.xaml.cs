using Xamarin.Forms;

namespace BroomService.Views
{
    public partial class ChooseServicePage : ContentPage
    {
        public ChooseServicePage()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {
            }
        }

        private void serviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            serviceList.SelectedItem = null;
        }
    }
}
