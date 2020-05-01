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

        #region ServiceList
        public ObservableCollection<CategoryData> AllServiceList = new ObservableCollection<CategoryData>();
        private ObservableCollection<CategoryData> _ServiceList = new ObservableCollection<CategoryData>();
        public ObservableCollection<CategoryData> ServiceList
        {
            get { return _ServiceList; }
            set { SetProperty(ref _ServiceList, value); }
        }
        #endregion

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

            Device.BeginInvokeOnMainThread(() =>
            {
                GetServicesList();
            });
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
                            item.PropertyModel.PropertyImages = item.PropertyImages;
                            item.PropertyModel.property_Image_display = "image1.png";
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

        #region GetServicesList
        private async void GetServicesList()
        {
            try
            {
                CategoryResponseModel response;
                try
                {
                    response = await webApiRestClient.GetAsync<CategoryResponseModel>(ApiUrl.GetCategories);
                }
                catch(Exception ex)
                {
                    response = null;
                }
                if(response != null)
                {
                    if (response.status)
                    {
                        foreach(var item in response.categoryData)
                        {
                            item.display_Description = item.Description;
                            item.display_Name = item.Name;
                            item.display_Icon = Common.IsImagesValid(item.Icon, ApiUrl.CategoryImageBaseUrl);
                            item.display_Picture = Common.IsImagesValid(item.Picture, ApiUrl.CategoryImageBaseUrl);
                            AllServiceList.Add(item);
                        }

                        ServiceList = AllServiceList;
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

        #region PropertyDetailCommand
        public Command PropertyDetailCommand
        {
            get
            {
                return new Command((e) =>
                {
                    var item = (PropertyModel)e;
                    var param = new NavigationParameters();
                    param.Add("SelectedPropertyDetail", item);
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await NavigationService.NavigateAsync(nameof(PropertyDetailPage), param);
                    });
                });
            }
        }
        #endregion

        #region SettingCommand
        public Command SettingCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateAsync(nameof(SettingPage));
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
