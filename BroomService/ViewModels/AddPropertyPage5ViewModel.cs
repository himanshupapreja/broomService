using Acr.UserDialogs;
using BroomService.DependancyInterface;
using BroomService.Helpers;
using BroomService.Models;
using BroomService.Views;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;

namespace BroomService.ViewModels
{
    public class AddPropertyPage5ViewModel : BaseViewModel, INavigationAware
    {
        int propertyResponse;
        private readonly INavigationService NavigationService;
        PropertyModel SelectedProperty;
        bool isVideoPageOpen = false;
        AddPropertyModel AddPropertyModel;
        byte[] thumbnailstream;
        IConverterVideoThumbnails videoThumbnails;
        byte[] myfile;

        #region PropertyUsername
        private string _PropertyUsername;
        public string PropertyUsername
        {
            get { return _PropertyUsername; }
            set { SetProperty(ref _PropertyUsername, value); }
        }
        #endregion

        #region PropertyPassword
        private string _PropertyPassword;
        public string PropertyPassword
        {
            get { return _PropertyPassword; }
            set { SetProperty(ref _PropertyPassword, value); }
        }
        #endregion

        #region IsPropertyPopupVisible
        private bool _IsPropertyPopupVisible = false;
        public bool IsPropertyPopupVisible
        {
            get { return _IsPropertyPopupVisible; }
            set { SetProperty(ref _IsPropertyPopupVisible, value); }
        }
        #endregion

        #region PropertyList
        public ObservableCollection<PropertyUploadFileModel> AllPropertyImageList = new ObservableCollection<PropertyUploadFileModel>();
        private ObservableCollection<PropertyUploadFileModel> _PropertyImageList = new ObservableCollection<PropertyUploadFileModel>();
        public ObservableCollection<PropertyUploadFileModel> PropertyImageList
        {
            get { return _PropertyImageList; }
            set { SetProperty(ref _PropertyImageList, value); }
        }
        #endregion

        #region Constructor
        public AddPropertyPage5ViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            propertyResponse = 0;
            videoThumbnails = DependencyService.Get<IConverterVideoThumbnails>();
        }
        #endregion

        #region UploadImageVideoCommand
        public Command UploadImageVideoCommand
        {
            get
            {
                return new Command(async (e) =>
                {
                    try
                    {
                        bool IsVideo = false;
                        var action = await App.Current.MainPage.DisplayActionSheet("Choose the file", "Cancel", null, "Images", "Videos");

                        MediaFile file;

                        if (action == "Images")
                        {
                            IsVideo = false;
                            await CrossMedia.Current.Initialize();
                            if (!CrossMedia.Current.IsPickPhotoSupported)
                            {
                                return;
                            }
                            file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                            {
                                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

                            });
                            if (file != null)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    file.GetStream().CopyTo(memoryStream);
                                    myfile = memoryStream.ToArray();
                                }
                            }
                        }
                        else if (action == "Videos")
                        {
                            IsVideo = true;
                            await CrossMedia.Current.Initialize();
                            if (!CrossMedia.Current.IsPickVideoSupported)
                            {
                                return;
                            }
                            file = await CrossMedia.Current.PickVideoAsync();
                            if (file != null)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    file.GetStream().CopyTo(memoryStream);
                                    myfile = memoryStream.ToArray();
                                }
                            }
                        }
                        else
                        {
                            IsVideo = false;
                            return;
                        }
                        if (file != null)
                        {
                            if (IsVideo)
                            {
                                thumbnailstream = videoThumbnails.Getthumbnails(file.Path);
                            }

                            try
                            {
                                AllPropertyImageList.Add(new PropertyUploadFileModel
                                {
                                    upload_Image = IsVideo ?  ImageSource.FromStream(() => new MemoryStream(thumbnailstream)) : ImageSource.FromStream(() => new MemoryStream(myfile)),
                                    upload_Image_array = myfile,
                                    upload_Image_path = file.Path,
                                    is_video = IsVideo,
                                    upload_Image_stream = file.GetStream()
                                });
                            }
                            catch (Exception ex)
                            {
                            }
                            PropertyImageList = AllPropertyImageList;
                            file.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }
        #endregion

