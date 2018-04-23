using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace MvvmSample.Model {
    class WeatherInfo {
        public DateTime Timestamp { get; private set; }
        public double Temperature { get; private set; }
        public int Pressure { get; private set; }
        public int RelativeHumidity { get; private set; }

        public WeatherInfo(
                DateTime timestamp, 
                double temperature, 
                int pressure, 
                int relativeHumidity
        ) {
            this.Timestamp = timestamp;
            this.Temperature = temperature;
            this.Pressure = pressure;
            this.RelativeHumidity = relativeHumidity;
        }
    }

    interface WeatherProvider {
        IEnumerable<WeatherInfo> WeatherInfos { get; }
    }

    class XmlWeatherProvider : WeatherProvider {
        string filename;
        public XmlWeatherProvider(string filename) {
            if (File.Exists(filename)) {
                this.filename = filename;
            }
            else {
                throw new Exception(String.Format("The \'{0}\' file does not exist.", filename));
            }
        }

        Collection<WeatherInfo> infos;
        public IEnumerable<WeatherInfo> WeatherInfos { get {
                if(infos == null) {
                    XDocument doc = XDocument.Load(filename);

                    infos = new Collection<WeatherInfo>();
                    foreach (XElement element in doc.Element("WeatherData").Elements("WeatherInfo")) {
                        infos.Add(new WeatherInfo(
                            timestamp:          DateTime.Parse(element.Element("Timestamp").Value, CultureInfo.InvariantCulture),
                            temperature:        double.Parse(element.Element("Temperature").Value, CultureInfo.InvariantCulture),
                            pressure:           int.Parse(element.Element("Pressure").Value, CultureInfo.InvariantCulture),
                            relativeHumidity:   int.Parse(element.Element("RelativeHumidity").Value, CultureInfo.InvariantCulture)
                        ));
                    }
                }
                return infos;
        }}
    }
}
