using BroomService.Services.ApiService;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroomService.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        protected readonly WebApiRestClient webApiRestClient;
        public static long userId;
        public static string userName;

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { SetProperty(ref _UserName, value); }
        }
        public BaseViewModel()
        {
            webApiRestClient = new WebApiRestClient();

            UserName = userName;
        }
    }
}
