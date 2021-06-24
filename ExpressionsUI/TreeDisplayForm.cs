using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpressionsUI
{
  public partial class TreeDisplayForm : Form
  {
    private Image image;

    internal void UpdateImage(string imagePath)
    {
      image = Bitmap.FromFile(imagePath);
      Size imgSize = image.Size;
      Size pbSize = TreePictureBox.Size;
      float hs, vs, mins;
      hs = (float)pbSize.Width / imgSize.Width;
      vs = (float)pbSize.Height / imgSize.Height;
      mins = Math.Min(hs, vs);
      if (mins < 1)
        image = new Bitmap(image, (int)(imgSize.Width * mins), (int)(imgSize.Height * mins));
      TreePictureBox.Image = image;
      this.Update();
    }

    public TreeDisplayForm(string imagePath)
    {
      InitializeComponent();

      UpdateImage(imagePath);
    }

    private void TreeDisplayForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        image.Dispose();
        e.Cancel = true;
        this.Hide();
      }
    }
  }
}