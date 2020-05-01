using System;
using System.Collections.Generic;
using System.Text;

namespace BroomService.Models
{
    public class InventoryDataModel
    {
        public List<object> JobInventories { get; set; }
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public object CreatedDate { get; set; }
        public object ModifiedDate { get; set; }
        public int? Stock { get; set; }
    }

    public class InventoryResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<InventoryDataModel> inventoryData { get; set; }
    }
}
