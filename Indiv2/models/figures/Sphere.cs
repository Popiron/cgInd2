using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models.figures
{
    public class Sphere : Figure
    {
        float radius;

        public Pen drawing_pen = new Pen(Color.Black);

        public Sphere(Vector3D p, float r)
        {
            points.Add(p);
            radius = r;
        }


        public static bool ray_sphere_intersection(Ray r, Vector3D sphere_pos, float sphere_rad, out float t)
        {
            Vector3D k = r.start - sphere_pos;
            float b = (float)Vector3D.DotProduct(k, r.direction);
            float c = (float) Vector3D.DotProduct(k, k) - sphere_rad * sphere_rad;
            float d = b * b - c;
            t = 0;

            if (d >= 0)
            {
                float sqrtd = (float)Math.Sqrt(d);
                float t1 = -b + sqrtd;
                float t2 = -b - sqrtd;

                float min_t = Math.Min(t1, t2);
                float max_t = Math.Max(t1, t2);

                t = (min_t > EPS) ? min_t : max_t;
                return t > EPS;
            }
            return false;
        }

        public override void set_pen(Pen dw)
        {
            drawing_pen = dw;

        }

        public override bool figure_intersection(Ray r, out float t, out Vector3D normal)
        {
            t = 0;
            normal = new Vector3D();

            if (ray_sphere_intersection(r, points[0], radius, out t) && (t > EPS))
            {
                normal = (r.start + r.direction * t) - points[0];
                normal.Normalize();
                figure_material.clr = new Vector3D(drawing_pen.Color.R / 255f, drawing_pen.Color.G / 255f, drawing_pen.Color.B / 255f);
                return true;
            }
            return false;
        }
    }
}
