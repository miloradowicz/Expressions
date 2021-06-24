using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using ExpressionEvaluatorLibrary;

namespace ExpressionsUI
{
  public partial class MainForm : Form
  {
    private const string dotPath = ".\\external\\dot.exe";

    private static string currentDirectory = Directory.GetCurrentDirectory();

    private bool parsed = false;
    private string expression = String.Empty;
    private int contextCounter = 1;

    private ExpressionBuilder exprBldr;
    private IReadOnlyCollection<string> variables;
    private DataTable varconBindings;

    private TreeDisplayForm treeDisplayForm;
    private PlotForm plotForm;
    private SolveForm solveForm;

    private void Clear()
    {
      parsed = false;
      expression = String.Empty;
      contextCounter = 1;
      exprBldr = null;
      variables = null;
      varconBindings.Rows.Clear();
      while (varconBindings.Columns.Count > 1)
        varconBindings.Columns.RemoveAt(1);
      ContextsListBox.Items.Clear();
      BindingsGridView.CellValueChanged -= BindingsGridView_CellValueChanged; // asjfhauwjb ry8 u8fu sdf dsaf dfas f
      VariablesTextBox.Clear();
    }

    private void AssembleContext(out Context context)
    {
      context = null;

      if (!parsed)
        return;

      string contextName = ContextsListBox.Text;
      context = ExpressionBuilder.CreateContext();

      foreach (DataRow row in varconBindings.Rows)
      {
        try
        {
          context[row["Name"] as string] = (double)row[contextName];
        }
        catch (InvalidCastException)
        {
        }
      }
    }

    private void NewContext()
    {
      string contextName = $"Context {contextCounter++}";

      varconBindings.Columns.Add(contextName, typeof(double));
      BindingsGridView.Columns[contextName].Width = 148;
      foreach (DataGridViewColumn column in BindingsGridView.Columns)
        column.Visible = false;
      BindingsGridView.Columns["Name"].Visible = true;
      BindingsGridView.Columns[contextName].Visible = true;
      ContextsListBox.Items.Add(contextName);
      ContextsListBox.SelectedItem = contextName;
      if (varconBindings.Columns.Count == 2)
        BindingsGridView.CellValueChanged += BindingsGridView_CellValueChanged;
    }

    private void DropContext()
    {
      if (ContextsListBox.Items.Count == 0)
        return;

      string contextName = ContextsListBox.Text;

      varconBindings.Columns.Remove(contextName);
      ContextsListBox.Items.Remove(contextName);
      if (varconBindings.Columns.Count == 1)
        BindingsGridView.CellValueChanged -= BindingsGridView_CellValueChanged;
    }

