using System.Windows;

// ReSharper disable once CheckNamespace
namespace WpfMessageBoxLibrary
{
    /// <summary>
    /// The properties of a <see cref="WpfMessageBox" />.
    /// </summary>
    public sealed class WpfMessageBoxProperties
    {
        /// <summary>
        /// Gets or sets the buttons used.
        /// </summary>
        public MessageBoxButton Button { get; set; }

        /// <summary>
        /// Gets or sets the "Cancel" button text.
        /// </summary>
        public string ButtonCancelText { get; set; }

        /// <summary>
        /// Gets or sets the "No" button text.
        /// </summary>
        public string ButtonNoText { get; set; }

        /// <summary>
        /// Gets or sets the "OK" button text.
        /// </summary>
        public string ButtonOkText { get; set; }

        /// <summary>
        /// Gets or sets the "Yes" button text.
        /// </summary>
        public string ButtonYesText { get; set; }

        /// <summary>
        /// Gets or sets the checkbox text.
        /// </summary>
        public string CheckBoxText { get; set; }

        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public MessageBoxImage Image { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the checkbox should be checked by default.
        /// </summary>
        public bool IsCheckBoxChecked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the checkbox should be shown.
        /// </summary>
        public bool IsCheckBoxVisible { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the textbox should be shown.
        /// </summary>
        public bool IsTextBoxVisible { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the textbox text.
        /// </summary>
        public string TextBoxText { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfMessageBoxProperties" /> class.
        /// </summary>
        public WpfMessageBoxProperties()
        {
            // Set default values
            ButtonCancelText = "_Cancel";
            ButtonNoText = "_No";
            ButtonOkText = "_OK";
            ButtonYesText = "_Yes";
            Button = MessageBoxButton.OK;
            CheckBoxText = "";
            Image = MessageBoxImage.None;
            Header = "";
            IsCheckBoxChecked = false;
            IsCheckBoxVisible = false;
            IsTextBoxVisible = false;
            Text = "";
            TextBoxText = "";
            Title = "";
        }
    }
}
