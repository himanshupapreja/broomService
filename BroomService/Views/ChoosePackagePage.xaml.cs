using Xamarin.Forms;

namespace BroomService.Views
{
    public partial class ChoosePackagePage : ContentPage
    {
        public ChoosePackagePage()
        {
            InitializeComponent();
        }

        private void subsubserviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            packageList.SelectedItem = null;
        }
    }
}
