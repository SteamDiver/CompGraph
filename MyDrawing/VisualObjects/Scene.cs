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
        public Model Model { get; set; }
        public List<Light> Lights { get; set; } = new List<Light>();
        public Camera Camera { get; set; } = new Camera(new Vector(0, 0, 1));

        public Scene()
        {
        }

        public Scene(Model model, List<Light> lights, Camera camera)
        {
            Model = model;
            Lights = lights;
            Camera = camera;
        }

        public Bitmap RenderScene()
        {
           return Model.Draw(Lights);
        }
    }
}
