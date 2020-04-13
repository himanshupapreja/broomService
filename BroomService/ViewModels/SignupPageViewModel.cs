using Acr.UserDialogs;
using BroomService.Helpers;
using BroomService.Models;
using BroomService.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace BroomService.ViewModels
{
    public class SignupPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;
        private byte[] ProfilepicBytes;

        #region ProfilePic
        private ImageSource _ProfilePic = "ic_default_image.png";
        public ImageSource ProfilePic
        {
            get { return _ProfilePic; }
            set { SetProperty(ref _ProfilePic, value); }
        }
        #endregion

        #region Name
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        #endregion

        #region CompanyName
        private string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set { SetProperty(ref _CompanyName, value); }
        }
        #endregion

        #region Email
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }
        #endregion

        #region PhoneNumber
        private string _PhoneNumber;
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { SetProperty(ref _PhoneNumber, value); }
        }
        #endregion

        #region Password
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
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

        #region BillingAddress
        private string _BillingAddress;
        public string BillingAddress
        {
            get { return _BillingAddress; }
            set { SetProperty(ref _BillingAddress, value); }
        }
        #endregion

        #region CompanyNameToggle
        private string _CompanyNameToggle = ImageHelpers.ic_off;
        public string CompanyNameToggle
        {
            get { return _CompanyNameToggle; }
            set 
            { 
                SetProperty(ref _CompanyNameToggle, value);
                if (!string.IsNullOrEmpty(CompanyNameToggle))
                {
                    IsCompanyName = CompanyNameToggle.Equals(ImageHelpers.ic_off) ? false : true;
                }
            }
        }
        #endregion

        #region BillingAddressToggle
        private string _BillingAddressToggle = ImageHelpers.ic_off;
        public string BillingAddressToggle
        {
            get { return _BillingAddressToggle; }
            set 
            { 
                SetProperty(ref _BillingAddressToggle, value);
                if (!string.IsNullOrEmpty(BillingAddressToggle))
                {
                    IsBillingAddress = BillingAddressToggle.Equals(ImageHelpers.ic_off) ? false : true;
                }
            }
        }
        #endregion

        #region IsCompanyName
        private bool _IsCompanyName;
        public bool IsCompanyName
        {
            get { return _IsCompanyName; }
            set { SetProperty(ref _IsCompanyName, value); }
        }
        #endregion

        #region IsBillingAddress
        private bool _IsBillingAddress;
        public bool IsBillingAddress
        {
            get { return _IsBillingAddress; }
            set { SetProperty(ref _IsBillingAddress, value); }
        }
        #endregion

        #region TermCheckImage
        private string _TermCheckImage = ImageHelpers.ic_checkbox_uncheck;
        public string TermCheckImage
        {
            get { return _TermCheckImage; }
            set { SetProperty(ref _TermCheckImage, value); }
        }
        #endregion

        #region Constructor
        public SignupPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            IsBillingAddress = BillingAddressToggle.Equals(ImageHelpers.ic_off) ? false : true;
            IsCompanyName = CompanyNameToggle.Equals(ImageHelpers.ic_off) ? false : true;
        }
        #endregion

        #region CompanyToggleSwitchCommand
        public Command CompanyToggleSwitchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    CompanyNameToggle = CompanyNameToggle.Equals(ImageHelpers.ic_off) ? ImageHelpers.ic_on : ImageHelpers.ic_off;
                });
            }
        }
        #endregion

        #region BillingToggleSwitchCommand
        public Command BillingToggleSwitchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    BillingAddressToggle = BillingAddressToggle.Equals(ImageHelpers.ic_off) ? ImageHelpers.ic_on : ImageHelpers.ic_off;
                });
            }
        }
        #endregion

        #region TermCheckCommand
        public Command TermCheckCommand
        {
            get
            {
                return new Command(async () =>
                {
                    TermCheckImage = TermCheckImage.Equals(ImageHelpers.ic_checkbox_uncheck) ? ImageHelpers.ic_checkbox_check : ImageHelpers.ic_checkbox_uncheck;
                });
            }
        }
        #endregion

        #region RegisterCommand
        public Command RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (Common.CheckConnection())
                        {
                            if (CheckReuiredFields())
                            {
                                UserDialogs.Instance.ShowLoading();
                                string boundary = "---8d0f01e6b3b5dafaaadaad";
                                MultipartFormDataContent multipartContent = new MultipartFormDataContent(boundary);
                                multipartContent.Add(new StringContent(Name), "FullName");
                                multipartContent.Add(new StringContent(Email), "Email");
                                multipartContent.Add(new StringContent(Password), "Password");
                                //multipartContent.Add(new StringContent(CountryCode), "CountryCode");

                                multipartContent.Add(new StringContent(PhoneNumber), "PhoneNumber");
                                if (!string.IsNullOrEmpty(CompanyName) && !string.IsNullOrWhiteSpace(CompanyName))
                                {
                                    multipartContent.Add(new StringContent(CompanyName), "CompanyName");
                                }
                                multipartContent.Add(new StringContent(Address), "Address");
                                multipartContent.Add(new StringContent(Enums.UserTypeEnum.Customer.GetHashCode().ToString()), "UserType");
                                if (!string.IsNullOrEmpty(BillingAddress) && !string.IsNullOrWhiteSpace(BillingAddress))
                                {
                                    multipartContent.Add(new StringContent(BillingAddress), "BillingAddress");
                                }


                                try
                                {
                                    if (ProfilepicBytes != null)
                                    {
                                        //StreamImageSource streamImageSource = (StreamImageSource)item.ReferenceImages;
                                        //System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
                                        //System.Threading.Tasks.Task<System.IO.Stream> task =
                                        //    streamImageSource.Stream(cancellationToken);
                                        //System.IO.Stream stream = task.Result;

                                        //bitmapData = ReadFully(stream);
                                        var fileContent = new ByteArrayContent(ProfilepicBytes);

                                        fileContent.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/octet-stream");
                                        fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                                        {
                                            Name = "PicturePath",
                                            FileName = "profilepic" + ".png",
                                        };

                                        multipartContent.Add(fileContent);
                                    }
                                }
                                catch (Exception)
                                {
                                }


                                SignupResponseModel response;
                                try
                                {
                                    response = await webApiRestClient.PostAsync<MultipartFormDataContent, SignupResponseModel>(ApiUrl.SignUp, multipartContent);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("SignupApi_Exception:- " + ex.Message);
                                    response = null;
                                }
                                if (response != null)
                                {
                                    if (response.status)
                                    {
                                        //await NavigationService.NavigateAsync(new Uri("/NavigationPage/WelcomePage", UriKind.Absolute));
                                        await NavigationService.GoBackAsync();
                                    }
                                    else
                                    {
                                        await App.Current.MainPage.DisplayAlert("", response.message, "Ok");
                                    }
                                }
                                //await NavigationService.NavigateAsync(nameof(AddPropertyPage));
                            }
                        }
                        else
                        {
                            await MaterialDialog.Instance.SnackbarAsync(StringHelpers.InternetError, 3000);
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

        #region Validation
        protected bool CheckReuiredFields()
        {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrWhiteSpace(PhoneNumber) && !string.IsNullOrEmpty(Name) && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrEmpty(Password) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrEmpty(Address) && !string.IsNullOrWhiteSpace(Address))
            {
                if (CheckBillingAddress() && CheckCompanyName())
                {
                    if (TermCheckImage.Equals(ImageHelpers.ic_checkbox_check))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool CheckCompanyName()
        {
            if (CompanyNameToggle.Equals(ImageHelpers.ic_off))
            {
                return true;
            }
            else if (!string.IsNullOrWhiteSpace(CompanyName) && !string.IsNullOrWhiteSpace(CompanyName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckBillingAddress()
        {
            if (BillingAddressToggle.Equals(ImageHelpers.ic_off))
            {
                return true;
            }
            else if (!string.IsNullOrWhiteSpace(BillingAddress) && !string.IsNullOrWhiteSpace(BillingAddress))
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion

        #region LoginCommand
        public Command LoginCommand
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

        #region TermConditionCommand
        public Command TermConditionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateAsync(nameof(AboutUsPage));
                });
            }
        }
        #endregion

        #region CloseCommand
        public Command CloseCommand
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

        #region ImageUploadCommand

        public Command ImageUploadCommand
        {
            get
            {
                return new Command(async (e) =>
                {
                    try
                    {
                        //if (Device.RuntimePlatform == Device.Android)
                        //{
                        //    DependencyService.Get<IStoragePermissions>().GetGalleryPermissions();
                        //}

                        var action = await App.Current.MainPage.DisplayActionSheet("Add Profile Pic", "Cancel", null, "Camera", "Gallery");

                        MediaFile file;

                        if (action == "Gallery")
                        {
                            await CrossMedia.Current.Initialize();
                            if (!CrossMedia.Current.IsPickPhotoSupported)
                            {
                                return;
                            }
                            byte[] myfile;
                            file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                            {
                                //PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

                            });
                            if (file != null)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    file.GetStream().CopyTo(memoryStream);
                                    ProfilepicBytes = memoryStream.ToArray();
                                }

                            }
                        }
                        else if (action == "Camera")
                        {
                            await CrossMedia.Current.Initialize();
                            if (!CrossMedia.Current.IsTakePhotoSupported)
                            {
                                return;
                            }
                            byte[] myfile;
                            file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                            {
                                Directory = "Profile Photo",
                                SaveToAlbum = true,
                                PhotoSize = PhotoSize.Medium,
                                MaxWidthHeight = 2000,
                                DefaultCamera = CameraDevice.Rear
                            });
                            if (file != null)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    file.GetStream().CopyTo(memoryStream);
                                    ProfilepicBytes = memoryStream.ToArray();
                                }

                            }
                        }
                        else
                        {
                            return;
                        }
                        if (file != null)
                        {
                            ProfilePic = ImageSource.FromStream(() => new MemoryStream(ProfilepicBytes));
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }
        #endregion
    }
}
