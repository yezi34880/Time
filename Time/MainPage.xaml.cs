using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Time
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DateTime birth;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(ApplicationData.Current.LocalSettings.Values["Birth"].ToString(), out birth) == false)
            {
                SettingDialog setting = new SettingDialog();
                await setting.ShowAsync();
            }
            DateTime.TryParse(ApplicationData.Current.LocalSettings.Values["Birth"].ToString(), out birth);

            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            var now = DateTime.Now;
            var span = now - birth;
            txt1.Text = String.Format("{0}天", span.Days);
            txt2.Text = String.Format("{0}小时", span.Hours);
            txt3.Text = String.Format("{0}分钟", span.Minutes);
            txt4.Text = String.Format("{0}秒", span.Seconds);
            txt5.Text = span.Milliseconds.ToString();
        }

        private async void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SettingDialog setting = new SettingDialog();
            var result = await setting.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                DateTime.TryParse(ApplicationData.Current.LocalSettings.Values["Birth"].ToString(), out birth);
            }
        }
    }
}
