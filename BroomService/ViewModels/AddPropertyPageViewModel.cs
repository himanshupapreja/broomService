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
    public class AddPropertyPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;

        #region PropertyName
        private string _PropertyName;
        public string PropertyName
        {
            get { return _PropertyName; }
            set { SetProperty(ref _PropertyName, value); }
        }
        #endregion

        #region Address
        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { SetProperty(ref _Address, value); }
        }
        #endregion

        #region ShortAirBnbImage
        private string _ShortAirBnbImage = ImageHelpers.ic_off;
        public string ShortAirBnbImage
        {
            get { return _ShortAirBnbImage; }
            set { SetProperty(ref _ShortAirBnbImage, value); }
        }
        #endregion

        #region AccessPropertyAccessImage
        private string _AccessPropertyAccessImage = ImageHelpers.ic_off;
        public string AccessPropertyAccessImage
        {
            get { return _AccessPropertyAccessImage; }
            set { SetProperty(ref _AccessPropertyAccessImage, value); }
        }
        #endregion

        #region IsAccessPropertyAccessVisible
        private bool _IsAccessPropertyAccessVisible = false;
        public bool IsAccessPropertyAccessVisible
        {
            get { return _IsAccessPropertyAccessVisible; }
            set { SetProperty(ref _IsAccessPropertyAccessVisible, value); }
        }
        #endregion

        #region PropertyType Picker static value
        public List<string> _propertyTypeList = new List<string> {
            "Apartment","Villa","Duplex","Penthouse"
        };
        public List<string> PropertyTypeList => _propertyTypeList;
        #endregion

        #region PropertyTypeListSelected SelectedItem property
        private string _PropertyTypeListSelected;
        public string PropertyTypeListSelected
        {
            get => _PropertyTypeListSelected;
            set { SetProperty(ref _PropertyTypeListSelected, value); }
        }
        #endregion

        #region Constructor
        public AddPropertyPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            IsAccessPropertyAccessVisible = ShortAirBnbImage == ImageHelpers.ic_off ? false : true;
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
                    if (!string.IsNullOrEmpty(PropertyName) && !string.IsNullOrWhiteSpace(PropertyName) && !string.IsNullOrEmpty(PropertyTypeListSelected) && !string.IsNullOrWhiteSpace(PropertyTypeListSelected) && !string.IsNullOrEmpty(Address) && !string.IsNullOrWhiteSpace(Address))
                    {
                        var dataModel = new AddPropertyModel()
                        {
                            Name = PropertyName,
                            Type = PropertyTypeListSelected,
                            Address = Address,
                            ShortTermApartment = ShortAirBnbImage == ImageHelpers.ic_off ? false : true,
                            AccesstoCode = AccessPropertyAccessImage == ImageHelpers.ic_off ? false : true,
                        };

                        var param = new NavigationParameters();
                        param.Add("TransferData", dataModel);
                        await NavigationService.NavigateAsync(nameof(AddPropertyPage2), param);
                    }
                    else
                    {
                        await MaterialDialog.Instance.SnackbarAsync("Please fill all the required fields", 3000);
                    }
                });
            }
        }
        #endregion

        #region ShortTermCommand
        public Command ShortTermCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (ShortAirBnbImage == ImageHelpers.ic_off)
                    {
                        ShortAirBnbImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        ShortAirBnbImage = ImageHelpers.ic_off;
                    }

                    IsAccessPropertyAccessVisible = ShortAirBnbImage == ImageHelpers.ic_off ? false : true;
                });
            }
        }
        #endregion

        #region AccessPropertyAccessCommand
        public Command AccessPropertyAccessCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (AccessPropertyAccessImage == ImageHelpers.ic_off)
                    {
                        AccessPropertyAccessImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        AccessPropertyAccessImage = ImageHelpers.ic_off;
                    }
                });
            }
        }
        #endregion
    }
}
