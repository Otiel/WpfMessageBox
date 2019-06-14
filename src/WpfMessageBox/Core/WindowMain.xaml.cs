using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;

namespace WpfMessageBoxLibrary {

    internal partial class WindowMain: Window {

        public string ButtonCancelText {
            get { return buttonCancel.Content.ToString(); }
            set { buttonCancel.Content = value.AddMnemonic(); }
        }

        public string ButtonNoText {
            get { return buttonNo.Content.ToString(); }
            set { buttonNo.Content = value.AddMnemonic(); }
        }

        public string ButtonOkText {
            get { return buttonOk.Content.ToString(); }
            set { buttonOk.Content = value.AddMnemonic(); }
        }

        public string ButtonYesText {
            get { return buttonYes.Content.ToString(); }
            set { buttonYes.Content = value.AddMnemonic(); }
        }

        public string CheckBoxText {
            get { return checkBox.Content.ToString(); }
            set { checkBox.Content = value.AddMnemonic(); }
        }

        public string Header {
            get {
                return textBlockHeader.Text;
            }
            set {
                textBlockHeader.Text = value;
                textBlockHeader.Visibility = String.IsNullOrWhiteSpace(value) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public bool IsCheckBoxChecked {
            get { return checkBox.IsChecked ?? false; }
            set { checkBox.IsChecked = value; }
        }

        public bool IsCheckBoxVisible {
            get { return checkBox.Visibility == Visibility.Visible; }
            set { checkBox.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public bool IsTextBoxVisible {
            get { return textBox.Visibility == Visibility.Visible; }
            set { textBox.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public string Message {
            get {
                return textBlockMessage.Text;
            }
            set {
                textBlockMessage.Text = value;
                scrollViewerMessage.Visibility = String.IsNullOrWhiteSpace(value) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public MessageBoxResult Result { get; set; }

        public string TextBoxText {
            get { return textBox.Text; }
            set { textBox.Text = value; }
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
                    buttonCancel.Visibility = Visibility.Collapsed;
                    buttonNo.Visibility = Visibility.Collapsed;
                    buttonOk.Visibility = Visibility.Visible;
                    buttonYes.Visibility = Visibility.Collapsed;
                    break;
                case MessageBoxButton.OKCancel:
                    buttonCancel.Visibility = Visibility.Visible;
                    buttonNo.Visibility = Visibility.Collapsed;
                    buttonOk.Visibility = Visibility.Visible;
                    buttonYes.Visibility = Visibility.Collapsed;
                    break;
                case MessageBoxButton.YesNo:
                    buttonCancel.Visibility = Visibility.Collapsed;
                    buttonNo.Visibility = Visibility.Visible;
                    buttonOk.Visibility = Visibility.Collapsed;
                    buttonYes.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButton.YesNoCancel:
                    buttonCancel.Visibility = Visibility.Visible;
                    buttonNo.Visibility = Visibility.Visible;
                    buttonOk.Visibility = Visibility.Collapsed;
                    buttonYes.Visibility = Visibility.Visible;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void DisplayImage(MessageBoxImage image) {
            switch (image) {
                case MessageBoxImage.Information:
                    // Also covers MessageBoxImage.Asterisk
                    imageIcon.Source = SystemIcons.Information.ToImageSource();
                    break;
                case MessageBoxImage.Error:
                    // Also covers MessageBoxImage.Hand Also covers MessageBoxImage.Stop
                    imageIcon.Source = SystemIcons.Error.ToImageSource();
                    break;
                case MessageBoxImage.Warning:
                    // Also covers MessageBoxImage.Exclamation
                    imageIcon.Source = SystemIcons.Warning.ToImageSource();
                    break;
                case MessageBoxImage.Question:
                    imageIcon.Source = SystemIcons.Question.ToImageSource();
                    break;
                default:
                    // Also covers MessageBoxImage.None
                    imageIcon.Source = null;
                    break;
            }

            imageIcon.Visibility = imageIcon.Source == null ? Visibility.Collapsed : Visibility.Visible;
        }

        private void SetDefaultAndCancelButtons(MessageBoxButton button) {
            switch (button) {
                case MessageBoxButton.OK:
                    buttonOk.IsDefault = true;
                    buttonOk.IsCancel = true;
                    break;
                case MessageBoxButton.OKCancel:
                    buttonOk.IsDefault = true;
                    buttonCancel.IsCancel = true;
                    break;
                case MessageBoxButton.YesNo:
                    buttonYes.IsDefault = true;
                    buttonNo.IsCancel = true;
                    break;
                case MessageBoxButton.YesNoCancel:
                    buttonYes.IsDefault = true;
                    buttonCancel.IsCancel = true;
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