Imports MvvmSample.Model
Imports System.Linq

Namespace MvvmSample.ViewModel

    Friend Class MainViewModel

        Private _Chart As ChartViewModel, _DataProvider As WeatherProvider

        Public Property Chart As ChartViewModel
            Get
                Return _Chart
            End Get

            Private Set(ByVal value As ChartViewModel)
                _Chart = value
            End Set
        End Property

        Public Property DataProvider As WeatherProvider
            Get
                Return _DataProvider
            End Get

            Private Set(ByVal value As WeatherProvider)
                _DataProvider = value
            End Set
        End Property

        Public Sub New()
            DataProvider = New XmlWeatherProvider("Data/WeatherData.xml")
            Dim temperaturePane As PaneViewModel = New PaneViewModel(showXAxis:=False)
            Dim pressurePane As PaneViewModel = New PaneViewModel(showXAxis:=False)
            Dim humidityPane As PaneViewModel = New PaneViewModel(showXAxis:=True)
            Dim temperatureLegend As LegendViewModel = New LegendViewModel(dockTarget:=temperaturePane)
            Dim pressureLegend As LegendViewModel = New LegendViewModel(dockTarget:=pressurePane)
            Dim humidityLegend As LegendViewModel = New LegendViewModel(dockTarget:=humidityPane)
            Dim xAxis As XAxisViewModel = New XAxisViewModel With {.MinValue = Enumerable.First(DataProvider.WeatherInfos).Timestamp, .MaxValue = Enumerable.ElementAt(DataProvider.WeatherInfos, 10).Timestamp}
            Dim temperatureYAxis As YAxisViewModel = New YAxisViewModel(title:="Temperature, F", constantLines:=Nothing)
            Dim pressureYAxis As YAxisViewModel = New YAxisViewModel(title:="Pressure, mbar", constantLines:=Nothing)
            Dim humidityYAxis As YAxisViewModel = New YAxisViewModel(title:="Humidity, %", constantLines:=New ConstantLineViewModel() {New ConstantLineViewModel(title:=String.Empty, value:=60.0)})
            Dim temperatureSeries As SeriesViewModel = New SeriesViewModel(name:="Temperature", type:=SeriesType.Line, argumentName:="Timestamp", valueName:="Temperature", legend:=temperatureLegend, pane:=temperaturePane, yAxis:=temperatureYAxis)
            Dim pressureSeries As SeriesViewModel = New SeriesViewModel(name:="Pressure", type:=SeriesType.Area, argumentName:="Timestamp", valueName:="Pressure", legend:=pressureLegend, pane:=pressurePane, yAxis:=pressureYAxis)
            Dim humiditySeries As SeriesViewModel = New SeriesViewModel(name:="Humidity", type:=SeriesType.Bar, argumentName:="Timestamp", valueName:="RelativeHumidity", legend:=humidityLegend, pane:=humidityPane, yAxis:=humidityYAxis)
            Chart = New ChartViewModel(series:=New SeriesViewModel() {temperatureSeries, pressureSeries, humiditySeries}, panes:=New PaneViewModel() {temperaturePane, pressurePane, humidityPane}, xAxis:=xAxis, yAxes:=New YAxisViewModel() {temperatureYAxis, pressureYAxis, humidityYAxis}, legends:=New LegendViewModel() {temperatureLegend, pressureLegend, humidityLegend})
        End Sub
    End Class
End Namespace
