using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using ExpressionEvaluatorLibrary;

namespace ExpressionsUI
{
  public partial class SolveForm : Form
  {
    private const int steps = 1000;

    private ExpressionBuilder exprBldr;
    private IReadOnlyContext context;
    private IReadOnlyCollection<string> variables;

    private void Clear()
    {
      SolutionTextBox.Clear();
      CalculatedErrorTextBox.Clear();
    }

    private void Solve()
    {
      Clear();

      try
      {
        string unknown = UnknownComboBox.Text;
        double guess = Convert.ToDouble(InitialGuessTextBox.Text);
        double error = Convert.ToDouble(ErrorTextBox.Text);
        double solution = exprBldr.Solve(context, unknown, guess, error, steps);
        Context clonetext = context.Clone();
        clonetext[unknown] = solution;
        double calculatedError = Math.Abs(exprBldr.Evaluate(clonetext));

        SolutionTextBox.Text = solution.ToString();
        CalculatedErrorTextBox.Text = calculatedError.ToString();
      }
      catch (ExpressionBuilder.CouldNotSolveException)
      {
        MessageBox.Show("Couldn't find a solution in the given number of steps. Try another initial guess", "Could not solve", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    public void UpdateExpression(ExpressionBuilder exprBldr, IReadOnlyContext context)
    {
      this.exprBldr = exprBldr;
      this.context = context;
      this.variables = exprBldr.GetVariables();
      UnknownComboBox.Items.Clear();
      UnknownComboBox.Items.AddRange(variables.ToArray());
      foreach (string variable in variables)
      {
        if (!context.IsBound(variable))
        {
          UnknownComboBox.Items.Clear();
          UnknownComboBox.Items.Add(variable);
          break;
        }
      }
      UnknownComboBox.SelectedIndex = 0;

      Clear();
    }

    public SolveForm(ExpressionBuilder exprBldr, IReadOnlyContext context)
    {
      InitializeComponent();

      UpdateExpression(exprBldr, context);
    }

    private void SolveForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        e.Cancel = true;
        this.Hide();
      }
    }

    private void InitialGuessTextBox_Validating(object sender, CancelEventArgs e)
    {
      InitialGuessTextBox.Text = InitialGuessTextBox.Text.Trim();
      if (!Regex.Match(InitialGuessTextBox.Text, @"^-?\d+(?:.\d+)?$").Success)
      {
        e.Cancel = true;
      }
    }

    private void ErrorTextbox_Validating(object sender, CancelEventArgs e)
    {
      ErrorTextBox.Text = ErrorTextBox.Text.Trim();
      if (!Regex.Match(ErrorTextBox.Text, @"^-?\d+(?:.\d+)?$").Success)
      {
        e.Cancel = true;
      }
    }

    private void SolveButton_Click(object sender, EventArgs e)
    {
      Solve();
    }
  }
}