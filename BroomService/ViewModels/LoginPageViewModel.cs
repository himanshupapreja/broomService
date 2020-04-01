using BroomService.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace BroomService.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;
        
        #region Constructor
        public LoginPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        } 
        #endregion

        #region SignupCommand
        public Command SignupCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateAsync(nameof(SignupPage));
                });
            }
        } 
        #endregion

        #region LoginCommand
        public Command LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateAsync(nameof(WelcomePage));
                });
            }
        } 
        #endregion
    }
}
