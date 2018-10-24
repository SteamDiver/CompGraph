using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDrawing;
using MyDrawing.D3;
using MyDrawing.VisualObjects;

namespace Task4WinForms
{
    public partial class Form1 : Form
    {
        private Drawer _drawer;
        private Bitmap _bmp;

        private string path1 = "";
        private string path2 = "";

        private Scene scene;

        private List<Light> lights = new List<Light>()
        {
            new DiffuseLight(new Vector(0, 0, 1)),
        };

        public Form1()
        {
            InitializeComponent();
            _bmp = new Bitmap(PictureBox.Width, PictureBox.Height);
            _drawer = new Drawer(PictureBox, _bmp, DrawType.Standart);
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
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

        private void Render()
        {
            Vector translate = new Vector(0, 0, 0);
            Vector scale = new Vector(1, 1, 1);
            Vector rotation = new Vector(0, 0, 0);


            Model alex = new Model(path1, path2)
            {
                Translation = translate,
                Scale = scale,
                Rotation = rotation
            };
            scene = new Scene(alex, lights, new Camera(new Vector(0, 0, 1)));
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox.Image = scene.RenderScene();
        }

        private void RedrawBtn_Click(object sender, EventArgs e)
        {
            var transX = double.Parse(TransXtb.Text);
            var transY = double.Parse(TransYtb.Text);
            var transZ = double.Parse(TransZtb.Text);
            var scaleX = double.Parse(ScaleXtb.Text);
            var scaleY = double.Parse(ScaleYtb.Text);
            var scaleZ = double.Parse(ScaleZtb.Text);
            var rotX = double.Parse(RotXtb.Text);
            var rotY = double.Parse(RotYtb.Text);
            var rotZ = double.Parse(RotZtb.Text);

            Vector translate = new Vector(transX, transY, transZ);
            Vector scale = new Vector(scaleX, scaleY, scaleZ);
            Vector rotation = new Vector(rotX, rotY, rotZ);

            scene.Model.Translation = translate;
            scene.Model.Scale = scale;
            scene.Model.Rotation = rotation;

            var bmp = scene.RenderScene();
            PictureBox.Image = bmp;
            bmp.Save("save.jpg");
        }
    }
}