    private bool Parse()
    {
      Clear();

      try
      {
        exprBldr = new ExpressionBuilder(ExpressionTextBox.Text);
        expression = ExpressionTextBox.Text;
        variables = exprBldr.GetVariables();
        VariablesTextBox.Text = String.Join(", ", variables.ToArray());
        NewContext();

        foreach (string variable in variables)
        {
          DataRow dr = varconBindings.NewRow();
          dr["Name"] = variable;
          varconBindings.Rows.Add(dr);
        }

        return parsed = true;
      }
      catch (ExpressionBuilder.EmptyExpressionException)
      {
        MessageBox.Show("Please, enter an expression", "No expression given", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      catch (ExpressionBuilder.UnrecognizedSymbolException)
      {
        MessageBox.Show("An unrecognized character was encountered while parsing the input. Please, check the expression", "Unrecognized symbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (ExpressionBuilder.BadValueException)
      {
        MessageBox.Show("One or several constants exceeds the range of allowed values. Please, check the expression", "Constant out of range", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (ExpressionBuilder.UnsupportedOperationException)
      {
        MessageBox.Show("An usupported operator symbol was encountered while parsing the input. Please, check the expression", "Unsupported operator", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (ExpressionBuilder.UnsupportedFunctionException)
      {
        MessageBox.Show("An usupported function was encountered while parsing the input. Please, check the expression", "Unsupported function", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (ExpressionBuilder.MismatchedParenthesesException)
      {
        MessageBox.Show("Parentheses do not match. Please, check the expression", "Mismatched parentheses", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (ExpressionBuilder.BadSyntaxException)
      {
        MessageBox.Show("The expression does not conform the infix notation rules. Please, check the expression", "Bad syntax", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return parsed = false;
    }

    public MainForm()
    {
      InitializeComponent();
      varconBindings = new DataTable();
      varconBindings.Columns.Add("Name", typeof(string));
      varconBindings.Columns["Name"].ReadOnly = true;
      BindingsGridView.DataSource = varconBindings;
      BindingsGridView.Columns["Name"].Width = 100;
      BindingsGridView.Controls.OfType<VScrollBar>().First().VisibleChanged +=
        (object sender, EventArgs e) =>
        {
          VScrollBar vscroll = sender as VScrollBar;
          if (vscroll.Visible)
            BindingsGridView.Columns["Name"].Width -= vscroll.Width;
          else
            BindingsGridView.Columns["Name"].Width += vscroll.Width;
        };
    }

    private void BindingsGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void ExpressionTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter)
      {
        if (ExpressionTextBox.Text != expression)
          Parse();

        e.Handled = true;
      }
    }

    private void ExpressionTextBox_Validating(object sender, CancelEventArgs e)
    {
      if (ExpressionTextBox.Text != expression)
        parsed = false;
    }

    private void LoadButton_Click(object sender, EventArgs e)
    {
      string filePath = String.Empty;

      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        ofd.InitialDirectory = currentDirectory;
        ofd.Filter = "Text files (*.txt)|*.txt";
        ofd.FilterIndex = 0;
        ofd.RestoreDirectory = true;

        if (ofd.ShowDialog() == DialogResult.OK)
        {
          filePath = ofd.FileName;

          var fileStream = ofd.OpenFile();
          using (StreamReader sr = new StreamReader(fileStream))
          {
            ExpressionTextBox.Text = sr.ReadLine();
            sr.Close();
          }

          Parse();

          currentDirectory = Path.GetDirectoryName(filePath);
        }
      }
    }

    private void StoreButton_Click(object sender, EventArgs e)
    {
      string filePath = String.Empty;

      using (SaveFileDialog sfd = new SaveFileDialog())
      {
        sfd.InitialDirectory = currentDirectory;
        sfd.Filter = "Text files (*.txt)|*.txt";
        sfd.FilterIndex = 0;
        sfd.RestoreDirectory = true;

        if (sfd.ShowDialog() == DialogResult.OK)
        {
          filePath = sfd.FileName;

          var fileStream = sfd.OpenFile();
          using (StreamWriter sw = new StreamWriter(fileStream))
          {
            sw.Write(ExpressionTextBox.Text);
            sw.Close();
          }

          currentDirectory = Path.GetDirectoryName(filePath);
        }
      }
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
      Clear();
      ExpressionTextBox.Text = String.Empty;
    }

    private void ShowTreeButton_Click(object sender, EventArgs e)
    {
      if (!parsed)
        Parse();

      if (!parsed)
        return;

      string listing = Path.Combine(Directory.GetCurrentDirectory(), "output.dot");
      string image = Path.Combine(Directory.GetCurrentDirectory(), "output.png");

      using (StreamWriter sw = new StreamWriter(listing))
      {
        sw.Write(exprBldr.GetListing());
        sw.Close();
        Process dot = new Process();
        dot.StartInfo = new ProcessStartInfo(dotPath);
        dot.StartInfo.Arguments = $"-Tpng {listing} -o {image}";
        dot.StartInfo.CreateNoWindow = true;
        dot.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        dot.Start();
        dot.WaitForExit();

        if (treeDisplayForm == null)
        {
          treeDisplayForm = new TreeDisplayForm(image);
          treeDisplayForm.ShowDialog();
        }
        else
        {
          treeDisplayForm.UpdateImage(image);
          treeDisplayForm.ShowDialog();
        }
      }
    }

    private void EvaluateButton_Click(object sender, EventArgs e)
    {
      if (!parsed)
        Parse();

      if (!parsed)
        return;

      if (ContextsListBox.SelectedIndex < 0)
      {
        MessageBox.Show("Select context first", "No context", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      Context context;
      AssembleContext(out context);
      try
      {
        double result = exprBldr.Evaluate(context);
        ResultTextBox.Text = result.ToString();
      }
      catch (ExpressionBuilder.UnboundVariableException)
      {
        MessageBox.Show("Some of the variables are unbound. Bind them first", "Unbound variables", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void PlotButton_Click(object sender, EventArgs e)
    {
      if (!parsed)
        Parse();

      if (!parsed)
        return;

      if (variables.Count == 0)
      {
        MessageBox.Show("The expression contains no varialbes. There's nothing to plot", "No variables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      if (ContextsListBox.SelectedIndex < 0)
      {
        MessageBox.Show("Select context first", "No context", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      Context context;
      AssembleContext(out context); int i = 0;
      foreach (string variable in variables)
      {
        if (!context.IsBound(variable))
          i++;
      }

      if (i > 1)
      {
        MessageBox.Show("More than one unbound variable. Try binding some first", "Unbound variables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      if (plotForm == null)
      {
        plotForm = new PlotForm(exprBldr, context);
        plotForm.ShowDialog();
      }
      else
      {
        plotForm.UpdateExpression(exprBldr, context);
        plotForm.ShowDialog();
      }
    }

    private void Solve_Click(object sender, EventArgs e)
    {
      if (!parsed)
        Parse();

      if (!parsed)
        return;

      if (variables.Count == 0)
      {
        MessageBox.Show("The expression contains no varialbes. There's nothing to solve", "No variables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      if (ContextsListBox.SelectedIndex < 0)
      {
        MessageBox.Show("Select context first", "No context", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      Context context;
      AssembleContext(out context); int i = 0;
      foreach (string variable in variables)
      {
        if (!context.IsBound(variable))
          i++;
      }

      if (i > 1)
      {
        MessageBox.Show("More than one unbound variable. Try binding some first", "Unbound variables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      if (solveForm == null)
      {
        solveForm = new SolveForm(exprBldr, context);
        solveForm.ShowDialog();
      }
      else
      {
        solveForm.UpdateExpression(exprBldr, context);
        solveForm.ShowDialog();
      }
    }

    private void NewContextButton_Click(object sender, EventArgs e)
    {
      NewContext();
    }

    private void DropContextButton_Click(object sender, EventArgs e)
    {
      if (ContextsListBox.SelectedIndex != -1)
        DropContext();
    }

    private void ContextsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      ResultTextBox.Clear();
      string contextName = ContextsListBox.SelectedItem as string;
      foreach (DataGridViewColumn column in BindingsGridView.Columns)
        column.Visible = false;
      BindingsGridView.Columns["Name"].Visible = true;
      if (ContextsListBox.SelectedIndex >= 0)
        BindingsGridView.Columns[contextName].Visible = true;
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("https://github.com/miloradowicz");
    }
  }
}