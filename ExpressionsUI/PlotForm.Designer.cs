
namespace ExpressionsUI
{
  partial class PlotForm
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
      this.PlotChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.RangeGroupBox = new System.Windows.Forms.GroupBox();
      this.RightBoundaryTextBox = new System.Windows.Forms.TextBox();
      this.RightBoundaryLabel = new System.Windows.Forms.Label();
      this.BoundarySeparatorLabel = new System.Windows.Forms.Label();
      this.LeftBoundaryLabel = new System.Windows.Forms.Label();
      this.LeftBoundaryTextBox = new System.Windows.Forms.TextBox();
      this.RedrawButton = new System.Windows.Forms.Button();
      this.ArgumentGroupBox = new System.Windows.Forms.GroupBox();
      this.ArgumentComboBox = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.PlotChart)).BeginInit();
      this.RangeGroupBox.SuspendLayout();
      this.ArgumentGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // PlotChart
      // 
      chartArea1.Name = "ChartArea1";
      this.PlotChart.ChartAreas.Add(chartArea1);
      legend1.Enabled = false;
      legend1.Name = "Legend1";
      this.PlotChart.Legends.Add(legend1);
      this.PlotChart.Location = new System.Drawing.Point(12, 12);
      this.PlotChart.Name = "PlotChart";
      series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
      series1.ChartArea = "ChartArea1";
      series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
      series1.Legend = "Legend1";
      series1.Name = "Series1";
      series1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.PlotChart.Series.Add(series1);
      this.PlotChart.Size = new System.Drawing.Size(910, 551);
      this.PlotChart.TabIndex = 0;
      this.PlotChart.Text = "Expression";
      // 
      // RangeGroupBox
      // 
      this.RangeGroupBox.Controls.Add(this.RightBoundaryTextBox);
      this.RangeGroupBox.Controls.Add(this.RightBoundaryLabel);
      this.RangeGroupBox.Controls.Add(this.BoundarySeparatorLabel);
      this.RangeGroupBox.Controls.Add(this.LeftBoundaryLabel);
      this.RangeGroupBox.Controls.Add(this.LeftBoundaryTextBox);
      this.RangeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.RangeGroupBox.Location = new System.Drawing.Point(427, 569);
      this.RangeGroupBox.Name = "RangeGroupBox";
      this.RangeGroupBox.Size = new System.Drawing.Size(302, 65);
      this.RangeGroupBox.TabIndex = 1;
      this.RangeGroupBox.TabStop = false;
      this.RangeGroupBox.Text = "Range";
      // 
      // RightBoundaryTextBox
      // 
      this.RightBoundaryTextBox.Location = new System.Drawing.Point(169, 27);
      this.RightBoundaryTextBox.MaxLength = 60;
      this.RightBoundaryTextBox.Name = "RightBoundaryTextBox";
      this.RightBoundaryTextBox.Size = new System.Drawing.Size(100, 22);
      this.RightBoundaryTextBox.TabIndex = 4;
      this.RightBoundaryTextBox.Text = "1";
      this.RightBoundaryTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.RightBoundaryTextBox_Validating);
      // 
      // RightBoundaryLabel
      // 
      this.RightBoundaryLabel.AutoSize = true;
      this.RightBoundaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.RightBoundaryLabel.Location = new System.Drawing.Point(275, 18);
      this.RightBoundaryLabel.Name = "RightBoundaryLabel";
      this.RightBoundaryLabel.Size = new System.Drawing.Size(23, 31);
      this.RightBoundaryLabel.TabIndex = 3;
      this.RightBoundaryLabel.Text = ")";
      // 
      // BoundarySeparatorLabel
      // 
      this.BoundarySeparatorLabel.AutoSize = true;
      this.BoundarySeparatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BoundarySeparatorLabel.Location = new System.Drawing.Point(141, 18);
      this.BoundarySeparatorLabel.Name = "BoundarySeparatorLabel";
      this.BoundarySeparatorLabel.Size = new System.Drawing.Size(22, 31);
      this.BoundarySeparatorLabel.TabIndex = 2;
      this.BoundarySeparatorLabel.Text = ";";
      // 
      // LeftBoundaryLabel
      // 
      this.LeftBoundaryLabel.AutoSize = true;
      this.LeftBoundaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LeftBoundaryLabel.Location = new System.Drawing.Point(6, 18);
      this.LeftBoundaryLabel.Name = "LeftBoundaryLabel";
      this.LeftBoundaryLabel.Size = new System.Drawing.Size(23, 31);
      this.LeftBoundaryLabel.TabIndex = 1;
      this.LeftBoundaryLabel.Text = "(";
      // 
      // LeftBoundaryTextBox
      // 
      this.LeftBoundaryTextBox.Location = new System.Drawing.Point(35, 27);
      this.LeftBoundaryTextBox.MaxLength = 60;
      this.LeftBoundaryTextBox.Name = "LeftBoundaryTextBox";
      this.LeftBoundaryTextBox.Size = new System.Drawing.Size(100, 22);
      this.LeftBoundaryTextBox.TabIndex = 0;
      this.LeftBoundaryTextBox.Text = "-1";
      this.LeftBoundaryTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.LeftBoundaryTextBox_Validating);
      // 
      // RedrawButton
      // 
      this.RedrawButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.RedrawButton.Location = new System.Drawing.Point(745, 575);
      this.RedrawButton.Name = "RedrawButton";
      this.RedrawButton.Size = new System.Drawing.Size(144, 59);
      this.RedrawButton.TabIndex = 2;
      this.RedrawButton.Text = "Redraw";
      this.RedrawButton.UseVisualStyleBackColor = true;
      this.RedrawButton.Click += new System.EventHandler(this.RedrawButton_Click);
      // 
      // ArgumentGroupBox
      // 
      this.ArgumentGroupBox.Controls.Add(this.ArgumentComboBox);
      this.ArgumentGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ArgumentGroupBox.Location = new System.Drawing.Point(229, 569);
      this.ArgumentGroupBox.Name = "ArgumentGroupBox";
      this.ArgumentGroupBox.Size = new System.Drawing.Size(192, 65);
      this.ArgumentGroupBox.TabIndex = 3;
      this.ArgumentGroupBox.TabStop = false;
      this.ArgumentGroupBox.Text = "Argument";
      // 
      // ArgumentComboBox
      // 
      this.ArgumentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ArgumentComboBox.FormattingEnabled = true;
      this.ArgumentComboBox.Location = new System.Drawing.Point(6, 27);
      this.ArgumentComboBox.Name = "ArgumentComboBox";
      this.ArgumentComboBox.Size = new System.Drawing.Size(180, 24);
      this.ArgumentComboBox.TabIndex = 0;
      // 
      // PlotForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(934, 661);
      this.Controls.Add(this.ArgumentGroupBox);
      this.Controls.Add(this.RedrawButton);
      this.Controls.Add(this.RangeGroupBox);
      this.Controls.Add(this.PlotChart);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PlotForm";
      this.Text = "Plot";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlotForm_FormClosing);
      this.Load += new System.EventHandler(this.PlotForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.PlotChart)).EndInit();
      this.RangeGroupBox.ResumeLayout(false);
      this.RangeGroupBox.PerformLayout();
      this.ArgumentGroupBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataVisualization.Charting.Chart PlotChart;
    private System.Windows.Forms.GroupBox RangeGroupBox;
    private System.Windows.Forms.TextBox RightBoundaryTextBox;
    private System.Windows.Forms.Label RightBoundaryLabel;
    private System.Windows.Forms.Label BoundarySeparatorLabel;
    private System.Windows.Forms.Label LeftBoundaryLabel;
    private System.Windows.Forms.TextBox LeftBoundaryTextBox;
    private System.Windows.Forms.Button RedrawButton;
    private System.Windows.Forms.GroupBox ArgumentGroupBox;
    private System.Windows.Forms.ComboBox ArgumentComboBox;
  }
}