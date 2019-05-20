using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ImageCustomView
{
    public class CustomBatteryView : Image
    {
        public CustomBatteryView()
        {           
            this.HeightRequest = 20;
            this.WidthRequest = 20;
        }

        public static readonly BindableProperty BatteryLevelProperty =
            BindableProperty.Create(nameof(BatteryLevel), typeof(int), typeof(CustomBatteryView), propertyChanged: OnBatteryLevelPropertyChanged);

        private static void OnBatteryLevelPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != oldValue && newValue != null)
            {
                ((CustomBatteryView)bindable).BatteryLevelStatus(newValue);
            }
        }

        public object BatteryLevel
        {
            get { return GetValue(BatteryLevelProperty); }
            set { SetValue(BatteryLevelProperty, value); }
        }

        //public static readonly BindableProperty RefreshCommandProperty =
        //   BindableProperty.Create(nameof(RefreshCommand), typeof(ICommand), typeof(CustomBatteryView), propertyChanged: OnRefreshCommandPropertyChanged);

        //private static void OnRefreshCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    if (newValue != oldValue && newValue != null)
        //    {
        //        ((CustomBatteryView)bindable).BatteryLevelStatus(50);
        //    }
        //}

        //public ICommand RefreshCommand
        //{
        //    get { return (ICommand)GetValue(RefreshCommandProperty); }
        //    set { SetValue(RefreshCommandProperty, value); }
        //}
      

        /// <summary>
        /// Battery Image show based on battery level
        /// </summary>
        /// <param name="value"></param>
        private void BatteryLevelStatus(object value)
        {
            if ((int)value == 1)
                this.Source = "low";
            else if ((int)value == 100)
                this.Source = "full";
            else if ((int)value == 50)
                this.Source = "half";
        }


    }
}
