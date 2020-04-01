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
    public class ChatDetailPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;
        private bool IsChatDetailOpen;

        #region ChatDetailList
        public ObservableCollection<ChatDetailListModel> AllChatDetailList = new ObservableCollection<ChatDetailListModel>();
        private ObservableCollection<ChatDetailListModel> _ChatDetailList = new ObservableCollection<ChatDetailListModel>();
        public ObservableCollection<ChatDetailListModel> ChatDetailList
        {
            get { return _ChatDetailList; }
            set { SetProperty(ref _ChatDetailList, value); }
        }
        #endregion

        #region Constructor
        public ChatDetailPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            IsChatDetailOpen = false;

            var msg1 = new ChatDetailListModel()
            {
                user_msg = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum.",
                is_sender = true
            };
            var msg2 = new ChatDetailListModel()
            {
                user_msg = "Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum.",
                is_sender = false
            };
            for (int i = 0; i < 2; i++)
            {
                AllChatDetailList.Add(msg1);
                AllChatDetailList.Add(msg2);
            }

            ChatDetailList = AllChatDetailList;
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

        #region AddCardCommand
        public Command AddCardCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateAsync(nameof(AddCardPage));
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
    }
}
