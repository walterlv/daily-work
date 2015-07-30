using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Waltelv.DailyWork
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loading += OnLoading;
        }

        private void OnLoading(FrameworkElement sender, object e)
        {
            Color accent = (Color)Application.Current.Resources["Theme.Color.Accent"];
            Color accentLight = (Color)Application.Current.Resources["Theme.Color.AccentLight"];
            Color accentDark = (Color)Application.Current.Resources["Theme.Color.AccentDark"];
            Color foreground = (Color)Application.Current.Resources["Theme.Color.AccentForeground"];

            ApplicationView view = ApplicationView.GetForCurrentView();
            view.TitleBar.BackgroundColor = view.TitleBar.InactiveBackgroundColor = accent;
            view.TitleBar.ButtonBackgroundColor = view.TitleBar.ButtonInactiveBackgroundColor = accent;
            view.TitleBar.ForegroundColor = view.TitleBar.ButtonForegroundColor = foreground;
            view.TitleBar.InactiveForegroundColor = view.TitleBar.ButtonInactiveForegroundColor = foreground;
            view.TitleBar.ButtonHoverBackgroundColor = accentLight;
            view.TitleBar.ButtonPressedBackgroundColor = accentDark;
            view.TitleBar.ButtonHoverForegroundColor = view.TitleBar.ButtonPressedForegroundColor = foreground;

            CoreApplicationView coreView = CoreApplication.GetCurrentView();
            coreView.TitleBar.ExtendViewIntoTitleBar = true;
            Window.Current.SetTitleBar(TitleBarPanel);
        }
    }
}
