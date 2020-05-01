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
using XF.Material.Forms.UI.Dialogs;

namespace BroomService.ViewModels
{
    public class PropertyDetailPageViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService NavigationService;
        bool isChangeCommandClick = false;
        #region SelectedProperty
        private PropertyModel _SelectedProperty = new PropertyModel();
        public PropertyModel SelectedProperty
        {
            get { return _SelectedProperty; }
            set { SetProperty(ref _SelectedProperty, value); }
        }
        #endregion

        #region PropertyImagesList
        private ObservableCollection<PropertyImage> AllPropertyImagesList = new ObservableCollection<PropertyImage>();
        private ObservableCollection<PropertyImage> _PropertyImagesList = new ObservableCollection<PropertyImage>();
        public ObservableCollection<PropertyImage> PropertyImagesList
        {
            get { return _PropertyImagesList; }
            set { SetProperty(ref _PropertyImagesList, value); }
        }
        #endregion

        #region IsChangePopup
        private bool _IsChangePopup;
        public bool IsChangePopup
        {
            get { return _IsChangePopup; }
            set { SetProperty(ref _IsChangePopup, value); }
        }
        #endregion

        #region IsAccessToProperty
        private bool _IsAccessToProperty;
        public bool IsAccessToProperty
        {
            get { return _IsAccessToProperty; }
            set { SetProperty(ref _IsAccessToProperty, value); }
        }
        #endregion

        #region Doorman
        private string _Doorman;
        public string Doorman
        {
            get { return _Doorman; }
            set { SetProperty(ref _Doorman, value); }
        }
        #endregion

        #region Parking
        private string _Parking;
        public string Parking
        {
            get { return _Parking; }
            set { SetProperty(ref _Parking, value); }
        }
        #endregion

        #region Balcony
        private string _Balcony;
        public string Balcony
        {
            get { return _Balcony; }
            set { SetProperty(ref _Balcony, value); }
        }
        #endregion

        #region Garden
        private string _Garden;
        public string Garden
        {
            get { return _Garden; }
            set { SetProperty(ref _Garden, value); }
        }
        #endregion

        #region Pool
        private string _Pool;
        public string Pool
        {
            get { return _Pool; }
            set { SetProperty(ref _Pool, value); }
        }
        #endregion

        #region Dishwasher
        private string _Dishwasher;
        public string Dishwasher
        {
            get { return _Dishwasher; }
            set { SetProperty(ref _Dishwasher, value); }
        } 
        #endregion

        #region Elevator
        private string _Elevator;
        public string Elevator
        {
            get { return _Elevator; }
            set { SetProperty(ref _Elevator, value); }
        } 
        #endregion

        #region CoffeeMachine
        private string _CoffeeMachine;
        public string CoffeeMachine
        {
            get { return _CoffeeMachine; }
            set { SetProperty(ref _CoffeeMachine, value); }
        } 
        #endregion

        #region AccessToProperty
        private string _AccessToProperty;
        public string AccessToProperty
        {
            get { return _AccessToProperty; }
            set { SetProperty(ref _AccessToProperty, value); }
        } 
        #endregion

        #region BuildingCode
        private string _BuildingCode;
        public string BuildingCode
        {
            get { return _BuildingCode; }
            set { SetProperty(ref _BuildingCode, value); }
        } 
        #endregion

        #region Constructor
        public PropertyDetailPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            isChangeCommandClick = false;
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

