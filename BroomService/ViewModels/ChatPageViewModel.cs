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
    public class ChatPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;
        private bool IsChatDetailOpen;

        #region ChatList
        public ObservableCollection<ChatListModel> AllChatList = new ObservableCollection<ChatListModel>();
        private ObservableCollection<ChatListModel> _ChatList = new ObservableCollection<ChatListModel>();
        public ObservableCollection<ChatListModel> ChatList
        {
            get { return _ChatList; }
            set { SetProperty(ref _ChatList, value); }
        }
        #endregion

        #region ChatListSelected
        private ChatListModel _ChatListSelected;
        public ChatListModel ChatListSelected
        {
            get { return _ChatListSelected; }
            set 
            { 
                SetProperty(ref _ChatListSelected, value); 
                if(ChatListSelected != null)
                {
                    Device.BeginInvokeOnMainThread(async() =>
                    {
                        //if (!IsChatDetailOpen)
                        //{
                        //    IsChatDetailOpen = true;
                        //}
                        await NavigationService.NavigateAsync(nameof(ChatDetailPage));
                    });
                }
            }
        }
        #endregion

        #region Constructor
        public ChatPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            IsChatDetailOpen = false;

            for (int i = 0; i < 2; i++)
            {
                AllChatList.Add(new ChatListModel()
                {
                    user_name = "Emma"
                });
            }

            ChatList = AllChatList;
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
