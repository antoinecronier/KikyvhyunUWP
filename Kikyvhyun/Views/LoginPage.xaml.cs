using Kikyvhyun.Database;
using Kikyvhyun.Entities;
using Kikyvhyun.Utils.Camera;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace Kikyvhyun.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
            CameraManager.Instance.SetCaptureSource(this.captureView);
        }

        private async void loginBtnLogin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var photo = await CameraManager.Instance.TakePick();
            var source = await CameraManager.Instance.ToBitmapSource(photo);
            this.image.Source = source;

            //CameraManager.Instance.TakeVideo();
            //(Window.Current.Content as Frame).Navigate(typeof(MeetingPage));
        }

        private void loginBtnSignUp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CameraManager.Instance.StopVideo();
            //(Window.Current.Content as Frame).Navigate(typeof(SignUpPage));
        }
    }
}
