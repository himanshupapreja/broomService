using BroomService.CustomControls;
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
    public class PrivacyPolicyViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;
        private HtmlToText htmlToText;

        #region PrivacyPolicyText
        private string _PrivacyPolicyText;
        public string PrivacyPolicyText
        {
            get { return _PrivacyPolicyText; }
            set { SetProperty(ref _PrivacyPolicyText, value); }
        }
        #endregion

        #region IsNodataFound
        private bool _IsNodataFound;
        public bool IsNodataFound
        {
            get { return _IsNodataFound; }
            set { SetProperty(ref _IsNodataFound, value); }
        }
        #endregion

        #region Constructor
        public PrivacyPolicyViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            htmlToText = new HtmlToText();
            IsNodataFound = false;

            GetPrivacyPolicy();
        }
        #endregion

        #region GetPrivacyPolicy
        public async void GetPrivacyPolicy()
        {
            PrivacyPolicyResponseModel response;
            try
            {
                response = await webApiRestClient.GetAsync<PrivacyPolicyResponseModel>(ApiUrl.GetPrivacyPolicy);
            }
            catch
            {
                response = null;
            }
            if (response != null)
            {
                if (response.status)
                {
                    PrivacyPolicyText = htmlToText.Convert(response.PrivacyPolicyData.PrivacyPolicyText);
                }
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
    }
}
