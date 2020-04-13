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
    public class PropertyListPageViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService NavigationService;

        #region PropertyList
        public ObservableCollection<PropertyModel> AllPropertyList = new ObservableCollection<PropertyModel>();
        private ObservableCollection<PropertyModel> _PropertyList = new ObservableCollection<PropertyModel>();
        public ObservableCollection<PropertyModel> PropertyList
        {
            get { return _PropertyList; }
            set { SetProperty(ref _PropertyList, value); }
        }
        #endregion

        #region SelectedPropertyList
        private PropertyModel _SelectedPropertyList;
        public PropertyModel SelectedPropertyList
        {
            get { return _SelectedPropertyList; }
            set 
            { 
                SetProperty(ref _SelectedPropertyList, value);
                if (SelectedPropertyList != null)
                {
                    var param = new NavigationParameters();
                    param.Add("SelectedPropertyDetail", SelectedPropertyList);
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await NavigationService.NavigateAsync(nameof(PropertyDetailPage),param);
                    });
                }
            }
        }
        #endregion

        #region Constructor
        public PropertyListPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        #endregion

        #region AddPropertyCommand
        public Command AddPropertyCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateAsync(nameof(AddPropertyPage));
                });
            }
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

        #region InavigationAware
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("PropertyList"))
            {
                PropertyList = (ObservableCollection<PropertyModel>)parameters["PropertyList"];
            }
        }
        #endregion
    }
}
