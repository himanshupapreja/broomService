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
    public class CardListPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;

        #region CardList
        public ObservableCollection<CardModel> AllCardList = new ObservableCollection<CardModel>();
        private ObservableCollection<CardModel> _CardList = new ObservableCollection<CardModel>();
        public ObservableCollection<CardModel> CardList
        {
            get { return _CardList; }
            set { SetProperty(ref _CardList, value); }
        }
        #endregion

        #region Constructor
        public CardListPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            for (int i = 0; i < 2; i++)
            {
                AllCardList.Add(new CardModel()
                {
                    card_number = "**** **** **** 2514"
                });
            }

            CardList = AllCardList;
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
