using BroomService.Helpers;
using BroomService.Models;
using BroomService.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XF.Material.Forms.Dialogs;
using XF.Material.Forms.UI.Dialogs;

namespace BroomService.ViewModels
{
    public class SettingPageViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService NavigationService;

        #region Constructor
        public SettingPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        #endregion

        #region SettingCommand
        public Command SettingCommand
        {
            get
            {
                return new Command(async(e) =>
                {
                    switch (e.ToString())
                    {
                        case "aboutus":
                            await NavigationService.NavigateAsync(nameof(AboutUsPage));
                            break;
                        case "terms":
                            await NavigationService.NavigateAsync(nameof(TermConditionPage));
                            break;
                        case "privacypolicy":
                            await NavigationService.NavigateAsync(nameof(PrivacyPolicy));
                            break;
                        case "contactus":
                            await NavigationService.NavigateAsync(nameof(NotificationPage));
                            break;
                    }
                });
            }
        }
        #endregion

        #region RightIconCommand
        public Command RightIconCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateAsync(nameof(NotificationPage));
                });
            }
        }
        #endregion

        #region INavigation Aware
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("AddJobDataModel"))
            {
                //AddJobDataModel = (AddJobDataModel)parameters["AddJobDataModel"];
            }

        }
        #endregion
    }
}
