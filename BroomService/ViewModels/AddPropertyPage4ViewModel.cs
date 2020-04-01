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
    public class AddPropertyPage4ViewModel : BaseViewModel
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
        public AddPropertyPage4ViewModel(INavigationService navigationService)
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

        #region NextIconButton
        public Command NextIconButton
        {
            get
            {
                return new Command(async () =>
                {
                    IsPropertyPopupVisible = true;
                    //await NavigationService.NavigateAsync(nameof(AddPropertyPage4));
                });
            }
        }
        #endregion

        #region PropertyCompleteCommand
        public Command PropertyCompleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsPropertyPopupVisible = false;
                    await NavigationService.NavigateAsync(nameof(PropertyListPage));
                });
            }
        }
        #endregion
    }
}
