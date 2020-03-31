using Xamarin.Forms;

namespace BroomService.Views
{
    public partial class ChooseSubServicePage : ContentPage
    {
        public ChooseSubServicePage()
        {
            InitializeComponent();
        }

        private void serviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            serviceList.SelectedItem = null;
        }
    }
}
