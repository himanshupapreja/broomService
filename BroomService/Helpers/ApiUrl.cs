using System;
using System.Collections.Generic;
using System.Text;

namespace BroomService.Helpers
{
    public class ApiUrl
    {
        public const string TemplateUrl = "https://app.broomservice.co.il:8071/Content/PropertyTemplate.xlsx";
        public const string BaseUrl = "https://app.broomservice.co.il:8071";
        public const string ImageUrl = "https://app.broomservice.co.il";
        //public const string ApiBaseUrl = "http://appmantechnologies.com:8020/api/";
        public const string ApiBaseUrl = BaseUrl + "/api/";
        public const string ImageBaseUrl = BaseUrl + "/Images/Property/";
        public static readonly string ReferenceImageBaseUrl = BaseUrl + "/Images/JobRequest/";
        public static readonly string CategoryImageBaseUrl = ImageUrl + "/Images/Category/";
        public static readonly string SubCategoryImageBaseUrl = ImageUrl + "/Images/SubCategory/";
        public static readonly string SubSubCategoryImageBaseUrl = ImageUrl + "/Images/SubSubCategory/";

        public const string Login = "Account/Login";
        public const string ChangePassword = "Account/ChangePassword";
        public const string ForgetPassword = "Account/ForgetPassword";
        public const string SignUp = "Account/SignUp";
        public const string UpdateDeviceInfo = "Account/UpdateDeviceInfo";
        public const string Logout = "Account/Logout";
        public const string EditProfile = "Account/EditProfile";
        public const string AddUpdateProperty = "Property/AddUpdateProperty";
        public const string ImportPropertyByExcel = "Property/ImportPropertyByExcel?user_id={0}";
        public const string AddJobRequest = "Order/AddJobRequest";


        public const string GetProfile = "Account/GetProfile?userId={0}";
        public const string GetPropertiesByUserId = "Property/GetPropertiesByUserId?userId={0}";
        public const string GetTermsConditions = "Settings/GetTermsConditions";
        public const string GetAboutus = "Settings/GetAboutus";
        public const string GetPrivacyPolicy = "Settings/GetPrivacyPolicy";
        public const string EditAccessCodeDetails = "Property/EditAccessCodeDetails?propertyID={0}&buildingCode={1}&accessToProperty={2}";
        public const string GetCategories = "Category/GetCategories";
        public const string GetInventoryList = "Order/GetInventoryList";
    }
}