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

        public Pen pen = new Pen(Color.Black);

        public Sphere(Vector3D point, float ray)
        {
            vertices.Add(point);
            radius = ray;
        }

        public override bool intersection(Ray ray, out float t, out Vector3D normal)
        {
            t = 0;
            normal = new Vector3D();
            if (RayTracing.ray_sphere_intersection(ray, vertices[0], radius, out t) && (t > RayTracing.EPS))
            {
                normal = (ray.begin + ray.direction * t) - vertices[0];
                normal.Normalize();
                material.color = new Vector3D(pen.Color.R / 255f, pen.Color.G / 255f, pen.Color.B / 255f);
                return true;
            }
            return false;
        }

    }
}
