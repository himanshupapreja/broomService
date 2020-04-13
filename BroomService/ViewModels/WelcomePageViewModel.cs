using Acr.UserDialogs;
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
    public class WelcomePageViewModel : BaseViewModel
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

        #region Constructor
        public WelcomePageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            GetPropertyList();
        }
        #endregion

        #region GetPropertyList
        private async void GetPropertyList()
        {
            try
            {
                PropertyListResponseModel response;
                try
                {
                    response = await webApiRestClient.GetAsync<PropertyListResponseModel>(string.Format(ApiUrl.GetPropertiesByUserId, userId));
                }
                catch(Exception ex)
                {
                    response = null;
                }
                if(response != null)
                {
                    if (response.status)
                    {
                        foreach(var item in response.data)
                        {
                            AllPropertyList.Add(item.PropertyModel);
                        }

                        PropertyList = AllPropertyList;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {

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

        #region ViewPropertiesList
        public Command ViewPropertiesList
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        UserDialogs.Instance.ShowLoading();
                        var param = new NavigationParameters();
                        param.Add("PropertyList", PropertyList);
                        await NavigationService.NavigateAsync(nameof(PropertyListPage), param);
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        UserDialogs.Instance.HideLoading();
                    }
                });
            }
        }
        #endregion
    }
}
