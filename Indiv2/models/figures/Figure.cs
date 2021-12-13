using Indiv2.logi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models.figures
{
    public class Figure
    {
        public List<Side> sides = new List<Side>();        // стороны
        public Material figure_material;
        public List<Vector3D> points = new List<Vector3D>();
        
        
        public Vector3D Center {
            get
            {
                Vector3D res = new Vector3D(0, 0, 0);
                foreach (Vector3D p in points)
                {
                    res.X += p.X;
                    res.Y += p.Y;
                    res.Z += p.Z;

                }
                res.X /= points.Count();
                res.Y /= points.Count();
                res.Z /= points.Count();
                return res;
            }
        }

        public List<Matrix3D> Matrices
        {
            get
            {
                List<Matrix3D> matrices = new List<Matrix3D>();
                for (int i = 0; i < points.Count; i++)
                {
                    var point = new Matrix3D(
                        (float)points[i].X, (float)points[i].Y, (float)points[i].Z, 1,
                        1,1,1,1,
                        1,1,1,1,
                        1,1,1,1);

                    matrices.Add(point);
                }
                return matrices;
            }
        }

        public Pen Pen
        {
            set {
                foreach (Side s in sides)
                    s.drawing_pen = value;
            }
        }

        public Figure() { }

        public Figure(Figure f)
        {
            foreach (var p in f.points)
                points.Add(new Vector3D(p.X,p.Y,p.Z));

            foreach (Side s in f.sides)
            {
                sides.Add(new Side(s));
                sides.Last().host = this;
            }
        }

        // пересечение луча с фигурой
        public virtual bool figure_intersection(Ray r, out float intersect, out Vector3D normal)
        {
            intersect = 0;
            normal = new Vector3D();
            Side sd = null;
            int fm = -1;         // номер стены комнаты, которую пересек луч

            for (int i = 0; i <  sides.Count; ++i)
            {

                if ( sides[i].points.Count == 3)
                {
                    if (RayTracing.ray_intersects_triangle(r,  sides[i].get_point(0),  sides[i].get_point(1),  sides[i].get_point(2), out float t) && (intersect == 0 || t < intersect))
                    {
                        intersect = t;
                        sd =  sides[i];
                    }
                }
                else if ( sides[i].points.Count == 4)
                {
                    if (RayTracing.ray_intersects_triangle(r,  sides[i].get_point(0),  sides[i].get_point(1),  sides[i].get_point(3), out float t) && (intersect == 0 || t < intersect))
                    {
                        fm = i;
                        intersect = t;
                        sd =  sides[i];
                    }
                    else if (RayTracing.ray_intersects_triangle(r,  sides[i].get_point(1),  sides[i].get_point(2),  sides[i].get_point(3), out t) && (intersect == 0 || t < intersect))
                    {
                        fm = i;
                        intersect = t;
                        sd =  sides[i];
                    }
                }
            }

            if (intersect != 0)
            {
                normal = sd.Normal;
                figure_material.clr = new Vector3D(sd.drawing_pen.Color.R / 255f, sd.drawing_pen.Color.G / 255f, sd.drawing_pen.Color.B / 255f);
                return true;
            }

            return false;
        }

    }
}