        #region PlayCommand
        public Command PlayCommand
        {
            get
            {
                return new Command(async(e) =>
                {
                    var item = (PropertyUploadFileModel)e;
                    if (item.is_video)
                    {
                        if (!isVideoPageOpen)
                        {
                            try
                            {
                                isVideoPageOpen = true;
                                var param = new NavigationParameters();
                                param.Add("VideoPath", item.upload_Image_path);
                                await NavigationService.NavigateAsync(nameof(VideoPlayerPage), param);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                isVideoPageOpen = false;
                            }
                        } 
                    }                   
                });
            }
        }
        #endregion

        #region EditCommand
        public Command EditCommand
        {
            get
            {
                return new Command(async(e) =>
                {
                    var item = (PropertyUploadFileModel)e;
                    try
                    {
                        bool IsVideo = false;
                        var action = await App.Current.MainPage.DisplayActionSheet("Choose the file", "Cancel", null, "Images", "Videos");

                        MediaFile file;

                        if (action == "Images")
                        {
                            IsVideo = false;
                            await CrossMedia.Current.Initialize();
                            if (!CrossMedia.Current.IsPickPhotoSupported)
                            {
                                return;
                            }
                            file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                            {
                                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

                            });
                            if (file != null)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    file.GetStream().CopyTo(memoryStream);
                                    myfile = memoryStream.ToArray();
                                }
                            }
                        }
                        else if (action == "Videos")
                        {
                            IsVideo = true;
                            await CrossMedia.Current.Initialize();
                            if (!CrossMedia.Current.IsPickVideoSupported)
                            {
                                return;
                            }
                            file = await CrossMedia.Current.PickVideoAsync();
                            if (file != null)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    file.GetStream().CopyTo(memoryStream);
                                    myfile = memoryStream.ToArray();
                                }
                            }
                        }
                        else
                        {
                            IsVideo = false;
                            return;
                        }
                        if (file != null)
                        {
                            if (IsVideo)
                            {
                                thumbnailstream = videoThumbnails.Getthumbnails(file.Path);
                            }

                            try
                            {
                                //var dataItem = new PropertyUploadFileModel()
                                //{
                                //    upload_Image = IsVideo ? ImageSource.FromStream(() => new MemoryStream(thumbnailstream)) : ImageSource.FromStream(() => new MemoryStream(myfile)),
                                //    upload_Image_array = myfile,
                                //    upload_Image_path = file.Path,
                                //    is_video = IsVideo,
                                //    upload_Image_stream = file.GetStream()
                                //};
                                var index = PropertyImageList.IndexOf(item);
                                PropertyImageList[index].upload_Image = IsVideo ? ImageSource.FromStream(() => new MemoryStream(thumbnailstream)) : ImageSource.FromStream(() => new MemoryStream(myfile));
                                PropertyImageList[index].upload_Image_array = myfile;
                                PropertyImageList[index].upload_Image_path = file.Path;
                                PropertyImageList[index].is_video = IsVideo;
                                PropertyImageList[index].upload_Image_stream = file.GetStream();
                            }
                            catch (Exception ex)
                            {
                            }
                            //PropertyImageList = AllPropertyImageList;
                            file.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }
        #endregion

        #region DeleteCommand
        public Command DeleteCommand
        {
            get
            {
                return new Command((e) =>
                {
                    var item = (PropertyUploadFileModel)e;
                    try
                    {
                        var index = AllPropertyImageList.IndexOf(item);
                        AllPropertyImageList.Remove(item);
                    }
                    catch (Exception ex)
                    {
                    }
                    PropertyImageList = AllPropertyImageList;

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
                    IsPropertyPopupVisible = false;
                    await NavigationService.GoBackAsync();
                });
            }
        }
        #endregion

