using Acr.UserDialogs;
using BroomService.Helpers;
using BroomService.Models;
using BroomService.Views;
using ImTools;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF.Material.Forms.Dialogs;
using XF.Material.Forms.UI.Dialogs;

namespace BroomService.ViewModels
{
    public class AddJobRequestViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService NavigationService;
        AddJobDataModel AddJobDataModel = new AddJobDataModel();
        bool IsFastOrder;
        List<InventoryDataModel> inventoryData;

        List<PropertyModel> AllPropertyList = new List<PropertyModel>();

        #region InventoryAddedList
        private ObservableCollection<InventoryAddedListModel> _InventoryAddedList = new ObservableCollection<InventoryAddedListModel>();
        public ObservableCollection<InventoryAddedListModel> InventoryAddedList
        {
            get { return _InventoryAddedList; }
            set { SetProperty(ref _InventoryAddedList, value); }
        }
        #endregion

        #region InventoryAddedListHeight Property
        private double _InventoryAddedListHeight;

        public double InventoryAddedListHeight
        {
            get { return _InventoryAddedListHeight; }
            set { SetProperty(ref _InventoryAddedListHeight, value); }
        }
        #endregion

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

        #region IsAddedInventoryProperty
        private bool _IsAddedInventoryProperty = false;
        public bool IsAddedInventoryProperty
        {
            get { return _IsAddedInventoryProperty; }
            set { SetProperty(ref _IsAddedInventoryProperty, value); }
        }
        #endregion

        #region IsSearchProperty
        private bool _IsSearchProperty = false;
        public bool IsSearchProperty
        {
            get { return _IsSearchProperty; }
            set { SetProperty(ref _IsSearchProperty, value); }
        }
        #endregion

        #region IsFastorderPopup
        private bool _IsFastorderPopup = false;
        public bool IsFastorderPopup
        {
            get { return _IsFastorderPopup; }
            set { SetProperty(ref _IsFastorderPopup, value); }
        }
        #endregion

        #region IsPropertyPopup
        private bool _IsPropertyPopup = false;
        public bool IsPropertyPopup
        {
            get { return _IsPropertyPopup; }
            set { SetProperty(ref _IsPropertyPopup, value); }
        }
        #endregion

        #region IsInventoryPopup
        private bool _IsInventoryPopup = false;
        public bool IsInventoryPopup
        {
            get { return _IsInventoryPopup; }
            set { SetProperty(ref _IsInventoryPopup, value); }
        }
        #endregion

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

