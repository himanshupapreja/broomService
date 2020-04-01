using System;
using System.Collections.Generic;
using System.Text;

namespace BroomService.Models
{
    public class ChatListResponseModel
    {
    }
    public class ChatListModel
    {
        public string user_pic { get; set; }
        public string user_name { get; set; }
        public string user_last_msg { get; set; }
        public string user_last_msg_time { get; set; }
    }
    public class ChatDetailListModel
    {
        public string user_msg { get; set; }
        public string user_msg_time { get; set; }
        public bool is_sender { get; set; }
    }
}
