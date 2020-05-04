using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BroomService.Models
{
    public class InventoryDataModel : INotifyPropertyChanged
    {
        public List<object> JobInventories { get; set; }
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string display_Image { get; set; }
        public object CreatedDate { get; set; }
        public object ModifiedDate { get; set; }
        public int? Stock { get; set; }
        public double? Price { get; set; }


        #region InventoryOrderCount
        private int _InventoryOrderCount = 0;
        public int InventoryOrderCount
        {
            get { return _InventoryOrderCount; }
            set 
            {
                _InventoryOrderCount = value;
                OnPropertyChanged();
            }
        }
        #endregion


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class InventoryResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<InventoryDataModel> inventoryData { get; set; }
    }


    public class InventoryAddedListModel
    {
        public long PropertyId { get; set; }
        public string PropertyName { get; set; }
        public long InventoryId { get; set; }
        public string InventoryName { get; set; }
        public long Qty { get; set; }
    }
}
