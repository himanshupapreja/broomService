using System;
using System.Collections.Generic;
using System.Text;

namespace BroomService.Helpers
{
    public class ApiUrl
    {
        //public const string BaseUrl = "http://appmantechnologies.com:8020/Images/Users/";
        //public const string ApiBaseUrl = "http://appmantechnologies.com:8020/api/";
        public const string ApiBaseUrl = "https://app.broomservice.co.il:8071/api/";

        public const string Login = "Account/Login";
        public const string ChangePassword = "Account/ChangePassword";
        public const string ForgetPassword = "Account/ForgetPassword";
        public const string SignUp = "Account/SignUp";
        public const string UpdateDeviceInfo = "Account/UpdateDeviceInfo";
        public const string Logout = "Account/Logout";
        public const string EditProfile = "Account/EditProfile";
        public const string AddUpdateProperty = "Property/AddUpdateProperty";


        public const string GetProfile = "Account/GetProfile?userId={0}";
        public const string GetPropertiesByUserId = "Property/GetPropertiesByUserId?userId={0}";
        public const string GetTermsConditions = "Settings/GetTermsConditions";
        public const string GetAboutus = "Settings/GetAboutus";
        public const string GetPrivacyPolicy = "Settings/GetPrivacyPolicy";
    }
}