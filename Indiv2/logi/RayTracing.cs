using Indiv2.models;
using Indiv2.models.figures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;
using Material = Indiv2.models.Material;

namespace Indiv2.logi
{
    public class RayTracing
    {
        public static float EPS = 0.00001f;

        public static bool ray_intersects_triangle(Ray r, Vector3D p0, Vector3D p1, Vector3D p2, out float intersect)
        {
            intersect = -1;

            Vector3D edge1 = p1 - p0;
            Vector3D edge2 = p2 - p0;
            Vector3D h = Vector3D.CrossProduct(r.direction, edge2);
            float a = (float)Vector3D.DotProduct(edge1, h);

            if (a > -EPS && a < EPS)
                return false;       // This ray is parallel to this triangle.

            float f = 1.0f / a;
            Vector3D s = r.start - p0;
            float u = f * (float)Vector3D.DotProduct(s, h);

            if (u < 0 || u > 1)
                return false;

            Vector3D q = Vector3D.CrossProduct(s, edge1);
            float v = f * (float)Vector3D.DotProduct(r.direction, q);

            if (v < 0 || u + v > 1)
                return false;
            // At this stage we can compute t to find out where the intersection point is on the line.
            float t = f * (float)Vector3D.DotProduct(edge2, q);
            if (t > EPS)
            {
                intersect = t;
                return true;
            }
            else      // This means that there is a line intersection but not a ray intersection.
                return false;
        }

        public static bool ray_sphere_intersection(Ray r, Vector3D sphere_pos, float sphere_rad, out float t)
        {
            Vector3D k = r.start - sphere_pos;
            float b = (float)Vector3D.DotProduct(k, r.direction);
            float c = (float)Vector3D.DotProduct(k, k) - sphere_rad * sphere_rad;
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

    }
}
