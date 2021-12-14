using Indiv2.models.figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models
{
    public class Face
    {
        public Figure owner = null;
        public List<int> vertices = new List<int>();
        public Pen pen = new Pen(Color.Black);
        public Vector3D Normal
        {
            get
            {
                if (vertices.Count < 3)
                    return new Vector3D(0, 0, 0);
                Vector3D U = get_point(1) - get_point(0);
                Vector3D V = get_point(vertices.Count - 1) - get_point(0);
                Vector3D normal = Vector3D.CrossProduct(U, V);
                normal.Normalize();
                return normal;
            }
        }

        public Face(Figure h = null)
        {
            owner = h;
        }
        public Face(Face s)
        {
            vertices = new List<int>(s.vertices);
            owner = s.owner;
            pen = s.pen.Clone() as Pen;
        }
        public Vector3D get_point(int ind)
        {
            if (owner != null)
                return owner.vertices[vertices[ind]];
            return new Vector3D();
        }

    }
}
