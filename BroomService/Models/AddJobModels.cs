using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BroomService.Models
{
    public class AddJobDataModel
    {
        public long propertyId { get; set; }
        public string propertyName { get; set; }
        public string propertyAddress { get; set; }
        public bool ShortTermApartment { get; set; }
        public ObservableCollection<CategoryData> ServiceList { get; set; }
        //public string SelectedSubServiceDescription { get; set; }
        //public string SelectedSubSubServiceDescription { get; set; }
        public string SelectedServiceDescription { get; set; }
        public string SelectedService { get; set; }
        //public string SelectedSubService { get; set; }
        //public string SelectedSubSubService { get; set; }
        public long SelectedServiceId { get; set; }
        public long SelectedSubServiceId { get; set; }
        public long SelectedSubSubServiceId { get; set; }



        public string DisplayServiceDescription { get; set; }
        public string DisplaySubServiceDescription { get; set; }
        public string DisplayServiceName { get; set; }
        public string DisplaySubServiceName { get; set; }

    }


    public class AddJobCheckList
    {
        public string CheckListValue { get; set; }
    }
}
