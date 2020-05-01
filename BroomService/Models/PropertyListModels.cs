using System;
using System.Collections.Generic;
using System.Text;

namespace BroomService.Models
{
    public class PropertyModel
    {
        public int? Id { get; set; }
        public string property_Image_display { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? ShortTermApartment { get; set; }
        public int? FloorNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string BuildingCode { get; set; }
        public string AccessToProperty { get; set; }
        public string LocationOfKey { get; set; }
        public int? NoOfBathrooms { get; set; }
        public int? NoOfQueenBeds { get; set; }
        public int? NoOfDoubleBeds { get; set; }
        public int? NoOfSingleBeds { get; set; }
        public int? NoOfSingleSofaBeds { get; set; }
        public int? NoOfDoubleSofaBeds { get; set; }
        public bool? Doorman { get; set; }
        public bool? Parking { get; set; }
        public bool? Balcony { get; set; }
        public bool? Dishwasher { get; set; }
        public bool? Pool { get; set; }
        public bool? Garden { get; set; }
        public bool? Elevator { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public object IsActive { get; set; }
        public object ModifiedDate { get; set; }
        public string Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? NoOfToilets { get; set; }
        public int? NoOfBedRooms { get; set; }
        public string Size { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public string WifiLogin { get; set; }
        public bool? CoffeeMachine { get; set; }
        public bool? IsSingleBed { get; set; }
        public bool? IsKingBed { get; set; }
        public bool? IsSofaBed { get; set; }
        public bool? AccesstoCode { get; set; }


        public List<PropertyImage> PropertyImages { get; set; }
    }
    public class PropertyImage
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public bool? IsImage { get; set; }
        public bool? IsVideo { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string VideoThumbnail { get; set; }
    }

    public class PropertyDataModel
    {
        public PropertyModel PropertyModel { get; set; }
        public List<PropertyImage> PropertyImages { get; set; }
    }

    public class PropertyListResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<PropertyDataModel> data { get; set; }
    }
}
