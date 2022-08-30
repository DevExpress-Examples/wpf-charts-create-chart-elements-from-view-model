Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.IO
Imports System.Xml.Linq

Namespace MvvmSample.Model

    Friend Class WeatherInfo

        Private _Timestamp As DateTime, _Temperature As Double, _Pressure As Integer, _RelativeHumidity As Integer

        Public Property Timestamp As DateTime
            Get
                Return _Timestamp
            End Get

            Private Set(ByVal value As DateTime)
                _Timestamp = value
            End Set
        End Property

        Public Property Temperature As Double
            Get
                Return _Temperature
            End Get

            Private Set(ByVal value As Double)
                _Temperature = value
            End Set
        End Property

        Public Property Pressure As Integer
            Get
                Return _Pressure
            End Get

            Private Set(ByVal value As Integer)
                _Pressure = value
            End Set
        End Property

        Public Property RelativeHumidity As Integer
            Get
                Return _RelativeHumidity
            End Get

            Private Set(ByVal value As Integer)
                _RelativeHumidity = value
            End Set
        End Property

        Public Sub New(ByVal timestamp As System.DateTime, ByVal temperature As Double, ByVal pressure As Integer, ByVal relativeHumidity As Integer)
            Me.Timestamp = timestamp
            Me.Temperature = temperature
            Me.Pressure = pressure
            Me.RelativeHumidity = relativeHumidity
        End Sub
    End Class

    Friend Interface WeatherProvider

        ReadOnly Property WeatherInfos As IEnumerable(Of MvvmSample.Model.WeatherInfo)

    End Interface

    Friend Class XmlWeatherProvider
        Implements MvvmSample.Model.WeatherProvider

        Private filename As String

        Public Sub New(ByVal filename As String)
            If System.IO.File.Exists(filename) Then
                Me.filename = filename
            Else
                Throw New System.Exception(System.[String].Format("The '{0}' file does not exist.", filename))
            End If
        End Sub

        Private infos As System.Collections.ObjectModel.Collection(Of MvvmSample.Model.WeatherInfo)

        Public ReadOnly Property WeatherInfos As IEnumerable(Of MvvmSample.Model.WeatherInfo) Implements Global.MvvmSample.Model.WeatherProvider.WeatherInfos
            Get
                If Me.infos Is Nothing Then
                    Dim doc As System.Xml.Linq.XDocument = System.Xml.Linq.XDocument.Load(Me.filename)
                    Me.infos = New System.Collections.ObjectModel.Collection(Of MvvmSample.Model.WeatherInfo)()
                    For Each element As System.Xml.Linq.XElement In doc.Element(CType(("WeatherData"), System.Xml.Linq.XName)).Elements("WeatherInfo")
                        Me.infos.Add(New MvvmSample.Model.WeatherInfo(timestamp:=System.DateTime.Parse(element.Element(CType(("Timestamp"), System.Xml.Linq.XName)).Value, System.Globalization.CultureInfo.InvariantCulture), temperature:=Double.Parse(element.Element(CType(("Temperature"), System.Xml.Linq.XName)).Value, System.Globalization.CultureInfo.InvariantCulture), pressure:=Integer.Parse(element.Element(CType(("Pressure"), System.Xml.Linq.XName)).Value, System.Globalization.CultureInfo.InvariantCulture), relativeHumidity:=Integer.Parse(element.Element(CType(("RelativeHumidity"), System.Xml.Linq.XName)).Value, System.Globalization.CultureInfo.InvariantCulture)))
                    Next
                End If

                Return Me.infos
            End Get
        End Property
    End Class
End Namespace
