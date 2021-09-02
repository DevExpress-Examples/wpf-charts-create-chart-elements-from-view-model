Imports MvvmSample.ViewModel
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace MvvmSample
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub
	End Class

	Public Class SeriesTypeTemplateSelector
		Inherits DataTemplateSelector

		Public Property AreaTemplate() As DataTemplate
		Public Property BarTemplate() As DataTemplate
		Public Property LineTemplate() As DataTemplate

		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
			Dim seriesVM As SeriesViewModel = TryCast(item, SeriesViewModel)
			If seriesVM Is Nothing Then
				Return MyBase.SelectTemplate(item, container)
			End If

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