        #region NextIconButton
        public Command NextIconButton
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        UserDialogs.Instance.ShowLoading();
                        string boundary = "---8d0f01e6b3b5dafaaadaad";
                        MultipartFormDataContent multipartContent = new MultipartFormDataContent(boundary);
                        if(SelectedProperty != null)
                        {
                            multipartContent.Add(new StringContent(SelectedProperty.Id.Value.ToString()), "Id");
                        }
                        multipartContent.Add(new StringContent(AddPropertyModel.Name), "Name");
                        multipartContent.Add(new StringContent(AddPropertyModel.AccesstoCode.ToString()), "AccesstoCode");
                        multipartContent.Add(new StringContent(AddPropertyModel.BuildingCode), "BuildingCode");
                        if (!string.IsNullOrEmpty(AddPropertyModel.AccessToProperty) && !string.IsNullOrWhiteSpace(AddPropertyModel.AccessToProperty))
                        {
                            multipartContent.Add(new StringContent(AddPropertyModel.AccessToProperty), "AccessToProperty");
                        }
                        multipartContent.Add(new StringContent(AddPropertyModel.Address), "Address");
                        multipartContent.Add(new StringContent(AddPropertyModel.ApartmentNumber), "ApartmentNumber");
                        multipartContent.Add(new StringContent(AddPropertyModel.Balcony.ToString()), "Balcony");
                        multipartContent.Add(new StringContent(AddPropertyModel.CoffeeMachine.ToString()), "CoffeeMachine");
                        multipartContent.Add(new StringContent(userId.ToString()), "UserId");
                        multipartContent.Add(new StringContent(AddPropertyModel.Dishwasher.ToString()), "Dishwasher");
                        multipartContent.Add(new StringContent(AddPropertyModel.Doorman.ToString()), "Doorman");
                        multipartContent.Add(new StringContent(AddPropertyModel.Elevator.ToString()), "Elevator");
                        multipartContent.Add(new StringContent(AddPropertyModel.FloorNumber), "FloorNumber");
                        multipartContent.Add(new StringContent(AddPropertyModel.Garden.ToString()), "Garden");
                        multipartContent.Add(new StringContent(AddPropertyModel.IsKingBed.ToString()), "IsKingBed");
                        multipartContent.Add(new StringContent(AddPropertyModel.IsSingleBed.ToString()), "IsSingleBed");
                        multipartContent.Add(new StringContent(AddPropertyModel.IsSofaBed.ToString()), "IsSofaBed");
                        multipartContent.Add(new StringContent(AddPropertyModel.Latitude.ToString()), "Latitude");
                        multipartContent.Add(new StringContent(AddPropertyModel.Longitude.ToString()), "Longitude");
                        multipartContent.Add(new StringContent(AddPropertyModel.NoOfBathrooms), "NoOfBathrooms");
                        multipartContent.Add(new StringContent(AddPropertyModel.NoOfBedRooms), "NoOfBedRooms");
                        multipartContent.Add(new StringContent(AddPropertyModel.NoOfDoubleBeds), "NoOfDoubleBeds");
                        multipartContent.Add(new StringContent(AddPropertyModel.NoOfDoubleSofaBeds), "NoOfDoubleSofaBeds");
                        multipartContent.Add(new StringContent(AddPropertyModel.NoOfQueenBeds), "NoOfQueenBeds");
                        multipartContent.Add(new StringContent(AddPropertyModel.NoOfSingleBeds), "NoOfSingleBeds");
                        multipartContent.Add(new StringContent(AddPropertyModel.NoOfSingleSofaBeds), "NoOfSingleSofaBeds");
                        multipartContent.Add(new StringContent(AddPropertyModel.NoOfToilets), "NoOfToilets");
                        multipartContent.Add(new StringContent(AddPropertyModel.Parking.ToString()), "Parking");
                        multipartContent.Add(new StringContent(AddPropertyModel.Pool.ToString()), "Pool");
                        multipartContent.Add(new StringContent(AddPropertyModel.ShortTermApartment.ToString()), "ShortTermApartment");
                        multipartContent.Add(new StringContent(AddPropertyModel.Size.ToString()), "Size");
                        if (!string.IsNullOrEmpty(AddPropertyModel.WifiLogin) && !string.IsNullOrWhiteSpace(AddPropertyModel.WifiLogin))
                        {
                            multipartContent.Add(new StringContent(AddPropertyModel.WifiLogin), "WifiLogin");
                        }
                        if (!string.IsNullOrEmpty(AddPropertyModel.LocationKey) && !string.IsNullOrWhiteSpace(AddPropertyModel.LocationKey))
                        {
                            multipartContent.Add(new StringContent(AddPropertyModel.LocationKey), "LocationOfKey");
                        }
                        multipartContent.Add(new StringContent(AddPropertyModel.Type), "Type");
                        if (PropertyImageList != null && PropertyImageList.Count > 0)
                        {
                            //multipartContent.Add(new StringContent(JsonConvert.SerializeObject(PropertyImageList)), "Image");

                            foreach (var item in PropertyImageList)
                            {
                                try
                                {
                                    var fileContent = new ByteArrayContent(item.upload_Image_array);

                                    fileContent.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/octet-stream");
                                    fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                                    {
                                        Name = "Image",
                                        FileName = item.upload_Image_path,
                                    };

                                    multipartContent.Add(fileContent);

                                }
                                catch (Exception)
                                {
                                } 
                            }
                        }


