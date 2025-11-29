using System;
using System.Windows;
using System.Windows.Input;

// ReSharper disable once CheckNamespace
namespace WpfMessageBoxLibrary
{
    internal sealed partial class WindowMain
    {
        public string ButtonCancelText
        {
            get => ButtonCancel.Content.ToString();
            set => ButtonCancel.Content = value.AddMnemonic();
        }

        public string ButtonNoText
        {
            get => ButtonNo.Content.ToString();
            set => ButtonNo.Content = value.AddMnemonic();
        }

        public string ButtonOkText
        {
            get => ButtonOk.Content.ToString();
            set => ButtonOk.Content = value.AddMnemonic();
        }

        public string ButtonYesText
        {
            get => ButtonYes.Content.ToString();
            set => ButtonYes.Content = value.AddMnemonic();
        }

        public string CheckBoxText
        {
            get => CheckBox.Content.ToString();
            set => CheckBox.Content = value.AddMnemonic();
        }

        public string Header
        {
            get => TextBlockHeader.Text;
            set
            {
                TextBlockHeader.Text = value;
                TextBlockHeader.Visibility = string.IsNullOrWhiteSpace(value) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public bool IsCheckBoxChecked
        {
            get => CheckBox.IsChecked ?? false;
            set => CheckBox.IsChecked = value;
        }

        public bool IsCheckBoxVisible
        {
            get => CheckBox.Visibility == Visibility.Visible;
            set => CheckBox.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public bool IsTextBoxVisible
        {
            get => TextBox.Visibility == Visibility.Visible;
            set => TextBox.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public string Message
        {
            get => TextBlockMessage.Text;
            set
            {
                TextBlockMessage.Text = value;
                ScrollViewerMessage.Visibility = string.IsNullOrWhiteSpace(value) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public WpfMessageBoxResult Result { get; set; }

        public string TextBoxText
        {
            get => TextBox.Text;
            set => TextBox.Text = value;
        }

        public WindowMain(string message, WpfMessageBoxButton button, WpfMessageBoxImage image)
        {
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

        protected override void OnSourceInitialized(EventArgs e)
        {
            this.RemoveIconAndCloseButtons();
            base.OnSourceInitialized(e);
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Result = WpfMessageBoxResult.Cancel;
            Close();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            Result = WpfMessageBoxResult.No;
            Close();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Result = WpfMessageBoxResult.OK;
            Close();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            Result = WpfMessageBoxResult.Yes;
            Close();
        }

        private void DisplayButtons(WpfMessageBoxButton button)
        {
            switch (button)
            {
                case WpfMessageBoxButton.OK:
                    ButtonCancel.Visibility = Visibility.Collapsed;
                    ButtonNo.Visibility = Visibility.Collapsed;
                    ButtonOk.Visibility = Visibility.Visible;
                    ButtonYes.Visibility = Visibility.Collapsed;
                    break;
                case WpfMessageBoxButton.OKCancel:
                    ButtonCancel.Visibility = Visibility.Visible;
                    ButtonNo.Visibility = Visibility.Collapsed;
                    ButtonOk.Visibility = Visibility.Visible;
                    ButtonYes.Visibility = Visibility.Collapsed;
                    break;
                case WpfMessageBoxButton.YesNo:
                    ButtonCancel.Visibility = Visibility.Collapsed;
                    ButtonNo.Visibility = Visibility.Visible;
                    ButtonOk.Visibility = Visibility.Collapsed;
                    ButtonYes.Visibility = Visibility.Visible;
                    break;
                case WpfMessageBoxButton.YesNoCancel:
                    ButtonCancel.Visibility = Visibility.Visible;
                    ButtonNo.Visibility = Visibility.Visible;
                    ButtonOk.Visibility = Visibility.Collapsed;
                    ButtonYes.Visibility = Visibility.Visible;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void DisplayImage(WpfMessageBoxImage image)
        {
            switch (image)
            {
                case WpfMessageBoxImage.Information:
                    ImageIcon.Source = WpfMessageBoxLibrary.Resources.ImageInformation;
                    break;
                case WpfMessageBoxImage.Error:
                    ImageIcon.Source = WpfMessageBoxLibrary.Resources.ImageCrossCircle;
                    break;
                case WpfMessageBoxImage.Exclamation:
                    ImageIcon.Source = WpfMessageBoxLibrary.Resources.ImageExclamation;
                    break;
                case WpfMessageBoxImage.Question:
                    ImageIcon.Source = WpfMessageBoxLibrary.Resources.ImageQuestion;
                    break;
                case WpfMessageBoxImage.Validation:
                    ImageIcon.Source = WpfMessageBoxLibrary.Resources.ImageTick;
                    break;
                case WpfMessageBoxImage.None:
                    ImageIcon.Source = null;
                    break;
                default:
                    throw new NotImplementedException();
            }

            ImageIcon.Visibility = ImageIcon.Source == null ? Visibility.Collapsed : Visibility.Visible;
        }

        private void SetDefaultAndCancelButtons(WpfMessageBoxButton button)
        {
            switch (button)
            {
                case WpfMessageBoxButton.OK:
                    ButtonOk.IsDefault = true;
                    ButtonOk.IsCancel = true;
                    break;
                case WpfMessageBoxButton.OKCancel:
                    ButtonOk.IsDefault = true;
                    ButtonCancel.IsCancel = true;
                    break;
                case WpfMessageBoxButton.YesNo:
                    ButtonYes.IsDefault = true;
                    ButtonNo.IsCancel = true;
                    break;
                case WpfMessageBoxButton.YesNoCancel:
                    ButtonYes.IsDefault = true;
                    ButtonCancel.IsCancel = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                var content = string.IsNullOrWhiteSpace(Header) ? "" : Header + Environment.NewLine + Environment.NewLine;
                content += Message;

                Clipboard.SetText(content);
            }
        }

        private void Window_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Focus TextBox if present
            if (TextBox.Visibility == Visibility.Visible)
            {
                TextBox.Focus();
                return;
            }

            // Else, focus CheckBox if present
            if (CheckBox.Visibility == Visibility.Visible)
            {
                CheckBox.Focus();
            }
        }
    }
}
