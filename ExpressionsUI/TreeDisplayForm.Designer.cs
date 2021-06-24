
namespace ExpressionsUI
{
  partial class TreeDisplayForm
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
      this.TreePictureBox = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.TreePictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // TreePictureBox
      // 
      this.TreePictureBox.BackColor = System.Drawing.SystemColors.Window;
      this.TreePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.TreePictureBox.Location = new System.Drawing.Point(9, 9);
      this.TreePictureBox.Margin = new System.Windows.Forms.Padding(0);
      this.TreePictureBox.Name = "TreePictureBox";
      this.TreePictureBox.Size = new System.Drawing.Size(766, 543);
      this.TreePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.TreePictureBox.TabIndex = 0;
      this.TreePictureBox.TabStop = false;
      // 
      // TreeDisplayForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Window;
      this.ClientSize = new System.Drawing.Size(784, 561);
      this.Controls.Add(this.TreePictureBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TreeDisplayForm";
      this.Text = "TreeDisplay";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TreeDisplayForm_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.TreePictureBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox TreePictureBox;
  }
}