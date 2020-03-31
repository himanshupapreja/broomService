using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BroomService.Models
{
    class ServiceResponseModel
    {
    }
    public class ServiceModel : INotifyPropertyChanged
    {
        public string category_service_name { get; set; }
        private string _service_image;
        public string service_image
        {
            get { return _service_image; }
            set
            {
                _service_image = value;
                OnPropertyChanged();
            }
        }
        private bool _ServiceShadow;
        public bool ServiceShadow 
        {
            get { return _ServiceShadow; }
            set
            {
                _ServiceShadow = value;
                OnPropertyChanged();
            }
        }
        private string _ServiceSelectedColor;
        public string ServiceSelectedColor 
        {
            get { return _ServiceSelectedColor; }
            set
            {
                _ServiceSelectedColor = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
