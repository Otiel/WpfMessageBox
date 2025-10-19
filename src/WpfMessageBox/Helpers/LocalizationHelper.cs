using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace WpfMessageBoxLibrary
{
    internal static class LocalizationHelper
    {
        private sealed class UserStringNotFoundException : Exception
        {
        }

        private const string DEFAULT_CANCEL_BUTTON_TEXT = "_Cancel";
        private const string DEFAULT_NO_BUTTON_TEXT = "_No";
        private const string DEFAULT_OK_BUTTON_TEXT = "_OK";
        private const string DEFAULT_YES_BUTTON_TEXT = "Yes";

        /// <summary>
        /// Returns the localized string of the native MessageBox "Cancel" button from user32.dll.
        /// </summary>
        public static string GetCancelButtonText()
        {
            try
            {
                return GetUserString(801);
            }
            catch (UserStringNotFoundException)
            {
                return DEFAULT_CANCEL_BUTTON_TEXT;
            }
        }

        /// <summary>
        /// Returns the localized string of the native MessageBox "No" button from user32.dll.
        /// </summary>
        public static string GetNoButtonText()
        {
            try
            {
                return GetUserString(806);
            }
            catch (UserStringNotFoundException)
            {
                return DEFAULT_NO_BUTTON_TEXT;
            }
        }

        /// <summary>
        /// Returns the localized string of the native MessageBox "OK" button from user32.dll.
        /// </summary>
        public static string GetOkButtonText()
        {
            try
            {
                return GetUserString(800);
            }
            catch (UserStringNotFoundException)
            {
                return DEFAULT_OK_BUTTON_TEXT;
            }
        }

        /// <summary>
        /// Returns the localized string of the native MessageBox "Yes" button from user32.dll.
        /// </summary>
        public static string GetYesButtonText()
        {
            try
            {
                return GetUserString(805);
            }
            catch (UserStringNotFoundException)
            {
                return DEFAULT_YES_BUTTON_TEXT;
            }
        }

        /// <summary>
        /// Returns a user String from user32.dll. See the list of ID: http://www.tech-archive.net/Archive/Development/microsoft.public.win32.programmer.kernel/2010-02/msg00129.html
        /// </summary>
        /// <param name="stringId">The id of the String.</param>
        private static string GetUserString(uint stringId)
        {
            var libraryHandle = GetModuleHandle("user32.dll");
            if (libraryHandle == IntPtr.Zero)
            {
                throw new UserStringNotFoundException();
            }

            var sb = new StringBuilder(1024);
            var size = LoadString(libraryHandle, stringId, sb, 1024);

            if (size > 0)
            {
                // Replace Win32 mnemonic with WPF mnemonic
                sb.Replace('&', '_');

                return sb.ToString();
            }

            throw new UserStringNotFoundException();
        }

        #region Dll Imports

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int LoadString(IntPtr hInstance, uint uId, StringBuilder lpBuffer, int nBufferMax);

        #endregion
    }
}
