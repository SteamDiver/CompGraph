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

namespace Task3WinForms
{
    public partial class Form1 : Form
    {
        private readonly Graphics _gScreen;
        private readonly Bitmap _bitmap;

        private Drawer drawer;

        public Form1()
        {
            InitializeComponent();
            _bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            _gScreen = CreateGraphics();
            drawer = new Drawer(_bitmap);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drawer.DrawPoint(e.Location, Brushes.CornflowerBlue);
            _gScreen.DrawImage(_bitmap, ClientRectangle);
        }
    }
}
