using Indiv2.logi;
using Indiv2.models;
using Indiv2.models.figures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using LightBox = Indiv2.models.figures.LightBox;
using Material = Indiv2.models.Material;

namespace Indiv2
{
    public partial class MainForm : Form
    {

        public List<Figure> scene = new List<Figure>();
        public List<LightBox> lights = new List<LightBox>();
        public Color[,] color_pixels;
        public Vector3D[,] pixels;
        public Vector3D focus;
        public Vector3D up_left, up_right, down_left, down_right;
        public int h, w;

        public MainForm()
        {
            InitializeComponent();
            focus = new Vector3D();
            up_left = new Vector3D();
            up_right = new Vector3D();
            down_left = new Vector3D();
            down_right = new Vector3D();
            h = pictureBox1.Height;
            w = pictureBox1.Width;
            pictureBox1.Image = new Bitmap(w, h);
            smallCubeRegularRadioButton.Checked = true;
            bigCubeSpecularityRadioButton.Checked = true;
            sphereTransparencyRadioButton.Checked = true;
            twoLightsCheckBox.Checked = false;
        }

        public void build_scene()
        {
            Room room = new Room(ReadyFigures.Hexahedron(10));
            up_left = room.faces[0].get_point(0);
            up_right = room.faces[0].get_point(1);
            down_right = room.faces[0].get_point(2);
            down_left = room.faces[0].get_point(3);

            Vector3D normal = room.faces[0].Normal;                            
            Vector3D center = (up_left + up_right + down_left + down_right) / 4;
            focus = center + normal * 10;

            room.Pen = new Pen(Color.Gray);

            float reflection, refraction, ambient, diffuse, environment;

            room.faces[0].pen = new Pen(Color.White);
            if (backWallSpecularCB.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.0f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            room.back = new Material(reflection, refraction, ambient, diffuse, environment);

            room.faces[1].pen = new Pen(Color.White);
            if (frontWallSpecularCB.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.0f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            room.front = new Material(reflection, refraction, ambient, diffuse, environment);

            room.faces[2].pen = new Pen(Color.Blue);
            if (rightWallSpecularCB.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.0f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            room.right = new Material(reflection, refraction, ambient, diffuse, environment);

            room.faces[3].pen = new Pen(Color.Red);
            if (leftWallSpecularCB.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.0f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            room.left = new Material(reflection, refraction, ambient, diffuse, environment);

            if (upWallSpecularCB.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.0f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            room.ceiling = new Material(reflection, refraction, ambient, diffuse, environment);

            if (downWallSpecularCB.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.0f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            room.floor = new Material(reflection, refraction, ambient, diffuse, environment);

            LightBox lightBox1 = new LightBox(new Vector3D(0f, 1f, 4.9f), new Vector3D(1f, 1f, 1f));
            lights.Add(lightBox1);
            if (twoLightsCheckBox.Checked)
            {
                LightBox lightBox2 = new LightBox(new Vector3D(0f, 4f, -4.9f), new Vector3D(1f, 1f, 1f));
                lights.Add(lightBox2);
            }

            Sphere sphere = new Sphere(new Vector3D(0.7f, 3.5f, -4.0f), 1f);
            sphere.pen = new Pen(Color.White);
            if (sphereSpecularityRadioButton.Checked)
            {
                reflection = 0.9f; refraction = 0f; ambient = 0f; diffuse = 0.1f; environment = 1f;
            }
            else if (sphereTransparencyRadioButton.Checked)
            {
                reflection = 0.0f; refraction = 0.9f; ambient = 0f; diffuse = 0.0f; environment = 1.03f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            sphere.material = new Material(reflection, refraction, ambient, diffuse, environment);

            Figure smallCube = ReadyFigures.Hexahedron(3.0f);
            AphineTransforms.offset(smallCube, 2.5f, 0.0f, -3.3f);
            smallCube.Pen = new Pen(Color.Yellow);
            if (smallCubeTransparencyRadioButton.Checked)
            {
                reflection = 0.0f; refraction = 0.8f; ambient = 0f; diffuse = 0.0f; environment = 1.03f;
            }
            if (smallCubeSpecularityRadioButton.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.05f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0f; refraction = 0f; ambient = 0.1f; diffuse = 0.7f; environment = 1f;
            }
            smallCube.material = new Material(reflection, refraction, ambient, diffuse, environment);

            Figure bigCube = ReadyFigures.Hexahedron(5.0f);
            AphineTransforms.offset(bigCube, -2.0f, -1.5f, -2.5f);
            AphineTransforms.rotateAround(bigCube, 30, Axis.Z);
            bigCube.Pen = new Pen(Color.White);
            if (bigCubeTransparencyRadioButton.Checked)
            {
                reflection = 0.0f; refraction = 0.8f; ambient = 0f; diffuse = 0.0f; environment = 1.03f;
            }
            else if (bigCubeSpecularityRadioButton.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.05f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            bigCube.material = new Material(reflection, refraction, ambient, diffuse, environment);

            scene.Add(room);
            scene.Add(sphere);
            scene.Add(smallCube);
            scene.Add(bigCube);
            
        }

        public void Clear()
        {
            scene.Clear();
            lights.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            build_scene();
            run_rayTrace();
            for (int i = 0; i < w; ++i)
            {
                for (int j = 0; j < h; ++j)
                    (pictureBox1.Image as Bitmap).SetPixel(i, j, color_pixels[i, j]);
            }
            pictureBox1.Invalidate();
        }

        public void run_rayTrace()
        {
            get_pixels();
            for (int i = 0; i < w; ++i)
                for (int j = 0; j < h; ++j)
                {
                    Ray ray = new Ray(focus, pixels[i, j]);
                    ray.begin = new Vector3D(pixels[i, j].X, pixels[i, j].Y, pixels[i, j].Z);
                    Vector3D color = RayTrace(ray, 10, 1);
                    if (color.X > 1.0f || color.Y > 1.0f || color.Z > 1.0f)
                        color.Normalize();
                    color_pixels[i, j] = Color.FromArgb((int)(255 * color.X), (int)(255 * color.Y), (int)(255 * color.Z));
                }
        }

        // получение всех пикселей сцены
        public void get_pixels()
        {
            pixels = new Vector3D[w, h];
            color_pixels = new Color[w, h];
            Vector3D step_up = (up_right - up_left) / (w - 1);
            Vector3D step_down = (down_right - down_left) / (w - 1);

            Vector3D up = new Vector3D(up_left.X,up_left.Y,up_left.Z);
            Vector3D down = new Vector3D(down_left.X,down_left.Y, down_left.Z);

            for (int i = 0; i < w; ++i)
            {
                Vector3D step_y = (up - down) / (h - 1);
                Vector3D d = new Vector3D(down.X,down.Y,down.Z);
                for (int j = 0; j < h; ++j)
                {
                    pixels[i, j] = d;
                    d += step_y;
                }
                up += step_up;
                down += step_down;
            }
        }

        // видима ли точка пересечения луча с фигурой из источника света
        public bool is_visible(Vector3D light_point, Vector3D collisionPoint)
        {
            var dist = (light_point - collisionPoint);
            float max_t = (float)Math.Sqrt(dist.X * dist.X + dist.Y * dist.Y + dist.Z * dist.Z); // позиция источника света на луче
            Ray ray = new Ray(collisionPoint, light_point);

            foreach (Figure fig in scene)
                if (fig.intersection(ray, out float t, out Vector3D n))
                    if (t < max_t && t > RayTracing.EPS)
                        return false;
            return true;
        }

        public Vector3D RayTrace(Ray ray, int iter, float environment)
        {
            if (iter <= 0)
                return new Vector3D(0, 0, 0);

            float t = 0;        // позиция точки пересечения луча с фигурой на луче
            Vector3D normal = new Vector3D();
            Material m = new Material();
            Vector3D res_color = new Vector3D(0, 0, 0);
            bool refract_out_of_figure = false; //  луч преломления выходит из объекта?

            foreach (Figure fig in scene)
            {
                if (fig.intersection(ray, out float interValue, out Vector3D n))
                    if (interValue < t || t == 0)     // нужна ближайшая фигура к точке наблюдения
                    {
                        t = interValue;
                        normal = n;
                        m = new Material(fig.material);
                    }
            }

            if (t == 0)
                return new Vector3D(0, 0, 0);
            //если угол между нормалью к поверхности объекта и направлением луча положительный, => угол острый, => луч выходит из объекта в среду
            if (Vector3D.DotProduct(ray.direction, normal) > 0)
            {
                normal *= -1;
                refract_out_of_figure = true;
            }

            Vector3D collisionPoint = ray.begin + ray.direction * t;

            foreach (LightBox l in lights)
            {
                Vector3D ambient = l.color * m.ambient;
                ambient.X = (ambient.X * m.color.X);
                ambient.Y = (ambient.Y * m.color.Y);
                ambient.Z = (ambient.Z * m.color.Z);
                res_color += ambient;

                // диффузное освещение
                if (is_visible(l.position, collisionPoint))
                    res_color += l.localLighting(collisionPoint, normal, m.color, m.diffuse);
            }

            if (m.reflection > 0)
            {
                Ray reflected_ray = ray.reflect(collisionPoint, normal);
                res_color += m.reflection * RayTrace(reflected_ray, iter - 1, environment);
            }

            if (m.refraction > 0)
            {
                float eta;                 //коэффициент преломления
                if (refract_out_of_figure) //луч выходит в среду
                    eta = m.environment;
                else
                    eta = 1 / m.environment;

                Ray refracted_ray = ray.refract(collisionPoint, normal, eta);
                if (refracted_ray != null)
                    res_color += m.refraction * RayTrace(refracted_ray, iter - 1, m.environment);
            }

            return res_color;
        }

    }
}
