using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;

namespace WpfMessageBoxLibrary {

    internal partial class WindowMain {

        public string ButtonCancelText {
            get { return ButtonCancel.Content.ToString(); }
            set { ButtonCancel.Content = value.AddMnemonic(); }
        }

        public string ButtonNoText {
            get { return ButtonNo.Content.ToString(); }
            set { ButtonNo.Content = value.AddMnemonic(); }
        }

        public string ButtonOkText {
            get { return ButtonOk.Content.ToString(); }
            set { ButtonOk.Content = value.AddMnemonic(); }
        }

        public string ButtonYesText {
            get { return ButtonYes.Content.ToString(); }
            set { ButtonYes.Content = value.AddMnemonic(); }
        }

        public string CheckBoxText {
            get { return CheckBox.Content.ToString(); }
            set { CheckBox.Content = value.AddMnemonic(); }
        }

        public string Header {
            get {
                return TextBlockHeader.Text;
            }
            set {
                TextBlockHeader.Text = value;
                TextBlockHeader.Visibility = String.IsNullOrWhiteSpace(value) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public bool IsCheckBoxChecked {
            get { return CheckBox.IsChecked ?? false; }
            set { CheckBox.IsChecked = value; }
        }

        public bool IsCheckBoxVisible {
            get { return CheckBox.Visibility == Visibility.Visible; }
            set { CheckBox.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public bool IsTextBoxVisible {
            get { return TextBox.Visibility == Visibility.Visible; }
            set { TextBox.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public string Message {
            get {
                return TextBlockMessage.Text;
            }
            set {
                TextBlockMessage.Text = value;
                ScrollViewerMessage.Visibility = String.IsNullOrWhiteSpace(value) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public MessageBoxResult Result { get; set; }

        public string TextBoxText {
            get { return TextBox.Text; }
            set { TextBox.Text = value; }
        }

        public WindowMain(string message, MessageBoxButton button, MessageBoxImage image) {
            InitializeComponent();

            Message = message;

            DisplayButtons(button);
            SetDefaultAndCancelButtons(button);

            DisplayImage(image);

            // Set default values
            ButtonCancelText = LocalizationHelper.GetCancelButtonText();
            ButtonNoText = LocalizationHelper.GetNoButtonText();
            ButtonOkText = LocalizationHelper.GetOkButtonText();
            ButtonYesText = LocalizationHelper.GetYesButtonText();
            CheckBoxText = "";
            Header = "";
            IsCheckBoxChecked = false;
            IsCheckBoxVisible = false;
            IsTextBoxVisible = false;
            TextBoxText = "";
            Title = "";
        }

        protected override void OnSourceInitialized(EventArgs e) {
            this.RemoveIconAndCloseButtons();
            base.OnSourceInitialized(e);
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e) {
            Result = MessageBoxResult.Cancel;
            Close();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e) {
            Result = MessageBoxResult.No;
            Close();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e) {
            Result = MessageBoxResult.OK;
            Close();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e) {
            Result = MessageBoxResult.Yes;
            Close();
        }

        private void DisplayButtons(MessageBoxButton button) {
            switch (button) {
                case MessageBoxButton.OK:
                    ButtonCancel.Visibility = Visibility.Collapsed;
                    ButtonNo.Visibility = Visibility.Collapsed;
                    ButtonOk.Visibility = Visibility.Visible;
                    ButtonYes.Visibility = Visibility.Collapsed;
                    break;
                case MessageBoxButton.OKCancel:
                    ButtonCancel.Visibility = Visibility.Visible;
                    ButtonNo.Visibility = Visibility.Collapsed;
                    ButtonOk.Visibility = Visibility.Visible;
                    ButtonYes.Visibility = Visibility.Collapsed;
                    break;
                case MessageBoxButton.YesNo:
                    ButtonCancel.Visibility = Visibility.Collapsed;
                    ButtonNo.Visibility = Visibility.Visible;
                    ButtonOk.Visibility = Visibility.Collapsed;
                    ButtonYes.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButton.YesNoCancel:
                    ButtonCancel.Visibility = Visibility.Visible;
                    ButtonNo.Visibility = Visibility.Visible;
                    ButtonOk.Visibility = Visibility.Collapsed;
                    ButtonYes.Visibility = Visibility.Visible;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void DisplayImage(MessageBoxImage image) {
            switch (image) {
                case MessageBoxImage.Information:
                    // Also covers MessageBoxImage.Asterisk
                    ImageIcon.Source = SystemIcons.Information.ToImageSource();
                    break;
                case MessageBoxImage.Error:
                    // Also covers MessageBoxImage.Hand Also covers MessageBoxImage.Stop
                    ImageIcon.Source = SystemIcons.Error.ToImageSource();
                    break;
                case MessageBoxImage.Warning:
                    // Also covers MessageBoxImage.Exclamation
                    ImageIcon.Source = SystemIcons.Warning.ToImageSource();
                    break;
                case MessageBoxImage.Question:
                    ImageIcon.Source = SystemIcons.Question.ToImageSource();
                    break;
                default:
                    // Also covers MessageBoxImage.None
                    ImageIcon.Source = null;
                    break;
            }

            ImageIcon.Visibility = ImageIcon.Source == null ? Visibility.Collapsed : Visibility.Visible;
        }

        private void SetDefaultAndCancelButtons(MessageBoxButton button) {
            switch (button) {
                case MessageBoxButton.OK:
                    ButtonOk.IsDefault = true;
                    ButtonOk.IsCancel = true;
                    break;
                case MessageBoxButton.OKCancel:
                    ButtonOk.IsDefault = true;
                    ButtonCancel.IsCancel = true;
                    break;
                case MessageBoxButton.YesNo:
                    ButtonYes.IsDefault = true;
                    ButtonNo.IsCancel = true;
                    break;
                case MessageBoxButton.YesNoCancel:
                    ButtonYes.IsDefault = true;
                    ButtonCancel.IsCancel = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control) {
                string content = String.IsNullOrWhiteSpace(Header) ? "" : Header + Environment.NewLine + Environment.NewLine;
                content += Message;

                Clipboard.SetText(content);
            }
        }
    }
}