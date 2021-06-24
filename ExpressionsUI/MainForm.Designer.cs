
namespace ExpressionsUI
{
  partial class MainForm
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
      this.ExpressionTextBox = new System.Windows.Forms.TextBox();
      this.ExpressionGroupBox = new System.Windows.Forms.GroupBox();
      this.ExpressionVariablesGroupBox = new System.Windows.Forms.GroupBox();
      this.VariablesTextBox = new System.Windows.Forms.TextBox();
      this.ShowTreeButton = new System.Windows.Forms.Button();
      this.ClearButton = new System.Windows.Forms.Button();
      this.StoreButton = new System.Windows.Forms.Button();
      this.LoadButton = new System.Windows.Forms.Button();
      this.BindingsGroupBox = new System.Windows.Forms.GroupBox();
      this.BindingsGridView = new System.Windows.Forms.DataGridView();
      this.PlotButton = new System.Windows.Forms.Button();
      this.EvaluateButton = new System.Windows.Forms.Button();
      this.Solve = new System.Windows.Forms.Button();
      this.ContextsGroupBox = new System.Windows.Forms.GroupBox();
      this.DropContextButton = new System.Windows.Forms.Button();
      this.NewContextButton = new System.Windows.Forms.Button();
      this.ContextsListBox = new System.Windows.Forms.ListBox();
      this.ResultGroupBox = new System.Windows.Forms.GroupBox();
      this.ResultTextBox = new System.Windows.Forms.TextBox();
      this.AuthorLabel = new System.Windows.Forms.Label();
      this.linkLabel1 = new System.Windows.Forms.LinkLabel();
      this.ProjectLabel = new System.Windows.Forms.Label();
      this.ExpressionGroupBox.SuspendLayout();
      this.ExpressionVariablesGroupBox.SuspendLayout();
      this.BindingsGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.BindingsGridView)).BeginInit();
      this.ContextsGroupBox.SuspendLayout();
      this.ResultGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // ExpressionTextBox
      // 
      this.ExpressionTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ExpressionTextBox.Location = new System.Drawing.Point(6, 21);
      this.ExpressionTextBox.MaxLength = 600;
      this.ExpressionTextBox.Multiline = true;
      this.ExpressionTextBox.Name = "ExpressionTextBox";
      this.ExpressionTextBox.Size = new System.Drawing.Size(692, 87);
      this.ExpressionTextBox.TabIndex = 0;
      this.ExpressionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ExpressionTextBox_KeyPress);
      this.ExpressionTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ExpressionTextBox_Validating);
      // 
      // ExpressionGroupBox
      // 
      this.ExpressionGroupBox.Controls.Add(this.ExpressionVariablesGroupBox);
      this.ExpressionGroupBox.Controls.Add(this.ShowTreeButton);
      this.ExpressionGroupBox.Controls.Add(this.ClearButton);
      this.ExpressionGroupBox.Controls.Add(this.ExpressionTextBox);
      this.ExpressionGroupBox.Controls.Add(this.StoreButton);
      this.ExpressionGroupBox.Controls.Add(this.LoadButton);
      this.ExpressionGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ExpressionGroupBox.Location = new System.Drawing.Point(12, 12);
      this.ExpressionGroupBox.Name = "ExpressionGroupBox";
      this.ExpressionGroupBox.Size = new System.Drawing.Size(760, 174);
      this.ExpressionGroupBox.TabIndex = 1;
      this.ExpressionGroupBox.TabStop = false;
      this.ExpressionGroupBox.Text = "Expression";
      // 
      // ExpressionVariablesGroupBox
      // 
      this.ExpressionVariablesGroupBox.Controls.Add(this.VariablesTextBox);
      this.ExpressionVariablesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ExpressionVariablesGroupBox.Location = new System.Drawing.Point(6, 114);
      this.ExpressionVariablesGroupBox.Name = "ExpressionVariablesGroupBox";
      this.ExpressionVariablesGroupBox.Size = new System.Drawing.Size(622, 54);
      this.ExpressionVariablesGroupBox.TabIndex = 7;
      this.ExpressionVariablesGroupBox.TabStop = false;
      this.ExpressionVariablesGroupBox.Text = "Expression variables";
      // 
      // VariablesTextBox
      // 
      this.VariablesTextBox.BackColor = System.Drawing.SystemColors.Control;
      this.VariablesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.VariablesTextBox.Enabled = false;
      this.VariablesTextBox.Location = new System.Drawing.Point(6, 20);
      this.VariablesTextBox.Multiline = true;
      this.VariablesTextBox.Name = "VariablesTextBox";
      this.VariablesTextBox.Size = new System.Drawing.Size(610, 28);
      this.VariablesTextBox.TabIndex = 0;
      // 
      // ShowTreeButton
      // 
      this.ShowTreeButton.Location = new System.Drawing.Point(634, 120);
      this.ShowTreeButton.Name = "ShowTreeButton";
      this.ShowTreeButton.Size = new System.Drawing.Size(120, 48);
      this.ShowTreeButton.TabIndex = 6;
      this.ShowTreeButton.Text = "Expression tree";
      this.ShowTreeButton.UseVisualStyleBackColor = true;
      this.ShowTreeButton.Click += new System.EventHandler(this.ShowTreeButton_Click);
      // 
      // ClearButton
      // 
      this.ClearButton.Location = new System.Drawing.Point(704, 83);
      this.ClearButton.Name = "ClearButton";
      this.ClearButton.Size = new System.Drawing.Size(50, 25);
      this.ClearButton.TabIndex = 4;
      this.ClearButton.Text = "Clear";
      this.ClearButton.UseVisualStyleBackColor = true;
      this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
      // 
      // StoreButton
      // 
      this.StoreButton.Location = new System.Drawing.Point(704, 52);
      this.StoreButton.Name = "StoreButton";
      this.StoreButton.Size = new System.Drawing.Size(50, 25);
      this.StoreButton.TabIndex = 2;
      this.StoreButton.Text = "Store";
      this.StoreButton.UseVisualStyleBackColor = true;
      this.StoreButton.Click += new System.EventHandler(this.StoreButton_Click);
      // 
      // LoadButton
      // 
      this.LoadButton.Location = new System.Drawing.Point(704, 21);
      this.LoadButton.Name = "LoadButton";
      this.LoadButton.Size = new System.Drawing.Size(50, 25);
      this.LoadButton.TabIndex = 1;
      this.LoadButton.Text = "Load";
      this.LoadButton.UseVisualStyleBackColor = true;
      this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
      // 
      // BindingsGroupBox
      // 
      this.BindingsGroupBox.Controls.Add(this.BindingsGridView);
      this.BindingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BindingsGroupBox.Location = new System.Drawing.Point(206, 192);
      this.BindingsGroupBox.Name = "BindingsGroupBox";
      this.BindingsGroupBox.Size = new System.Drawing.Size(262, 286);
      this.BindingsGroupBox.TabIndex = 2;
      this.BindingsGroupBox.TabStop = false;
      this.BindingsGroupBox.Text = "Bindings";
      // 
      // BindingsGridView
      // 
      this.BindingsGridView.AllowUserToAddRows = false;
      this.BindingsGridView.AllowUserToDeleteRows = false;
      this.BindingsGridView.AllowUserToResizeColumns = false;
      this.BindingsGridView.AllowUserToResizeRows = false;
      this.BindingsGridView.BackgroundColor = System.Drawing.SystemColors.Window;
      this.BindingsGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.BindingsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.BindingsGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
      this.BindingsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.BindingsGridView.GridColor = System.Drawing.SystemColors.Control;
      this.BindingsGridView.Location = new System.Drawing.Point(6, 21);
      this.BindingsGridView.MultiSelect = false;
      this.BindingsGridView.Name = "BindingsGridView";
      this.BindingsGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
      this.BindingsGridView.RowHeadersVisible = false;
      this.BindingsGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.BindingsGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.BindingsGridView.Size = new System.Drawing.Size(250, 247);
      this.BindingsGridView.TabIndex = 3;
      // 
      // PlotButton
      // 
      this.PlotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.PlotButton.Location = new System.Drawing.Point(626, 316);
      this.PlotButton.Name = "PlotButton";
      this.PlotButton.Size = new System.Drawing.Size(140, 48);
      this.PlotButton.TabIndex = 5;
      this.PlotButton.Text = "Plot";
      this.PlotButton.UseVisualStyleBackColor = true;
      this.PlotButton.Click += new System.EventHandler(this.PlotButton_Click);
      // 
      // EvaluateButton
      // 
      this.EvaluateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.EvaluateButton.Location = new System.Drawing.Point(480, 262);
      this.EvaluateButton.Name = "EvaluateButton";
      this.EvaluateButton.Size = new System.Drawing.Size(286, 48);
      this.EvaluateButton.TabIndex = 4;
      this.EvaluateButton.Text = "Evaluate";
      this.EvaluateButton.UseVisualStyleBackColor = true;
      this.EvaluateButton.Click += new System.EventHandler(this.EvaluateButton_Click);
      // 
      // Solve
      // 
      this.Solve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Solve.Location = new System.Drawing.Point(480, 316);
      this.Solve.Name = "Solve";
      this.Solve.Size = new System.Drawing.Size(140, 48);
      this.Solve.TabIndex = 6;
      this.Solve.Text = "Solve";
      this.Solve.UseVisualStyleBackColor = true;
      this.Solve.Click += new System.EventHandler(this.Solve_Click);
      // 
      // ContextsGroupBox
      // 
      this.ContextsGroupBox.Controls.Add(this.DropContextButton);
      this.ContextsGroupBox.Controls.Add(this.NewContextButton);
      this.ContextsGroupBox.Controls.Add(this.ContextsListBox);
      this.ContextsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ContextsGroupBox.Location = new System.Drawing.Point(12, 192);
      this.ContextsGroupBox.Name = "ContextsGroupBox";
      this.ContextsGroupBox.Size = new System.Drawing.Size(188, 286);
      this.ContextsGroupBox.TabIndex = 7;
      this.ContextsGroupBox.TabStop = false;
      this.ContextsGroupBox.Text = "Contexts";
      // 
      // DropContextButton
      // 
      this.DropContextButton.Location = new System.Drawing.Point(97, 255);
      this.DropContextButton.Name = "DropContextButton";
      this.DropContextButton.Size = new System.Drawing.Size(85, 25);
      this.DropContextButton.TabIndex = 4;
      this.DropContextButton.Text = "Drop";
      this.DropContextButton.UseVisualStyleBackColor = true;
      this.DropContextButton.Click += new System.EventHandler(this.DropContextButton_Click);
      // 
      // NewContextButton
      // 
      this.NewContextButton.Location = new System.Drawing.Point(6, 255);
      this.NewContextButton.Name = "NewContextButton";
      this.NewContextButton.Size = new System.Drawing.Size(85, 25);
      this.NewContextButton.TabIndex = 3;
      this.NewContextButton.Text = "New";
      this.NewContextButton.UseVisualStyleBackColor = true;
      this.NewContextButton.Click += new System.EventHandler(this.NewContextButton_Click);
      // 
      // ContextsListBox
      // 
      this.ContextsListBox.FormattingEnabled = true;
      this.ContextsListBox.ItemHeight = 16;
      this.ContextsListBox.Location = new System.Drawing.Point(6, 21);
      this.ContextsListBox.Name = "ContextsListBox";
      this.ContextsListBox.Size = new System.Drawing.Size(176, 228);
      this.ContextsListBox.TabIndex = 0;
      this.ContextsListBox.SelectedIndexChanged += new System.EventHandler(this.ContextsListBox_SelectedIndexChanged);
      // 
      // ResultGroupBox
      // 
      this.ResultGroupBox.Controls.Add(this.ResultTextBox);
      this.ResultGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ResultGroupBox.Location = new System.Drawing.Point(474, 192);
      this.ResultGroupBox.Name = "ResultGroupBox";
      this.ResultGroupBox.Size = new System.Drawing.Size(298, 64);
      this.ResultGroupBox.TabIndex = 8;
      this.ResultGroupBox.TabStop = false;
      this.ResultGroupBox.Text = "Result";
      // 
      // ResultTextBox
      // 
      this.ResultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.ResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ResultTextBox.Location = new System.Drawing.Point(6, 21);
      this.ResultTextBox.Name = "ResultTextBox";
      this.ResultTextBox.ReadOnly = true;
      this.ResultTextBox.Size = new System.Drawing.Size(286, 37);
      this.ResultTextBox.TabIndex = 7;
      this.ResultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // AuthorLabel
      // 
      this.AuthorLabel.AutoSize = true;
      this.AuthorLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.AuthorLabel.Location = new System.Drawing.Point(689, 452);
      this.AuthorLabel.Name = "AuthorLabel";
      this.AuthorLabel.Size = new System.Drawing.Size(83, 13);
      this.AuthorLabel.TabIndex = 9;
      this.AuthorLabel.Text = "by miloradowicz";
      // 
      // linkLabel1
      // 
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.linkLabel1.Location = new System.Drawing.Point(645, 465);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new System.Drawing.Size(127, 13);
      this.linkLabel1.TabIndex = 10;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "github.com/miloradowicz";
      this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      // 
      // ProjectLabel
      // 
      this.ProjectLabel.AutoSize = true;
      this.ProjectLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ProjectLabel.Location = new System.Drawing.Point(612, 438);
      this.ProjectLabel.Name = "ProjectLabel";
      this.ProjectLabel.Size = new System.Drawing.Size(160, 14);
      this.ProjectLabel.TabIndex = 11;
      this.ProjectLabel.Text = "Expression Evaluator © 2021";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 490);
      this.Controls.Add(this.ProjectLabel);
      this.Controls.Add(this.linkLabel1);
      this.Controls.Add(this.AuthorLabel);
      this.Controls.Add(this.ResultGroupBox);
      this.Controls.Add(this.Solve);
      this.Controls.Add(this.PlotButton);
      this.Controls.Add(this.EvaluateButton);
      this.Controls.Add(this.ContextsGroupBox);
      this.Controls.Add(this.BindingsGroupBox);
      this.Controls.Add(this.ExpressionGroupBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Text = "Expression Evaluator";
      this.ExpressionGroupBox.ResumeLayout(false);
      this.ExpressionGroupBox.PerformLayout();
      this.ExpressionVariablesGroupBox.ResumeLayout(false);
      this.ExpressionVariablesGroupBox.PerformLayout();
      this.BindingsGroupBox.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.BindingsGridView)).EndInit();
      this.ContextsGroupBox.ResumeLayout(false);
      this.ResultGroupBox.ResumeLayout(false);
      this.ResultGroupBox.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox ExpressionTextBox;
    private System.Windows.Forms.GroupBox ExpressionGroupBox;
    private System.Windows.Forms.Button StoreButton;
    private System.Windows.Forms.Button LoadButton;
    private System.Windows.Forms.Button ClearButton;
    private System.Windows.Forms.Button ShowTreeButton;
    private System.Windows.Forms.GroupBox ExpressionVariablesGroupBox;
    private System.Windows.Forms.TextBox VariablesTextBox;
    private System.Windows.Forms.GroupBox BindingsGroupBox;
    private System.Windows.Forms.DataGridView BindingsGridView;
    private System.Windows.Forms.Button EvaluateButton;
    private System.Windows.Forms.Button PlotButton;
    private System.Windows.Forms.Button Solve;
    private System.Windows.Forms.GroupBox ContextsGroupBox;
    private System.Windows.Forms.Button DropContextButton;
    private System.Windows.Forms.Button NewContextButton;
    private System.Windows.Forms.ListBox ContextsListBox;
    private System.Windows.Forms.GroupBox ResultGroupBox;
    private System.Windows.Forms.TextBox ResultTextBox;
    private System.Windows.Forms.Label AuthorLabel;
    private System.Windows.Forms.LinkLabel linkLabel1;
    private System.Windows.Forms.Label ProjectLabel;
  }
}

