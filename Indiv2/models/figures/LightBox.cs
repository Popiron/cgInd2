using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models.figures
{
    public class LightBox : Figure
    {
        public Vector3D point_light;       // точка, где находится источник света
        public Vector3D color_light;       // цвет источника света

        public LightBox(Vector3D p, Vector3D c)
        {
            point_light = new Vector3D(p.X,p.Y,p.Z);
            color_light = new Vector3D(c.X,c.Y,c.Z);
        }

        // вычисление локальной модели освещения
        public Vector3D shade(Vector3D hit_point, Vector3D normal, Vector3D color_obj, float diffuse_coef)
        {
            Vector3D dir = point_light - hit_point;
            dir.Normalize();               // направление луча из источника света в точку удара

            Vector3D diff = diffuse_coef * color_light * Math.Max(Vector3D.DotProduct(normal, dir), 0);
            return new Vector3D(diff.X * color_obj.X, diff.Y * color_obj.Y, diff.Z * color_obj.Z);
        }
    }
}
