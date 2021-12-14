using Indiv2.logi;
using Indiv2.models;
using Indiv2.models.figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using LightBox = Indiv2.models.figures.LightBox;
using Material = Indiv2.models.Material;

namespace Indiv2
{
    public partial class MainForm : Form
    {

        public List<Figure> workSpace = new List<Figure>();
        public List<LightBox> lightBoxes = new List<LightBox>();
        public Color[,] colorPixels;
        public Vector3D[,] pixels;
        public Vector3D focus;
        public Vector3D upLeft, upRight, downLeft, downRight;
        public int pictureHeight, pictureWidth;

        public MainForm()
        {
            InitializeComponent();
            focus = new Vector3D();
            upLeft = new Vector3D();
            upRight = new Vector3D();
            downLeft = new Vector3D();
            downRight = new Vector3D();
            pictureHeight = pictureBox1.Height;
            pictureWidth = pictureBox1.Width;
            pictureBox1.Image = new Bitmap(pictureWidth, pictureHeight);
            smallCubeRegularRadioButton.Checked = true;
            bigCubeSpecularityRadioButton.Checked = true;
            sphereTransparencyRadioButton.Checked = true;
            twoLightsCheckBox.Checked = false;

            twoLightsCheckBox.Checked = false;
            secondLightBoxControls.Enabled = false;

            xUpDown.DecimalPlaces = 2;
            xUpDown.Increment = 0.1M;
            xUpDown.Maximum = 10;
            xUpDown.Minimum = -10;

            yUpDown.DecimalPlaces = 2;
            yUpDown.Increment = 0.1M;
            yUpDown.Maximum = 10;
            yUpDown.Minimum = -10;

            zUpDown.DecimalPlaces = 2;
            zUpDown.Increment = 0.1M;
            zUpDown.Maximum = 10;
            zUpDown.Minimum = -10;

        }

