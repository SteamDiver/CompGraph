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
using MyDrawing.VisualObjects;

namespace Task3WinForms
{
    public sealed partial class Form1 : Form
    {
        private Bitmap bmp;
        private bool _isDown = false;
        private Line _l1 = new Line(new List<PointF>(), Brushes.Blue, 2);
        private Line _l2 = new Line(new List<PointF>(), Brushes.DarkRed, 2);
        private Line _lineToUse;
        private bool _newLine = false;
        private readonly Drawer _drawer;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(Field.Width, Field.Height);            
            _drawer = new Drawer(Field, bmp, DrawType.Standart);
        }

        private void NewLineChB_CheckedChanged(object sender, EventArgs e)
        {
            _newLine = NewLineChB.Checked;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                _l1.NormalizeWithNewLine(_l2);
                _drawer.MoveObject(_l1, _l2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Field_MouseUp(object sender, MouseEventArgs e)
        {
            _isDown = false;
        }

        private void Field_MouseDown(object sender, MouseEventArgs e)
        {
            _isDown = true;
        }

        private void Field_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
            {
                _lineToUse = _newLine ? _l2 : _l1;
                _lineToUse.Points.Add(e.Location);
                if (_lineToUse.Points.Count > 1)
                {
                    //_drawer.Clear();
                    _drawer.Draw(_lineToUse);
                }
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _drawer.Clear();
            _l1 = new Line(new List<PointF>(), Brushes.Blue, 2);
            _l2 = new Line(new List<PointF>(), Brushes.DarkRed, 2);
        }
    }
}
