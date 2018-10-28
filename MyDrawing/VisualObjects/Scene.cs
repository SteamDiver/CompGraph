using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDrawing.D3;

namespace MyDrawing.VisualObjects
{
    public class Scene
    {
        public Bitmap Bmp;
        public Model Model { get; set; }
        public List<Light> Lights { get; set; } = new List<Light>();
        public Camera Camera { get; set; } = new Camera(new Vector(0, 0, 1));
        public Point WorldCenter { get; }

        public Scene()
        {
        }

        public Scene(Bitmap bmp, Model model, List<Light> lights, Camera camera, Point worldCenter)
        {
            Bmp = bmp;
            Model = model;
            Lights = lights;
            Camera = camera;
            WorldCenter = worldCenter;
        }

        public Bitmap RenderScene()
        {
            return Model.Draw(Bmp, Lights, WorldCenter, Camera);
        }
    }
}
