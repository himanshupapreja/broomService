using Acr.UserDialogs;
using BroomService.Helpers;
using BroomService.Models;
using BroomService.Views;
using Plugin.FilePicker;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BroomService.ViewModels
{
    public class PropertyListPageViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService NavigationService;

        #region IsPropertyFilePopup
        private bool _IsPropertyFilePopup = false;
        public bool IsPropertyFilePopup
        {
            get { return _IsPropertyFilePopup; }
            set { SetProperty(ref _IsPropertyFilePopup, value); }
        }
        #endregion

        #region PropertyList
        public ObservableCollection<PropertyModel> AllPropertyList = new ObservableCollection<PropertyModel>();
        private ObservableCollection<PropertyModel> _PropertyList = new ObservableCollection<PropertyModel>();
        public ObservableCollection<PropertyModel> PropertyList
        {
            get { return _PropertyList; }
            set { SetProperty(ref _PropertyList, value); }
        }
        #endregion

        #region SelectedPropertyList
        private PropertyModel _SelectedPropertyList;
        public PropertyModel SelectedPropertyList
        {
            get { return _SelectedPropertyList; }
            set 
            { 
                SetProperty(ref _SelectedPropertyList, value);
                if (SelectedPropertyList != null)
                {
                    var param = new NavigationParameters();
                    param.Add("SelectedPropertyDetail", SelectedPropertyList);
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await NavigationService.NavigateAsync(nameof(PropertyDetailPage),param);
                    });
                }
            }
        }
        #endregion

        #region Constructor
        public PropertyListPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            IsPropertyFilePopup = false;
        }
        #endregion

        #region AddPropertyCommand
        public Command AddPropertyCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var action = await App.Current.MainPage.DisplayActionSheet("Add Property", "Cancel", null, "Add Manual", "Import From File");
                    switch (action)
                    {
                        case "Add Manual":
                            await NavigationService.NavigateAsync(nameof(AddPropertyPage));
                            break;
                        case "Import From File":
                            IsPropertyFilePopup = true;
                            break;
                    }
                });
            }
        }
        #endregion

        #region PropertyFileCommand
        public Command PropertyFileCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        var data = await CrossFilePicker.Current.PickFile();
                        if (data != null)
                        {
                            UserDialogs.Instance.ShowLoading();
                            var extensionList = new List<string>()
                            {
                                ".xls", ".xlsx", ".xlsm", ".xlt", ".xltx", ".xltm", ".xla", ".xlam"
                            };
                            if (Common.FileExtensionCheck(data.FileName, extensionList))
                            {
                                string boundary = "---8d0f01e6b3b5dafaaadaad";
                                MultipartFormDataContent multipartContent = new MultipartFormDataContent(boundary);
                                try
                                {
                                    var fileContent = new ByteArrayContent(data.DataArray);

                                    fileContent.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/octet-stream");
                                    fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                                    {
                                        Name = "ExcelFile",
                                        FileName = "template" + ".xlsx",
                                    };

                                    multipartContent.Add(fileContent);
                                }
                                catch (Exception ex)
                                {
                                }

                                BaseModels response;
                                try
                                {
                                    response = await webApiRestClient.PostAsync<MultipartFormDataContent, BaseModels>(string.Format(ApiUrl.ImportPropertyByExcel, userId), multipartContent);
                                }
                                catch (Exception ex)
                                {
                                    response = null;
                                }
                                
                                if (response != null)
                                {
                                    if (response.status)
                                    {
                                        IsPropertyFilePopup = false;
                                        await NavigationService.NavigateAsync(new Uri("/NavigationPage/WelcomePage", UriKind.Absolute));
                                    }
                                    else
                                    {
                                        await App.Current.MainPage.DisplayAlert("", response.message, "OK");
                                    }
                                }
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("", "Please select valid file", "Ok");
                            }
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

        #region DownloadSampleFileCommand
        public Command DownloadSampleFileCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Launcher.OpenAsync(ApiUrl.TemplateUrl);
                });
            }
        }
        #endregion

        #region PropertyCloseCommand
        public Command PropertyCloseCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsPropertyFilePopup = false;
                });
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

        #region RightIconCommand
        public Command RightIconCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateAsync(nameof(NotificationPage));
                });
            }
        }

        #endregion

        #region InavigationAware
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("PropertyList"))
            {
                PropertyList = (ObservableCollection<PropertyModel>)parameters["PropertyList"];
            }
        }
        #endregion
    }
}
