using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiProject
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private Window? _window;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
        }

        private static void SetWindowDetails(IntPtr hwnd, int width, int height)
        {
            // Take screen information to get a good size for the windows
            var dpi = Windows.Win32.PInvoke.GetDpiForWindow((Windows.Win32.Foundation.HWND)hwnd);
            float scalingFactor = (float)dpi / 96;
            width = (int)(width * scalingFactor);
            height = (int)(height * scalingFactor);

            // Specifie the good position for the windows when is open
            _ = Windows.Win32.PInvoke.SetWindowPos((Windows.Win32.Foundation.HWND)hwnd,
                                        Windows.Win32.Foundation.HWND.HWND_TOP,
                                        0, 0, width, height,
                                        Windows.Win32.UI.WindowsAndMessaging.SET_WINDOW_POS_FLAGS.SWP_NOMOVE);

            var nIndex = Windows.Win32.PInvoke.GetWindowLong((Windows.Win32.Foundation.HWND)hwnd,
                      Windows.Win32.UI.WindowsAndMessaging.WINDOW_LONG_PTR_INDEX.GWL_STYLE) &
                      ~(int)Windows.Win32.UI.WindowsAndMessaging.WINDOW_STYLE.WS_MINIMIZEBOX &
                      ~(int)Windows.Win32.UI.WindowsAndMessaging.WINDOW_STYLE.WS_MAXIMIZEBOX;

            // to disable the Minimize and Maximize buttons.
            _ = Windows.Win32.PInvoke.SetWindowLong((Windows.Win32.Foundation.HWND)hwnd,
                   Windows.Win32.UI.WindowsAndMessaging.WINDOW_LONG_PTR_INDEX.GWL_STYLE,
                   nIndex);
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            _window = new MainWindow();

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(_window);

            SetWindowDetails(hwnd, 800, 600);

            _window.Activate();
        }


    }
}
