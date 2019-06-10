using System;
using System.Text;
using System.Windows;
using WpfMessageBoxLibrary;

namespace Demo {

    public partial class WindowMain: Window {

        public WindowMain() {
            InitializeComponent();
        }

        private void ButtonStdMsgBoxAllFeatures_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show(this, GetLongSampleText(), "Some title", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
            DisplayResult(result);
        }

        private void ButtonStdMsgBoxLongText_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show(this, GetLongSampleText(), "Some title", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
            DisplayResult(result);
        }

        private void ButtonStdMsgBoxWithIcon_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show(this, "Some text", "Some title", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            DisplayResult(result);
        }

        private void ButtonStdMsgBoxWithoutTitle_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show(this, "Some text", "", MessageBoxButton.OKCancel);
            DisplayResult(result);
        }

        private void ButtonStdMsgBoxWithText_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show(this, "Some text", "Some title", MessageBoxButton.YesNoCancel);
            DisplayResult(result);
        }

        private void ButtonWpfMsgBoxAllFeatures_Click(object sender, RoutedEventArgs e) {
            var msgProperties = new WpfMessageBoxProperties() {
                Button = MessageBoxButton.YesNoCancel,
                ButtonCancelText = "Cancel, cancel!",
                ButtonNoText = "Please no",
                ButtonYesText = "Yes _Sir",
                CheckBoxText = "I've pre-checked this for you",
                Image = MessageBoxImage.Error,
                Header = "Here we have an example of a very very very very very very very very very very very very very very very very very long instruction text.",
                IsCheckBoxChecked = true,
                IsCheckBoxVisible = true,
                IsTextBoxVisible = true,
                Text = GetLongSampleText(),
                TextBoxText = "You should enter something here",
                Title = "Some title",
            };

            MessageBoxResult result = WpfMessageBox.Show(this, ref msgProperties);
            DisplayResult(result, msgProperties);
        }

        private void ButtonWpfMsgBoxCustomButtons_Click(object sender, RoutedEventArgs e) {
            var msgProperties = new WpfMessageBoxProperties() {
                Button = MessageBoxButton.YesNoCancel,
                ButtonCancelText = "Cancel, cancel!",
                ButtonNoText = "Please no",
                ButtonYesText = "Yes _Sir",
                Image = MessageBoxImage.Information,
                Text = "Some text",
                Title = "Some title",
            };

            MessageBoxResult result = WpfMessageBox.Show(this, ref msgProperties);
            DisplayResult(result);
        }

        private void ButtonWpfMsgBoxLongInstruction_Click(object sender, RoutedEventArgs e) {
            var msgProperties = new  WpfMessageBoxProperties() {
                Button = MessageBoxButton.OK,
                Header = "Here we have an example of a very very very very very very very very very very very very very very very very very long instruction text.",
                Image = MessageBoxImage.Information,
                Text = "Some text",
                Title = "Some title",
            };

            MessageBoxResult result = WpfMessageBox.Show(this, ref msgProperties);
            DisplayResult(result);
        }

        private void ButtonWpfMsgBoxLongText_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult result = WpfMessageBox.Show(this, GetLongSampleText(), "Some title", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
            DisplayResult(result);
        }

        private void ButtonWpfMsgBoxNiceExample_Click(object sender, RoutedEventArgs e) {
            var msgProperties = new WpfMessageBoxProperties() {
                Button = MessageBoxButton.OKCancel,
                ButtonOkText = "Set name",
                CheckBoxText = "Don't ask again",
                Image = MessageBoxImage.Exclamation,
                Header = "No name defined",
                IsCheckBoxChecked = true,
                IsCheckBoxVisible = true,
                IsTextBoxVisible = true,
                Text = "Please enter the name to use. You can leave the field empty in order to continue using the default name.",
                Title = "A nice example",
            };

            MessageBoxResult result = WpfMessageBox.Show(this, ref msgProperties);
            DisplayResult(result, msgProperties);
        }

        private void ButtonWpfMsgBoxWithCheckBox_Click(object sender, RoutedEventArgs e) {
            var msgProperties = new WpfMessageBoxProperties() {
                Button = MessageBoxButton.OKCancel,
                CheckBoxText = "I've pre-checked this for you",
                IsCheckBoxChecked = true,
                IsCheckBoxVisible = true,
                Text = "Some text",
                Title = "Some title",
            };

            MessageBoxResult result = WpfMessageBox.Show(this, ref msgProperties);
            DisplayResult(result, msgProperties);
        }

        private void ButtonWpfMsgBoxWithHeader_Click(object sender, RoutedEventArgs e) {
            var msgProperties = new  WpfMessageBoxProperties() {
                Button = MessageBoxButton.OK,
                Header = "Some header",
                Image = MessageBoxImage.Exclamation,
                Text = "Some text",
                Title = "Some title",
            };

            MessageBoxResult result = WpfMessageBox.Show(this, ref msgProperties);
            DisplayResult(result);
        }

        private void ButtonWpfMsgBoxWithIcon_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult result = WpfMessageBox.Show(this, "Some text", "Some title", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            DisplayResult(result);
        }

        private void ButtonWpfMsgBoxWithoutTitle_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult result = WpfMessageBox.Show(this, "Some text", "", MessageBoxButton.OKCancel);
            DisplayResult(result);
        }

        private void ButtonWpfMsgBoxWithText_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult result = WpfMessageBox.Show(this, "Some text", "Some title", MessageBoxButton.YesNoCancel);
            DisplayResult(result);
        }

        private void ButtonWpfMsgBoxWithTextBox_Click(object sender, RoutedEventArgs e) {
            var msgProperties = new WpfMessageBoxProperties() {
                Button = MessageBoxButton.OKCancel,
                IsTextBoxVisible = true,
                Text = "Some text",
                TextBoxText = "Pre-defined text",
                Title = "Some title",
            };

            MessageBoxResult result = WpfMessageBox.Show(this, ref msgProperties);
            DisplayResult(result, msgProperties);
        }

        private void ButtonWpfMsgBoxWithTextBoxAndCheckBox_Click(object sender, RoutedEventArgs e) {
            var msgProperties = new WpfMessageBoxProperties() {
                Button = MessageBoxButton.OKCancel,
                CheckBoxText = "I've pre-checked this for you",
                IsCheckBoxChecked = true,
                IsCheckBoxVisible = true,
                IsTextBoxVisible = true,
                Text = "Some text",
                Title = "Some title",
            };

            MessageBoxResult result = WpfMessageBox.Show(this, ref msgProperties);
            DisplayResult(result, msgProperties);
        }

        private void DisplayResult(MessageBoxResult result) {
            WpfMessageBox.Show(this, "Result is: DialogResult." + result, "Result", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DisplayResult(MessageBoxResult result, WpfMessageBoxProperties msgProperties) {
            WpfMessageBox.Show(
                this,
                "Result is: DialogResult." + result + Environment.NewLine +
                "Checkbox is " + (msgProperties.IsCheckBoxChecked ? "" : "not ") + "checked" + Environment.NewLine +
                "Textbox value is: " + msgProperties.TextBoxText);
        }

        private string GetLongSampleText() {
            var longText = new StringBuilder();
            for (int row = 0; row < 20; row++) {
                for (int column = 0; column < 30; column++) {
                    longText.Append(row);
                    longText.Append('-');
                    longText.Append(column);
                    longText.Append(' ');
                }
                longText.Append(Environment.NewLine);
                longText.Append(Environment.NewLine);
            }
            return longText.ToString();
        }
    }
}