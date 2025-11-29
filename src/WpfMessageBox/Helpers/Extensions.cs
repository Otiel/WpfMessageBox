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
    }
}
