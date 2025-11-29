# WpfMessageBox

[![Nuget](https://img.shields.io/nuget/v/wpfmessagebox.svg?logo=nuget)](https://www.nuget.org/packages/WpfMessageBox) [![Workflow status](https://github.com/Otiel/WpfMessageBox/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/Otiel/WpfMessageBox/actions/workflows/dotnet.yml)

## Description

WpfMessageBox is a WPF message box implementation, aimed to be visually balanced between the default WPF style and the native .NET MessageBox. It offers the following features:

* Returns an equivalent of the standard .NET [MessageBoxResult](https://docs.microsoft.com/en-us/dotnet/api/system.windows.messageboxresult)s.
* Uses an equivalent of the standard MessageBox [icons](https://docs.microsoft.com/en-us/windows/desktop/uxguide/vis-std-icons).
* Ability to define custom buttons text.
* Optional header text.
* Optional TextBox.
* Optional CheckBox.

![Screenshot 1](docs/images/Screenshot-custom-buttons.png)
![Screenshot 2](docs/images/Screenshot-full.png)

## Usage

1. Install through [Nuget](https://www.nuget.org/packages/WpfMessageBox)
2. WpfMessageBox uses static methods like the standard .NET MessageBox:

    ```csharp
    using WpfMessageBoxLibrary;

    WpfMessageBoxResult result = WpfMessageBox.Show("Some text", "Some title", WpfMessageBoxButton.OK, WpfMessageBoxImage.Exclamation);
    ```

3. In order to use the extra features offered by WpfMessageBox, you need to initialize a new `WpfMessageBoxProperties` which will hold the desired properties, then use the relevant static method:

    ```csharp
    using WpfMessageBoxLibrary;

    var msgProperties = new WpfMessageBoxProperties() {
        Button = WpfMessageBoxButton.OKCancel,
        ButtonOkText = "Set name",
        CheckBoxText = "Don't ask again",
        Image = WpfMessageBoxImage.Exclamation,
        Header = "No name defined",
        IsCheckBoxChecked = true,
        IsCheckBoxVisible = true,
        IsTextBoxVisible = true,
        Text = "Please enter the name to use. You can leave the field empty in order to continue using the default name.",
        Title = "A nice example",
    };

    WpfMessageBoxResult result = WpfMessageBox.Show(this, ref msgProperties);
    ```

4. The `WpfMessageBoxProperties` object allows you to retrieve the `TextBox` and `CheckBox` values after the user closed the message box:

    ```csharp
    bool checkBoxChecked = msgProperties.IsCheckBoxChecked;
    string textBoxContent = msgProperties.TextBoxText;
    ```

More examples can be found in the Demo project of this repository.

## Release notes

See the [changelog](CHANGELOG.md).

## License

WpfMessageBox is licensed under the MIT license - see the [LICENSE](LICENSE) file for details.

## Credits

Some icons by [Yusuke Kamiyamane](http://p.yusukekamiyamane.com) licensed under a [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0).

