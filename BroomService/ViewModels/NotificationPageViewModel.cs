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
    public class NotificationPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;

        #region NotificationList
        public ObservableCollection<NotificationModel> AllNotificationList = new ObservableCollection<NotificationModel>();
        private ObservableCollection<NotificationModel> _NotificationList = new ObservableCollection<NotificationModel>();
        public ObservableCollection<NotificationModel> NotificationList
        {
            get { return _NotificationList; }
            set { SetProperty(ref _NotificationList, value); }
        }
        #endregion

        #region NotificationListSelected
        private NotificationModel _NotificationListSelected;
        public NotificationModel NotificationListSelected
        {
            get { return _NotificationListSelected; }
            set 
            { 
                SetProperty(ref _NotificationListSelected, value); 
                if(NotificationListSelected != null)
                {
                    NavigationService.NavigateAsync(nameof(ChatPage));
                }
            }
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
