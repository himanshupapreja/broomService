using Acr.UserDialogs;
using BroomService.Helpers;
using BroomService.Models;
using BroomService.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using XF.Material.Forms.Dialogs;
using XF.Material.Forms.UI.Dialogs;

namespace BroomService.ViewModels
{
    public class AddJobRequestViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService NavigationService;
        AddJobDataModel AddJobDataModel = new AddJobDataModel();

        #region InventoryList
        private ObservableCollection<InventoryDataModel> AllInventoryList = new ObservableCollection<InventoryDataModel>();
        private ObservableCollection<InventoryDataModel> _InventoryList = new ObservableCollection<InventoryDataModel>();
        public ObservableCollection<InventoryDataModel> InventoryList
        {
            get { return _InventoryList; }
            set { SetProperty(ref _InventoryList, value); }
        }
        #endregion

        /// <summary>
        /// IsVisible
        /// </summary>

        #region IsPackageListVisible
        private bool _IsPackageListVisible = false;
        public bool IsPackageListVisible
        {
            get { return _IsPackageListVisible; }
            set { SetProperty(ref _IsPackageListVisible, value); }
        }
        #endregion

        #region IsAnotherServicePopup
        private bool _IsAnotherServicePopup = false;
        public bool IsAnotherServicePopup
        {
            get { return _IsAnotherServicePopup; }
            set { SetProperty(ref _IsAnotherServicePopup, value); }
        }
        #endregion

        #region IsSubserviceAvailable
        private bool _IsSubserviceAvailable;
        public bool IsSubserviceAvailable
        {
            get { return _IsSubserviceAvailable; }
            set { SetProperty(ref _IsSubserviceAvailable, value); }
        }
        #endregion

        #region IsPackageAvailable
        private bool _IsPackageAvailable;
        public bool IsPackageAvailable
        {
            get { return _IsPackageAvailable; }
            set { SetProperty(ref _IsPackageAvailable, value); }
        }
        #endregion

        #region IsDescription
        private bool _IsDescription;
        public bool IsDescription
        {
            get { return _IsDescription; }
            set { SetProperty(ref _IsDescription, value); }
        }
        #endregion

        #region IsAnotherService
        private bool _IsAnotherService;
        public bool IsAnotherService
        {
            get { return _IsAnotherService; }
            set { SetProperty(ref _IsAnotherService, value); }
        }
        #endregion

        #region IsInventory
        private bool _IsInventory;
        public bool IsInventory
        {
            get { return _IsInventory; }
            set { SetProperty(ref _IsInventory, value); }
        } 
        #endregion

        #region IsEndTime
        private bool _IsEndTime;
        public bool IsEndTime
        {
            get { return _IsEndTime; }
            set { SetProperty(ref _IsEndTime, value); }
        }
        #endregion

        #region IsInventoryShows
        private bool _IsInventoryShows;
        public bool IsInventoryShows
        {
            get { return _IsInventoryShows; }
            set { SetProperty(ref _IsInventoryShows, value); }
        }
        #endregion
        

        #region IsCheckList
        private bool _IsCheckList;
        public bool IsCheckList
        {
            get { return _IsCheckList; }
            set { SetProperty(ref _IsCheckList, value); }
        }
        #endregion

        #region CheckList
        private List<string> AddedCheckList = new List<string>();
        private ObservableCollection<AddJobCheckList> _CheckList = new ObservableCollection<AddJobCheckList>();
        public ObservableCollection<AddJobCheckList> CheckList
        {
            get { return _CheckList; }
            set { SetProperty(ref _CheckList, value); }
        }
        #endregion
        
        #region CheckListHeight Property
        private double _CheckListHeight;

        public double CheckListHeight
        {
            get { return _CheckListHeight; }
            set { SetProperty(ref _CheckListHeight, value); }
        }
        #endregion



        #region SelectedPackageList
        private List<string> AddedpackageList = new List<string>();
        private ObservableCollection<SelectedPackageListModel> _SelectedPackageList = new ObservableCollection<SelectedPackageListModel>();
        public ObservableCollection<SelectedPackageListModel> SelectedPackageList
        {
            get { return _SelectedPackageList; }
            set { SetProperty(ref _SelectedPackageList, value); }
        }
        #endregion

        #region PackageListHeight Property
        private double _PackageListHeight;

