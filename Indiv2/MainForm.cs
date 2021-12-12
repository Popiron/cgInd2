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
using Light = Indiv2.models.figures.Light;
using Material = Indiv2.models.Material;

namespace Indiv2
{
    public partial class MainForm : Form
    {

        public List<Figure> scene = new List<Figure>();
        public List<Light> lights = new List<Light>();   // список источников света
        public Color[,] color_pixels;                    // цвета пикселей для отображения на pictureBox
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
            cubeSpecularCB.Checked = true;
            sphereSpecularCB.Checked = true;
            refractCubeCB.Checked = false;
            refractSphereCB.Checked = true;
            frontWallSpecularCB.Checked = backWallSpecularCB.Checked = leftWallSpecularCB.Checked = rightWallSpecularCB.Checked = false;
            twoLightsCB.Checked = false;
        }

        public void build_scene()
        {
            Figure room = Figure.get_Hexahedron(10);
            up_left = room.sides[0].get_point(0);
            up_right = room.sides[0].get_point(1);
            down_right = room.sides[0].get_point(2);
            down_left = room.sides[0].get_point(3);

            Vector3D normal = Side.norm(room.sides[0]);                            // нормаль стороны комнаты
            Vector3D center = (up_left + up_right + down_left + down_right) / 4;   // центр стороны комнаты
            focus = center + normal * 10;

            room.set_pen(new Pen(Color.Gray));

            room.isRoom = true;

            float refl, refr, amb, dif, env;

            room.sides[0].drawing_pen = new Pen(Color.Green);
            if (backWallSpecularCB.Checked)
            {
                refl = 0.8f; refr = 0f; amb = 0.0f; dif = 0.0f; env = 1f;
            }
            else
            {
                refl = 0.0f; refr = 0f; amb = 0.1f; dif = 0.8f; env = 1f;
            }
            room.back_wall_material = new Material(refl, refr, amb, dif, env);

            room.sides[1].drawing_pen = new Pen(Color.Gold);
            if (frontWallSpecularCB.Checked)
            {
                refl = 0.8f; refr = 0f; amb = 0.0f; dif = 0.0f; env = 1f;
            }
            else
            {
                refl = 0.0f; refr = 0f; amb = 0.1f; dif = 0.8f; env = 1f;
            }
            room.front_wall_material = new Material(refl, refr, amb, dif, env);

            room.sides[2].drawing_pen = new Pen(Color.DeepPink);
            if (rightWallSpecularCB.Checked)
            {
                refl = 0.8f; refr = 0f; amb = 0.0f; dif = 0.0f; env = 1f;
            }
            else
            {
                refl = 0.0f; refr = 0f; amb = 0.1f; dif = 0.8f; env = 1f;
            }
            room.right_wall_material = new Material(refl, refr, amb, dif, env);

            room.sides[3].drawing_pen = new Pen(Color.BlueViolet);
            if (leftWallSpecularCB.Checked)
            {
                refl = 0.8f; refr = 0f; amb = 0.0f; dif = 0.0f; env = 1f;
            }
            else
            {
                refl = 0.0f; refr = 0f; amb = 0.1f; dif = 0.8f; env = 1f;
            }
            room.left_wall_material = new Material(refl, refr, amb, dif, env);

            if (upWallSpecularCB.Checked)
            {
                refl = 0.8f; refr = 0f; amb = 0.0f; dif = 0.0f; env = 1f;
            }
            else
            {
                refl = 0.0f; refr = 0f; amb = 0.1f; dif = 0.8f; env = 1f;
            }
            room.up_wall_material = new Material(refl, refr, amb, dif, env);

            if (downWallSpecularCB.Checked)
            {
                refl = 0.8f; refr = 0f; amb = 0.0f; dif = 0.0f; env = 1f;
            }
            else
            {
                refl = 0.0f; refr = 0f; amb = 0.1f; dif = 0.8f; env = 1f;
            }
            room.down_wall_material = new Material(refl, refr, amb, dif, env);

            Light l1 = new Light(new Vector3D(0f, 1f, 4.9f), new Vector3D(1f, 1f, 1f));
            lights.Add(l1);
            if (twoLightsCB.Checked)
            {
                Light l2 = new Light(new Vector3D(0f, 4f, -4.9f), new Vector3D(1f, 1f, 1f));
                lights.Add(l2);
            }

            Sphere s1 = new Sphere(new Vector3D(2.8f, -2.5f, 2.5f), 2f);
            s1.set_pen(new Pen(Color.White));
            if (sphereSpecularCB.Checked)
            {
                refl = 0.9f; refr = 0f; amb = 0f; dif = 0.1f; env = 1f;
            }
            else
            {
                refl = 0.0f; refr = 0f; amb = 0.1f; dif = 0.8f; env = 1f;
            }
            s1.figure_material = new Material(refl, refr, amb, dif, env);

            Figure cube1 = Figure.get_Hexahedron(3.2f);
            cube1.offset(-0.5f, -1, -3.5f);
            cube1.rotate_around(55, "CZ");
            cube1.set_pen(new Pen(Color.Aqua));
            if (refractCubeCB.Checked)
            {
                refl = 0.0f; refr = 0.8f; amb = 0f; dif = 0.0f; env = 1.03f;
            }
            else
            {
                refl = 0f; refr = 0f; amb = 0.1f; dif = 0.7f; env = 1f;
            }
            cube1.figure_material = new Material(refl, refr, amb, dif, env);

            Figure cube2 = Figure.get_Hexahedron(2.6f);
            cube2.offset(-2.4f, 2, -3.8f);
            cube2.rotate_around(30, "CZ");
            cube2.set_pen(new Pen(Color.Blue));
            if (cubeSpecularCB.Checked)
            {
                refl = 0.8f; refr = 0f; amb = 0.05f; dif = 0.0f; env = 1f;
            }
            else
            {
                refl = 0.0f; refr = 0f; amb = 0.1f; dif = 0.8f; env = 1f;
            }
            cube2.figure_material = new Material(refl, refr, amb, dif, env);

            Sphere s2 = new Sphere(new Vector3D(-2.2f, 1.6f, -1.4f), 1.2f);
            s2.set_pen(new Pen(Color.DarkOrange));
            s2.figure_material = new Material(0.0f, 0.0f, 0.1f, 0.7f, 1.0f);

            Sphere s3 = new Sphere(new Vector3D(2.5f, 2f, -3.4f), 1.7f);
            s3.set_pen(new Pen(Color.LimeGreen));
            if (refractSphereCB.Checked)
            {
                refl = 0.0f; refr = 0.9f; amb = 0f; dif = 0.0f; env = 1.03f;
            }
            else
            {
                refl = 0.0f; refr = 0f; amb = 0.1f; dif = 0.9f; env = 1f;
            }
            s3.figure_material = new Material(refl, refr, amb, dif, env);

            Sphere s4 = new Sphere(new Vector3D(2.7f, -2.5f, 3.95f), 1.3f);
            s4.set_pen(new Pen(Color.Red));
            s4.figure_material = new Material(0.7f, 0f, 0.0f, 0.0f, 1f);

            scene.Add(room);
            scene.Add(cube1);
            scene.Add(cube2);
            scene.Add(s1);
            scene.Add(s2);
            scene.Add(s3);
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
                    Ray r = new Ray(focus, pixels[i, j]);
                    r.start = new Vector3D(pixels[i, j].X, pixels[i, j].Y, pixels[i, j].Z);
                    Vector3D clr = RayTrace(r, 10, 1);
                    if (clr.X > 1.0f || clr.Y > 1.0f || clr.Z > 1.0f)
                        clr.Normalize();
                    color_pixels[i, j] = Color.FromArgb((int)(255 * clr.X), (int)(255 * clr.Y), (int)(255 * clr.Z));
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
        public bool is_visible(Vector3D light_point, Vector3D hit_point)
        {
            var dist = (light_point - hit_point);
            float max_t = (float)Math.Sqrt(dist.X * dist.X + dist.Y * dist.Y + dist.Z * dist.Z); // позиция источника света на луче
            Ray r = new Ray(hit_point, light_point);

            foreach (Figure fig in scene)
                if (fig.figure_intersection(r, out float t, out Vector3D n))
                    if (t < max_t && t > Figure.EPS)
                        return false;
            return true;
        }

        public Vector3D RayTrace(Ray r, int iter, float env)
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
                if (fig.figure_intersection(r, out float intersect, out Vector3D n))
                    if (intersect < t || t == 0)     // нужна ближайшая фигура к точке наблюдения
                    {
                        t = intersect;
                        normal = n;
                        m = new Material(fig.figure_material);
                    }
            }

