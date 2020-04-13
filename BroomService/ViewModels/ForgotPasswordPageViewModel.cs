using Acr.UserDialogs;
using BroomService.Helpers;
using BroomService.Models;
using BroomService.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace BroomService.ViewModels
{
    public class ForgotPasswordPageViewModel : BaseViewModel
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

        #region Constructor
        public ForgotPasswordPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        #endregion

        #region ForgotCommand
        public Command ForgotCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (Common.CheckConnection())
                        {
                            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrWhiteSpace(Email))
                            {
                                UserDialogs.Instance.ShowLoading();
                                ForgotPasswordRequestModel request = new ForgotPasswordRequestModel()
                                {
                                    Email = Email,
                                };
                                BaseModels response;
                                try
                                {
                                    response = await webApiRestClient.PostAsync<ForgotPasswordRequestModel, BaseModels>(ApiUrl.ForgetPassword, request);
                                }
                                catch (Exception ex)
                                {
                                    response = null;
                                }
                                if (response != null)
                                {
                                    if (response.status)
                                    {
                                        await App.Current.MainPage.DisplayAlert("", response.message, "OK");
                                        await NavigationService.NavigateAsync(nameof(LoginPage));
                                    }
                                    else
                                    {
                                        await App.Current.MainPage.DisplayAlert("Alert", response.message, "OK");
                                    }
                                }
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
