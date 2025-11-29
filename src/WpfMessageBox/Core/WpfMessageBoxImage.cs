// ReSharper disable once CheckNamespace

namespace WpfMessageBoxLibrary
{
    /// <summary>Specifies the icon that is displayed by a message box.</summary>
    public enum WpfMessageBoxImage
    {
        /// <summary>The message box contains no symbols.</summary>
        None,

        /// <summary>The message box contains a symbol consisting of white X in a circle with a red background.</summary>
        Error,

        /// <summary>The message box contains a symbol consisting of a question mark in a circle.</summary>
        Question,

        /// <summary>The message box contains a symbol consisting of an exclamation point in a triangle with a yellow background.</summary>
        Exclamation,

        /// <summary>The message box contains a symbol consisting of a lowercase letter i in a circle.</summary>
        Information,

        /// <summary>The message box contains a symbol consisting of a green tick.</summary>
        Validation,
    }
}
