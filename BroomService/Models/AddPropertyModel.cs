using System;
using System.Collections.Generic;
using System.IO;
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
        public string Latitude { get; set; }
        public string Longitude { get; set; }
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
    }

    public class PropertyUploadFileModel
    {
        public ImageSource upload_Image { get; set; }
        public byte[] upload_Image_array { get; set; }
        public Stream upload_Image_stream { get; set; }
        public string upload_Image_path { get; set; }
        public bool is_video { get; set; }
    }
}
