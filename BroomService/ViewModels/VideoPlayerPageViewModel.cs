using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BroomService.ViewModels
{
    public class VideoPlayerPageViewModel : BindableBase, INavigationAware
    {
        #region VideoSource
        private string _VideoSource;
        public string VideoSource
        {
            get { return _VideoSource; }
            set { SetProperty(ref _VideoSource, value); }
        }
        #endregion

        public VideoPlayerPageViewModel()
        {

        }

        #region Navigation Aware Methods
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("TransferData"))
            {
                VideoSource = (string)parameters["TransferData"];
            }
        }
        #endregion
    }
}
