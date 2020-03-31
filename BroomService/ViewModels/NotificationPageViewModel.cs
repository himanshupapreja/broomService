using BroomService.Models;
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
    public class NotificationPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;

        #region MotificationList
        public ObservableCollection<NotificationModel> AllNotificationList = new ObservableCollection<NotificationModel>();
        private ObservableCollection<NotificationModel> _NotificationList = new ObservableCollection<NotificationModel>();
        public ObservableCollection<NotificationModel> NotificationList
        {
            get { return _NotificationList; }
            set { SetProperty(ref _NotificationList, value); }
        }
        #endregion

        #region Constructor
        public NotificationPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            var notificationItem = new NotificationModel()
            {
                category_service_name = "Cleaning Serices"
            };
            for (int i = 0; i < 5; i++)
            {
                AllNotificationList.Add(notificationItem);
            }

            NotificationList = AllNotificationList;
        }
        #endregion

        #region BackIconCommand
        public Command BackIconCommand
        {
            get
            {
                return new Command(async() =>
                {
                    await NavigationService.GoBackAsync();
                });
            }
        }
        #endregion
    }
}
