Imports MvvmSample.Model
Imports System
Imports System.Linq

Namespace MvvmSample.ViewModel
    Friend Class MainViewModel
        Private privateChart As ChartViewModel
        Public Property Chart() As ChartViewModel
            Get
                Return privateChart
            End Get
            Private Set(ByVal value As ChartViewModel)
                privateChart = value
            End Set
        End Property

        Private privateDataProvider As WeatherProvider
        Public Property DataProvider() As WeatherProvider
            Get
                Return privateDataProvider
            End Get
            Private Set(ByVal value As WeatherProvider)
                privateDataProvider = value
            End Set
        End Property

        Public Sub New()
            DataProvider = New XmlWeatherProvider("Data/WeatherData.xml")


            Dim temperaturePane As New PaneViewModel(showXAxis:= False)
            Dim pressurePane As New PaneViewModel(showXAxis:= False)
            Dim humidityPane As New PaneViewModel(showXAxis:= True)

            Dim temperatureLegend As New LegendViewModel(dockTarget:= temperaturePane)
            Dim pressureLegend As New LegendViewModel(dockTarget:= pressurePane)
            Dim humidityLegend As New LegendViewModel(dockTarget:= humidityPane)


            Dim xAxis As XAxisViewModel = New XAxisViewModel With { _
                .MinValue = DataProvider.WeatherInfos.First().Timestamp, _
                .MaxValue = DataProvider.WeatherInfos.ElementAt(10).Timestamp _
            }

            Dim temperatureYAxis As New YAxisViewModel(title:= "Temperature, F", constantLines:= Nothing)
            Dim pressureYAxis As New YAxisViewModel(title:= "Pressure, mbar", constantLines:= Nothing)
            Dim humidityYAxis As New YAxisViewModel(title:= "Humidity, %", constantLines:= New ConstantLineViewModel() { New ConstantLineViewModel(title:= String.Empty, value:= 60.0) })

            Dim temperatureSeries As New SeriesViewModel(name:= "Temperature", type:= SeriesType.Line, argumentName:= "Timestamp", valueName:= "Temperature", legend:= temperatureLegend, pane:= temperaturePane, yAxis:= temperatureYAxis)
            Dim pressureSeries As New SeriesViewModel(name:= "Pressure", type:= SeriesType.Area, argumentName:= "Timestamp", valueName:= "Pressure", legend:= pressureLegend, pane:= pressurePane, yAxis:= pressureYAxis)
            Dim humiditySeries As New SeriesViewModel(name:= "Humidity", type:= SeriesType.Bar, argumentName:= "Timestamp", valueName:= "RelativeHumidity", legend:= humidityLegend, pane:= humidityPane, yAxis:= humidityYAxis)

            Chart = New ChartViewModel(series:= New SeriesViewModel() { temperatureSeries, pressureSeries, humiditySeries }, panes:= New PaneViewModel() { temperaturePane, pressurePane, humidityPane }, xAxis:= xAxis, yAxes:= New YAxisViewModel() { temperatureYAxis, pressureYAxis, humidityYAxis }, legends:= New LegendViewModel() { temperatureLegend, pressureLegend, humidityLegend })
        End Sub
    End Class
End Namespace
