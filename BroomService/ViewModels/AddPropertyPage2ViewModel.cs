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
    public class AddPropertyPage2ViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;

        #region Constructor
        public AddPropertyPage2ViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
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
                    await NavigationService.NavigateAsync(nameof(AddPropertyPage3));
                });
            }
        }
        #endregion
    }
}
