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
    public class ChooseServicePageViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService NavigationService;
        AddJobDataModel AddJobDataModel = new AddJobDataModel();

        #region ServiceList
        public ObservableCollection<CategoryData> AllServiceList = new ObservableCollection<CategoryData>();
        private ObservableCollection<CategoryData> _ServiceList = new ObservableCollection<CategoryData>();
        public ObservableCollection<CategoryData> ServiceList
        {
            get { return _ServiceList; }
            set { SetProperty(ref _ServiceList, value); }
        }
        #endregion

        #region SelectedServiceList
        private CategoryData _SelectedServiceList;
        public CategoryData SelectedServiceList
        {
            get { return _SelectedServiceList; }
            set 
            { 
                SetProperty(ref _SelectedServiceList, value); 
                if(SelectedServiceList != null)
                {
                    var subitem = SelectedServiceList.SubCategories;
                    AddJobDataModel.ServiceList = ServiceList;
                    AddJobDataModel.DisplayServiceName = SelectedServiceList.display_Name;
                    AddJobDataModel.DisplayServiceDescription = SelectedServiceList.display_Description;
                    AddJobDataModel.SelectedServiceId = SelectedServiceList.Id;
                    var item = ServiceList.Where(x => x.SelectedColor == ColorHelpers.BlueColor).FirstOrDefault();

                    if (item != null)
                    {
                        var itemIndex = ServiceList.IndexOf(item);
                        ServiceList[itemIndex].SelectedColor = ColorHelpers.GrayColor;
                    }

                    var selectedIndex = ServiceList.IndexOf(SelectedServiceList);
                    ServiceList[selectedIndex].SelectedColor = ColorHelpers.BlueColor;

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var param = new NavigationParameters();
                        param.Add("SubServiceData", subitem);
                        param.Add("AddJobDataModel", AddJobDataModel);
                        await NavigationService.NavigateAsync(nameof(ChooseSubServicePage),param);
                    });
                }
            }
        }
        #endregion

        #region Constructor
        public ChooseServicePageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            Device.BeginInvokeOnMainThread(() =>
            {
                GetServicesList();
            });
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
                catch (Exception ex)
                {
                    response = null;
                }
                if (response != null)
                {
                    if (response.status)
                    {
                        foreach (var item in response.categoryData)
                        {
                            item.display_Description = item.Description;
                            item.display_Name = item.Name;
                            item.display_Icon = Common.IsImagesValid(item.Icon, ApiUrl.CategoryImageBaseUrl);
                            item.display_Picture = Common.IsImagesValid(item.Picture, ApiUrl.CategoryImageBaseUrl);
                            item.SelectedColor = ColorHelpers.GrayColor;
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
            if (parameters.ContainsKey("AddJobDataModel"))
            {
                AddJobDataModel = (AddJobDataModel)parameters["AddJobDataModel"];
            }
        }
        #endregion
    }
}
