Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Core

Namespace DXApplication3

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits ThemedWindow

        Public Sub New()
            Me.InitializeComponent()
            gc = New GroupingControllerTasksWithCategories(Me.grid)
            AddHandler gc.AfterGrouping, New EventHandler(AddressOf gc_AfterGrouping)
            InitButtonCaption()
        End Sub

        Private Sub groupButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If gc.CategoryColumn Is Nothing Then
                Me.groupButton.IsEnabled = False
                Return
            End If

            If Not gc.CategoryColumn.IsGrouped Then
                Me.grid.GroupBy(gc.CategoryColumn)
            Else
                Me.grid.UngroupBy(gc.CategoryColumn)
            End If
        End Sub

        Private gc As GroupingControllerTasksWithCategories

        Private Sub InitButtonCaption()
            Me.groupButton.Content = If(gc.IsCategoryGrouping, " Ungroup by 'Category'", "Group by 'Category'")
        End Sub

        Private Sub gc_AfterGrouping(ByVal sender As Object, ByVal e As EventArgs)
            InitButtonCaption()
        End Sub
    End Class
End Namespace