        #region ViewPropertiesListCommand
        public Command ViewPropertiesListCommand
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                        if (!isChangeCommandClick)
                        {
                            isChangeCommandClick = true;
                            AccessToProperty = SelectedProperty.AccessToProperty;
                            BuildingCode = SelectedProperty.BuildingCode;
                            IsChangePopup = true;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        isChangeCommandClick = false;
                    }
                });
            }
        }
        #endregion

        #region PropertyCloseCommand
        public Command PropertyCloseCommand
        {
            get
            {
                return new Command(async () =>
                {
                    BuildingCode = string.Empty;
                    AccessToProperty = string.Empty;
                    IsChangePopup = false;
                });
            }
        }
        #endregion

        #region NextIconButton
        public Command NextIconButton
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        UserDialogs.Instance.ShowLoading();
                        BaseModels response;
                        try
                        {
                            response = await webApiRestClient.GetAsync<BaseModels>(string.Format(ApiUrl.EditAccessCodeDetails, SelectedProperty.Id,BuildingCode,AccessToProperty));
                        }
                        catch (Exception ex)
                        {
                            response = null;
                        }
                        if (response != null)
                        {
                            if (response.status)
                            {
                                IsChangePopup = false;
                                await MaterialDialog.Instance.SnackbarAsync(response.message);
                                await NavigationService.NavigateAsync(new Uri("/NavigationPage/WelcomePage", UriKind.Absolute));
                            }
                            else
                            {
                                await MaterialDialog.Instance.SnackbarAsync(response.message);
                            }
                        }
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

        #region EditPropertyCommand
        public Command EditPropertyCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var param = new NavigationParameters();
                    param.Add("PropertyDetail", SelectedProperty);
                    await NavigationService.NavigateAsync(nameof(AddPropertyPage),param);
                });
            }
        }
        #endregion

        #region AddJobCommand
        public Command AddJobCommand
        {
            get
            {
                return new Command(async () =>
                {
                    AddJobDataModel addJobDataModel = new AddJobDataModel()
                    {
                        propertyId = SelectedProperty.Id.Value,
                        propertyName = SelectedProperty.Name,
                        propertyAddress = SelectedProperty.Address,
                        ShortTermApartment = SelectedProperty.ShortTermApartment.HasValue ? SelectedProperty.ShortTermApartment.Value : false
                    };

                    var param = new NavigationParameters();
                    param.Add("AddJobDataModel", addJobDataModel);
                    await NavigationService.NavigateAsync(nameof(ChooseServicePage),param);
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
            if (parameters.ContainsKey("SelectedPropertyDetail"))
            {
                SelectedProperty = (PropertyModel)parameters["SelectedPropertyDetail"];
            }
            IsChangePopup = false;
            IsAccessToProperty = !string.IsNullOrEmpty(SelectedProperty.AccessToProperty) && !string.IsNullOrWhiteSpace(SelectedProperty.AccessToProperty) ? true : false;

            Doorman = SelectedProperty.Doorman.HasValue && SelectedProperty.Doorman.Value ? ImageHelpers.ic_online : ImageHelpers.ic_offline;
            Balcony = SelectedProperty.Balcony.HasValue && SelectedProperty.Balcony.Value ? ImageHelpers.ic_online : ImageHelpers.ic_offline;
            Parking = SelectedProperty.Parking.HasValue && SelectedProperty.Parking.Value ? ImageHelpers.ic_online : ImageHelpers.ic_offline;
            Garden = SelectedProperty.Garden.HasValue && SelectedProperty.Garden.Value ? ImageHelpers.ic_online : ImageHelpers.ic_offline;
            Pool = SelectedProperty.Pool.HasValue && SelectedProperty.Pool.Value ? ImageHelpers.ic_online : ImageHelpers.ic_offline;
            Dishwasher = SelectedProperty.Dishwasher.HasValue && SelectedProperty.Dishwasher.Value ? ImageHelpers.ic_online : ImageHelpers.ic_offline;
            Elevator = SelectedProperty.Elevator.HasValue && SelectedProperty.Elevator.Value ? ImageHelpers.ic_online : ImageHelpers.ic_offline;
            CoffeeMachine = SelectedProperty.CoffeeMachine.HasValue && SelectedProperty.CoffeeMachine.Value ? ImageHelpers.ic_online : ImageHelpers.ic_offline;

            foreach (var item in SelectedProperty.PropertyImages)
            {
                var imageItem = new PropertyImage()
                {
                    CreatedDate = item.CreatedDate,
                    Id = item.Id,
                    ImageUrl = Common.IsImagesValid(item.ImageUrl,ApiUrl.ImageBaseUrl),
                    VideoUrl = Common.IsImagesValid(item.VideoUrl, ApiUrl.ImageBaseUrl),
                    IsImage = item.IsImage.HasValue && item.IsImage.Value ? true : false,
                    IsVideo = item.IsVideo.HasValue && item.IsVideo.Value ? true : false,
                    PropertyId = item.PropertyId,
                    VideoThumbnail = item.VideoThumbnail
                };
                AllPropertyImagesList.Add(imageItem);
            }

            //var imageItem1 = new PropertyImage()
            //{
            //    ImageUrl = "/storage/emulated/0/Android/data/com.companyname.appname/files/Pictures/temp/IMG_20200318_170341_5.jpg",
            //    VideoUrl = string.Empty,
            //    IsImage = true,
            //    IsVideo = false,
            //};

            //var imageItem2 = new PropertyImage()
            //{
            //    ImageUrl = string.Empty,
            //    VideoUrl = "/storage/emulated/0/Android/data/com.companyname.appname/files/Movies/temp/ca6b6adfed25c4e3021dd034707b4bb4~2_5.mp4",
            //    IsImage = false,
            //    IsVideo = true,
            //};

            //var imageItem3 = new PropertyImage()
            //{
            //    ImageUrl = string.Empty,
            //    VideoUrl = "/storage/emulated/0/Android/data/com.companyname.appname/files/Movies/temp/4c64d601ea3016de043725978cab1e2f~2_5.mp4",
            //    IsImage = false,
            //    IsVideo = true,
            //};
            //AllPropertyImagesList.Add(imageItem2);
            //AllPropertyImagesList.Add(imageItem1);
            //AllPropertyImagesList.Add(imageItem3);

            PropertyImagesList = AllPropertyImagesList;
        }
        #endregion
    }
}