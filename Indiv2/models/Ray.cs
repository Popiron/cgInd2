using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models
{
    public class Ray
    {
        public Vector3D start, direction;

        public Ray(Vector3D st, Vector3D end)
        {
            start = new Vector3D(st.X,st.Y,st.Z);
            direction = end - st;
            direction.Normalize();
        }

        public Ray() { }

        public Ray(Ray r)
        {
            start = r.start;
            direction = r.direction;
        }

        // отражение
        public Ray reflect(Vector3D hit_point, Vector3D normal)
        {
            Vector3D reflect_dir = direction - 2 * normal * Vector3D.DotProduct(direction, normal);
            return new Ray(hit_point, hit_point + reflect_dir);
        }

        // преломление
        public Ray refract(Vector3D hit_point, Vector3D normal, float eta)
        {
            Ray res_ray = new Ray();
            float sclr = (float)Vector3D.DotProduct(normal, direction);

            float k = 1 - eta * eta * (1 - sclr * sclr);

            if (k >= 0)
            {
                float cos_theta = (float)Math.Sqrt(k);
                res_ray.start = new Vector3D(hit_point.X,hit_point.Y,hit_point.Z);
                //res_ray.direction = Point3D.norm(eta * direction + (cos_theta * eta - (float)Math.Sqrt(k)) * normal);
                res_ray.direction = eta * direction - (cos_theta + eta * sclr) * normal;
                res_ray.direction.Normalize();
                return res_ray;
            }
            else
                return null;
        }
    }
}
