using Prism;
using Prism.Ioc;
using BroomService.ViewModels;
using BroomService.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Newtonsoft.Json;
using BroomService.Models;

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
            XF.Material.Forms.Material.Init(this);

            if (SecureStorage.GetAsync("LoginData") != null)
            {
                try
                {
                    var loginData = JsonConvert.DeserializeObject<LoginResponseModel>(SecureStorage.GetAsync("LoginData").Result.ToString());

                    if (loginData.status)
                    {
                        BaseViewModel.userId = loginData.userData.UserId;
                        BaseViewModel.userName = loginData.userData.FullName;
                        await NavigationService.NavigateAsync("NavigationPage/WelcomePage");
                    }
                    else
                    {
                        await NavigationService.NavigateAsync("NavigationPage/LoginPage");
                    }
                }
                catch (System.Exception ex)
                {
                    await NavigationService.NavigateAsync("NavigationPage/LoginPage");
                }
            }
            else
            {
                await NavigationService.NavigateAsync("NavigationPage/LoginPage");
            }
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
            containerRegistry.RegisterForNavigation<AddPropertyPage, AddPropertyPageViewModel>();
            containerRegistry.RegisterForNavigation<AddPropertyPage2, AddPropertyPage2ViewModel>();
            containerRegistry.RegisterForNavigation<AddPropertyPage3, AddPropertyPage3ViewModel>();
            containerRegistry.RegisterForNavigation<AddPropertyPage4, AddPropertyPage4ViewModel>();
            containerRegistry.RegisterForNavigation<ForgotPasswordPage, ForgotPasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<TermConditionPage, TermConditionPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutUsPage, AboutUsPageViewModel>();
            containerRegistry.RegisterForNavigation<PrivacyPolicy, PrivacyPolicyViewModel>();
            containerRegistry.RegisterForNavigation<AddPropertyPage5, AddPropertyPage5ViewModel>();
            containerRegistry.RegisterForNavigation<VideoPlayerPage, VideoPlayerPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingPage, SettingPageViewModel>();
        }
    }
}
