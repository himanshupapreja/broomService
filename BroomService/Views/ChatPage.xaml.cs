using Xamarin.Forms;

namespace BroomService.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
        }

        private void chatList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chatList.SelectedItem = null;
        }
    }
}
