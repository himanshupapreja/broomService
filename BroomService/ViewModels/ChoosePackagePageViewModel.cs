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
    public class ChoosePackagePageViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService NavigationService;
        AddJobDataModel AddJobDataModel = new AddJobDataModel();

        #region SubServiceDescription
        private string _SubServiceDescription;
        public string SubServiceDescription
        {
            get { return _SubServiceDescription; }
            set { SetProperty(ref _SubServiceDescription, value); }
        }
        #endregion

        #region SubServiceName
        private string _SubServiceName;
        public string SubServiceName
        {
            get { return _SubServiceName; }
            set { SetProperty(ref _SubServiceName, value); }
        }
        #endregion

        #region SubSubServiceList
        public ObservableCollection<SubSubCategory> AllSubSubServiceList = new ObservableCollection<SubSubCategory>();
        private ObservableCollection<SubSubCategory> _SubSubServiceList = new ObservableCollection<SubSubCategory>();
        public ObservableCollection<SubSubCategory> SubSubServiceList
        {
            get { return _SubSubServiceList; }
            set { SetProperty(ref _SubSubServiceList, value); }
        }
        #endregion

        #region SelectedSubSubServiceList
        private SubSubCategory _SelectedSubSubServiceList;
        public SubSubCategory SelectedSubSubServiceList
        {
            get { return _SelectedSubSubServiceList; }
            set
            {
                SetProperty(ref _SelectedSubSubServiceList, value);
                if (SelectedSubSubServiceList != null)
                {
                    var item = SubSubServiceList.Where(x => x.SelectedColor == ColorHelpers.BlueColor).FirstOrDefault();
                    if (item != null)
                    {
                        var itemIndex = SubSubServiceList.IndexOf(item);
                        SubSubServiceList[itemIndex].SelectedColor = ColorHelpers.GrayColor;
                    }

                    AddJobDataModel.SelectedService = SelectedSubSubServiceList.display_Name;
                    AddJobDataModel.SelectedServiceDescription = SelectedSubSubServiceList.display_Description;
                    AddJobDataModel.SelectedSubSubServiceId = SelectedSubSubServiceList.Id;

                    var selectedIndex = SubSubServiceList.IndexOf(SelectedSubSubServiceList);
                    SubSubServiceList[selectedIndex].SelectedColor = ColorHelpers.BlueColor;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var param = new NavigationParameters();
                        param.Add("AddJobDataModel", AddJobDataModel);
                        await NavigationService.NavigateAsync(nameof(AddJobRequest),param);
                    });

                }
            }
        }
        #endregion

        #region Constructor
        public ChoosePackagePageViewModel(INavigationService navigationService)
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
            if (parameters.ContainsKey("SubSubServiceData"))
            {
                var data = (List<SubSubCategory>)parameters["SubSubServiceData"];

                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        item.display_Name = item.Name;
                        item.display_Description = item.Description;
                        item.display_Icon = Common.IsImagesValid(item.Icon, ApiUrl.SubSubCategoryImageBaseUrl);
                        item.display_Picture = Common.IsImagesValid(item.Picture, ApiUrl.SubSubCategoryImageBaseUrl);
                        item.SelectedColor = ColorHelpers.GrayColor;
                        AllSubSubServiceList.Add(item);
                    }

                    SubSubServiceList = AllSubSubServiceList;
                }
            }
            if (parameters.ContainsKey("AddJobDataModel"))
            {
                AddJobDataModel = (AddJobDataModel)parameters["AddJobDataModel"];
            }

            SubServiceDescription = AddJobDataModel.DisplaySubServiceDescription;
            SubServiceName = AddJobDataModel.DisplaySubServiceName;
        }
        #endregion
    }
}
