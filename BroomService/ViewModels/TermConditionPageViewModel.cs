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
    public class TermConditionPageViewModel : BaseViewModel
    {
        private readonly INavigationService NavigationService;
        private HtmlToText htmlToText;

        #region TermConditionText
        private string _TermConditionText;
        public string TermConditionText
        {
            get { return _TermConditionText; }
            set { SetProperty(ref _TermConditionText, value); }
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
        public TermConditionPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            htmlToText = new HtmlToText();
            IsNodataFound = false;

            GetTermCondition();
        }
        #endregion

        #region GetTermCondition
        public async void GetTermCondition()
        {
            TermConditionResponseModel response;
            try
            {
                response = await webApiRestClient.GetAsync<TermConditionResponseModel>(ApiUrl.GetTermsConditions);
            }
            catch
            {
                response = null;
            }
            if(response != null)
            {
                if (response.status)
                {
                    TermConditionText = htmlToText.Convert(response.TermsConditionsData.TermsConditionText);
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
