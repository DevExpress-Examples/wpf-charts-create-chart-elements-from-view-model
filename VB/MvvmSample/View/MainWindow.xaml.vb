Imports MvvmSample.ViewModel
Imports System.Windows
Imports System.Windows.Controls

Namespace MvvmSample

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub
    End Class

    Public Class SeriesTypeTemplateSelector
        Inherits DataTemplateSelector

        Public Property AreaTemplate As DataTemplate

        Public Property BarTemplate As DataTemplate

        Public Property LineTemplate As DataTemplate

        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
            Dim seriesVM As SeriesViewModel = TryCast(item, SeriesViewModel)
            If seriesVM Is Nothing Then Return MyBase.SelectTemplate(item, container)
            Select Case seriesVM.Type
                Case SeriesType.Area
                    Return AreaTemplate
                Case SeriesType.Bar
                    Return BarTemplate
                Case SeriesType.Line
                    Return LineTemplate
                Case Else
                    Return MyBase.SelectTemplate(item, container)
            End Select
        End Function
    End Class
End Namespace
