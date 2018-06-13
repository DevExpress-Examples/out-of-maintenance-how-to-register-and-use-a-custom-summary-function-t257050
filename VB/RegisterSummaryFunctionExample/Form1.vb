Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports DevExpress.XtraCharts

Namespace RegisterSummaryFunctionExample
    Partial Public Class Form1
        Inherits Form

        ' Declare the Financial summary function.
        Private Shared Function CalculateProductValue(ByVal series As Series, ByVal argument As Object, ByVal functionArguments() As String, ByVal values() As DataSourceValues, ByVal colors() As Object) As SeriesPoint()

            Dim functionArgument As String = functionArguments(0)
            Dim lastIndex As Integer = values.Length - 1

            Dim open As Double = Convert.ToDouble(values(0)(functionArgument), CultureInfo.InvariantCulture)

            Dim close_Renamed As Double = Convert.ToDouble(values(lastIndex)(functionArgument), CultureInfo.InvariantCulture)
            Dim high As Double = Math.Max(open, close_Renamed)
            Dim low As Double = Math.Min(open, close_Renamed)

            For i As Integer = 1 To lastIndex - 1
                high = Math.Max(high, Convert.ToDouble(values(i)(functionArgument), CultureInfo.InvariantCulture))
                low = Math.Min(low, Convert.ToDouble(values(i)(functionArgument), CultureInfo.InvariantCulture))
            Next i
            ' Return the result.
            Return New SeriesPoint() { New SeriesPoint(argument, high, low, open, close_Renamed) }
        End Function

        Public Sub New()
            InitializeComponent()
            chartControl.DataSource = (New CurrencyRateLoader("../../Data/EurUsdRate.xml")).Load()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            ' Register the summary function in a chart.
            chartControl.RegisterSummaryFunction(name:= "FINANCIAL", displayName:= "Financial", resultScaleType:= ScaleType.Numerical, resultDimension:= 4, argumentDescriptions:= New SummaryFunctionArgumentDescription() { New SummaryFunctionArgumentDescription("Value", ScaleType.Numerical) }, [function]:= AddressOf CalculateProductValue)

            Dim series As Series = chartControl.Series("EurUsd")
            series.SummaryFunction = "FINANCIAL([Value])"
        End Sub
    End Class

    Public Class CurrencyRate
        Private privateDateTime As Date
        Public Property DateTime() As Date
            Get
                Return privateDateTime
            End Get
            Private Set(ByVal value As Date)
                privateDateTime = value
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
        Public Sub New(ByVal dateTime As Date, ByVal value As Double)
            Me.DateTime = dateTime
            Me.Value = value
        End Sub
    End Class

    Public Class CurrencyRateLoader
        Private filePath As String

        Public Sub New(ByVal filePath As String)
            Me.filePath = filePath
        End Sub

        Public Function Load() As IEnumerable(Of CurrencyRate)
            Dim rates As New List(Of CurrencyRate)()
            Dim document As XDocument = XDocument.Load(filePath)
            Dim root As XElement = document.Element("EurUsd").Element("EurUsdRate")
            For Each rateElement As XElement In root.Elements("CurrencyRate")
                rates.Add(New CurrencyRate(dateTime:= Convert.ToDateTime(rateElement.Element("DateTime").Value, CultureInfo.InvariantCulture), value:= Convert.ToDouble(rateElement.Element("Rate").Value, CultureInfo.InvariantCulture)))
            Next rateElement
            Return rates
        End Function
    End Class
End Namespace
