using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace BroomService.Models
{
    public class SubSubCategory : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string display_Name { get; set; }
        public string display_Icon { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public bool? HasPrice { get; set; }
        public double? Price { get; set; }
        public string display_Description { get; set; }
        public string Description { get; set; }
        public string Description_Russian { get; set; }
        public string Description_Hebrew { get; set; }
        public string Description_French { get; set; }
        public double? ClientPrice { get; set; }
        public bool IsSelected { get; set; }
        public string Picture { get; set; }
        public string display_Picture { get; set; }
        public string Icon { get; set; }
        public string Name_Russian { get; set; }
        public string Name_Hebrew { get; set; }
        public string Name_French { get; set; }
        [JsonIgnore]
        private string _SelectedColor;
        public string SelectedColor
        {
            get { return _SelectedColor; }
            set
            {
                _SelectedColor = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class SubCategory : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string display_Name { get; set; }
        public string display_Icon { get; set; }
        public string display_Picture { get; set; }
        public string Name { get; set; }
        public string Name_Russian { get; set; }
        public string Name_Hebrew { get; set; }
        public string Name_French { get; set; }
        public string display_Description { get; set; }
        public string Description { get; set; }
        public string Description_Russian { get; set; }
        public string Description_Hebrew { get; set; }
        public string Description_French { get; set; }
        public double? Price { get; set; }
        public double? ClientPrice { get; set; }
        public string Picture { get; set; }
        public string Icon { get; set; }
        public bool HasSubSubCategories { get; set; }
        public List<SubSubCategory> SubSubCategories { get; set; }
        [JsonIgnore]
        private string _SelectedColor;
        public string SelectedColor
        {
            get { return _SelectedColor; }
            set
            {
                _SelectedColor = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class CategoryData : INotifyPropertyChanged
    {
        public List<SubCategory> SubCategories { get; set; }
        public int Id { get; set; }
        public string display_Name { get; set; }
        public string display_Icon { get; set; }
        public string display_Picture { get; set; }
        public string Name { get; set; }
        public string Name_Russian { get; set; }
        public string Name_Hebrew { get; set; }
        public string Name_French { get; set; }
        public object DisplayOrder { get; set; }
        public string display_Description { get; set; }
        public string Description { get; set; }
        public string Description_Russian { get; set; }
        public string Description_Hebrew { get; set; }
        public string Description_French { get; set; }
        public string Picture { get; set; }
        public string Icon { get; set; }
        public bool HasPrice { get; set; }
        public bool ForWorkers { get; set; }
        public bool? IsActive { get; set; }
        public bool IsSelected { get; set; }
        [JsonIgnore]
        private string _SelectedColor;
        public string SelectedColor
        {
            get { return _SelectedColor; }
            set
            {
                _SelectedColor = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class CategoryResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<CategoryData> categoryData { get; set; }
    }







    public class SelectedPropertyListModel
    {
        public long property_id { get; set; }
        public string PropertyNameAddress { get; set; }
    }
    public class SelectedServiceListModel
    {
        public long service_id { get; set; }
        public string ServiceName { get; set; }
    }
    public class SelectedSubServiceListModel
    {
        public long service_id { get; set; }
        public string SubServiceName { get; set; }
    }
    public class SelectedPackageListModel
    {
        public long package_id { get; set; }
        public string PackageName { get; set; }
    }
}
