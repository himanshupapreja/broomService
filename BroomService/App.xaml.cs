using Prism;
using Prism.Ioc;
using BroomService.ViewModels;
using BroomService.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BroomService
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/ChatPage");
            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<SignupPage, SignupPageViewModel>();
            containerRegistry.RegisterForNavigation<NotificationPage, NotificationPageViewModel>();
            containerRegistry.RegisterForNavigation<PropertyListPage, PropertyListPageViewModel>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();
            containerRegistry.RegisterForNavigation<PropertyDetailPage, PropertyDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ChooseServicePage, ChooseServicePageViewModel>();
            containerRegistry.RegisterForNavigation<ChooseSubServicePage, ChooseSubServicePageViewModel>();
            containerRegistry.RegisterForNavigation<ChoosePackagePage, ChoosePackagePageViewModel>();
            containerRegistry.RegisterForNavigation<AddCardPage, AddCardPageViewModel>();
            containerRegistry.RegisterForNavigation<AddJobRequest, AddJobRequestViewModel>();
            containerRegistry.RegisterForNavigation<CardListPage, CardListPageViewModel>();
            containerRegistry.RegisterForNavigation<ChatPage, ChatPageViewModel>();
            containerRegistry.RegisterForNavigation<ChatDetailPage, ChatDetailPageViewModel>();
        }
    }
}