        public void loadWorkSpace()
        {
            Room room = new Room(ReadyFigures.Hexahedron(10));
            upLeft = room.faces[0].pointByIndex(0);
            upRight = room.faces[0].pointByIndex(1);
            downRight = room.faces[0].pointByIndex(2);
            downLeft = room.faces[0].pointByIndex(3);

            Vector3D normal = room.faces[0].Normal;                            
            Vector3D center = (upLeft + upRight + downLeft + downRight) / 4;
            focus = center + normal * 10;

            room.Pen = new Pen(Color.Gray);

            float reflection, refraction, ambient, diffuse, environment;

            room.faces[0].pen = new Pen(Color.White);
            if (backWallSpecularCheckBox.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.0f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            room.back = new Material(reflection, refraction, ambient, diffuse, environment);

            room.faces[1].pen = new Pen(Color.White);
            if (frontWallSpecularCheckBox.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.0f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            room.front = new Material(reflection, refraction, ambient, diffuse, environment);

            room.faces[2].pen = new Pen(Color.Blue);
            if (rightWallSpecularCheckBox.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.0f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            room.right = new Material(reflection, refraction, ambient, diffuse, environment);

            room.faces[3].pen = new Pen(Color.Red);
            if (leftWallSpecularCheckBox.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.0f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            room.left = new Material(reflection, refraction, ambient, diffuse, environment);

            if (ceilingWallSpecularCheckBox.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.0f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            room.ceiling = new Material(reflection, refraction, ambient, diffuse, environment);

            if (floorWallSpecularCheckBox.Checked)
            {
                reflection = 0.8f; refraction = 0f; ambient = 0.0f; diffuse = 0.0f; environment = 1f;
            }
            else
            {
                reflection = 0.0f; refraction = 0f; ambient = 0.1f; diffuse = 0.8f; environment = 1f;
            }
            room.floor = new Material(reflection, refraction, ambient, diffuse, environment);

            LightBox lightBox1 = new LightBox(new Vector3D(0f, 1f, 4.9f), new Vector3D(1f, 1f, 1f));
            lightBoxes.Add(lightBox1);
            if (twoLightsCheckBox.Checked)
            {
                LightBox lightBox2 = new LightBox(new Vector3D( (float)xUpDown.Value, (float)yUpDown.Value, (float)zUpDown.Value), new Vector3D(1f, 1f, 1f));
                lightBoxes.Add(lightBox2);
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

            workSpace.Add(room);
            workSpace.Add(sphere);
            workSpace.Add(smallCube);
            workSpace.Add(bigCube);
            
        }

        public void Clear()
        {
            workSpace.Clear();
            lightBoxes.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            loadWorkSpace();
            run_rayTrace();
            for (int i = 0; i < pictureWidth; ++i)
            {
                for (int j = 0; j < pictureHeight; ++j)
                    (pictureBox1.Image as Bitmap).SetPixel(i, j, colorPixels[i, j]);
            }
            pictureBox1.Invalidate();
        }

        private void twoLightsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (twoLightsCheckBox.Checked)
            {
                secondLightBoxControls.Enabled = true;
            } else
            {
                secondLightBoxControls.Enabled = false;
            }
        }

        public void run_rayTrace()
        {
            allWorkSpacePixels();
            for (int i = 0; i < pictureWidth; ++i)
                for (int j = 0; j < pictureHeight; ++j)
                {
                    Ray ray = new Ray(focus, pixels[i, j]);
                    ray.begin = new Vector3D(pixels[i, j].X, pixels[i, j].Y, pixels[i, j].Z);
                    Vector3D color = RayTrace(ray, 10, 1);
                    if (color.X > 1.0f || color.Y > 1.0f || color.Z > 1.0f)
                        color.Normalize();
                    colorPixels[i, j] = Color.FromArgb((int)(255 * color.X), (int)(255 * color.Y), (int)(255 * color.Z));
                }
        }

        // получение всех пикселей сцены
        public void allWorkSpacePixels()
        {
            pixels = new Vector3D[pictureWidth, pictureHeight];
            colorPixels = new Color[pictureWidth, pictureHeight];
            Vector3D stepUp = (upRight - upLeft) / (pictureWidth - 1);
            Vector3D stepDown = (downRight - downLeft) / (pictureWidth - 1);

            Vector3D up = new Vector3D(upLeft.X,upLeft.Y,upLeft.Z);
            Vector3D down = new Vector3D(downLeft.X,downLeft.Y, downLeft.Z);

            for (int i = 0; i < pictureWidth; ++i)
            {
                Vector3D step_y = (up - down) / (pictureHeight - 1);
                Vector3D d = new Vector3D(down.X,down.Y,down.Z);
                for (int j = 0; j < pictureHeight; ++j)
                {
                    pixels[i, j] = d;
                    d += step_y;
                }
                up += stepUp;
                down += stepDown;
            }
        }

        // видима ли точка пересечения луча с фигурой из источника света
        public bool isVisible(Vector3D light_point, Vector3D collisionPoint)
        {
            var dist = (light_point - collisionPoint);
            float max_t = (float)Math.Sqrt(dist.X * dist.X + dist.Y * dist.Y + dist.Z * dist.Z); // позиция источника света на луче
            Ray ray = new Ray(collisionPoint, light_point);

            foreach (Figure fig in workSpace)
                if (fig.intersection(ray, out float t, out Vector3D n))
                    if (t < max_t && t > RayTracing.EPS)
                        return false;
            return true;
        }

        public Vector3D RayTrace(Ray ray, int iter, float environment)
        {
            if (iter <= 0)
                return new Vector3D(0, 0, 0);

            float t = 0;
            Vector3D normal = new Vector3D();
            Material m = new Material();
            Vector3D res_color = new Vector3D(0, 0, 0);
            bool refract_out_of_figure = false;

            foreach (Figure fig in workSpace)
            {
                if (fig.intersection(ray, out float interValue, out Vector3D n))
                    if (interValue < t || t == 0)
                    {
                        t = interValue;
                        normal = n;
                        m = new Material(fig.material);
                    }
            }

            if (t == 0)
                return new Vector3D(0, 0, 0);
            if (Vector3D.DotProduct(ray.direction, normal) > 0)
            {
                normal *= -1;
                refract_out_of_figure = true;
            }

            Vector3D collisionPoint = ray.begin + ray.direction * t;

            foreach (LightBox l in lightBoxes)
            {
                Vector3D ambient = l.color * m.ambient;
                ambient.X *= m.color.X;
                ambient.Y *= m.color.Y;
                ambient.Z *= m.color.Z;
                res_color += ambient;

                if (isVisible(l.position, collisionPoint))
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
