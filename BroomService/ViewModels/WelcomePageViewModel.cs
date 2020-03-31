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
    public class WelcomePageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;

        #region MotificationList
        public ObservableCollection<NotificationModel> AllPropertyList = new ObservableCollection<NotificationModel>();
        private ObservableCollection<NotificationModel> _PropertyList = new ObservableCollection<NotificationModel>();
        public ObservableCollection<NotificationModel> PropertyList
        {
            get { return _PropertyList; }
            set { SetProperty(ref _PropertyList, value); }
        }
        #endregion

        #region Constructor
        public WelcomePageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            var propertyItem = new NotificationModel()
            {
                category_service_name = "Luxary Apartment"
            };
            for (int i = 0; i < 5; i++)
            {
                AllPropertyList.Add(propertyItem);
            }

            PropertyList = AllPropertyList;
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

        #region ViewPropertiesList
        public Command ViewPropertiesList
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
    }
}
