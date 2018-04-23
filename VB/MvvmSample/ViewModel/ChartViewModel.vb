Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace MvvmSample.ViewModel
    Friend Class ChartViewModel
        Private privatePanes As IEnumerable(Of PaneViewModel)
        Public Property Panes() As IEnumerable(Of PaneViewModel)
            Get
                Return privatePanes
            End Get
            Private Set(ByVal value As IEnumerable(Of PaneViewModel))
                privatePanes = value
            End Set
        End Property
        Private privateXAxis As XAxisViewModel
        Public Property XAxis() As XAxisViewModel
            Get
                Return privateXAxis
            End Get
            Private Set(ByVal value As XAxisViewModel)
                privateXAxis = value
            End Set
        End Property
        Private privateYAxes As IEnumerable(Of YAxisViewModel)
        Public Property YAxes() As IEnumerable(Of YAxisViewModel)
            Get
                Return privateYAxes
            End Get
            Private Set(ByVal value As IEnumerable(Of YAxisViewModel))
                privateYAxes = value
            End Set
        End Property
        Private privateSeries As IEnumerable(Of SeriesViewModel)
        Public Property Series() As IEnumerable(Of SeriesViewModel)
            Get
                Return privateSeries
            End Get
            Private Set(ByVal value As IEnumerable(Of SeriesViewModel))
                privateSeries = value
            End Set
        End Property
        Private privateLegends As IEnumerable(Of LegendViewModel)
        Public Property Legends() As IEnumerable(Of LegendViewModel)
            Get
                Return privateLegends
            End Get
            Private Set(ByVal value As IEnumerable(Of LegendViewModel))
                privateLegends = value
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
        Private privateDockTarget As PaneViewModel
        Public Property DockTarget() As PaneViewModel
            Get
                Return privateDockTarget
            End Get
            Private Set(ByVal value As PaneViewModel)
                privateDockTarget = value
            End Set
        End Property

        Public Sub New(ByVal dockTarget As PaneViewModel)
            Me.DockTarget = dockTarget
        End Sub
    End Class

    Friend Class PaneViewModel
        Private privateShowXAxis As Boolean
        Public Property ShowXAxis() As Boolean
            Get
                Return privateShowXAxis
            End Get
            Private Set(ByVal value As Boolean)
                privateShowXAxis = value
            End Set
        End Property

        Public Sub New(ByVal showXAxis As Boolean)
            Me.ShowXAxis = showXAxis
        End Sub
    End Class

    Friend Class XAxisViewModel
        Public Property MinValue() As Date
        Public Property MaxValue() As Date
    End Class

    Friend Class YAxisViewModel
        Private privateTitle As String
        Public Property Title() As String
            Get
                Return privateTitle
            End Get
            Private Set(ByVal value As String)
                privateTitle = value
            End Set
        End Property
        Private privateConstantLines As IEnumerable(Of ConstantLineViewModel)
        Public Property ConstantLines() As IEnumerable(Of ConstantLineViewModel)
            Get
                Return privateConstantLines
            End Get
            Private Set(ByVal value As IEnumerable(Of ConstantLineViewModel))
                privateConstantLines = value
            End Set
        End Property

        Public Sub New(ByVal title As String, ByVal constantLines As IEnumerable(Of ConstantLineViewModel))
            Me.Title = title
            Me.ConstantLines = constantLines
        End Sub
    End Class

    Friend Class SeriesViewModel
        Public Property Name() As String
        Private privateArgumentName As String
        Public Property ArgumentName() As String
            Get
                Return privateArgumentName
            End Get
            Private Set(ByVal value As String)
                privateArgumentName = value
            End Set
        End Property
        Private privateValueName As String
        Public Property ValueName() As String
            Get
                Return privateValueName
            End Get
            Private Set(ByVal value As String)
                privateValueName = value
            End Set
        End Property
        Private privateLegend As LegendViewModel
        Public Property Legend() As LegendViewModel
            Get
                Return privateLegend
            End Get
            Private Set(ByVal value As LegendViewModel)
                privateLegend = value
            End Set
        End Property
        Private privatePane As PaneViewModel
        Public Property Pane() As PaneViewModel
            Get
                Return privatePane
            End Get
            Private Set(ByVal value As PaneViewModel)
                privatePane = value
            End Set
        End Property
        Private privateYAxis As YAxisViewModel
        Public Property YAxis() As YAxisViewModel
            Get
                Return privateYAxis
            End Get
            Private Set(ByVal value As YAxisViewModel)
                privateYAxis = value
            End Set
        End Property
        Private privateType As SeriesType
        Public Property Type() As SeriesType
            Get
                Return privateType
            End Get
            Private Set(ByVal value As SeriesType)
                privateType = value
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
        Private privateTitle As String
        Public Property Title() As String
            Get
                Return privateTitle
            End Get
            Private Set(ByVal value As String)
                privateTitle = value
            End Set
        End Property
        Private privateValue As Double
        Public Property Value() As Double
            Get
                Return privateValue
            End Get
            Private Set(ByVal value As Double)
                privateValue = value
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
