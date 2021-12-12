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

        public static float EPS = 0.0001f;
        public List<Vector3D> points = new List<Vector3D>(); // точки 
        public List<Side> sides = new List<Side>();        // стороны
        public Material figure_material;
        public bool isRoom = false;                       // данный куб - комната?
        public Material front_wall_material;               // материалы для стен комнаты
        public Material back_wall_material;
        public Material left_wall_material;
        public Material right_wall_material;
        public Material up_wall_material;
        public Material down_wall_material;
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


        public bool ray_intersects_triangle(Ray r, Vector3D p0, Vector3D p1, Vector3D p2, out float intersect)
        {
            intersect = -1;

            Vector3D edge1 = p1 - p0;
            Vector3D edge2 = p2 - p0;
            Vector3D h = Vector3D.CrossProduct(r.direction,edge2);
            float a = (float)Vector3D.DotProduct(edge1, h);

            if (a > -EPS && a < EPS)
                return false;       // This ray is parallel to this triangle.

            float f = 1.0f / a;
            Vector3D s = r.start - p0;
            float u = f * (float)Vector3D.DotProduct(s, h);

            if (u < 0 || u > 1)
                return false;

            Vector3D q = Vector3D.CrossProduct(s,edge1);
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

        // пересечение луча с фигурой
        public virtual bool figure_intersection(Ray r, out float intersect, out Vector3D normal)
        {
            intersect = 0;
            normal = new Vector3D();
            Side sd = null;
            int fm = -1;         // номер стены комнаты, которую пересек луч

            for (int i = 0; i < sides.Count; ++i)
            {

                if (sides[i].points.Count == 3)
                {
                    if (ray_intersects_triangle(r, sides[i].get_point(0), sides[i].get_point(1), sides[i].get_point(2), out float t) && (intersect == 0 || t < intersect))
                    {
                        intersect = t;
                        sd = sides[i];
                    }
                }
                else if (sides[i].points.Count == 4)
                {
                    if (ray_intersects_triangle(r, sides[i].get_point(0), sides[i].get_point(1), sides[i].get_point(3), out float t) && (intersect == 0 || t < intersect))
                    {
                        fm = i;
                        intersect = t;
                        sd = sides[i];
                    }
                    else if (ray_intersects_triangle(r, sides[i].get_point(1), sides[i].get_point(2), sides[i].get_point(3), out t) && (intersect == 0 || t < intersect))
                    {
                        fm = i;
                        intersect = t;
                        sd = sides[i];
                    }
                }
            }

            if (intersect != 0)
            {
                normal = Side.norm(sd);
                if (isRoom)
                    switch (fm)
                    {
                        case 0:
                            figure_material = new Material(back_wall_material);
                            break;
                        case 1:
                            figure_material = new Material(front_wall_material);
                            break;
                        case 2:
                            figure_material = new Material(right_wall_material);
                            break;
                        case 3:
                            figure_material = new Material(left_wall_material);
                            break;
                        case 4:
                            figure_material = new Material(up_wall_material);
                            break;
                        case 5:
                            figure_material = new Material(down_wall_material);
                            break;
                        default:
                            break;
                    }
                figure_material.clr = new Vector3D(sd.drawing_pen.Color.R / 255f, sd.drawing_pen.Color.G / 255f, sd.drawing_pen.Color.B / 255f);
                return true;
            }

            return false;
        }

        

        ///
        /// ------------------------STATIC READY FIGURES-----------------------------
        ///

        static public Figure get_Hexahedron(float sz)
        {
            Figure res = new Figure();
            res.points.Add(new Vector3D(sz / 2, sz / 2, sz / 2)); // 0 
            res.points.Add(new Vector3D(-sz / 2, sz / 2, sz / 2)); // 1
            res.points.Add(new Vector3D(-sz / 2, sz / 2, -sz / 2)); // 2
            res.points.Add(new Vector3D(sz / 2, sz / 2, -sz / 2)); //3

            res.points.Add(new Vector3D(sz / 2, -sz / 2, sz / 2)); // 4
            res.points.Add(new Vector3D(-sz / 2, -sz / 2, sz / 2)); //5
            res.points.Add(new Vector3D(-sz / 2, -sz / 2, -sz / 2)); // 6
            res.points.Add(new Vector3D(sz / 2, -sz / 2, -sz / 2)); // 7

            Side s = new Side(res);
            s.points.AddRange(new int[] { 3, 2, 1, 0 });
            res.sides.Add(s);

            s = new Side(res);
            s.points.AddRange(new int[] { 4, 5, 6, 7 });
            res.sides.Add(s);

            s = new Side(res);
            s.points.AddRange(new int[] { 2, 6, 5, 1 });
            res.sides.Add(s);

            s = new Side(res);
            s.points.AddRange(new int[] { 0, 4, 7, 3 });
            res.sides.Add(s);

            s = new Side(res);
            s.points.AddRange(new int[] { 1, 5, 4, 0 });
            res.sides.Add(s);

            s = new Side(res);
            s.points.AddRange(new int[] { 2, 3, 7, 6 });
            res.sides.Add(s);

            return res;
        }
    }
}
