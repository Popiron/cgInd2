using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models.figures
{
    public class LightBox : Figure
    {
        public Vector3D position;
        public Vector3D color;

        public LightBox(Vector3D point, Vector3D c)
        {
            position = new Vector3D(point.X,point.Y,point.Z);
            color = new Vector3D(c.X,c.Y,c.Z);
        }

        public Vector3D localLighting(Vector3D collisionPoint, Vector3D normal, Vector3D ObjectColor, float diffusion)
        {
            Vector3D direction = position - collisionPoint;
            direction.Normalize();

            Vector3D diff = diffusion * color * Math.Max(Vector3D.DotProduct(normal, direction), 0);
            return new Vector3D(diff.X * ObjectColor.X, diff.Y * ObjectColor.Y, diff.Z * ObjectColor.Z);
        }
    }
}
