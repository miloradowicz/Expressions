
namespace ExpressionsUI
{
  partial class SolveForm
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
      this.UnknownGroupBox = new System.Windows.Forms.GroupBox();
      this.UnknownComboBox = new System.Windows.Forms.ComboBox();
      this.SolveButton = new System.Windows.Forms.Button();
      this.InitialGuessGroupBox = new System.Windows.Forms.GroupBox();
      this.InitialGuessTextBox = new System.Windows.Forms.TextBox();
      this.SolutionGroupBox = new System.Windows.Forms.GroupBox();
      this.SolutionTextBox = new System.Windows.Forms.TextBox();
      this.ErrorGroupBox = new System.Windows.Forms.GroupBox();
      this.ErrorTextBox = new System.Windows.Forms.TextBox();
      this.CalculatedErrorGroupBox = new System.Windows.Forms.GroupBox();
      this.CalculatedErrorTextBox = new System.Windows.Forms.TextBox();
      this.UnknownGroupBox.SuspendLayout();
      this.InitialGuessGroupBox.SuspendLayout();
      this.SolutionGroupBox.SuspendLayout();
      this.ErrorGroupBox.SuspendLayout();
      this.CalculatedErrorGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // UnknownGroupBox
      // 
      this.UnknownGroupBox.Controls.Add(this.UnknownComboBox);
      this.UnknownGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.UnknownGroupBox.Location = new System.Drawing.Point(12, 194);
      this.UnknownGroupBox.Name = "UnknownGroupBox";
      this.UnknownGroupBox.Size = new System.Drawing.Size(192, 65);
      this.UnknownGroupBox.TabIndex = 6;
      this.UnknownGroupBox.TabStop = false;
      this.UnknownGroupBox.Text = "Unknown";
      // 
      // UnknownComboBox
      // 
      this.UnknownComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.UnknownComboBox.FormattingEnabled = true;
      this.UnknownComboBox.Location = new System.Drawing.Point(6, 28);
      this.UnknownComboBox.Name = "UnknownComboBox";
      this.UnknownComboBox.Size = new System.Drawing.Size(180, 24);
      this.UnknownComboBox.TabIndex = 0;
      // 
      // SolveButton
      // 
      this.SolveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SolveButton.Location = new System.Drawing.Point(456, 200);
      this.SolveButton.Name = "SolveButton";
      this.SolveButton.Size = new System.Drawing.Size(144, 59);
      this.SolveButton.TabIndex = 5;
      this.SolveButton.Text = "Solve";
      this.SolveButton.UseVisualStyleBackColor = true;
      this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
      // 
      // InitialGuessGroupBox
      // 
      this.InitialGuessGroupBox.Controls.Add(this.InitialGuessTextBox);
      this.InitialGuessGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.InitialGuessGroupBox.Location = new System.Drawing.Point(210, 194);
      this.InitialGuessGroupBox.Name = "InitialGuessGroupBox";
      this.InitialGuessGroupBox.Size = new System.Drawing.Size(112, 65);
      this.InitialGuessGroupBox.TabIndex = 4;
      this.InitialGuessGroupBox.TabStop = false;
      this.InitialGuessGroupBox.Text = "Initial guess";
      // 
      // InitialGuessTextBox
      // 
      this.InitialGuessTextBox.Location = new System.Drawing.Point(6, 28);
      this.InitialGuessTextBox.MaxLength = 60;
      this.InitialGuessTextBox.Name = "InitialGuessTextBox";
      this.InitialGuessTextBox.Size = new System.Drawing.Size(100, 22);
      this.InitialGuessTextBox.TabIndex = 0;
      this.InitialGuessTextBox.Text = "1";
      this.InitialGuessTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.InitialGuessTextBox_Validating);
      // 
      // SolutionGroupBox
      // 
      this.SolutionGroupBox.Controls.Add(this.SolutionTextBox);
      this.SolutionGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SolutionGroupBox.Location = new System.Drawing.Point(12, 103);
      this.SolutionGroupBox.Name = "SolutionGroupBox";
      this.SolutionGroupBox.Size = new System.Drawing.Size(588, 85);
      this.SolutionGroupBox.TabIndex = 7;
      this.SolutionGroupBox.TabStop = false;
      this.SolutionGroupBox.Text = "Solution";
      // 
      // SolutionTextBox
      // 
      this.SolutionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.SolutionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SolutionTextBox.Location = new System.Drawing.Point(6, 30);
      this.SolutionTextBox.Name = "SolutionTextBox";
      this.SolutionTextBox.ReadOnly = true;
      this.SolutionTextBox.Size = new System.Drawing.Size(576, 37);
      this.SolutionTextBox.TabIndex = 0;
      this.SolutionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // ErrorGroupBox
      // 
      this.ErrorGroupBox.Controls.Add(this.ErrorTextBox);
      this.ErrorGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ErrorGroupBox.Location = new System.Drawing.Point(328, 194);
      this.ErrorGroupBox.Name = "ErrorGroupBox";
      this.ErrorGroupBox.Size = new System.Drawing.Size(112, 65);
      this.ErrorGroupBox.TabIndex = 8;
      this.ErrorGroupBox.TabStop = false;
      this.ErrorGroupBox.Text = "Error";
      // 
      // ErrorTextBox
      // 
      this.ErrorTextBox.Location = new System.Drawing.Point(6, 28);
      this.ErrorTextBox.MaxLength = 60;
      this.ErrorTextBox.Name = "ErrorTextBox";
      this.ErrorTextBox.Size = new System.Drawing.Size(100, 22);
      this.ErrorTextBox.TabIndex = 0;
      this.ErrorTextBox.Text = "0.001";
      this.ErrorTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ErrorTextbox_Validating);
      // 
      // CalculatedErrorGroupBox
      // 
      this.CalculatedErrorGroupBox.Controls.Add(this.CalculatedErrorTextBox);
      this.CalculatedErrorGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CalculatedErrorGroupBox.Location = new System.Drawing.Point(12, 12);
      this.CalculatedErrorGroupBox.Name = "CalculatedErrorGroupBox";
      this.CalculatedErrorGroupBox.Size = new System.Drawing.Size(588, 85);
      this.CalculatedErrorGroupBox.TabIndex = 10;
      this.CalculatedErrorGroupBox.TabStop = false;
      this.CalculatedErrorGroupBox.Text = "Calculated error";
      // 
      // CalculatedErrorTextBox
      // 
      this.CalculatedErrorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.CalculatedErrorTextBox.Enabled = false;
      this.CalculatedErrorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CalculatedErrorTextBox.Location = new System.Drawing.Point(6, 30);
      this.CalculatedErrorTextBox.Name = "CalculatedErrorTextBox";
      this.CalculatedErrorTextBox.Size = new System.Drawing.Size(576, 37);
      this.CalculatedErrorTextBox.TabIndex = 0;
      this.CalculatedErrorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // SolveForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(612, 271);
      this.Controls.Add(this.CalculatedErrorGroupBox);
      this.Controls.Add(this.ErrorGroupBox);
      this.Controls.Add(this.SolutionGroupBox);
      this.Controls.Add(this.UnknownGroupBox);
      this.Controls.Add(this.InitialGuessGroupBox);
      this.Controls.Add(this.SolveButton);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SolveForm";
      this.Text = "Solve";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SolveForm_FormClosing);
      this.UnknownGroupBox.ResumeLayout(false);
      this.InitialGuessGroupBox.ResumeLayout(false);
      this.InitialGuessGroupBox.PerformLayout();
      this.SolutionGroupBox.ResumeLayout(false);
      this.SolutionGroupBox.PerformLayout();
      this.ErrorGroupBox.ResumeLayout(false);
      this.ErrorGroupBox.PerformLayout();
      this.CalculatedErrorGroupBox.ResumeLayout(false);
      this.CalculatedErrorGroupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox UnknownGroupBox;
    private System.Windows.Forms.ComboBox UnknownComboBox;
    private System.Windows.Forms.Button SolveButton;
    private System.Windows.Forms.GroupBox InitialGuessGroupBox;
    private System.Windows.Forms.TextBox InitialGuessTextBox;
    private System.Windows.Forms.GroupBox SolutionGroupBox;
    private System.Windows.Forms.TextBox SolutionTextBox;
    private System.Windows.Forms.GroupBox ErrorGroupBox;
    private System.Windows.Forms.TextBox ErrorTextBox;
    private System.Windows.Forms.GroupBox CalculatedErrorGroupBox;
    private System.Windows.Forms.TextBox CalculatedErrorTextBox;
  }
}