            if (t == 0)
                return new Vector3D(0, 0, 0);
            //если угол между нормалью к поверхности объекта и направлением луча положительный, => угол острый, => луч выходит из объекта в среду
            if (Vector3D.DotProduct(r.direction, normal) > 0)
            {
                normal *= -1;
                refract_out_of_figure = true;
            }

            Vector3D hit_point = r.start + r.direction * t;

            foreach (Light l in lights)
            {
                Vector3D amb = l.color_light * m.ambient;
                amb.X = (amb.X * m.clr.X);
                amb.Y = (amb.Y * m.clr.Y);
                amb.Z = (amb.Z * m.clr.Z);
                res_color += amb;

                // диффузное освещение
                if (is_visible(l.point_light, hit_point))
                    res_color += l.shade(hit_point, normal, m.clr, m.diffuse);
            }

            if (m.reflection > 0)
            {
                Ray reflected_ray = r.reflect(hit_point, normal);
                res_color += m.reflection * RayTrace(reflected_ray, iter - 1, env);
            }

            if (m.refraction > 0)
            {
                float eta;                 //коэффициент преломления
                if (refract_out_of_figure) //луч выходит в среду
                    eta = m.environment;
                else
                    eta = 1 / m.environment;

                Ray refracted_ray = r.refract(hit_point, normal, eta);
                if (refracted_ray != null)
                    res_color += m.refraction * RayTrace(refracted_ray, iter - 1, m.environment);
            }

            return res_color;
        }

    }
}
