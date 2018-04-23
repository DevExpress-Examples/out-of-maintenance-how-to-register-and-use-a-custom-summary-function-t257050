Namespace RegisterSummaryFunctionExample
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim xyDiagram1 As New DevExpress.XtraCharts.XYDiagram()
            Dim series1 As New DevExpress.XtraCharts.Series()
            Dim chartTitle1 As New DevExpress.XtraCharts.ChartTitle()
            Me.chartControl1 = New DevExpress.XtraCharts.ChartControl()
            Me.productsTableAdapter1 = New RegisterSummaryFunctionExample.nwindDataSetTableAdapters.ProductsTableAdapter()
            Me.bindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
            Me.nwindDataSet1 = New RegisterSummaryFunctionExample.nwindDataSet()
            CType(Me.chartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(xyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(series1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nwindDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' chartControl1
            ' 
            Me.chartControl1.DataAdapter = Me.productsTableAdapter1
            Me.chartControl1.DataSource = Me.bindingSource1
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
            Me.chartControl1.Diagram = xyDiagram1
            Me.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chartControl1.Location = New System.Drawing.Point(0, 0)
            Me.chartControl1.Name = "chartControl1"
            Me.chartControl1.PaletteName = "Office 2013"
            series1.ArgumentDataMember = "ProductName"
            series1.Name = "Product"
            series1.ValueDataMembersSerializable = "UnitPrice"
            Me.chartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() { series1}
            Me.chartControl1.Size = New System.Drawing.Size(1278, 719)
            Me.chartControl1.TabIndex = 0
            chartTitle1.Text = "Products Comparison"
            Me.chartControl1.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() { chartTitle1})
            ' 
            ' productsTableAdapter1
            ' 
            Me.productsTableAdapter1.ClearBeforeFill = True
            ' 
            ' bindingSource1
            ' 
            Me.bindingSource1.DataMember = "Products"
            Me.bindingSource1.DataSource = Me.nwindDataSet1
            Me.bindingSource1.Sort = ""
            ' 
            ' nwindDataSet1
            ' 
            Me.nwindDataSet1.DataSetName = "nwindDataSet"
            Me.nwindDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1278, 719)
            Me.Controls.Add(Me.chartControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType(xyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(series1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chartControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nwindDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private chartControl1 As DevExpress.XtraCharts.ChartControl
        Private productsTableAdapter1 As nwindDataSetTableAdapters.ProductsTableAdapter
        Private bindingSource1 As System.Windows.Forms.BindingSource
        Private nwindDataSet1 As nwindDataSet
    End Class
End Namespace

