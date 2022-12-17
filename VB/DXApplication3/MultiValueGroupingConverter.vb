Imports System
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Markup

Namespace DXApplication3

    Public Class PercentCompleteToFontWeightConverter
        Inherits MarkupExtension
        Implements IValueConverter

        Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
            Return Me
        End Function

        Private Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
            Dim percentComplete As Double = System.Convert.ToDouble(value)
            Return If(0 < percentComplete AndAlso percentComplete < 100, FontWeights.Bold, FontWeights.Normal)
        End Function

        Private Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