                        AddPropertyResponseModel response;
                        try
                        {
                            response = await webApiRestClient.PostAsync<MultipartFormDataContent, AddPropertyResponseModel>(ApiUrl.AddUpdateProperty, multipartContent);
                        }
                        catch (Exception ex)
                        {
                            response = null;
                        }
                        if (response != null)
                        {
                            if (response.status)
                            {
                                propertyResponse = response.property_id;
                                PropertyUsername = AddPropertyModel.Name.Replace(" ", "");
                                PropertyPassword = AddPropertyModel.Name.Replace(" ", "") + "bnb";
                                IsPropertyPopupVisible = true;
                                //await NavigationService.GoBackAsync();
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("", response.message, "Ok");
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

        #region PropertyCompleteCommand
        public Command PropertyCompleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var result = await App.Current.MainPage.DisplayAlert("", "Do you want to request service for this Property.", "YES", "NO");
                    if (result)
                    {
                        AddJobDataModel addJobDataModel = new AddJobDataModel()
                        {
                            propertyId = propertyResponse,
                            propertyName = AddPropertyModel.Name,
                            propertyAddress = AddPropertyModel.Address,
                            ShortTermApartment = AddPropertyModel.ShortTermApartment
                        };

                        var param = new NavigationParameters();
                        param.Add("AddJobDataModel", addJobDataModel);
                        await NavigationService.NavigateAsync(nameof(ChooseServicePage), param);
                    }
                    else
                    {
                        await NavigationService.NavigateAsync(new Uri("/NavigationPage/WelcomePage", UriKind.Absolute));
                    }
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
            if (parameters.ContainsKey("TransferData"))
            {
                AddPropertyModel = (AddPropertyModel)parameters["TransferData"];
            }
            if (parameters.ContainsKey("PropertyDetail"))
            {
                SelectedProperty = (PropertyModel)parameters["PropertyDetail"];


                foreach (var item in SelectedProperty.PropertyImages)
                {
                    try
                    {
                        AllPropertyImageList.Add(new PropertyUploadFileModel
                        {
                            upload_Image = item.IsVideo.HasValue && item.IsVideo.Value ? ImageSource.FromStream(() => new MemoryStream(videoThumbnails.Getthumbnails(Common.IsImagesValid(item.VideoUrl, ApiUrl.ImageBaseUrl)))) : ImageSource.FromStream(() => new MemoryStream(Common.getImageFromUrl(Common.IsImagesValid(item.ImageUrl, ApiUrl.ImageBaseUrl)))),
                            upload_Image_array = item.IsVideo.HasValue && item.IsVideo.Value ? Common.getImageFromUrl(Common.IsImagesValid(item.VideoUrl, ApiUrl.ImageBaseUrl)) : Common.getImageFromUrl(Common.IsImagesValid(item.ImageUrl, ApiUrl.ImageBaseUrl)),
                            upload_Image_path = item.IsVideo.HasValue && item.IsVideo.Value ? item.VideoUrl : item.ImageUrl,
                            is_video = item.IsVideo.HasValue && item.IsVideo.Value ? true : false,
                        });
                    }
                    catch (Exception ex)
                    {
                    } 
                }
                PropertyImageList = AllPropertyImageList;
            }
        }
        #endregion
    }
}
