namespace Libreria_Anglik
{
    partial class Reportes_Productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartProductosMasVendidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartProductosMayorStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartProMinVen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartProduntosMenor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosMasVendidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosMayorStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProMinVen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProduntosMenor)).BeginInit();
            this.SuspendLayout();
            // 
            // chartProductosMasVendidos
            // 
            this.chartProductosMasVendidos.BackColor = System.Drawing.Color.Gray;
            chartArea1.BackColor = System.Drawing.Color.Gray;
            chartArea1.Name = "ChartArea1";
            this.chartProductosMasVendidos.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Gray;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartProductosMasVendidos.Legends.Add(legend1);
            this.chartProductosMasVendidos.Location = new System.Drawing.Point(89, 35);
            this.chartProductosMasVendidos.Name = "chartProductosMasVendidos";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartProductosMasVendidos.Series.Add(series1);
            this.chartProductosMasVendidos.Size = new System.Drawing.Size(548, 308);
            this.chartProductosMasVendidos.TabIndex = 1;
            this.chartProductosMasVendidos.Text = "chart1";
            // 
            // chartProductosMayorStock
            // 
            this.chartProductosMayorStock.BackColor = System.Drawing.Color.Gray;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DarkHorizontal;
            chartArea2.BorderColor = System.Drawing.Color.White;
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.BorderWidth = 3;
            chartArea2.Name = "ChartArea1";
            this.chartProductosMayorStock.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Gray;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartProductosMayorStock.Legends.Add(legend2);
            this.chartProductosMayorStock.Location = new System.Drawing.Point(89, 368);
            this.chartProductosMayorStock.Name = "chartProductosMayorStock";
            this.chartProductosMayorStock.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.BackSecondaryColor = System.Drawing.Color.White;
            series2.BorderColor = System.Drawing.Color.Green;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.LabelBackColor = System.Drawing.Color.White;
            series2.LabelBorderColor = System.Drawing.Color.Black;
            series2.LabelBorderWidth = 2;
            series2.Legend = "Legend1";
            series2.Name = "Productos";
            this.chartProductosMayorStock.Series.Add(series2);
            this.chartProductosMayorStock.Size = new System.Drawing.Size(548, 308);
            this.chartProductosMayorStock.TabIndex = 2;
            this.chartProductosMayorStock.Text = "chart1";
            // 
            // chartProMinVen
            // 
            this.chartProMinVen.BackColor = System.Drawing.Color.Gray;
            chartArea3.BackColor = System.Drawing.Color.Gray;
            chartArea3.Name = "ChartArea1";
            this.chartProMinVen.ChartAreas.Add(chartArea3);
            legend3.BackColor = System.Drawing.Color.Gray;
            legend3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.ForeColor = System.Drawing.Color.White;
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.chartProMinVen.Legends.Add(legend3);
            this.chartProMinVen.Location = new System.Drawing.Point(708, 35);
            this.chartProMinVen.Name = "chartProMinVen";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartProMinVen.Series.Add(series3);
            this.chartProMinVen.Size = new System.Drawing.Size(558, 308);
            this.chartProMinVen.TabIndex = 3;
            this.chartProMinVen.Text = "chart1";
            // 
            // chartProduntosMenor
            // 
            this.chartProduntosMenor.BackColor = System.Drawing.Color.Gray;
            chartArea4.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Stacked;
            chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea4.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DarkHorizontal;
            chartArea4.BackImageTransparentColor = System.Drawing.Color.White;
            chartArea4.BackSecondaryColor = System.Drawing.Color.Silver;
            chartArea4.BorderColor = System.Drawing.Color.White;
            chartArea4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.BorderWidth = 3;
            chartArea4.IsSameFontSizeForAllAxes = true;
            chartArea4.Name = "ChartArea1";
            chartArea4.ShadowColor = System.Drawing.Color.Silver;
            this.chartProduntosMenor.ChartAreas.Add(chartArea4);
            legend4.BackColor = System.Drawing.Color.Gray;
            legend4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend4.ForeColor = System.Drawing.Color.White;
            legend4.IsTextAutoFit = false;
            legend4.Name = "Legend1";
            this.chartProduntosMenor.Legends.Add(legend4);
            this.chartProduntosMenor.Location = new System.Drawing.Point(708, 368);
            this.chartProduntosMenor.Name = "chartProduntosMenor";
            this.chartProduntosMenor.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series4.BackImageTransparentColor = System.Drawing.Color.White;
            series4.BorderColor = System.Drawing.Color.Red;
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.IsValueShownAsLabel = true;
            series4.LabelBackColor = System.Drawing.Color.White;
            series4.LabelBorderColor = System.Drawing.Color.Black;
            series4.LabelBorderWidth = 2;
            series4.Legend = "Legend1";
            series4.MarkerBorderColor = System.Drawing.Color.White;
            series4.MarkerColor = System.Drawing.Color.White;
            series4.MarkerImageTransparentColor = System.Drawing.Color.White;
            series4.Name = "Productos";
            this.chartProduntosMenor.Series.Add(series4);
            this.chartProduntosMenor.Size = new System.Drawing.Size(558, 308);
            this.chartProduntosMenor.TabIndex = 4;
            this.chartProduntosMenor.Text = "chart1";
            title1.BackColor = System.Drawing.Color.Gray;
            title1.Name = "Title1";
            this.chartProduntosMenor.Titles.Add(title1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(86, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Productos Mayor Stock";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(705, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Productos Menor Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(86, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Productos Mas Vendidos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(705, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Productos Menos Vendidos";
            // 
            // Reportes_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1410, 688);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartProduntosMenor);
            this.Controls.Add(this.chartProMinVen);
            this.Controls.Add(this.chartProductosMayorStock);
            this.Controls.Add(this.chartProductosMasVendidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reportes_Productos";
            this.Text = "Reportes_Productos";
            this.Load += new System.EventHandler(this.Reportes_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosMasVendidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosMayorStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProMinVen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProduntosMenor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartProductosMasVendidos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProductosMayorStock;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProMinVen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProduntosMenor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}