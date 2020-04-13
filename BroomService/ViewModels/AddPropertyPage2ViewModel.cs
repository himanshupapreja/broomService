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
    public class AddPropertyPage2ViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService NavigationService;
        AddPropertyModel AddPropertyModel;

        #region FloorNumber
        private string _FloorNumber;
        public string FloorNumber
        {
            get { return _FloorNumber; }
            set { SetProperty(ref _FloorNumber, value); }
        }
        #endregion

        #region ApartmentNumber
        private string _ApartmentNumber;
        public string ApartmentNumber
        {
            get { return _ApartmentNumber; }
            set { SetProperty(ref _ApartmentNumber, value); }
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

        #region AccessProperty
        private string _AccessProperty;
        public string AccessProperty
        {
            get { return _AccessProperty; }
            set { SetProperty(ref _AccessProperty, value); }
        }
        #endregion

        #region WifiLoginKey
        private string _WifiLoginKey;
        public string WifiLoginKey
        {
            get { return _WifiLoginKey; }
            set { SetProperty(ref _WifiLoginKey, value); }
        }
        #endregion

        #region Constructor
        public AddPropertyPage2ViewModel(INavigationService navigationService)
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

        #region NextIconButton
        public Command NextIconButton
        {
            get
            {
                return new Command(async () =>
                {
                    if (!string.IsNullOrEmpty(FloorNumber) && !string.IsNullOrWhiteSpace(FloorNumber) && !string.IsNullOrEmpty(ApartmentNumber) && !string.IsNullOrWhiteSpace(ApartmentNumber) && !string.IsNullOrEmpty(BuildingCode) && !string.IsNullOrWhiteSpace(BuildingCode))
                    {
                        AddPropertyModel.BuildingCode = BuildingCode;
                        AddPropertyModel.FloorNumber = FloorNumber;
                        AddPropertyModel.ApartmentNumber = ApartmentNumber;
                        AddPropertyModel.AccessToProperty = AccessProperty;
                        AddPropertyModel.WifiLogin = WifiLoginKey;

                        var param = new NavigationParameters();
                        param.Add("TransferData", AddPropertyModel);
                        await NavigationService.NavigateAsync(nameof(AddPropertyPage3), param);
                    }
                    else
                    {
                        await MaterialDialog.Instance.SnackbarAsync("Please fill all the required fields", 3000);
                    }
                });
            }
        }
        #endregion

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("TransferData"))
            {
                AddPropertyModel = (AddPropertyModel)parameters["TransferData"];
            }
        }
    }
}