        #region IsProperty
        private bool _IsProperty;
        public bool IsProperty
        {
            get { return _IsProperty; }
            set { SetProperty(ref _IsProperty, value); }
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
        # endregion



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



        #region InventoryPropertySelected
        private SelectedPropertyListModel _InventoryPropertySelected;
        public SelectedPropertyListModel InventoryPropertySelected
        {
            get { return _InventoryPropertySelected; }
            set { SetProperty(ref _InventoryPropertySelected, value); }
        }
        #endregion

        #region InventoryPropertyList
        private ObservableCollection<SelectedPropertyListModel> _InventoryPropertyList = new ObservableCollection<SelectedPropertyListModel>();
        public ObservableCollection<SelectedPropertyListModel> InventoryPropertyList
        {
            get { return _InventoryPropertyList; }
            set { SetProperty(ref _InventoryPropertyList, value); }
        }

        #endregion

        #region Another ProeprtyList
        private ObservableCollection<PropertyModel> _AnotherPropertyList = new ObservableCollection<PropertyModel>();
        public ObservableCollection<PropertyModel> AnotherPropertyList
        {
            get { return _AnotherPropertyList; }
            set { SetProperty(ref _AnotherPropertyList, value); }
        }

        
        private PropertyModel _SelectedAnotherProperty;
        public PropertyModel SelectedAnotherProperty
        {
            get { return _SelectedAnotherProperty; }
            set 
            { 
                SetProperty(ref _SelectedAnotherProperty, value); 
                if(SelectedAnotherProperty != null)
                {
                    var existData = SelectedPropertyList.Where(x => x.property_id == SelectedAnotherProperty.Id.Value).ToList().FirstOrDefault();
                    if (existData == null)
                    {
                        SelectedPropertyList.Add(new SelectedPropertyListModel
                        {
                            PropertyName = SelectedAnotherProperty.Name,
                            PropertyAddress = SelectedAnotherProperty.Address,
                            PropertyNameAddress = SelectedAnotherProperty.Name + ", " + SelectedAnotherProperty.Address,
                            property_id = SelectedAnotherProperty.Id.Value,
                            IsShortTermAirBnb = SelectedAnotherProperty.ShortTermApartment.HasValue ? SelectedAnotherProperty.ShortTermApartment.Value : false,
                            IsInventoryAdded = false
                        });
                        var shortTermPropertydata = SelectedPropertyList.Where(x => x.IsShortTermAirBnb).ToList();
                        if (shortTermPropertydata != null && shortTermPropertydata.Count > 0)
                        {
                            IsInventoryShows = true;
                        }
                        else
                        {
                            IsInventoryShows = false;
                        }
                        AddedPropertyList.Add(SelectedAnotherProperty.Id.Value);
                        PropertyListHeight = (55 * SelectedPropertyList.Count) + 10;

                        IsPropertyPopup = false;
                        PropertyName = string.Empty;
                    }
                    else
                    {
                        MaterialDialog.Instance.SnackbarAsync("Property Already added.", 1000);
                    }
                }
            }
        }


        #endregion


        #region SelectedPropertyList
        private List<long> AddedPropertyList = new List<long>();
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

        #region FastOrderName
        private string _FastOrderName;
        public string FastOrderName
        {
            get { return _FastOrderName; }
            set { SetProperty(ref _FastOrderName, value); }
        } 
        #endregion

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
            set 
            { 
                SetProperty(ref _PropertyName, value); 
                if(!string.IsNullOrEmpty(PropertyName) && !string.IsNullOrWhiteSpace(PropertyName))
                {
                    if (AllPropertyList != null && AllPropertyList.Count > 0)
                    {
                        try
                        {
                            IsSearchProperty = true;
                            AnotherPropertyList = new ObservableCollection<PropertyModel>(AllPropertyList.Where(x => !string.IsNullOrEmpty(x.Name) && x.Name.ToLower().StartsWith(PropertyName)).ToList());
                        }
                        catch (Exception ex)
                        {
                        }
                        
                    }
                    else
                    {
                        MaterialDialog.Instance.SnackbarAsync("Currently there is no property available", 1000);
                    }
                }
                else
                {
                    IsSearchProperty = false;
                }
            }
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

        #region TotalPrice
        private double _TotalPrice = 0;
        public double TotalPrice
        {
            get { return _TotalPrice; }
            set { SetProperty(ref _TotalPrice, value); }
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

        #region PropertyImage
        private string _PropertyImage = ImageHelpers.ic_off;
        public string PropertyImage
        {
            get { return _PropertyImage; }
            set { SetProperty(ref _PropertyImage, value); }
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

        #region RepeatServiceImage
        private string _RepeatServiceImage = ImageHelpers.ic_off;
        public string RepeatServiceImage
        {
            get { return _RepeatServiceImage; }
            set { SetProperty(ref _RepeatServiceImage, value); }
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

        #region FastOrderImage
        private string _FastOrderImage = ImageHelpers.ic_checkbox_uncheck;
        public string FastOrderImage
        {
            get { return _FastOrderImage; }
            set { SetProperty(ref _FastOrderImage, value); }
        } 
        #endregion

        #region Constructor
        public AddJobRequestViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            IsFastOrder = false;
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

        #region AddPropertyCommand
        public Command AddPropertyCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsPropertyPopup = true;
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
                    InventoryPropertyList = new ObservableCollection<SelectedPropertyListModel>(SelectedPropertyList.Where(x => x.IsShortTermAirBnb && !x.IsInventoryAdded).ToList());

                    if (InventoryPropertyList != null && InventoryPropertyList.Count > 0)
                    {
                        if (inventoryData != null && inventoryData.Count > 0)
                        {
                            AllInventoryList.Clear();
                            foreach (var item in inventoryData)
                            {
                                item.display_Image = Common.IsImagesValid(item.Image, ApiUrl.InventoryImageBaseUrl);
                                item.InventoryOrderCount = 0;

                                AllInventoryList.Add(item);
                            }

                            InventoryList = AllInventoryList;
                        }
                        IsInventoryPopup = true;
                    }
                    else
                    {
                        IsInventoryPopup = false;
                        MaterialDialog.Instance.SnackbarAsync("There is no more property to add inventory.", 1000);
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
                                SubSubCategoryyId = SubSubServiceListSelected.Id,
                                CategoryId = ServiceListSelected.Id,
                                SubCategoryId = SubServiceListSelected.Id
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
                                CategoryId = ServiceListSelected.Id,
                                SubCategoryId = SubServiceListSelected.Id,
                                SubSubCategoryyId = 0
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

        #region PropertyCommand
        public Command PropertyCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (PropertyImage.Equals(ImageHelpers.ic_off))
                    {
                        PropertyImage = ImageHelpers.ic_on;
                        IsProperty = true;
                    }
                    else
                    {
                        PropertyImage = ImageHelpers.ic_off;
                        IsProperty = false;
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

        #region InventoryCountMinusCommand
        public Command InventoryCountMinusCommand
        {
            get
            {
                return new Command((e) =>
                {
                    var item = (InventoryDataModel)e;
                    try
                    {
                        if (item.InventoryOrderCount > 0)
                        {
                            item.InventoryOrderCount = item.InventoryOrderCount - 1;
                            TotalPrice = TotalPrice - item.Price.Value;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                });
            }
        }
        #endregion

        #region InventoryCountPlusCommand
        public Command InventoryCountPlusCommand
        {
            get
            {
                return new Command(async(e) =>
                {
                    var item = (InventoryDataModel)e;
                    try
                    {
                        if (item.Stock.HasValue)
                        {
                            if (item.InventoryOrderCount < item.Stock.Value)
                            {
                                TotalPrice = TotalPrice + item.Price.Value;
                                item.InventoryOrderCount = item.InventoryOrderCount + 1;
                            }
                        }
                        else
                        {
                            await MaterialDialog.Instance.SnackbarAsync("Currently there is no item in the stock. Please try again after some time.", 3000);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                });
            }
        }
        #endregion

        #region AnotherPropertyCloseCommand
        public Command AnotherPropertyCloseCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsPropertyPopup = false;
                    PropertyName = string.Empty;
                });
            }
        }
        #endregion

        #region InventoryPopupCloseCommand
        public Command InventoryPopupCloseCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsInventoryPopup = false;
                    InventoryList = AllInventoryList;
                });
            }
        }
        #endregion

        #region AddInventoryButton
        public Command AddInventoryButton
        {
            get
            {
                return new Command(async() =>
                {
                    if (InventoryPropertySelected != null)
                    {
                        IsInventoryPopup = false;

                        foreach (var item in InventoryList)
                        {
                            if (item.InventoryOrderCount > 0)
                            {
                                InventoryAddedList.Add(new InventoryAddedListModel
                                {
                                    InventoryId = item.InventoryId,
                                    InventoryName = item.Name,
                                    PropertyName = InventoryPropertySelected.PropertyName,
                                    PropertyId = InventoryPropertySelected.property_id,
                                    Qty = item.InventoryOrderCount
                                });
                            }
                            else
                            {

                            }
                        }

                        

                        InventoryAddedListHeight = (55 * InventoryAddedList.Count) + 10;

                        if (inventoryData != null && inventoryData.Count > 0)
                        {
                            AllInventoryList.Clear();
                            foreach (var item in inventoryData)
                            {
                                item.display_Image = Common.IsImagesValid(item.Image, ApiUrl.InventoryImageBaseUrl);
                                item.InventoryOrderCount = 0;

                                AllInventoryList.Add(item);
                            }

                            InventoryList = AllInventoryList;
                        }

                        if (InventoryAddedList != null && InventoryAddedList.Count > 0)
                        {
                            var propertyListData = SelectedPropertyList.Where(x => x.property_id == InventoryPropertySelected.property_id).ToList().FirstOrDefault();
                            var propertyDataIndex = SelectedPropertyList.IndexOf(propertyListData);
                            SelectedPropertyList[propertyDataIndex].IsInventoryAdded = true;

                            IsAddedInventoryProperty = true;
                        }
                        else
                        {
                            IsAddedInventoryProperty = false;
                        }
                    }
                    else
                    {
                        await MaterialDialog.Instance.SnackbarAsync("Please select property.", 1000);
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

        #region RepeatServiceCommand
        public Command RepeatServiceCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (RepeatServiceImage.Equals(ImageHelpers.ic_off))
                    {
                        RepeatServiceImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        RepeatServiceImage = ImageHelpers.ic_off;
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

        #region FastOrderCommand
        public Command FastOrderCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (FastOrderImage.Equals(ImageHelpers.ic_checkbox_uncheck))
                    {
                        FastOrderImage = ImageHelpers.ic_checkbox_check;
                        IsFastOrder = true;
                    }
                    else
                    {
                        FastOrderImage = ImageHelpers.ic_checkbox_uncheck;
                        IsFastOrder = false;
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

        #region FastOrderCloseCommand
        public Command FastOrderCloseCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsFastorderPopup = false;
                    FastOrderName = string.Empty;
                });
            }
        }
        #endregion

        #region FastOrderNextButton
        public Command FastOrderNextButton
        {
            get
            {
                return new Command(async () =>
                {
                    if (!string.IsNullOrEmpty(FastOrderName) && !string.IsNullOrWhiteSpace(FastOrderName))
                    {
                        AddJobApiCall();
                    }
                    else
                    {
                        await MaterialDialog.Instance.SnackbarAsync("Please enter Fast order Name.", 1000);
                    }
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
                        if (IsFastOrder)
                        {
                            IsFastorderPopup = true;
                        }
                        else
                        {
                            IsFastorderPopup = false;
                            FastOrderName = string.Empty;
                            AddJobApiCall();
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

        #region Api Call
        private async void AddJobApiCall()
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

                multipartContent.Add(new StringContent(JsonConvert.SerializeObject(SelectedServiceList)), "Categories");
                multipartContent.Add(new StringContent(userId.ToString()), "UserId");
                multipartContent.Add(new StringContent(IsFastOrder.ToString()), "IsFastOrder");

                if (!string.IsNullOrWhiteSpace(FastOrderName) && !string.IsNullOrEmpty(FastOrderName))
                {
                    multipartContent.Add(new StringContent(FastOrderName), "FastOrderName");
                }
                if (!string.IsNullOrEmpty(EndTime) && !string.IsNullOrWhiteSpace(EndTime) && EndTime != "Click here to choose the end time")
                {
                    multipartContent.Add(new StringContent(EndTime), "JobEndDateTime");
                }
                if (AddedCheckList != null && AddedCheckList.Count > 0)
                {
                    multipartContent.Add(new StringContent(JsonConvert.SerializeObject(AddedCheckList)), "CheckList");
                }
                multipartContent.Add(new StringContent(JsonConvert.SerializeObject(AddedPropertyList)), "Property_List_Id");

                if (InventoryAddedList != null && InventoryAddedList.Count > 0)
                {
                    multipartContent.Add(new StringContent(JsonConvert.SerializeObject(InventoryAddedList)), "InventoryList");
                }


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
                        IsFastorderPopup = false;
                        FastOrderName = string.Empty;
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

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("AddJobDataModel"))
            {
                AddJobDataModel = (AddJobDataModel)parameters["AddJobDataModel"];
            }

            try
            {
                var data = await SecureStorage.GetAsync("PropertyList");

                var response = JsonConvert.DeserializeObject<PropertyListResponseModel>(data);

                foreach (var item in response.data)
                {
                    item.PropertyModel.PropertyImages = item.PropertyImages;
                    item.PropertyModel.property_Image_display = "image1.png";
                    AllPropertyList.Add(item.PropertyModel);
                }
            }
            catch (Exception ex)
            {
                AllPropertyList = new List<PropertyModel>();
            }


            SelectedPropertyList.Add(new SelectedPropertyListModel
            {
                PropertyName = AddJobDataModel.propertyName,
                PropertyAddress = AddJobDataModel.propertyAddress,
                PropertyNameAddress = AddJobDataModel.propertyName + ", " + AddJobDataModel.propertyAddress,
                property_id = AddJobDataModel.propertyId,
                IsShortTermAirBnb = AddJobDataModel.ShortTermApartment,
                IsInventoryAdded = false
            });
            AddedPropertyList.Add(AddJobDataModel.propertyId);
            PropertyListHeight = (55 * SelectedPropertyList.Count) + 10;


            SelectedServiceList.Add(new SelectedServiceListModel
            {
                ServiceName = AddJobDataModel.SelectedService,
                CategoryId = AddJobDataModel.SelectedServiceId,
                SubCategoryId= AddJobDataModel.SelectedSubServiceId,
                SubSubCategoryyId = AddJobDataModel.SelectedSubSubServiceId
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
                    inventoryData = response.inventoryData;
                    foreach (var item in response.inventoryData)
                    {
                        item.display_Image = Common.IsImagesValid(item.Image, ApiUrl.InventoryImageBaseUrl);
                        item.InventoryOrderCount = 0;

                        AllInventoryList.Add(item);
                    }

                    InventoryList = AllInventoryList;
                }
                else
                {
                    inventoryData = null;
                }
            }
        }
        #endregion
    }
}
