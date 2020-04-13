using System;
using System.Collections.Generic;
using System.Text;

namespace BroomService.Models
{
    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public UserModel userData { get; set; }
    }
}