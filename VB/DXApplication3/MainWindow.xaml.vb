Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Core

Namespace DXApplication3
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits DXWindow

		Public Sub New()
			InitializeComponent()
			gc = New GroupingControllerTasksWithCategories(grid)
			AddHandler gc.AfterGrouping, AddressOf gc_AfterGrouping
			InitButtonCaption()
		End Sub

		Private Sub groupButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If gc.CategoryColumn Is Nothing Then
				groupButton.IsEnabled = False
				Return
			End If
			If Not gc.CategoryColumn.IsGrouped Then
				grid.GroupBy(gc.CategoryColumn)
			Else
				grid.UngroupBy(gc.CategoryColumn)
			End If

		End Sub

		Private gc As GroupingControllerTasksWithCategories
		Private Sub InitButtonCaption()
			groupButton.Content = If(gc.IsCategoryGrouping, " Ungroup by 'Category'", "Group by 'Category'")
		End Sub

		Private Sub gc_AfterGrouping(ByVal sender As Object, ByVal e As EventArgs)
			InitButtonCaption()
		End Sub
	End Class
End Namespace
