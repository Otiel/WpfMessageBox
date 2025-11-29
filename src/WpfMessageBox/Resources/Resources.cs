using System;
using System.Windows.Media.Imaging;

// ReSharper disable once CheckNamespace
namespace WpfMessageBoxLibrary
{
    internal static class Resources
    {
        private const string RESOURCES_ROOT_PATH = "pack://application:,,,/WpfMessageBox;component/Resources";

        public static BitmapImage ImageCrossCircle => new BitmapImage(new Uri($"{RESOURCES_ROOT_PATH}/cross-circle.png"));
        public static BitmapImage ImageExclamation => new BitmapImage(new Uri($"{RESOURCES_ROOT_PATH}/exclamation.png"));
        public static BitmapImage ImageInformation => new BitmapImage(new Uri($"{RESOURCES_ROOT_PATH}/information.png"));
        public static BitmapImage ImageQuestion => new BitmapImage(new Uri($"{RESOURCES_ROOT_PATH}/question.png"));
        public static BitmapImage ImageTick => new BitmapImage(new Uri($"{RESOURCES_ROOT_PATH}/tick.png"));
    }
}
