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
    public class AddPropertyPage4ViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService NavigationService;
        AddPropertyModel AddPropertyModel;
        string Size;
        string Bedroom;
        string Bathroom;
        string Toilets;
        bool IsKingBedVisible;

        #region Bathroom1RadioButtonImage
        private string _Bathroom1RadioButtonImage = ImageHelpers.ic_radio_select;
        public string Bathroom1RadioButtonImage
        {
            get { return _Bathroom1RadioButtonImage; }
            set { SetProperty(ref _Bathroom1RadioButtonImage, value); }
        }
        #endregion

        #region Bathroom2RadioButtonImage
        private string _Bathroom2RadioButtonImage = ImageHelpers.ic_radio_unselect;
        public string Bathroom2RadioButtonImage
        {
            get { return _Bathroom2RadioButtonImage; }
            set { SetProperty(ref _Bathroom2RadioButtonImage, value); }
        }
        #endregion

        #region Bathroom3RadioButtonImage
        private string _Bathroom3RadioButtonImage = ImageHelpers.ic_radio_unselect;
        public string Bathroom3RadioButtonImage
        {
            get { return _Bathroom3RadioButtonImage; }
            set { SetProperty(ref _Bathroom3RadioButtonImage, value); }
        }
        #endregion

        #region BathroomMoreRadioButtonImage
        private string _BathroomMoreRadioButtonImage = ImageHelpers.ic_radio_unselect;
        public string BathroomMoreRadioButtonImage
        {
            get { return _BathroomMoreRadioButtonImage; }
            set { SetProperty(ref _BathroomMoreRadioButtonImage, value); }
        }
        #endregion

        #region IsMoreBathroomVisible
        private bool _IsMoreBathroomVisible = false;
        public bool IsMoreBathroomVisible
        {
            get { return _IsMoreBathroomVisible; }
            set { SetProperty(ref _IsMoreBathroomVisible, value); }
        }
        #endregion

        #region BathroomList Picker static value
        public List<string> _BathroomList = new List<string> {
            "4","5","6","7","8","9","10"
        };
        public List<string> BathroomList => _BathroomList;
        #endregion

        #region BathroomSelected SelectedItem property
        private string _BathroomSelected;
        public string BathroomSelected
        {
            get => _BathroomSelected;
            set 
            { 
                SetProperty(ref _BathroomSelected, value); 
                if(BathroomSelected != null)
                {
                    Bathroom = BathroomSelected;
                }
            }
        }
        #endregion

        #region BathroomIndexSelected SelectedItem property
        private int _BathroomIndexSelected = 0;
        public int BathroomIndexSelected
        {
            get => _BathroomIndexSelected;
            set { SetProperty(ref _BathroomIndexSelected, value); }
        }
        #endregion




        #region Toilets1RadioButtonImage
        private string _Toilets1RadioButtonImage = ImageHelpers.ic_radio_select;
        public string Toilets1RadioButtonImage
        {
            get { return _Toilets1RadioButtonImage; }
            set { SetProperty(ref _Toilets1RadioButtonImage, value); }
        }
        #endregion

        #region Toilets2RadioButtonImage
        private string _Toilets2RadioButtonImage = ImageHelpers.ic_radio_unselect;
        public string Toilets2RadioButtonImage
        {
            get { return _Toilets2RadioButtonImage; }
            set { SetProperty(ref _Toilets2RadioButtonImage, value); }
        }
        #endregion

        #region Toilets3RadioButtonImage
        private string _Toilets3RadioButtonImage = ImageHelpers.ic_radio_unselect;
        public string Toilets3RadioButtonImage
        {
            get { return _Toilets3RadioButtonImage; }
            set { SetProperty(ref _Toilets3RadioButtonImage, value); }
        }
        #endregion

        #region ToiletsMoreRadioButtonImage
        private string _ToiletsMoreRadioButtonImage = ImageHelpers.ic_radio_unselect;
        public string ToiletsMoreRadioButtonImage
        {
            get { return _ToiletsMoreRadioButtonImage; }
            set { SetProperty(ref _ToiletsMoreRadioButtonImage, value); }
        }
        #endregion

        #region IsMoreToiletVisible
        private bool _IsMoreToiletVisible = false;
        public bool IsMoreToiletVisible
        {
            get { return _IsMoreToiletVisible; }
            set { SetProperty(ref _IsMoreToiletVisible, value); }
        }
        #endregion

        #region ToiletList Picker static value
        public List<string> _ToiletList = new List<string> {
            "4","5","6","7","8","9","10"
        };
        public List<string> ToiletList => _ToiletList;
        #endregion

        #region ToiletSelected SelectedItem property
        private string _ToiletSelected;
        public string ToiletSelected
        {
            get => _ToiletSelected;
            set 
            { 
                SetProperty(ref _ToiletSelected, value); 
                if(ToiletSelected != null)
                {
                    Toilets = ToiletSelected;
                }
            }
        }
        #endregion

        #region ToiletIndexSelected SelectedItem property
        private int _ToiletIndexSelected = 0;
        public int ToiletIndexSelected
        {
            get => _ToiletIndexSelected;
            set { SetProperty(ref _ToiletIndexSelected, value); }
        }
        #endregion


        

        #region Bedroom1RadioButtonImage
        private string _Bedroom1RadioButtonImage = ImageHelpers.ic_radio_select;
        public string Bedroom1RadioButtonImage
        {
            get { return _Bedroom1RadioButtonImage; }
            set { SetProperty(ref _Bedroom1RadioButtonImage, value); }
        }
        #endregion

        #region Bedroom2RadioButtonImage
        private string _Bedroom2RadioButtonImage = ImageHelpers.ic_radio_unselect;
        public string Bedroom2RadioButtonImage
        {
            get { return _Bedroom2RadioButtonImage; }
            set { SetProperty(ref _Bedroom2RadioButtonImage, value); }
        }
        #endregion

        #region Bedroom3RadioButtonImage
        private string _Bedroom3RadioButtonImage = ImageHelpers.ic_radio_unselect;
        public string Bedroom3RadioButtonImage
        {
            get { return _Bedroom3RadioButtonImage; }
            set { SetProperty(ref _Bedroom3RadioButtonImage, value); }
        }
        #endregion

        #region BedroomMoreRadioButtonImage
        private string _BedroomMoreRadioButtonImage = ImageHelpers.ic_radio_unselect;
        public string BedroomMoreRadioButtonImage
        {
            get { return _BedroomMoreRadioButtonImage; }
            set { SetProperty(ref _BedroomMoreRadioButtonImage, value); }
        }
        #endregion

        #region IsMoreBedroomVisible
        private bool _IsMoreBedroomVisible = false;
        public bool IsMoreBedroomVisible
        {
            get { return _IsMoreBedroomVisible; }
            set { SetProperty(ref _IsMoreBedroomVisible, value); }
        }
        #endregion

        #region BedroomList Picker static value
        public List<string> _BedroomList = new List<string> {
            "4","5","6","7","8","9","10"
        };
        public List<string> BedroomList => _BedroomList;
        #endregion

        #region BedroomSelected SelectedItem property
        private string _BedroomSelected;
        public string BedroomSelected
        {
            get => _BedroomSelected;
            set 
            { 
                SetProperty(ref _BedroomSelected, value); 
                if(BedroomSelected != null)
                {
                    Bedroom = BedroomSelected;
                }
            }
        }
        #endregion

        #region BedroomIndexSelected SelectedItem property
        private int _BedroomIndexSelected = 0;
        public int BedroomIndexSelected
        {
            get => _BedroomIndexSelected;
            set { SetProperty(ref _BedroomIndexSelected, value); }
        }
        #endregion



        #region Size1RadioButtonImage
        private string _Size1RadioButtonImage = ImageHelpers.ic_radio_select;
        public string Size1RadioButtonImage
        {
            get { return _Size1RadioButtonImage; }
            set { SetProperty(ref _Size1RadioButtonImage, value); }
        }
        #endregion

        #region Size2RadioButtonImage
        private string _Size2RadioButtonImage = ImageHelpers.ic_radio_unselect;
        public string Size2RadioButtonImage
        {
            get { return _Size2RadioButtonImage; }
            set { SetProperty(ref _Size2RadioButtonImage, value); }
        }
        #endregion

        #region Size3RadioButtonImage
        private string _Size3RadioButtonImage = ImageHelpers.ic_radio_unselect;
        public string Size3RadioButtonImage
        {
            get { return _Size3RadioButtonImage; }
            set { SetProperty(ref _Size3RadioButtonImage, value); }
        }
        #endregion

        #region Size4RadioButtonImage
        private string _Size4RadioButtonImage = ImageHelpers.ic_radio_unselect;
        public string Size4RadioButtonImage
        {
            get { return _Size4RadioButtonImage; }
            set { SetProperty(ref _Size4RadioButtonImage, value); }
        }
        #endregion

        #region IsMoreSizeVisible
        private bool _IsMoreSizeVisible = false;
        public bool IsMoreSizeVisible
        {
            get { return _IsMoreSizeVisible; }
            set { SetProperty(ref _IsMoreSizeVisible, value); }
        } 
        #endregion

        #region Size Picker static value
        public List<string> _SizeList = new List<string> {
            "100-120","125-150","160-190","200-250","260-350"
        };
        public List<string> SizeList => _SizeList;
        #endregion

        #region SizeListSelected SelectedItem property
        private string _SizeListSelected;
        public string SizeListSelected
        {
            get => _SizeListSelected;
            set 
            { 
                SetProperty(ref _SizeListSelected, value); 
                if(SizeListSelected != null)
                {
                    Size = SizeListSelected;
                }
            }
        }
        #endregion

        #region SizeListIndexSelected SelectedItem property
        private int _SizeListIndexSelected = 0;
        public int SizeListIndexSelected
        {
            get => _SizeListIndexSelected;
            set { SetProperty(ref _SizeListIndexSelected, value); }
        }
        #endregion





        #region IsSingleBedCountVisible
        private bool _IsSingleBedCountVisible = false;
        public bool IsSingleBedCountVisible
        {
            get { return _IsSingleBedCountVisible; }
            set { SetProperty(ref _IsSingleBedCountVisible, value); }
        }
        #endregion

        #region IsSofaBedCountVisible
        private bool _IsSofaBedCountVisible = false;
        public bool IsSofaBedCountVisible
        {
            get { return _IsSofaBedCountVisible; }
            set { SetProperty(ref _IsSofaBedCountVisible, value); }
        }
        #endregion

        #region IsDoubleBedCountVisible
        private bool _IsDoubleBedCountVisible = false;
        public bool IsDoubleBedCountVisible
        {
            get { return _IsDoubleBedCountVisible; }
            set { SetProperty(ref _IsDoubleBedCountVisible, value); }
        }
        #endregion

        #region DoubleSofaBedCount
        private int _DoubleSofaBedCount = 0;
        public int DoubleSofaBedCount
        {
            get { return _DoubleSofaBedCount; }
            set { SetProperty(ref _DoubleSofaBedCount, value); }
        }
        #endregion

        #region SingleSofaBedCount
        private int _SingleSofaBedCount = 0;
        public int SingleSofaBedCount
        {
            get { return _SingleSofaBedCount; }
            set { SetProperty(ref _SingleSofaBedCount, value); }
        }
        #endregion

        #region SingleBedCount
        private int _SingleBedCount = 0;
        public int SingleBedCount
        {
            get { return _SingleBedCount; }
            set { SetProperty(ref _SingleBedCount, value); }
        }
        #endregion

        #region DoubleBedCount
        private int _DoubleBedCount = 0;
        public int DoubleBedCount
        {
            get { return _DoubleBedCount; }
            set { SetProperty(ref _DoubleBedCount, value); }
        }
        #endregion

        #region KingBedImage
        private string _KingBedImage = ImageHelpers.ic_off;
        public string KingBedImage
        {
            get { return _KingBedImage; }
            set 
            { 
                SetProperty(ref _KingBedImage, value);
                if (KingBedImage.Equals(ImageHelpers.ic_on))
                {
                    IsKingBedVisible = true;
                }
                else
                {
                    IsKingBedVisible = false;
                }
            }
        }
        #endregion

        #region SingleBedImage
        private string _SingleBedImage = ImageHelpers.ic_off;
        public string SingleBedImage
        {
            get { return _SingleBedImage; }
            set 
            { 
                SetProperty(ref _SingleBedImage, value);
                if (SingleBedImage.Equals(ImageHelpers.ic_on))
                {
                    IsSingleBedCountVisible = true;
                }
                else
                {
                    IsSingleBedCountVisible = false;
                }
            }
        }
        #endregion

        #region SofaBedImage
        private string _SofaBedImage = ImageHelpers.ic_off;
        public string SofaBedImage
        {
            get { return _SofaBedImage; }
            set 
            { 
                SetProperty(ref _SofaBedImage, value);
                if (SofaBedImage.Equals(ImageHelpers.ic_on))
                {
                    IsSofaBedCountVisible = true;
                }
                else
                {
                    IsSofaBedCountVisible = false;
                }
            }
        }
        #endregion

        #region DoubleBedImage
        private string _DoubleBedImage = ImageHelpers.ic_off;
        public string DoubleBedImage
        {
            get { return _DoubleBedImage; }
            set 
            { 
                SetProperty(ref _DoubleBedImage, value);
                if (DoubleBedImage.Equals(ImageHelpers.ic_on))
                {
                    IsDoubleBedCountVisible = true;
                }
                else
                {
                    IsDoubleBedCountVisible = false;
                }
            }
        }
        #endregion


        #region IsPropertyPopupVisible
        private bool _IsPropertyPopupVisible;
        public bool IsPropertyPopupVisible
        {
            get { return _IsPropertyPopupVisible; }
            set { SetProperty(ref _IsPropertyPopupVisible, value); }
        }
        #endregion

        #region Constructor
        public AddPropertyPage4ViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            IsPropertyPopupVisible = false;

            Size = "20-40";
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

        #region Size1RadioButtonCommand
        public Command Size1RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    IsMoreSizeVisible = false;
                    Size1RadioButtonImage = ImageHelpers.ic_radio_select;
                    Size2RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Size3RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Size4RadioButtonImage = ImageHelpers.ic_radio_unselect;

                    Size = e.ToString();
                });
            }
        }
        #endregion

        #region Size2RadioButtonCommand
        public Command Size2RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    IsMoreSizeVisible = false;
                    Size2RadioButtonImage = ImageHelpers.ic_radio_select;
                    Size1RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Size3RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Size4RadioButtonImage = ImageHelpers.ic_radio_unselect;

                    Size = e.ToString();
                });
            }
        }
        #endregion

        #region Size3RadioButtonCommand
        public Command Size3RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    IsMoreSizeVisible = false;
                    Size3RadioButtonImage = ImageHelpers.ic_radio_select;
                    Size2RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Size1RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Size4RadioButtonImage = ImageHelpers.ic_radio_unselect;

                    Size = e.ToString();
                });
            }
        }
        #endregion

        #region Size4RadioButtonCommand
        public Command Size4RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    Size4RadioButtonImage = ImageHelpers.ic_radio_select;
                    Size2RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Size3RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Size1RadioButtonImage = ImageHelpers.ic_radio_unselect;

                    SizeListIndexSelected = 0;
                    IsMoreSizeVisible = true;
                    Size = SizeListSelected;
                });
            }
        }
        #endregion


        #region Bedroom1RadioButtonCommand
        public Command Bedroom1RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    IsMoreBedroomVisible = false;
                    Bedroom1RadioButtonImage = ImageHelpers.ic_radio_select;
                    Bedroom2RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Bedroom3RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    BedroomMoreRadioButtonImage = ImageHelpers.ic_radio_unselect;

                    Bedroom = e.ToString();
                });
            }
        }
        #endregion

        #region Bedroom2RadioButtonCommand
        public Command Bedroom2RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    IsMoreBedroomVisible = false;
                    Bedroom2RadioButtonImage = ImageHelpers.ic_radio_select;
                    Bedroom1RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Bedroom3RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    BedroomMoreRadioButtonImage = ImageHelpers.ic_radio_unselect;

                    Bedroom = e.ToString();
                });
            }
        }
        #endregion

        #region Bedroom3RadioButtonCommand
        public Command Bedroom3RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    IsMoreBedroomVisible = false;
                    Bedroom3RadioButtonImage = ImageHelpers.ic_radio_select;
                    Bedroom2RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Bedroom1RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    BedroomMoreRadioButtonImage = ImageHelpers.ic_radio_unselect;

                    Bedroom = e.ToString();
                });
            }
        }
        #endregion

        #region BedroomMoreRadioButtonCommand
        public Command BedroomMoreRadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    BedroomMoreRadioButtonImage = ImageHelpers.ic_radio_select;
                    Bedroom2RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Bedroom3RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Bedroom1RadioButtonImage = ImageHelpers.ic_radio_unselect;

                    BedroomIndexSelected = 0;
                    IsMoreBedroomVisible = true;
                    Bedroom = BedroomSelected;
                });
            }
        }
        #endregion



        #region Bathroom1RadioButtonCommand
        public Command Bathroom1RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    IsMoreBathroomVisible = false;
                    Bathroom1RadioButtonImage = ImageHelpers.ic_radio_select;
                    Bathroom2RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Bathroom3RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    BathroomMoreRadioButtonImage = ImageHelpers.ic_radio_unselect;

                    Bathroom = e.ToString();
                });
            }
        }
        #endregion

        #region Bathroom2RadioButtonCommand
        public Command Bathroom2RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    IsMoreBathroomVisible = false;
                    Bathroom2RadioButtonImage = ImageHelpers.ic_radio_select;
                    Bathroom1RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Bathroom3RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    BathroomMoreRadioButtonImage = ImageHelpers.ic_radio_unselect;

                    Bathroom = e.ToString();
                });
            }
        }
        #endregion

        #region Bathroom3RadioButtonCommand
        public Command Bathroom3RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    IsMoreBathroomVisible = false;
                    Bathroom3RadioButtonImage = ImageHelpers.ic_radio_select;
                    Bathroom2RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Bathroom1RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    BathroomMoreRadioButtonImage = ImageHelpers.ic_radio_unselect;

                    Bathroom = e.ToString();
                });
            }
        }
        #endregion

        #region BathroomMoreRadioButtonCommand
        public Command BathroomMoreRadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    BathroomMoreRadioButtonImage = ImageHelpers.ic_radio_select;
                    Bathroom2RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Bathroom3RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Bathroom1RadioButtonImage = ImageHelpers.ic_radio_unselect;

                    BathroomIndexSelected = 0;
                    IsMoreBathroomVisible = true;
                    Bathroom = BathroomSelected;
                });
            }
        }
        #endregion




        #region Toilets1RadioButtonCommand
        public Command Toilets1RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    IsMoreToiletVisible = false;
                    Toilets1RadioButtonImage = ImageHelpers.ic_radio_select;
                    Toilets2RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Toilets3RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    ToiletsMoreRadioButtonImage = ImageHelpers.ic_radio_unselect;

                    Toilets = e.ToString();
                });
            }
        }
        #endregion

        #region Toilets2RadioButtonCommand
        public Command Toilets2RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    IsMoreToiletVisible = false;
                    Toilets2RadioButtonImage = ImageHelpers.ic_radio_select;
                    Toilets1RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Toilets3RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    ToiletsMoreRadioButtonImage = ImageHelpers.ic_radio_unselect;

                    Toilets = e.ToString();
                });
            }
        }
        #endregion

        #region Toilets3RadioButtonCommand
        public Command Toilets3RadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    IsMoreToiletVisible = false;
                    Toilets3RadioButtonImage = ImageHelpers.ic_radio_select;
                    Toilets2RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Toilets1RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    ToiletsMoreRadioButtonImage = ImageHelpers.ic_radio_unselect;

                    Toilets = e.ToString();
                });
            }
        }
        #endregion

        #region ToiletsMoreRadioButtonCommand
        public Command ToiletsMoreRadioButtonCommand
        {
            get
            {
                return new Command((e) =>
                {
                    ToiletsMoreRadioButtonImage = ImageHelpers.ic_radio_select;
                    Toilets2RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Toilets3RadioButtonImage = ImageHelpers.ic_radio_unselect;
                    Toilets1RadioButtonImage = ImageHelpers.ic_radio_unselect;

                    ToiletIndexSelected = 0;
                    IsMoreToiletVisible = true;
                    Toilets = ToiletSelected;
                });
            }
        }
        #endregion





        #region KingBedImageCommand
        public Command KingBedImageCommand
        {
            get
            {
                return new Command((e) =>
                {
                    if (KingBedImage.Equals(ImageHelpers.ic_off))
                    {
                        KingBedImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        KingBedImage = ImageHelpers.ic_off;
                    }
                });
            }
        }
        #endregion

        #region SingleBedImageCommand
        public Command SingleBedImageCommand
        {
            get
            {
                return new Command((e) =>
                {
                    if (SingleBedImage.Equals(ImageHelpers.ic_off))
                    {
                        SingleBedImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        SingleBedImage = ImageHelpers.ic_off;
                    }
                });
            }
        }
        #endregion

        #region SofaBedImageCommand
        public Command SofaBedImageCommand
        {
            get
            {
                return new Command((e) =>
                {
                    if (SofaBedImage.Equals(ImageHelpers.ic_off))
                    {
                        SofaBedImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        SofaBedImage = ImageHelpers.ic_off;
                    }
                });
            }
        }
        #endregion

        #region DoubleBedCountCommand
        public Command DoubleBedCountCommand
        {
            get
            {
                return new Command((e) =>
                {
                    if (DoubleBedImage.Equals(ImageHelpers.ic_off))
                    {
                        DoubleBedImage = ImageHelpers.ic_on;
                    }
                    else
                    {
                        DoubleBedImage = ImageHelpers.ic_off;
                    }
                });
            }
        }
        #endregion

        #region SingleBedcountMinusCommand
        public Command SingleBedcountMinusCommand
        {
            get
            {
                return new Command((e) =>
                {
                    if (SingleBedCount > 0)
                    {
                        SingleBedCount = SingleBedCount - 1; 
                    }
                });
            }
        }
        #endregion

        #region SingleBedcountPlusCommand
        public Command SingleBedcountPlusCommand
        {
            get
            {
                return new Command((e) =>
                {
                    SingleBedCount = SingleBedCount + 1;
                });
            }
        }
        #endregion

        #region SingleSofaBedcountMinusCommand
        public Command SingleSofaBedcountMinusCommand
        {
            get
            {
                return new Command((e) =>
                {
                    if (SingleSofaBedCount > 0)
                    {
                        SingleSofaBedCount = SingleSofaBedCount - 1; 
                    }
                });
            }
        }
        #endregion

        #region SingleSofaBedcountPlusCommand
        public Command SingleSofaBedcountPlusCommand
        {
            get
            {
                return new Command((e) =>
                {
                    SingleSofaBedCount = SingleSofaBedCount + 1;
                });
            }
        }
        #endregion

        #region DoubleSofaBedcountMinusCommand
        public Command DoubleSofaBedcountMinusCommand
        {
            get
            {
                return new Command((e) =>
                {
                    if (DoubleSofaBedCount > 0)
                    {
                        DoubleSofaBedCount = DoubleSofaBedCount - 1; 
                    }
                });
            }
        }
        #endregion

        #region DoubleSofaBedcountPlusCommand
        public Command DoubleSofaBedcountPlusCommand
        {
            get
            {
                return new Command((e) =>
                {
                    DoubleSofaBedCount = DoubleSofaBedCount + 1;
                });
            }
        }
        #endregion

        #region DoubleBedcountMinusCommand
        public Command DoubleBedcountMinusCommand
        {
            get
            {
                return new Command((e) =>
                {
                    if (DoubleBedCount > 0)
                    {
                        DoubleBedCount = DoubleBedCount - 1; 
                    }
                });
            }
        }
        #endregion

        #region DoubleBedcountPlusCommand
        public Command DoubleBedcountPlusCommand
        {
            get
            {
                return new Command((e) =>
                {
                    DoubleBedCount = DoubleBedCount + 1;
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
                    //IsPropertyPopupVisible = true;
                    AddPropertyModel.Size = Size;
                    AddPropertyModel.IsKingBed = IsKingBedVisible;
                    AddPropertyModel.IsSingleBed = IsSingleBedCountVisible;
                    AddPropertyModel.IsSofaBed = IsSofaBedCountVisible;
                    AddPropertyModel.NoOfToilets = Toilets;
                    AddPropertyModel.NoOfSingleSofaBeds = SingleSofaBedCount.ToString();
                    AddPropertyModel.NoOfSingleBeds = SingleBedCount.ToString();
                    AddPropertyModel.NoOfQueenBeds = DoubleBedCount.ToString();
                    AddPropertyModel.NoOfDoubleSofaBeds = DoubleSofaBedCount.ToString();
                    AddPropertyModel.NoOfDoubleBeds = DoubleBedCount.ToString();
                    AddPropertyModel.NoOfBedRooms = Bedroom;
                    AddPropertyModel.NoOfBathrooms = Bathroom;

                    var param = new NavigationParameters();
                    param.Add("TransferData", AddPropertyModel);
                    await NavigationService.NavigateAsync(nameof(AddPropertyPage5), param);
                    //await NavigationService.NavigateAsync(nameof(AddPropertyPage4));
                });
            }
        }
        #endregion

        #region PropertyCompleteCommand
        public Command PropertyCompleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsPropertyPopupVisible = false;
                    await NavigationService.NavigateAsync(nameof(WelcomePage));
                });
            }
        }
        #endregion

        #region Navigation Aware Methods
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
        #endregion
    }
}
