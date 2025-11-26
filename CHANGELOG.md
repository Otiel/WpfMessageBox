# 2.0.0 (2025-11-29)

## Breaking changes

* The use of the standard `MessageBox` objects have been replaced in order to remove the `System.Drawing.Common` dependency. [#7](https://github.com/Otiel/WpfMessageBox/pull/7)

  You should replace the use of:

  * `MessageBoxResult` by `WpfMessageBoxResult`
  * `MessageBoxIcon` by `WpfMessageBoxIcon`
  * `MessageBoxImage` by `WpfMessageBoxImage`

## New features

* Add `WpfMessageBoxImage.Validation` showing a green tick ✔. [#7](https://github.com/Otiel/WpfMessageBox/pull/7)
* Add support for .NET 10. [#6](https://github.com/Otiel/WpfMessageBox/pull/6)

# 1.3.0 (2025-10-19)

## Breaking changes

* Now targets .NET Framework 4.8 instead of 4.0.

## New features

* Multi-targets .NET Framework 4.8 and .NET 9. [#3](https://github.com/Otiel/WpfMessageBox/issues/3)
* Focus is automatically set on TextBox (if present) or CheckBox (if present) when the window is open. [#2](https://github.com/Otiel/WpfMessageBox/issues/2)

# 1.2.0 (2019-06-14)

## New features

* Default button texts (Ok, Cancel, Yes, No) are now localized by looking for the localized strings in user32.dll.
* Hitting Ctrl-C while focus is on the message box will save its content to the clipboard.

# 1.1.1 (2019-06-10)

## Bug fixes

* Set MessageBox to be centered on its parent window.
* Fix blurry font.

# 1.1.0 (2019-06-10)

## Improvements

* Target .NET Framework 4 instead of 4.7.2.

# 1.0.1 (2019-06-10)

## Improvements

* Added XML documentation for IntelliSense.
* Unified project name.

# 1.0.0 (2019-06-10)

This is the first release of WpfMessageBox.
