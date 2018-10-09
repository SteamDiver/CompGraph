using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetNormals();
        }

        private Vector3D CreateNormal(Point3D p0, Point3D p1, Point3D p2)
        {
            Vector3D v0 = new Vector3D(p1.X - p0.X, p1.Y - p0.Y, p1.Z - p0.Z);
            Vector3D v1 = new Vector3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
            return Vector3D.CrossProduct(v0, v1);
        }

        private void SetNormals()
        {
            var normals = new Vector3DCollection()
            {
               new Vector3D(0,0,-1),
                new Vector3D(0,0,1),
                new Vector3D(1,0,0),
                new Vector3D(-1,0,0),
                new Vector3D(0, 1, 0),
                new Vector3D(0, -1, 0)
            };
            var n2 = new Vector3DCollection()
            {
                normals[0] + normals[3] + normals[5],
                normals[0] + normals[2] + normals[5],
                normals[0] + normals[3] + normals[4],
                normals[0] + normals[2] + normals[4],
                normals[1] + normals[5] + normals[3],
                normals[1] + normals[2] + normals[5],
                normals[1] + normals[3] + normals[4],
                normals[2] + normals[4] + normals[1],
            };
             n2.ToList().ForEach(x=>x.Normalize());
            D.Normals = n2;
        }
    }
}
