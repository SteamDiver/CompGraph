using System.Drawing;
using System.Windows.Forms;

namespace Task1WinForms
{
    public partial class Form1 : Form
    {
        private Graphics _gBitmap;
        private readonly Graphics _gScreen;
        private readonly Bitmap _bitmap;

        public Form1()
        {
            InitializeComponent();

            _gScreen = CreateGraphics();
            _bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            _gBitmap = Graphics.FromImage(_bitmap);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            _gBitmap = CreateGraphics();
            _gBitmap.Clear(Color.Wheat);

            //brushes
            Brush bFace = new SolidBrush(Color.Beige);
            Brush bEyeSmall = new SolidBrush(Color.Black);
            Brush bEyeBig = new SolidBrush(Color.Red);
            Brush bWords = new SolidBrush(Color.Red);
            Brush bMouse = new SolidBrush(Color.DarkRed);

            _gBitmap.FillEllipse(bFace, 10, 10, 200, 200);
            _gBitmap.DrawEllipse(Pens.Black, 10, 10, 200, 200);
           
            //левый глаз
            
            _gBitmap.FillEllipse(bEyeBig, 50, 50, 50, 50);
            _gBitmap.DrawEllipse(Pens.Black, 50, 50, 50, 50);
            
            _gBitmap.FillEllipse(bEyeSmall, 62, 62, 25, 25);
            _gBitmap.DrawEllipse(Pens.Black, 62, 62, 25, 25);

            //правый глаз
            _gBitmap.FillEllipse(bEyeBig, 125, 50, 50, 50);
            _gBitmap.DrawEllipse(Pens.Black, 125, 50, 50, 50);

            
            _gBitmap.FillEllipse(bEyeSmall, 137, 62, 25, 25);
            _gBitmap.DrawEllipse(Pens.Black, 137, 62, 25, 25);

            //рот
            _gBitmap.FillEllipse(bMouse, 50, 135, 120, 35);
            _gBitmap.DrawEllipse(Pens.Black, 50, 135, 120, 35);

            //кругляхи    
            _gBitmap.FillEllipse(bWords, 215, 130, 18, 18);
            _gBitmap.DrawEllipse(Pens.Black, 215, 130, 18, 18);
            
            _gBitmap.FillEllipse(bWords, 235, 115, 25, 25);
            _gBitmap.DrawEllipse(Pens.Black, 235, 115, 25, 25);
            
            _gBitmap.FillEllipse(bWords, 255, 50, 85, 85);
            _gBitmap.DrawEllipse(Pens.Black, 255, 50, 85, 85);

            Font f = new Font(FontFamily.GenericSansSerif, 11);
            Brush bStr = new SolidBrush(Color.Yellow);
            _gBitmap.DrawString("Hello World!", f, bStr, 255, 85);

            _gScreen.DrawImage(_bitmap, ClientRectangle);
            _gBitmap.Dispose();
        }
    }
}
