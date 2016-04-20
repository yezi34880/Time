using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “内容对话框”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上进行了说明

namespace Time
{
    public sealed partial class SettingDialog : ContentDialog
    {
        public SettingDialog()
        {
            this.InitializeComponent();
            if (ApplicationData.Current.LocalSettings.Values["Birth"]!=null)
            {
                DateTime birth;
                if (DateTime.TryParse(ApplicationData.Current.LocalSettings.Values["Birth"].ToString(), out birth))
                {
                    datapicker.Date = birth.Date;
                    timepicker.Time = birth.TimeOfDay;
                }

            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ApplicationData.Current.LocalSettings.Values["Birth"] = (datapicker.Date + timepicker.Time).ToString();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
