using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ImageCustomView
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _batteryLevel1;
        public int BatteryLevel1
        {
            get { return _batteryLevel1; }
            set { SetField(ref _batteryLevel1, value, "BatteryLevel1"); }
        }
        private int _batteryLevel2;
        public int BatteryLevel2
        {
            get { return _batteryLevel2; }
            set { SetField(ref _batteryLevel2, value, "BatteryLevel2"); }
        }
        private int _batteryLevel3;
        public int BatteryLevel3
        {
            get { return _batteryLevel3; }
            set { SetField(ref _batteryLevel3, value, "BatteryLevel3"); }
        }



        //private ICommand _refreshCommand;
        //public ICommand RefreshCommand
        //{
        //    get
        //    {
        //        return _refreshCommand ?? (_refreshCommand = new Command(() =>
        //        {

        //        }));
        //    }
        //}

        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new Command(() =>
                {
                    BatteryLevel1 = 100; BatteryLevel2 = 0; BatteryLevel3 = 50;
                }));
            }
        }

        public MainViewModel()
        {
            BatteryLevel1 = 1; BatteryLevel2 = 50; BatteryLevel3 = 100;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

    }
}