        public double PackageListHeight
        {
            get { return _PackageListHeight; }
            set { SetProperty(ref _PackageListHeight, value); }
        }
        #endregion



        #region SelectedPropertyList
        private List<string> AddedPropertyList = new List<string>();
        private ObservableCollection<SelectedPropertyListModel> _SelectedPropertyList = new ObservableCollection<SelectedPropertyListModel>();
        public ObservableCollection<SelectedPropertyListModel> SelectedPropertyList
        {
            get { return _SelectedPropertyList; }
            set { SetProperty(ref _SelectedPropertyList, value); }
        }
        #endregion

        #region PropertyListHeight Property
        private double _PropertyListHeight;

        public double PropertyListHeight
        {
            get { return _PropertyListHeight; }
            set { SetProperty(ref _PropertyListHeight, value); }
        }
        #endregion



        #region SelectedServiceList
        private List<string> AddedServiceList = new List<string>();
        private ObservableCollection<SelectedServiceListModel> _SelectedServiceList = new ObservableCollection<SelectedServiceListModel>();
        public ObservableCollection<SelectedServiceListModel> SelectedServiceList
        {
            get { return _SelectedServiceList; }
            set { SetProperty(ref _SelectedServiceList, value); }
        }
        #endregion

        #region ServiceListHeight Property
        private double _ServiceListHeight;

        public double ServiceListHeight
        {
            get { return _ServiceListHeight; }
            set { SetProperty(ref _ServiceListHeight, value); }
        }
        #endregion




        /// <summary>
        /// Label/Entry 
        /// </summary>

