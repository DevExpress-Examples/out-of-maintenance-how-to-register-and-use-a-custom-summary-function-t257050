using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.XtraCharts;

namespace RegisterSummaryFunctionExample {
    public partial class Form1 : Form {
        // Declare the Financial summary function.
        private static SeriesPoint[] CalculateProductValue(
            Series series,
            object argument,
            string[] functionArguments,
            DataSourceValues[] values,
            object[] colors) {

            string functionArgument = functionArguments[0];
            int lastIndex = values.Length - 1;

            double open = Convert.ToDouble(values[0][functionArgument], CultureInfo.InvariantCulture);
            double close = Convert.ToDouble(values[lastIndex][functionArgument], CultureInfo.InvariantCulture);
            double high = Math.Max(open, close);
            double low = Math.Min(open, close);
            
            for (int i = 1; i < lastIndex; i++) {
                high = Math.Max(high, Convert.ToDouble(values[i][functionArgument], CultureInfo.InvariantCulture));
                low = Math.Min(low, Convert.ToDouble(values[i][functionArgument], CultureInfo.InvariantCulture));
            }
            // Return the result.
            return new SeriesPoint[] {
                new SeriesPoint(argument, high, low, open, close)
            };
        }

        public Form1() {
            InitializeComponent();
            chartControl.DataSource = new CurrencyRateLoader("../../Data/EurUsdRate.xml").Load();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Register the summary function in a chart.
            chartControl.RegisterSummaryFunction(
                name: "FINANCIAL",
                displayName: "Financial",
                resultScaleType: ScaleType.Numerical,
                resultDimension: 4,
                argumentDescriptions: new SummaryFunctionArgumentDescription[] {
                    new SummaryFunctionArgumentDescription("Value", ScaleType.Numerical)
                },
                function: CalculateProductValue
            );

            Series series = chartControl.Series["EurUsd"];
            series.SummaryFunction = "FINANCIAL([Value])";
        }
    }

    public class CurrencyRate {
        public DateTime DateTime { get; private set; }
        public double Value { get; private set; }
        public CurrencyRate(DateTime dateTime, double value) {
            DateTime = dateTime;
            Value = value;
        }
    }

    public class CurrencyRateLoader {
        private string filePath;

        public CurrencyRateLoader(String filePath) {
            this.filePath = filePath;
        }

        public IEnumerable<CurrencyRate> Load() {
            List<CurrencyRate> rates = new List<CurrencyRate>();
            XDocument document = XDocument.Load(filePath);
            XElement root = document.Element("EurUsd").Element("EurUsdRate");
            foreach(XElement rateElement in root.Elements("CurrencyRate")) {
                rates.Add(new CurrencyRate(
                    dateTime: Convert.ToDateTime(rateElement.Element("DateTime").Value, CultureInfo.InvariantCulture),
                    value: Convert.ToDouble(rateElement.Element("Rate").Value, CultureInfo.InvariantCulture)
                ));
            }
            return rates;
        }
    }
}
