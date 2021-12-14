using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models
{
    public class Ray
    {
        public Vector3D begin, direction;

        public Ray(Vector3D begin, Vector3D end)
        {
            this.begin = new Vector3D(begin.X,begin.Y,begin.Z);
            direction = end - begin;
            direction.Normalize();
        }

        public Ray() { }

        public Ray(Ray ray)
        {
            begin = ray.begin;
            direction = ray.direction;
        }

        // отражение
        public Ray reflect(Vector3D collisionPoint, Vector3D normal)
        {
            Vector3D reflectionDirection = direction - 2 * normal * Vector3D.DotProduct(direction, normal);
            return new Ray(collisionPoint, collisionPoint + reflectionDirection);
        }

        // преломление
        public Ray refract(Vector3D collisionPoint, Vector3D normal, float eta)
        {
            Ray ray = new Ray();
            float scalar = (float)Vector3D.DotProduct(normal, direction);

            float k = 1 - eta * eta * (1 - scalar * scalar);

            if (k >= 0)
            {
                float cos_theta = (float)Math.Sqrt(k);
                ray.begin = new Vector3D(collisionPoint.X,collisionPoint.Y,collisionPoint.Z);
                ray.direction = eta * direction - (cos_theta + eta * scalar) * normal;
                ray.direction.Normalize();
                return ray;
            }
            else
                return null;
        }
    }
}