        #region Description
        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        } 
        #endregion

        #region AnotherServiceName
        private string _AnotherServiceName;
        public string AnotherServiceName
        {
            get { return _AnotherServiceName; }
            set { SetProperty(ref _AnotherServiceName, value); }
        } 
        #endregion

        #region CheckListEntry
        private string _CheckListEntry;
        public string CheckListEntry
        {
            get { return _CheckListEntry; }
            set { SetProperty(ref _CheckListEntry, value); }
        } 
        #endregion

        #region StartDate
        private string _StartDate = "Click here to choose the start date";
        public string StartDate
        {
            get { return _StartDate; }
            set { SetProperty(ref _StartDate, value); }
        } 
        #endregion

        #region EndTime
        private string _EndTime = "Click here to choose the end time";
        public string EndTime
        {
            get { return _EndTime; }
            set { SetProperty(ref _EndTime, value); }
        } 
        #endregion

        #region PropertyAddress
        private string _PropertyAddress;
        public string PropertyAddress
        {
            get { return _PropertyAddress; }
            set { SetProperty(ref _PropertyAddress, value); }
        } 
        #endregion

        #region PropertyName
        private string _PropertyName;
        public string PropertyName
        {
            get { return _PropertyName; }
            set { SetProperty(ref _PropertyName, value); }
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

        #region ServiceName
        private string _ServiceName;
        public string ServiceName
        {
            get { return _ServiceName; }
            set { SetProperty(ref _ServiceName, value); }
        }
        #endregion




        /// <summary>
        /// Picker List
        /// </summary>

        #region ServiceList
        private ObservableCollection<CategoryData> _ServiceList = new ObservableCollection<CategoryData>();
        public ObservableCollection<CategoryData> ServiceList
        {
            get { return _ServiceList; }
            set { SetProperty(ref _ServiceList, value); }
        }
        #endregion

        #region ServiceListSelected
        private CategoryData _ServiceListSelected;
        public CategoryData ServiceListSelected
        {
            get { return _ServiceListSelected; }
            set 
            { 
                SetProperty(ref _ServiceListSelected, value); 
                if(ServiceListSelected != null)
                {
                    foreach (var item in ServiceListSelected.SubCategories)
                    {
                        item.display_Name = item.Name;
                        item.display_Description = item.Description;
                        item.display_Icon = Common.IsImagesValid(item.Icon, ApiUrl.SubCategoryImageBaseUrl);
                        item.display_Picture = Common.IsImagesValid(item.Picture, ApiUrl.SubCategoryImageBaseUrl);
                        item.SelectedColor = ColorHelpers.GrayColor;
                        AllSubServiceList.Add(item);
                    }

                    SubServiceList = AllSubServiceList;
                    IsSubserviceAvailable = SubServiceList != null && SubServiceList.Count > 0 ? true : false;
                }
            }
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

        #region SubServiceListSelected
        private SubCategory _SubServiceListSelected;
        public SubCategory SubServiceListSelected
        {
            get { return _SubServiceListSelected; }
            set 
            { 
                SetProperty(ref _SubServiceListSelected, value); 
                if(SubServiceListSelected != null)
                {
                    foreach (var item in SubServiceListSelected.SubSubCategories)
                    {
                        item.display_Name = item.Name;
                        item.display_Description = item.Description;
                        item.display_Icon = Common.IsImagesValid(item.Icon, ApiUrl.SubSubCategoryImageBaseUrl);
                        item.display_Picture = Common.IsImagesValid(item.Picture, ApiUrl.SubSubCategoryImageBaseUrl);
                        item.SelectedColor = ColorHelpers.GrayColor;
                        AllSubSubServiceList.Add(item);
                    }

                    SubSubServiceList = AllSubSubServiceList;
                    IsPackageAvailable = SubSubServiceList != null && SubSubServiceList.Count > 0 ? true : false;
                }
            }
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

        #region SubSubServiceListSelected
        private SubSubCategory _SubSubServiceListSelected;
        public SubSubCategory SubSubServiceListSelected
        {
            get { return _SubSubServiceListSelected; }
            set { SetProperty(ref _SubSubServiceListSelected, value); }
        }
        #endregion




        /// <summary>
        /// Images
        /// </summary>

        #region AnotherPropertyImage
        private string _AnotherPropertyImage = ImageHelpers.ic_off;
        public string AnotherPropertyImage
        {
            get { return _AnotherPropertyImage; }
            set { SetProperty(ref _AnotherPropertyImage, value); }
        } 
        #endregion

        #region EndDateImage
        private string _EndDateImage = ImageHelpers.ic_off;
        public string EndDateImage
        {
            get { return _EndDateImage; }
            set { SetProperty(ref _EndDateImage, value); }
        } 
        #endregion

        #region CheckListImage
        private string _CheckListImage = ImageHelpers.ic_off;
        public string CheckListImage
        {
            get { return _CheckListImage; }
            set { SetProperty(ref _CheckListImage, value); }
        } 
        #endregion

        #region InventoryImage
        private string _InventoryImage = ImageHelpers.ic_off;
        public string InventoryImage
        {
            get { return _InventoryImage; }
            set { SetProperty(ref _InventoryImage, value); }
        } 
        #endregion

        #region AnotherServiceImage
        private string _AnotherServiceImage = ImageHelpers.ic_off;
        public string AnotherServiceImage
        {
            get { return _AnotherServiceImage; }
            set { SetProperty(ref _AnotherServiceImage, value); }
        } 
        #endregion

        #region DescriptionImage
        private string _DescriptionImage = ImageHelpers.ic_off;
        public string DescriptionImage
        {
            get { return _DescriptionImage; }
            set { SetProperty(ref _DescriptionImage, value); }
        } 
        #endregion

        #region Constructor
        public AddJobRequestViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        #endregion





        /// <summary>
        /// Commands
        /// </summary>

        #region EndDateCommand
        public Command EndDateCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (EndDateImage.Equals(ImageHelpers.ic_off))
                    {
                        EndDateImage = ImageHelpers.ic_on;
                        IsEndTime = true;
                    }
                    else
                    {
                        EndDateImage = ImageHelpers.ic_off;
                        IsEndTime = false;
                    }
                });
            }
        }
        #endregion

        #region ChecklistCommand
        public Command ChecklistCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (CheckListImage.Equals(ImageHelpers.ic_off))
                    {
                        CheckListImage = ImageHelpers.ic_on;
                        IsCheckList = true;
                    }
                    else
                    {
                        CheckListImage = ImageHelpers.ic_off;
                        IsCheckList = false;
                    }
                });
            }
        }
        #endregion

        #region AddInventryCommand
        public Command AddInventryCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (InventoryImage.Equals(ImageHelpers.ic_off))
                    {
                        InventoryImage = ImageHelpers.ic_on;
                        IsInventory = true;
                    }
                    else
                    {
                        InventoryImage = ImageHelpers.ic_off;
                        IsInventory = false;
                    }
                });
            }
        }
        #endregion

        #region ServiceCloseCommand
        public Command ServiceCloseCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsAnotherServicePopup = false;
                });
            }
        }
        #endregion

        #region AddServiceCommand
        public Command AddServiceCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsAnotherServicePopup = true;
                });
            }
        }
        #endregion

        #region AddServiceButton
        public Command AddServiceButton
        {
            get
            {
                return new Command(() =>
                {
                    if (IsPackageAvailable)
                    {
                        if(SubSubServiceListSelected != null)
                        {
                            SelectedServiceList.Add(new SelectedServiceListModel
                            {
                                ServiceName = SubSubServiceListSelected.display_Name,
                                service_id = SubSubServiceListSelected.Id
                            });
                            ServiceListHeight = (55 * SelectedServiceList.Count) + 10;

                            IsAnotherServicePopup = false;
                            ServiceListSelected = null;
                            SubServiceListSelected = null;
                            SubSubServiceListSelected = null;
                        }
                    }
                    else
                    {
                        if(SubServiceListSelected != null)
                        {
                            SelectedServiceList.Add(new SelectedServiceListModel
                            {
                                ServiceName = SubServiceListSelected.display_Name,
                                service_id = SubServiceListSelected.Id
                            });
                            ServiceListHeight = (55 * SelectedServiceList.Count) + 10;

                            IsAnotherServicePopup = false;
                            ServiceListSelected = null;
                            SubServiceListSelected = null;
                        }
                    }
                });
            }
        }
        #endregion

        #region InventoryCommand
        public Command InventoryCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (InventoryImage.Equals(ImageHelpers.ic_off))
                    {
                        InventoryImage = ImageHelpers.ic_on;
                        IsInventory = true;
                    }
                    else
                    {
                        InventoryImage = ImageHelpers.ic_off;
                        IsInventory = false;
                    }
                });
            }
        }
        #endregion

        #region AnotherServiceCommand
        public Command AnotherServiceCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (AnotherServiceImage.Equals(ImageHelpers.ic_off))
                    {
                        AnotherServiceImage = ImageHelpers.ic_on;
                        IsAnotherService = true;
                    }
                    else
                    {
                        AnotherServiceImage = ImageHelpers.ic_off;
                        IsAnotherService = false;
                    }
                });
            }
        }
        #endregion

        #region DescriptionCommand
        public Command DescriptionCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (DescriptionImage.Equals(ImageHelpers.ic_off))
                    {
                        DescriptionImage = ImageHelpers.ic_on;
                        IsDescription = true;
                    }
                    else
                    {
                        DescriptionImage = ImageHelpers.ic_off;
                        IsDescription = false;
                    }
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

        #region NextIconButton
        public Command NextIconButton
        {
            get
            {
                return new Command(async () =>
                {
                    if (!string.IsNullOrEmpty(StartDate) && !string.IsNullOrWhiteSpace(StartDate) && StartDate != "Click here to choose the start date")
                    {
                        try
                        {
                            UserDialogs.Instance.ShowLoading();
                            string boundary = "---8d0f01e6b3b5dafaaadaad";
                            MultipartFormDataContent multipartContent = new MultipartFormDataContent(boundary);
                            multipartContent.Add(new StringContent(StartDate), "JobStartDateTime");
                            if (!string.IsNullOrWhiteSpace(Description) && !string.IsNullOrEmpty(Description))
                            {
                                multipartContent.Add(new StringContent(Description), "JobDesc"); 
                            }
                            multipartContent.Add(new StringContent(userId.ToString()), "UserId");
                            if (!string.IsNullOrEmpty(EndTime) && !string.IsNullOrWhiteSpace(EndTime) && EndTime != "Click here to choose the end time")
                            {
                                multipartContent.Add(new StringContent(EndTime), "JobEndDateTime");
                            }
                            multipartContent.Add(new StringContent(AddJobDataModel.SelectedServiceId.ToString()), "CategoryId");
                            if (AddedCheckList != null && AddedCheckList.Count > 0)
                            {
                                multipartContent.Add(new StringContent(JsonConvert.SerializeObject(AddedCheckList)), "CheckList");
                            }
                            multipartContent.Add(new StringContent(AddJobDataModel.propertyId.ToString()), "property_id");
                            multipartContent.Add(new StringContent(AddJobDataModel.propertyAddress), "Address");
                            multipartContent.Add(new StringContent(AddJobDataModel.propertyName), "Name");


                            BaseModels response;
                            try
                            {
                                response = await webApiRestClient.PostAsync<MultipartFormDataContent, BaseModels>(ApiUrl.AddJobRequest, multipartContent);
                            }
                            catch (Exception ex)
                            {
                                response = null;
                            }
                            if (response != null)
                            {
                                if (response.status)
                                {

                                    await NavigationService.NavigateAsync(new Uri("/NavigationPage/WelcomePage", UriKind.Absolute));
                                }
                                else
                                {
                                    await App.Current.MainPage.DisplayAlert("", response.message, "Ok");
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
                        //await NavigationService.NavigateAsync(nameof(CardListPage)); 
                    }
                    else
                    {
                        await MaterialDialog.Instance.SnackbarAsync("Please select job start date.", 3000);
                    }
                });
            }
        }
        #endregion

        #region StartDatePickerCommand
        public Command StartDatePickerCommand
        {
            get
            {
                return new Command(async () =>
                {
                    AddJobRequest.startDatePicker.Focus();
                });
            }
        }
        #endregion

        #region EndTimePickerCommand
        public Command EndTimePickerCommand
        {
            get
            {
                return new Command(async () =>
                {
                    AddJobRequest.endTimePicker.Focus();
                });
            }
        }
        #endregion

        #region AddCheckListCommand
        public Command AddCheckListCommand
        {
            get
            {
                return new Command(() =>
                {
                    CheckList.Add(new AddJobCheckList
                    {
                        CheckListValue = CheckListEntry
                    });
                    CheckListHeight = (55 * CheckList.Count) + 10;
                    CheckListEntry = string.Empty;

                    AddedCheckList.Add(CheckListEntry);
                });
            }
        }
        #endregion

        #region CloseCheckListCommand
        public Command CloseCheckListCommand
        {
            get
            {
                return new Command((e) =>
                {
                    try
                    {
                        var item = ((AddJobCheckList)e);
                        CheckList.Remove(item);
                        CheckListHeight = (55 * CheckList.Count) + 10;
                        if (CheckList == null || CheckList.Count == 0)
                        {
                            CheckListHeight = 0;
                        }

                        AddedCheckList.Remove(item.CheckListValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("SendCommand_Exception:- " + ex.Message);
                    }
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
            if (parameters.ContainsKey("AddJobDataModel"))
            {
                AddJobDataModel = (AddJobDataModel)parameters["AddJobDataModel"];
            }


            SelectedPropertyList.Add(new SelectedPropertyListModel
            {
                PropertyNameAddress = AddJobDataModel.propertyName + ", " + AddJobDataModel.propertyAddress,
                property_id = AddJobDataModel.propertyId
            });
            PropertyListHeight = (55 * SelectedPropertyList.Count) + 10;


            SelectedServiceList.Add(new SelectedServiceListModel
            {
                ServiceName = AddJobDataModel.SelectedService,
                service_id = AddJobDataModel.SelectedServiceId
            });
            ServiceListHeight = (55 * SelectedServiceList.Count) + 10;

            //ServiceName = AddJobDataModel.SelectedService;
            //SubServiceName = AddJobDataModel.SelectedSubService;
            //PropertyName = AddJobDataModel.propertyName;
            //PropertyAddress = AddJobDataModel.propertyAddress;

            IsSubserviceAvailable = SubServiceList != null && SubServiceList.Count > 0 ? true : false;
            IsPackageAvailable = SubSubServiceList != null && SubSubServiceList.Count > 0 ? true : false;

            ServiceList = AddJobDataModel.ServiceList;

            IsInventoryShows = AddJobDataModel.ShortTermApartment;

            Device.BeginInvokeOnMainThread(() =>
            {
                GetInventoryData();
            });
        }
        #endregion

        #region GetInventoryData
        private async void GetInventoryData()
        {
            InventoryResponseModel response;
            try
            {
                response = await webApiRestClient.GetAsync<InventoryResponseModel>(ApiUrl.GetInventoryList);
            }
            catch (Exception ex)
            {
                response = null;
            }
            if(response != null)
            {
                if (response.status)
                {

                }
                else
                {
                }
            }
        }
        #endregion
    }
}
