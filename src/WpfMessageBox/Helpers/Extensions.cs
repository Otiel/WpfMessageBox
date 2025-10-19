using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

// ReSharper disable once CheckNamespace
namespace WpfMessageBoxLibrary
{
    internal static class Extensions
    {
        /// <summary>
        /// Adds the WPF keyboard accelerator '_' in front of the first character of the specified string if it doesn't
        /// already contain an accelerator.
        /// </summary>
        /// <param name="input">The string to modify.</param>
        public static string AddMnemonic(this string input)
        {
            const string accelerator = "_";

            if (string.IsNullOrWhiteSpace(input) || input.Contains(accelerator))
            {
                return input;
            }

            return accelerator + input;
        }

        /// <summary>
        /// Tranforms the specified Icon instance to an ImageSource.
        /// </summary>
        /// <param name="icon">The Icon to transform.</param>
        public static ImageSource ToImageSource(this Icon icon)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            return imageSource;
        }
    }
}
