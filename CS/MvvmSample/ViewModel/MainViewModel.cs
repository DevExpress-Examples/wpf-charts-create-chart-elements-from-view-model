using MvvmSample.Model;
using System;
using System.Linq;

namespace MvvmSample.ViewModel {
    class MainViewModel {
        public ChartViewModel Chart { get; private set; }

        public WeatherProvider DataProvider { get; private set; }

        public MainViewModel() {
            DataProvider = new XmlWeatherProvider("Data/WeatherData.xml");


            PaneViewModel temperaturePane = new PaneViewModel(
                    showXAxis: false
                );
            PaneViewModel pressurePane = new PaneViewModel(
                    showXAxis: false
                );
            PaneViewModel humidityPane = new PaneViewModel(
                showXAxis: true
            );

            LegendViewModel temperatureLegend = new LegendViewModel(dockTarget: temperaturePane);
            LegendViewModel pressureLegend = new LegendViewModel(dockTarget: pressurePane);
            LegendViewModel humidityLegend = new LegendViewModel(dockTarget: humidityPane);


            XAxisViewModel xAxis = new XAxisViewModel {
                MinValue = DataProvider.WeatherInfos.First().Timestamp,
                MaxValue = DataProvider.WeatherInfos.ElementAt(10).Timestamp
            };

            YAxisViewModel temperatureYAxis = new YAxisViewModel(
                    title: "Temperature, F",
                    constantLines: null
                );
            YAxisViewModel pressureYAxis = new YAxisViewModel(
                    title: "Pressure, mbar",
                    constantLines: null
                );
            YAxisViewModel humidityYAxis = new YAxisViewModel(
                    title: "Humidity, %",
                    constantLines: new ConstantLineViewModel[] {
                        new ConstantLineViewModel(
                            title: String.Empty, 
                            value: 60.0)
                    }
                );

            SeriesViewModel temperatureSeries = new SeriesViewModel(
                    name: "Temperature",
                    type: SeriesType.Line,
                    argumentName: "Timestamp",
                    valueName: "Temperature",
                    legend: temperatureLegend,
                    pane: temperaturePane,
                    yAxis: temperatureYAxis
                );
            SeriesViewModel pressureSeries = new SeriesViewModel(
                    name: "Pressure",
                    type: SeriesType.Area,
                    argumentName: "Timestamp",
                    valueName: "Pressure",
                    legend: pressureLegend,
                    pane: pressurePane,
                    yAxis: pressureYAxis
                );
            SeriesViewModel humiditySeries = new SeriesViewModel(
                name: "Humidity",
                type: SeriesType.Bar,
                argumentName: "Timestamp",
                valueName: "RelativeHumidity",
                legend: humidityLegend,
                pane: humidityPane,
                yAxis: humidityYAxis);

            Chart = new ChartViewModel(
                series: new SeriesViewModel[] { temperatureSeries, pressureSeries, humiditySeries },
                panes: new PaneViewModel[] { temperaturePane, pressurePane, humidityPane },
                xAxis: xAxis,
                yAxes: new YAxisViewModel[] { temperatureYAxis, pressureYAxis, humidityYAxis },
                legends: new LegendViewModel[] { temperatureLegend, pressureLegend, humidityLegend }
            );
        }
    }
}
