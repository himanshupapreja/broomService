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
    public class AboutUsPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;
        private HtmlToText htmlToText;

        #region AboutUsText
        private string _AboutUsText;
        public string AboutUsText
        {
            get { return _AboutUsText; }
            set { SetProperty(ref _AboutUsText, value); }
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
        public AboutUsPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            htmlToText = new HtmlToText();
            IsNodataFound = false;

            GetAboutUs();
        }
        #endregion

        #region GetAboutUs
        public async void GetAboutUs()
        {
            AboutUsResponseModel response;
            try
            {
                response = await webApiRestClient.GetAsync<AboutUsResponseModel>(ApiUrl.GetAboutus);
            }
            catch
            {
                response = null;
            }
            if (response != null)
            {
                if (response.status)
                {
                    AboutUsText = htmlToText.Convert(response.AboutUsData.Text);
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
