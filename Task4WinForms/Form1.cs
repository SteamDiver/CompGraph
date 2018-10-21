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
            
                List<double[]> vector = new List<double[]>();
                //double[] values1 = { Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox6.Text), Convert.ToDouble(textBox9.Text) }; vector.Add(values1);
                //double[] values2 = { Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox8.Text) }; vector.Add(values2);
                //double[] values3 = { Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox7.Text) }; vector.Add(values3);

                double[] values1 = {0, 0, 0};
                vector.Add(values1);
                double[] values2 = {1, 1, 1};
                vector.Add(values2);
                double[] values3 = {0, 0, 0};
                vector.Add(values3);

                Model alex = new Model();
                PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                PictureBox.Image = alex.Draw(path1, path2, vector);
            
            
        }
    }
}
