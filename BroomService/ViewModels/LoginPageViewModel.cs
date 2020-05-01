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
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF.Material.Forms.Dialogs;
using XF.Material.Forms.UI.Dialogs;

namespace BroomService.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;

        #region Email
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
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

        #region Constructor
        public LoginPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        } 
        #endregion

        #region SignupCommand
        public Command SignupCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateAsync(nameof(SignupPage));
                });
            }
        }
        #endregion

        #region ForgotPasswordCommand
        public Command ForgotPasswordCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateAsync(nameof(ForgotPasswordPage));
                });
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
                    try
                    {
                        if (Common.CheckConnection())
                        {
                            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrWhiteSpace(Password))
                            {
                                UserDialogs.Instance.ShowLoading();
                                LoginRequestModel request = new LoginRequestModel()
                                {
                                    Email = Email,
                                    Password = Password
                                };
                                LoginResponseModel response;
                                try
                                {
                                    response = await webApiRestClient.PostAsync<LoginRequestModel, LoginResponseModel>(ApiUrl.Login, request);
                                }
                                catch (Exception ex)
                                {
                                    response = null;
                                }
                                if (response != null)
                                {
                                    if (response.status)
                                    {
                                        var loginData = JsonConvert.SerializeObject(response);
                                        await SecureStorage.SetAsync("LoginData", loginData);

                                        userId = response.userData.UserId;
                                        userName = response.userData.FullName;
                                        await NavigationService.NavigateAsync(new Uri("/NavigationPage/WelcomePage", UriKind.Absolute));
                                    }
                                    else
                                    {
                                        await MaterialDialog.Instance.SnackbarAsync(response.message, 3000);
                                    }
                                }
                            }
                            else
                            {
                                await MaterialDialog.Instance.SnackbarAsync("Please enter email and password", 3000);
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
    }
}
