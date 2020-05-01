using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace BroomService.Models
{
    public class AddPropertyModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool AccesstoCode { get; set; }
        public string AccessToProperty { get; set; }
        public string Address { get; set; }
        public string ApartmentNumber { get; set; }
        public string BuildingCode { get; set; }
        public string UserId { get; set; }
        public bool Balcony { get; set; }
        public bool CoffeeMachine { get; set; }
        public bool Dishwasher { get; set; }
        public bool Doorman { get; set; }
        public bool Elevator { get; set; }
        public bool Garden { get; set; }
        public bool Parking { get; set; }
        public bool Pool { get; set; }
        public string FloorNumber { get; set; }
        public bool IsKingBed { get; set; }
        public bool IsSingleBed { get; set; }
        public bool IsSofaBed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string NoOfBathrooms { get; set; }
        public string NoOfBedRooms { get; set; }
        public string NoOfDoubleBeds { get; set; }
        public string NoOfDoubleSofaBeds { get; set; }
        public string NoOfQueenBeds { get; set; }
        public string NoOfSingleBeds { get; set; }
        public string NoOfSingleSofaBeds { get; set; }
        public string NoOfToilets { get; set; }
        public bool ShortTermApartment { get; set; }
        public string Size { get; set; }
        public string WifiLogin { get; set; }
        public string LocationKey { get; set; }
    }

    public class PropertyUploadFileModel : INotifyPropertyChanged
    {
        private ImageSource _upload_Image;
        public ImageSource upload_Image 
        {
            get { return _upload_Image; }
            set
            {
                _upload_Image = value;
                OnPropertyChanged();
            }
        }
        public byte[] upload_Image_array { get; set; }
        public Stream upload_Image_stream { get; set; }
        public string upload_Image_path { get; set; }
        private bool _is_video;
        public bool is_video
        {
            get { return _is_video; }
            set
            {
                _is_video = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AddPropertyResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public int property_id { get; set; }
    }
}