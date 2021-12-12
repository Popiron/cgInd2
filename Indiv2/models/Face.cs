using Indiv2.models.figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models
{
    public class Side
    {
        public Figure host = null;
        public List<int> points = new List<int>();
        public Pen drawing_pen = new Pen(Color.Black);
        public Vector3D Normal;

        public Side(Figure h = null)
        {
            host = h;
        }
        public Side(Side s)
        {
            points = new List<int>(s.points);
            host = s.host;
            drawing_pen = s.drawing_pen.Clone() as Pen;
            Normal = new Vector3D(s.Normal.X,s.Normal.Y,s.Normal.Z);
        }
        public Vector3D get_point(int ind)
        {
            if (host != null)
                return host.points[points[ind]];
            return new Vector3D();
        }

        public static Vector3D norm(Side S)
        {
            if (S.points.Count < 3)
                return new Vector3D(0, 0, 0);
            Vector3D U = S.get_point(1) - S.get_point(0);
            Vector3D V = S.get_point(S.points.Count - 1) - S.get_point(0);
            Vector3D normal = Vector3D.CrossProduct(U, V);
            normal.Normalize();
            return normal;
        }
    }
}
