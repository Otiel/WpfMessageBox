using System.Windows;

// ReSharper disable once CheckNamespace
namespace WpfMessageBoxLibrary {

    /// <summary>
    /// Displays a message box.
    /// </summary>
    public static class WpfMessageBox {

        /// <summary>
        /// Displays a message box with the specified text.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <returns>One of the MessageBoxResult values.</returns>
        public static MessageBoxResult Show(string text) {
            var msg = new WindowMain(text, MessageBoxButton.OK, MessageBoxImage.None);
            msg.ShowDialog();
            return msg.Result;
        }

        /// <summary>
        /// Displays a message box in front of the specified Window and with the specified text.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <returns>One of the MessageBoxResult values.</returns>
        public static MessageBoxResult Show(Window owner, string text) {
            var msg = new WindowMain(text, MessageBoxButton.OK, MessageBoxImage.None) {
                Owner = owner,
            };
            msg.ShowDialog();
            return msg.Result;
        }

        /// <summary>
        /// Displays a message box with the specified text and title.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="title">The text to display in the title bar of the message box.</param>
        /// <returns>One of the MessageBoxResult values.</returns>
        public static MessageBoxResult Show(string text, string title) {
            var msg = new WindowMain(text, MessageBoxButton.OK, MessageBoxImage.None) {
                Title = title,
            };
            msg.ShowDialog();
            return msg.Result;
        }

        /// <summary>
        /// Displays a message box in front of the specified Window and with the specified text and title.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="title">The text to display in the title bar of the message box.</param>
        /// <returns>One of the MessageBoxResult values.</returns>
        public static MessageBoxResult Show(Window owner, string text, string title) {
            var msg = new WindowMain(text, MessageBoxButton.OK, MessageBoxImage.None) {
                Owner = owner,
                Title = title,
            };
            msg.ShowDialog();
            return msg.Result;
        }

        /// <summary>
        /// Displays a message box with specified text, title, and button.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="title">The text to display in the title bar of the message box.</param>
        /// <param name="button">
        /// One of the MessageBoxButton values that specifies which button to display in the message box.
        /// </param>
        /// <returns>One of the MessageBoxResult values.</returns>
        public static MessageBoxResult Show(string text, string title, MessageBoxButton button) {
            var msg = new WindowMain(text, button, MessageBoxImage.None) {
                Title = title,
            };
            msg.ShowDialog();

            return msg.Result;
        }

        /// <summary>
        /// Displays a message box in front of the specified Window and with the specified text, title, and button.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="title">The text to display in the title bar of the message box.</param>
        /// <param name="button">
        /// One of the MessageBoxButton values that specifies which button to display in the message box.
        /// </param>
        /// <returns>One of the MessageBoxResult values.</returns>
        public static MessageBoxResult Show(Window owner, string text, string title, MessageBoxButton button) {
            var msg = new WindowMain(text, button, MessageBoxImage.None) {
                Owner = owner,
                Title = title,
            };
            msg.ShowDialog();
            return msg.Result;
        }

        /// <summary>
        /// Displays a message box with specified text, title, button, and image.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="title">The text to display in the title bar of the message box.</param>
        /// <param name="button">
        /// One of the MessageBoxButton values that specifies which button to display in the message box.
        /// </param>
        /// <param name="image">
        /// One of the MessageBoxImage values that specifies which image to display in the message box.
        /// </param>
        /// <returns>One of the MessageBoxResult values.</returns>
        public static MessageBoxResult Show(string text, string title, MessageBoxButton button, MessageBoxImage image) {
            var msg = new WindowMain(text, button, image) {
                Title = title,
            };
            msg.ShowDialog();

            return msg.Result;
        }

        /// <summary>
        /// Displays a message box in front of the specified Window and with the specified text, title, button, and image.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="title">The text to display in the title bar of the message box.</param>
        /// <param name="button">
        /// One of the MessageBoxButton values that specifies which button to display in the message box.
        /// </param>
        /// <param name="image">
        /// One of the MessageBoxImage values that specifies which image to display in the message box.
        /// </param>
        /// <returns>One of the MessageBoxResult values.</returns>
        public static MessageBoxResult Show(Window owner, string text, string title, MessageBoxButton button, MessageBoxImage image) {
            var msg = new WindowMain(text, button, image) {
                Owner = owner,
                Title = title,
            };
            msg.ShowDialog();
            return msg.Result;
        }

        /// <summary>
        /// Displays a message box with the specified properties.
        /// </summary>
        /// <param name="properties">The WpfMessageBoxProperties to apply to the message box.</param>
        /// <returns>One of the MessageBoxResult values.</returns>
        public static MessageBoxResult Show(ref WpfMessageBoxProperties properties) {
            var msg = new WindowMain(properties.Text, properties.Button, properties.Image) {
                ButtonCancelText = properties.ButtonCancelText,
                ButtonNoText = properties.ButtonNoText,
                ButtonOkText = properties.ButtonOkText,
                ButtonYesText = properties.ButtonYesText,
                CheckBoxText = properties.CheckBoxText,
                Header = properties.Header,
                IsCheckBoxChecked = properties.IsCheckBoxChecked,
                IsCheckBoxVisible = properties.IsCheckBoxVisible,
                IsTextBoxVisible = properties.IsTextBoxVisible,
                TextBoxText = properties.TextBoxText,
                Title = properties.Title,
            };

            msg.ShowDialog();

            properties.IsCheckBoxChecked = msg.IsCheckBoxChecked;
            properties.TextBoxText = msg.TextBoxText;

            return msg.Result;
        }

        /// <summary>
        /// Displays a message box in front of the specified Window and with the specified properties.
        /// </summary>
        /// <param name="owner">A Window that represents the owner window of the message box.</param>
        /// <param name="properties">The WpfMessageBoxProperties to apply to the message box.</param>
        /// <returns>One of the MessageBoxResult values.</returns>
        public static MessageBoxResult Show(Window owner, ref WpfMessageBoxProperties properties) {
            var msg = new WindowMain(properties.Text, properties.Button, properties.Image) {
                ButtonCancelText = properties.ButtonCancelText,
                ButtonNoText = properties.ButtonNoText,
                ButtonOkText = properties.ButtonOkText,
                ButtonYesText = properties.ButtonYesText,
                CheckBoxText = properties.CheckBoxText,
                Header = properties.Header,
                IsCheckBoxChecked = properties.IsCheckBoxChecked,
                IsCheckBoxVisible = properties.IsCheckBoxVisible,
                IsTextBoxVisible = properties.IsTextBoxVisible,
                Owner = owner,
                TextBoxText = properties.TextBoxText,
                Title = properties.Title,
            };

            msg.ShowDialog();

            properties.IsCheckBoxChecked = msg.IsCheckBoxChecked;
            properties.TextBoxText = msg.TextBoxText;

            return msg.Result;
        }
    }
}