using System;
using System.Collections.Generic;
using System.Text;

namespace BroomService.Models
{
    public class SignupResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public UserModel userData { get; set; }
    }
}
