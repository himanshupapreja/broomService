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
    public class ChooseSubServicePageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;

        #region ServiceList
        public ObservableCollection<ServiceModel> AllServiceList = new ObservableCollection<ServiceModel>();
        private ObservableCollection<ServiceModel> _ServiceList = new ObservableCollection<ServiceModel>();
        public ObservableCollection<ServiceModel> ServiceList
        {
            get { return _ServiceList; }
            set { SetProperty(ref _ServiceList, value); }
        }
        #endregion

        #region SelectedServiceList
        private ServiceModel _SelectedServiceList;
        public ServiceModel SelectedServiceList
        {
            get { return _SelectedServiceList; }
            set
            {
                SetProperty(ref _SelectedServiceList, value);
                if (SelectedServiceList != null)
                {
                    //var item = ServiceList.Where(x => x.ServiceShadow == true).FirstOrDefault();

                    //if (item != null)
                    //{
                    //    var itemIndex = ServiceList.IndexOf(item);
                    //    ServiceList[itemIndex].ServiceShadow = false;
                    //    ServiceList[itemIndex].ServiceSelectedColor = ColorHelpers.LightGrayColor;
                    //    var image = ServiceList[itemIndex].service_image.Replace("_select.png", ".png");
                    //    ServiceList[itemIndex].service_image = image;
                    //}

                    //var selectedIndex = ServiceList.IndexOf(SelectedServiceList);
                    //ServiceList[selectedIndex].ServiceShadow = true;
                    //ServiceList[selectedIndex].ServiceSelectedColor = ColorHelpers.WhiteColor;
                    //var selectedimage = ServiceList[selectedIndex].service_image.Replace(".png", "_select.png");
                    //ServiceList[selectedIndex].service_image = selectedimage;


                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await NavigationService.NavigateAsync(nameof(ChoosePackagePage));
                    });
                }
            }
        }
        #endregion

        #region Constructor
        public ChooseSubServicePageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            AllServiceList.Add(new ServiceModel()
            {
                category_service_name = "Cleaning Serices",
                ServiceSelectedColor = ColorHelpers.WhiteColor,
                ServiceShadow = true,
                service_image = "ic_cat_bnb_select.png"
            });
            AllServiceList.Add(new ServiceModel()
            {
                category_service_name = "Cleaning Serices",
                ServiceSelectedColor = ColorHelpers.LightGrayColor,
                ServiceShadow = false,
                service_image = "ic_cat_cleen.png"
            });
            AllServiceList.Add(new ServiceModel()
            {
                category_service_name = "Cleaning Serices",
                ServiceSelectedColor = ColorHelpers.LightGrayColor,
                ServiceShadow = false,
                service_image = "ic_cat_fix.png"
            });
            AllServiceList.Add(new ServiceModel()
            {
                category_service_name = "Cleaning Serices",
                ServiceSelectedColor = ColorHelpers.LightGrayColor,
                ServiceShadow = false,
                service_image = "ic_cat_hosting.png"
            });
            AllServiceList.Add(new ServiceModel()
            {
                category_service_name = "Cleaning Serices",
                ServiceSelectedColor = ColorHelpers.LightGrayColor,
                ServiceShadow = false,
                service_image = "ic_cat_inside.png"
            });

            ServiceList = AllServiceList;
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
    }
}
