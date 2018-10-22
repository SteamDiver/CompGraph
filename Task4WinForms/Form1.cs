using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDrawing;
using MyDrawing.D3;

namespace Task4WinForms
{
    public partial class Form1 : Form
    {
        private Drawer _drawer;
        private Bitmap _bmp;

        private string path1 = "";
        private string path2 = "";

        public Form1()
        {
            InitializeComponent();
            _bmp = new Bitmap(PictureBox.Width, PictureBox.Height);
            _drawer = new Drawer(PictureBox, _bmp, DrawType.Standart);
        }

        private void ModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path1 = openFileDialog.FileName;
            }
        }

        private void TextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = TextureOpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path2 = TextureOpenFileDialog.FileName;
            }
        }

        private void RenderBtn_Click(object sender, EventArgs e)
        {
            Render();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Render();
        }

        private void Render()
        {
                Vector translate = new Vector(0, -100, 0);
                Vector scale = new Vector(1, 1, 1);
                Vector rotation = new Vector(XRotate.Value / 10d, 0, 0);

                Model alex = new Model(path1, path2);
                PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                PictureBox.Image = alex.Draw(translate, scale, rotation);
            
            
        }
    }
}
