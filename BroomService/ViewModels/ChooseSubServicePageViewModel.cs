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
    public class ChooseSubServicePageViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService NavigationService;
        AddJobDataModel AddJobDataModel = new AddJobDataModel();

        #region ServiceDescription
        private string _ServiceDescription;
        public string ServiceDescription
        {
            get { return _ServiceDescription; }
            set { SetProperty(ref _ServiceDescription, value); }
        }
        #endregion

        #region ServiceName
        private string _ServiceName;
        public string ServiceName
        {
            get { return _ServiceName; }
            set { SetProperty(ref _ServiceName, value); }
        }
        #endregion

        #region SubServiceList
        public ObservableCollection<SubCategory> AllSubServiceList = new ObservableCollection<SubCategory>();
        private ObservableCollection<SubCategory> _SubServiceList = new ObservableCollection<SubCategory>();
        public ObservableCollection<SubCategory> SubServiceList
        {
            get { return _SubServiceList; }
            set { SetProperty(ref _SubServiceList, value); }
        }
        #endregion

        #region SelectedSubServiceList
        private SubCategory _SelectedSubServiceList;
        public SubCategory SelectedSubServiceList
        {
            get { return _SelectedSubServiceList; }
            set
            {
                SetProperty(ref _SelectedSubServiceList, value);
                if (SelectedSubServiceList != null)
                {
                    var subsubitem = SelectedSubServiceList.SubSubCategories;
                    var item = SubServiceList.Where(x => x.SelectedColor == ColorHelpers.BlueColor).FirstOrDefault();


                    if (item != null)
                    {
                        var itemIndex = SubServiceList.IndexOf(item);
                        SubServiceList[itemIndex].SelectedColor = ColorHelpers.GrayColor;
                    }

                    var selectedIndex = SubServiceList.IndexOf(SelectedSubServiceList);
                    SubServiceList[selectedIndex].SelectedColor = ColorHelpers.BlueColor;

                    AddJobDataModel.DisplaySubServiceName = SelectedSubServiceList.display_Name;
                    AddJobDataModel.DisplaySubServiceDescription = SelectedSubServiceList.display_Description;

                    if (subsubitem != null && subsubitem.Count >0)
                    {
                        Device.BeginInvokeOnMainThread(async() =>
                        {
                            var param = new NavigationParameters();
                            param.Add("SubSubServiceData", subsubitem);
                            param.Add("AddJobDataModel", AddJobDataModel);
                            await NavigationService.NavigateAsync(nameof(ChoosePackagePage), param);
                        });
                    }
                    else
                    {
                        AddJobDataModel.SelectedService = SelectedSubServiceList.display_Name;
                        AddJobDataModel.SelectedServiceDescription = SelectedSubServiceList.display_Description;
                        AddJobDataModel.SelectedServiceId = SelectedSubServiceList.Id;
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            var param = new NavigationParameters();
                            param.Add("SubSubServiceData", subsubitem);
                            param.Add("AddJobDataModel", AddJobDataModel);
                            await NavigationService.NavigateAsync(nameof(AddJobRequest), param);
                        });
                    }
                }
            }
        }
        #endregion

        #region Constructor
        public ChooseSubServicePageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
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

        #region INavigation Aware
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("SubServiceData"))
            {
                var data = (List<SubCategory>)parameters["SubServiceData"];

                if(data != null && data.Count > 0)
                {
                    foreach(var item in data)
                    {
                        item.display_Name = item.Name;
                        item.display_Description = item.Description;
                        item.display_Icon = Common.IsImagesValid(item.Icon, ApiUrl.SubCategoryImageBaseUrl);
                        item.display_Picture = Common.IsImagesValid(item.Picture, ApiUrl.SubCategoryImageBaseUrl);
                        item.SelectedColor = ColorHelpers.GrayColor;
                        AllSubServiceList.Add(item);
                    }

                    SubServiceList = AllSubServiceList;
                }
            }
            if (parameters.ContainsKey("AddJobDataModel"))
            {
                AddJobDataModel = (AddJobDataModel)parameters["AddJobDataModel"];
            }

            ServiceName = AddJobDataModel.DisplayServiceName;
            ServiceDescription = AddJobDataModel.DisplayServiceDescription;
        }
        #endregion
    }
}
