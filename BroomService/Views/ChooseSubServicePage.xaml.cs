using Xamarin.Forms;

namespace BroomService.Views
{
    public partial class ChooseSubServicePage : ContentPage
    {
        public ChooseSubServicePage()
        {
            InitializeComponent();
        }

        private void subserviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            subserviceList.SelectedItem = null;
        }
    }
}
