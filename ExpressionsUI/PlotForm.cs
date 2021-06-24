using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using ExpressionEvaluatorLibrary;

namespace ExpressionsUI
{
  public partial class PlotForm : Form
  {
    private const int datapoints = 1000;

    private ExpressionBuilder exprBldr;
    private IReadOnlyContext context;
    private IReadOnlyCollection<string> variables;

    private void Clear()
    {
      PlotChart.Series.Clear();
    }

    private void Plot()
    {
      Func<System.Windows.Forms.DataVisualization.Charting.Series> newSeries = () =>
        {
          return new System.Windows.Forms.DataVisualization.Charting.Series()
          {
            Color = System.Drawing.Color.Blue,
            IsVisibleInLegend = false,
            IsXValueIndexed = false,
            ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline,
          };
        };

      Clear();

      Context clonetext = context.Clone();
      string argument = ArgumentComboBox.Text;
      double leftBoundary = Convert.ToDouble(LeftBoundaryTextBox.Text);
      double rightBoundary = Convert.ToDouble(RightBoundaryTextBox.Text);
      double x, f, step;
      x = leftBoundary;
      step = (rightBoundary - leftBoundary) / datapoints;

      System.Windows.Forms.DataVisualization.Charting.Series series = null;
      bool created = false;
      for (int i = 0; i < datapoints; i++)
      {
        clonetext[argument] = x;
        f = exprBldr.Evaluate(clonetext);

        if (Math.Abs(f) < 100000)
        {
          if (!created)
          {
            series = newSeries();
            PlotChart.Series.Add(series);
            created = true;
          }
          series.Points.AddXY(x, f);
        }
        else
        {
          created = false;
        }

        x += step;
      }
      PlotChart.ChartAreas[0].RecalculateAxesScale();
      PlotChart.Invalidate();
    }

    public void UpdateExpression(ExpressionBuilder exprBldr, IReadOnlyContext context)
    {
      Clear();
      this.exprBldr = exprBldr;
      this.context = context;
      this.variables = exprBldr.GetVariables();
      ArgumentComboBox.Items.Clear();
      ArgumentComboBox.Items.AddRange(variables.ToArray());
      foreach (string variable in variables)
      {
        if (!context.IsBound(variable))
        {
          ArgumentComboBox.Items.Clear();
          ArgumentComboBox.Items.Add(variable);
        }
      }
      ArgumentComboBox.SelectedIndex = 0;
    }

    public PlotForm(ExpressionBuilder exprBldr, IReadOnlyContext context)
    {
      InitializeComponent();

      UpdateExpression(exprBldr, context);
    }

    private void PlotForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        e.Cancel = true;
        this.Hide();
      }
    }

    private void PlotForm_Load(object sender, EventArgs e)
    {
      Plot();
    }

    private void LeftBoundaryTextBox_Validating(object sender, CancelEventArgs e)
    {
      LeftBoundaryTextBox.Text = LeftBoundaryTextBox.Text.Trim();
      if (!Regex.Match(LeftBoundaryTextBox.Text, @"^-?\d+(?:.\d+)?$").Success)
      {
        e.Cancel = true;
      }
      else
      {
        double leftBoundary = Convert.ToDouble(LeftBoundaryTextBox.Text);
        double rightBoundary = Convert.ToDouble(RightBoundaryTextBox.Text);
        if (leftBoundary > rightBoundary)
        {
          string ms = LeftBoundaryTextBox.Text;
          LeftBoundaryTextBox.Text = RightBoundaryTextBox.Text;
          RightBoundaryTextBox.Text = ms;
        }
      }
    }

    private void RightBoundaryTextBox_Validating(object sender, CancelEventArgs e)
    {
      RightBoundaryTextBox.Text = RightBoundaryTextBox.Text.Trim();
      if (!Regex.Match(RightBoundaryTextBox.Text, @"^-?\d+(?:.\d+)?$").Success)
      {
        e.Cancel = true;
      }
      else
      {
        double leftBoundary = Convert.ToDouble(LeftBoundaryTextBox.Text);
        double rightBoundary = Convert.ToDouble(RightBoundaryTextBox.Text);
        if (leftBoundary > rightBoundary)
        {
          string ms = LeftBoundaryTextBox.Text;
          LeftBoundaryTextBox.Text = RightBoundaryTextBox.Text;
          RightBoundaryTextBox.Text = ms;
        }
      }
    }

    private void RedrawButton_Click(object sender, EventArgs e)
    {
      Plot();
    }
  }
}