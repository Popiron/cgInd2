using Indiv2.logi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models.figures
{
    public class Sphere : Figure
    {
        public float radius;

        public Pen drawing_pen = new Pen(Color.Black);

        public Sphere(Vector3D p, float r)
        {
            points.Add(p);
            radius = r;
        }

        public override bool figure_intersection(Ray r, out float t, out Vector3D normal)
        {
            t = 0;
            normal = new Vector3D();
            if (RayTracing.ray_sphere_intersection(r, points[0], radius, out t) && (t > RayTracing.EPS))
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
