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
        public BaseViewModel()
        {
            webApiRestClient = new WebApiRestClient();
        }
    }
}
