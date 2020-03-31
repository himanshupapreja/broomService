using BroomService.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace BroomService.ViewModels
{
    public class SignupPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;
        
        #region Constructor
        public SignupPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        #endregion

        #region RegisterCommand
        public Command RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateAsync(nameof(PropertyListPage));
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
                    await NavigationService.GoBackAsync();
                });
            }
        }
        #endregion

        #region CloseCommand
        public Command CloseCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.GoBackAsync();
                });
            }
        }
        #endregion
    }
}
