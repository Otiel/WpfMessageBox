using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

// ReSharper disable once CheckNamespace
namespace WpfMessageBoxLibrary {

    internal static class WindowHelper {
        private const int GWL_STYLE = -16;

        private const uint WS_SYSMENU = 0x80000;

        public static void RemoveIconAndCloseButtons(this Window window) {
            // Get window's handle
            IntPtr hwnd = new WindowInteropHelper(window).Handle;

            // Change the extended window style to not show a window icon and close button
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & (0xFFFFFFFF ^ WS_SYSMENU));
        }

        [DllImport("user32.dll")]
        private static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
    }
}