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

namespace BroomService.ViewModels
{
    public class PropertyDetailPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;

        #region IsPropertyPopupVisible
        private bool _IsPropertyPopupVisible;
        public bool IsPropertyPopupVisible
        {
            get { return _IsPropertyPopupVisible; }
            set { SetProperty(ref _IsPropertyPopupVisible, value); }
        }
        #endregion

        #region Constructor
        public PropertyDetailPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            IsPropertyPopupVisible = false;
        }
        #endregion

        #region BackIconCommand
        public Command BackIconCommand
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

        #region ViewPropertiesListCommand
        public Command ViewPropertiesListCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsPropertyPopupVisible = true;
                });
            }
        }
        #endregion

        #region PropertyCloseCommand
        public Command PropertyCloseCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsPropertyPopupVisible = false;
                });
            }
        }
        #endregion

        #region NextIconButton
        public Command NextIconButton
        {
            get
            {
                return new Command(async () =>
                {
                    IsPropertyPopupVisible = false;
                    await NavigationService.GoBackAsync();
                });
            }
        }
        #endregion

        #region AddJobCommand
        public Command AddJobCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateAsync(nameof(ChooseServicePage));
                });
            }
        }
        #endregion
    }
}
