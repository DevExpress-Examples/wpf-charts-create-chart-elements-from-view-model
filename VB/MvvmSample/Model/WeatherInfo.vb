Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.IO
Imports System.Xml.Linq

Namespace MvvmSample.Model
	Friend Class WeatherInfo
		Private privateTimestamp As DateTime
		Public Property Timestamp() As DateTime
			Get
				Return privateTimestamp
			End Get
			Private Set(ByVal value As DateTime)
				privateTimestamp = value
			End Set
		End Property
		Private privateTemperature As Double
		Public Property Temperature() As Double
			Get
				Return privateTemperature
			End Get
			Private Set(ByVal value As Double)
				privateTemperature = value
			End Set
		End Property
		Private privatePressure As Integer
		Public Property Pressure() As Integer
			Get
				Return privatePressure
			End Get
			Private Set(ByVal value As Integer)
				privatePressure = value
			End Set
		End Property
		Private privateRelativeHumidity As Integer
		Public Property RelativeHumidity() As Integer
			Get
				Return privateRelativeHumidity
			End Get
			Private Set(ByVal value As Integer)
				privateRelativeHumidity = value
			End Set
		End Property

		Public Sub New(ByVal timestamp As DateTime, ByVal temperature As Double, ByVal pressure As Integer, ByVal relativeHumidity As Integer)
			Me.Timestamp = timestamp
			Me.Temperature = temperature
			Me.Pressure = pressure
			Me.RelativeHumidity = relativeHumidity
		End Sub
	End Class

	Friend Interface WeatherProvider
		ReadOnly Property WeatherInfos() As IEnumerable(Of WeatherInfo)
	End Interface

	Friend Class XmlWeatherProvider
		Implements WeatherProvider

		Private filename As String
		Public Sub New(ByVal filename As String)
			If File.Exists(filename) Then
				Me.filename = filename
			Else
				Throw New Exception(String.Format("The '{0}' file does not exist.", filename))
			End If
		End Sub

		Private infos As Collection(Of WeatherInfo)
		Public ReadOnly Property WeatherInfos() As IEnumerable(Of WeatherInfo) Implements WeatherProvider.WeatherInfos
			Get
				If infos Is Nothing Then
					Dim doc As XDocument = XDocument.Load(filename)

					infos = New Collection(Of WeatherInfo)()
					For Each element As XElement In doc.Element("WeatherData").Elements("WeatherInfo")
						infos.Add(New WeatherInfo(timestamp:= DateTime.Parse(element.Element("Timestamp").Value, CultureInfo.InvariantCulture), temperature:= Double.Parse(element.Element("Temperature").Value, CultureInfo.InvariantCulture), pressure:= Integer.Parse(element.Element("Pressure").Value, CultureInfo.InvariantCulture), relativeHumidity:= Integer.Parse(element.Element("RelativeHumidity").Value, CultureInfo.InvariantCulture)))
					Next element
				End If
				Return infos
			End Get
		End Property
	End Class
End Namespace
