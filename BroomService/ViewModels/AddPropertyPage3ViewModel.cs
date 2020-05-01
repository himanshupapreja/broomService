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
    public class AddPropertyPage3ViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService NavigationService;
        AddPropertyModel AddPropertyModel;
        PropertyModel SelectedProperty;
        bool IsDoorman;
        bool IsParking;
        bool IsBalcony;
        bool IsDishwasher;
        bool IsPool;
        bool IsGarden;
        bool IsElevator;
        bool IsCoffee;

        #region DoormanImage
        private string _DoormanImage = ImageHelpers.ic_off;
        public string DoormanImage
        {
            get { return _DoormanImage; }
            set { SetProperty(ref _DoormanImage, value); }
        }
        #endregion

        #region ParkingImage
        private string _ParkingImage = ImageHelpers.ic_off;
        public string ParkingImage
        {
            get { return _ParkingImage; }
            set { SetProperty(ref _ParkingImage, value); }
        }
        #endregion

        #region BalconyImage
        private string _BalconyImage = ImageHelpers.ic_off;
        public string BalconyImage
        {
            get { return _BalconyImage; }
            set { SetProperty(ref _BalconyImage, value); }
        }
        #endregion

        #region DishwasherImage
        private string _DishwasherImage = ImageHelpers.ic_off;
        public string DishwasherImage
        {
            get { return _DishwasherImage; }
            set { SetProperty(ref _DishwasherImage, value); }
        }
        #endregion

        #region PoolImage
        private string _PoolImage = ImageHelpers.ic_off;
        public string PoolImage
        {
            get { return _PoolImage; }
            set { SetProperty(ref _PoolImage, value); }
        }
        #endregion

        #region GardenImage
        private string _GardenImage = ImageHelpers.ic_off;
        public string GardenImage
        {
            get { return _GardenImage; }
            set { SetProperty(ref _GardenImage, value); }
        }
        #endregion

        #region ElevatorImage
        private string _ElevatorImage = ImageHelpers.ic_off;
        public string ElevatorImage
        {
            get { return _ElevatorImage; }
            set { SetProperty(ref _ElevatorImage, value); }
        }
        #endregion

        #region CoffeeImage
        private string _CoffeeImage = ImageHelpers.ic_off;
        public string CoffeeImage
        {
            get { return _CoffeeImage; }
            set { SetProperty(ref _CoffeeImage, value); }
        }
        #endregion

        #region Constructor
        public AddPropertyPage3ViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            IsDoorman = DoormanImage == ImageHelpers.ic_on ? true : false;
            IsParking = ParkingImage == ImageHelpers.ic_on ? true : false;
            IsBalcony = BalconyImage == ImageHelpers.ic_on ? true : false;
            IsDishwasher = DishwasherImage == ImageHelpers.ic_on ? true : false;
            IsPool = PoolImage == ImageHelpers.ic_on ? true : false;
            IsGarden = GardenImage == ImageHelpers.ic_on ? true : false;
            IsElevator = ElevatorImage == ImageHelpers.ic_on ? true : false;
            IsCoffee = CoffeeImage == ImageHelpers.ic_on ? true : false;
        }
        #endregion

        #region DoormanCommand
        public Command DoormanCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (DoormanImage == ImageHelpers.ic_off)
                    {
                        DoormanImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        DoormanImage = ImageHelpers.ic_off;
                    }

                    IsDoorman = DoormanImage == ImageHelpers.ic_on ? true : false;
                });
            }
        }
        #endregion

        #region ParkingCommand
        public Command ParkingCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (ParkingImage == ImageHelpers.ic_off)
                    {
                        ParkingImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        ParkingImage = ImageHelpers.ic_off;
                    }

                    IsParking = ParkingImage == ImageHelpers.ic_on ? true : false;
                });
            }
        }
        #endregion

        #region BalconyCommand
        public Command BalconyCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (BalconyImage == ImageHelpers.ic_off)
                    {
                        BalconyImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        BalconyImage = ImageHelpers.ic_off;
                    }

                    IsBalcony = BalconyImage == ImageHelpers.ic_on ? true : false;
                });
            }
        }
        #endregion

        #region DishwasherCommand
        public Command DishwasherCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (DishwasherImage == ImageHelpers.ic_off)
                    {
                        DishwasherImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        DishwasherImage = ImageHelpers.ic_off;
                    }

                    IsDishwasher = DishwasherImage == ImageHelpers.ic_on ? true : false;
                });
            }
        }
        #endregion

        #region PoolCommand
        public Command PoolCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (PoolImage == ImageHelpers.ic_off)
                    {
                        PoolImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        PoolImage = ImageHelpers.ic_off;
                    }

                    IsPool = PoolImage == ImageHelpers.ic_on ? true : false;
                });
            }
        }
        #endregion

        #region GardenCommand
        public Command GardenCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (GardenImage == ImageHelpers.ic_off)
                    {
                        GardenImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        GardenImage = ImageHelpers.ic_off;
                    }

                    IsGarden = GardenImage == ImageHelpers.ic_on ? true : false;
                });
            }
        }
        #endregion

        #region ElevatorCommand
        public Command ElevatorCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (ElevatorImage == ImageHelpers.ic_off)
                    {
                        ElevatorImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        ElevatorImage = ImageHelpers.ic_off;
                    }

                    IsElevator = ElevatorImage == ImageHelpers.ic_on ? true : false;
                });
            }
        }
        #endregion

        #region CoffeeCommand
        public Command CoffeeCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (CoffeeImage == ImageHelpers.ic_off)
                    {
                        CoffeeImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        CoffeeImage = ImageHelpers.ic_off;
                    }

                    IsCoffee = CoffeeImage == ImageHelpers.ic_on ? true : false;
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
                    AddPropertyModel.Doorman = IsDoorman;
                    AddPropertyModel.Parking = IsParking;
                    AddPropertyModel.Pool = IsPool;
                    AddPropertyModel.Dishwasher = IsDishwasher;
                    AddPropertyModel.CoffeeMachine = IsCoffee;
                    AddPropertyModel.Balcony = IsBalcony;
                    AddPropertyModel.Elevator = IsElevator;
                    AddPropertyModel.Garden = IsGarden;

                    var param = new NavigationParameters();
                    param.Add("TransferData", AddPropertyModel);
                    if(SelectedProperty != null)
                    {
                        param.Add("PropertyDetail", SelectedProperty);
                    }
                    await NavigationService.NavigateAsync(nameof(AddPropertyPage4), param);
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
            if (parameters.ContainsKey("PropertyDetail"))
            {
                SelectedProperty = (PropertyModel)parameters["PropertyDetail"];

                DoormanImage = SelectedProperty.Doorman.HasValue && SelectedProperty.Doorman.Value ? ImageHelpers.ic_on : ImageHelpers.ic_off;
                IsDoorman = DoormanImage == ImageHelpers.ic_on ? true : false;

                BalconyImage = SelectedProperty.Balcony.HasValue && SelectedProperty.Balcony.Value ? ImageHelpers.ic_on : ImageHelpers.ic_off;
                IsBalcony = BalconyImage == ImageHelpers.ic_on ? true : false;

                ParkingImage = SelectedProperty.Parking.HasValue && SelectedProperty.Parking.Value ? ImageHelpers.ic_on : ImageHelpers.ic_off;
                IsParking = ParkingImage == ImageHelpers.ic_on ? true : false;

                GardenImage = SelectedProperty.Garden.HasValue && SelectedProperty.Garden.Value ? ImageHelpers.ic_on : ImageHelpers.ic_off;
                IsGarden = GardenImage == ImageHelpers.ic_on ? true : false;

                PoolImage = SelectedProperty.Pool.HasValue && SelectedProperty.Pool.Value ? ImageHelpers.ic_on : ImageHelpers.ic_off;
                IsPool = PoolImage == ImageHelpers.ic_on ? true : false;

                DishwasherImage = SelectedProperty.Dishwasher.HasValue && SelectedProperty.Dishwasher.Value ? ImageHelpers.ic_on : ImageHelpers.ic_off;
                IsDishwasher = DishwasherImage == ImageHelpers.ic_on ? true : false;

                ElevatorImage = SelectedProperty.Elevator.HasValue && SelectedProperty.Elevator.Value ? ImageHelpers.ic_on : ImageHelpers.ic_off;
                IsElevator = ElevatorImage == ImageHelpers.ic_on ? true : false;

                CoffeeImage = SelectedProperty.CoffeeMachine.HasValue && SelectedProperty.CoffeeMachine.Value ? ImageHelpers.ic_on : ImageHelpers.ic_off;
                IsCoffee = CoffeeImage == ImageHelpers.ic_on ? true : false;
            }
        }
    }
}
