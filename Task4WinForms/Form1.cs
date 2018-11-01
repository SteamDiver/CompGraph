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

        private string _modelPath = "";
        private string _texturePath = "";

        private Scene _scene;
        private Model _model;

        private readonly List<Light> _lights = new List<Light>()
        {
            new DirectionalLight(LightType.Diffuse, new Vector(0, 0, 1)),
            new DirectionalLight(LightType.Diffuse, new Vector(0, 1, 0)),
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
                _texturePath = "";
                _modelPath = openFileDialog.FileName;
            }
        }

        private void TextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = TextureOpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _texturePath = TextureOpenFileDialog.FileName;
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

            _model = new Model(_modelPath, _texturePath)
            {
                Translation = translate,
                Scale = scale,
                Rotation = rotation
            };

            _scene = new Scene(_bmp, _model, _lights, new Camera(new Vector(0, 0, 1)), new Point(PictureBox.Width / 2, -PictureBox.Height / 2));

            PictureBox.SizeMode = PictureBoxSizeMode.Normal;
            PictureBox.Image = _scene.RenderScene();

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

            _scene.Model.Translation = translate;
            _scene.Model.Scale = scale;
            _scene.Model.Rotation = rotation;

            var bmp = _scene.RenderScene();
            PictureBox.Image = bmp;
            //bmp.Save("save.jpg");
        }

        private Vertex _prevPoint;
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            var curPoint = new Vertex(e.X, e.Y, 0);
            if (_prevPoint != null && _scene != null)
            {
                if ((e.Button & MouseButtons.Left) != 0)
                {
                    Vertex v1 = new Vertex(_prevPoint.Y / 100, _prevPoint.X / 100, 0);
                    Vertex v2 = new Vertex(curPoint.Y / 100, curPoint.X / 100, 0);
                    var rotateVector = new Vector(v1, v2);
                    _scene.Model.Rotation += rotateVector;
                    PictureBox.Image = _scene.RenderScene();
                }

                if ((e.Button & MouseButtons.Middle) != 0)
                {
                    Vertex v1 = new Vertex(-_prevPoint.X, _prevPoint.Y, 0);
                    Vertex v2 = new Vertex(-curPoint.X, curPoint.Y, 0);
                    _scene.Model.Translation += new Vector(v1, v2);
                    PictureBox.Image = _scene.RenderScene();
                }
            }

            _prevPoint = curPoint;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (_scene != null)
            {
                _scene.Camera.ProjectionValue = trackBar1.Value;
                PictureBox.Image = _scene.RenderScene();
            }
        }
    }
}
