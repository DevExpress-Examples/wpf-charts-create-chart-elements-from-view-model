Imports System.Collections.Generic

Namespace MvvmSample.ViewModel

    Friend Class ChartViewModel

        Private _Panes As IEnumerable(Of MvvmSample.ViewModel.PaneViewModel), _XAxis As XAxisViewModel, _YAxes As IEnumerable(Of MvvmSample.ViewModel.YAxisViewModel), _Series As IEnumerable(Of MvvmSample.ViewModel.SeriesViewModel), _Legends As IEnumerable(Of MvvmSample.ViewModel.LegendViewModel)

        Public Property Panes As IEnumerable(Of PaneViewModel)
            Get
                Return _Panes
            End Get

            Private Set(ByVal value As IEnumerable(Of PaneViewModel))
                _Panes = value
            End Set
        End Property

        Public Property XAxis As XAxisViewModel
            Get
                Return _XAxis
            End Get

            Private Set(ByVal value As XAxisViewModel)
                _XAxis = value
            End Set
        End Property

        Public Property YAxes As IEnumerable(Of YAxisViewModel)
            Get
                Return _YAxes
            End Get

            Private Set(ByVal value As IEnumerable(Of YAxisViewModel))
                _YAxes = value
            End Set
        End Property

        Public Property Series As IEnumerable(Of SeriesViewModel)
            Get
                Return _Series
            End Get

            Private Set(ByVal value As IEnumerable(Of SeriesViewModel))
                _Series = value
            End Set
        End Property

        Public Property Legends As IEnumerable(Of LegendViewModel)
            Get
                Return _Legends
            End Get

            Private Set(ByVal value As IEnumerable(Of LegendViewModel))
                _Legends = value
            End Set
        End Property

        Public Sub New(ByVal series As IEnumerable(Of SeriesViewModel), ByVal legends As IEnumerable(Of LegendViewModel), ByVal panes As IEnumerable(Of PaneViewModel), ByVal xAxis As XAxisViewModel, ByVal yAxes As IEnumerable(Of YAxisViewModel))
            Me.Series = series
            Me.XAxis = xAxis
            Me.YAxes = yAxes
            Me.Panes = panes
            Me.Legends = legends
        End Sub
    End Class

    Friend Class LegendViewModel

        Private _DockTarget As PaneViewModel

        Public Property DockTarget As PaneViewModel
            Get
                Return _DockTarget
            End Get

            Private Set(ByVal value As PaneViewModel)
                _DockTarget = value
            End Set
        End Property

        Public Sub New(ByVal dockTarget As PaneViewModel)
            Me.DockTarget = dockTarget
        End Sub
    End Class

    Friend Class PaneViewModel

        Private _ShowXAxis As Boolean

        Public Property ShowXAxis As Boolean
            Get
                Return _ShowXAxis
            End Get

            Private Set(ByVal value As Boolean)
                _ShowXAxis = value
            End Set
        End Property

        Public Sub New(ByVal showXAxis As Boolean)
            Me.ShowXAxis = showXAxis
        End Sub
    End Class

    Friend Class XAxisViewModel

        Public Property MinValue As Date

        Public Property MaxValue As Date
    End Class

    Friend Class YAxisViewModel

        Private _Title As String, _ConstantLines As IEnumerable(Of MvvmSample.ViewModel.ConstantLineViewModel)

        Public Property Title As String
            Get
                Return _Title
            End Get

            Private Set(ByVal value As String)
                _Title = value
            End Set
        End Property

        Public Property ConstantLines As IEnumerable(Of ConstantLineViewModel)
            Get
                Return _ConstantLines
            End Get

            Private Set(ByVal value As IEnumerable(Of ConstantLineViewModel))
                _ConstantLines = value
            End Set
        End Property

        Public Sub New(ByVal title As String, ByVal constantLines As IEnumerable(Of ConstantLineViewModel))
            Me.Title = title
            Me.ConstantLines = constantLines
        End Sub
    End Class

    Friend Class SeriesViewModel

        Private _ArgumentName As String, _ValueName As String, _Legend As LegendViewModel, _Pane As PaneViewModel, _YAxis As YAxisViewModel, _Type As SeriesType

        Public Property Name As String

        Public Property ArgumentName As String
            Get
                Return _ArgumentName
            End Get

            Private Set(ByVal value As String)
                _ArgumentName = value
            End Set
        End Property

        Public Property ValueName As String
            Get
                Return _ValueName
            End Get

            Private Set(ByVal value As String)
                _ValueName = value
            End Set
        End Property

        Public Property Legend As LegendViewModel
            Get
                Return _Legend
            End Get

            Private Set(ByVal value As LegendViewModel)
                _Legend = value
            End Set
        End Property

        Public Property Pane As PaneViewModel
            Get
                Return _Pane
            End Get

            Private Set(ByVal value As PaneViewModel)
                _Pane = value
            End Set
        End Property

        Public Property YAxis As YAxisViewModel
            Get
                Return _YAxis
            End Get

            Private Set(ByVal value As YAxisViewModel)
                _YAxis = value
            End Set
        End Property

        Public Property Type As SeriesType
            Get
                Return _Type
            End Get

            Private Set(ByVal value As SeriesType)
                _Type = value
            End Set
        End Property

        Public Sub New(ByVal name As String, ByVal type As SeriesType, ByVal argumentName As String, ByVal valueName As String, ByVal legend As LegendViewModel, ByVal pane As PaneViewModel, ByVal yAxis As YAxisViewModel)
            Me.Name = name
            Me.Type = type
            Me.ArgumentName = argumentName
            Me.ValueName = valueName
            Me.Legend = legend
            Me.Pane = pane
            Me.YAxis = yAxis
        End Sub
    End Class

    Friend Class ConstantLineViewModel

        Private _Title As String, _Value As Double

        Public Property Title As String
            Get
                Return _Title
            End Get

            Private Set(ByVal value As String)
                _Title = value
            End Set
        End Property

        Public Property Value As Double
            Get
                Return _Value
            End Get

            Private Set(ByVal value As Double)
                _Value = value
            End Set
        End Property

        Public Sub New(ByVal title As String, ByVal value As Double)
            Me.Title = title
            Me.Value = value
        End Sub
    End Class

    Public Enum SeriesType
        Bar
        Area
        Line
    End Enum
End Namespace
