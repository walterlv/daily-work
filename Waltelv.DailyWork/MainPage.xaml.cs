using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Waltelv.DailyWork.Pages;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
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
            InitializeComponent();
            Loading += OnLoading;
        }

        private SystemNavigationManager _systemNavigator;

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

            _systemNavigator = SystemNavigationManager.GetForCurrentView();
            _systemNavigator.BackRequested += SystemNavigationManager_BackRequested;

            NavigationListBox.SelectedIndex = 0;
        }

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = Frame.CanGoBack;
            _systemNavigator.AppViewBackButtonVisibility = Frame.CanGoBack
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed;
        }

        private void NavigationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContentFrame.Content == null)
            {
                ContentFrame.Navigate(typeof(WorkPage));
            }
        }
    }
}
