using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models.figures
{
    class ReadyFigures
    {
        static public Figure Hexahedron(float sz)
        {
            Figure res = new Figure();
            res.vertices.Add(new Vector3D(sz / 2, sz / 2, sz / 2)); // 0 
            res.vertices.Add(new Vector3D(-sz / 2, sz / 2, sz / 2)); // 1
            res.vertices.Add(new Vector3D(-sz / 2, sz / 2, -sz / 2)); // 2
            res.vertices.Add(new Vector3D(sz / 2, sz / 2, -sz / 2)); //3
            res.vertices.Add(new Vector3D(sz / 2, -sz / 2, sz / 2)); // 4
            res.vertices.Add(new Vector3D(-sz / 2, -sz / 2, sz / 2)); //5
            res.vertices.Add(new Vector3D(-sz / 2, -sz / 2, -sz / 2)); // 6
            res.vertices.Add(new Vector3D(sz / 2, -sz / 2, -sz / 2)); // 7
            Face s = new Face(res);
            s.vertices.AddRange(new int[] { 3, 2, 1, 0 });
            res.faces.Add(s);
            s = new Face(res);
            s.vertices.AddRange(new int[] { 4, 5, 6, 7 });
            res.faces.Add(s);
            s = new Face(res);
            s.vertices.AddRange(new int[] { 2, 6, 5, 1 });
            res.faces.Add(s);
            s = new Face(res);
            s.vertices.AddRange(new int[] { 0, 4, 7, 3 });
            res.faces.Add(s);
            s = new Face(res);
            s.vertices.AddRange(new int[] { 1, 5, 4, 0 });
            res.faces.Add(s);
            s = new Face(res);
            s.vertices.AddRange(new int[] { 2, 3, 7, 6 });
            res.faces.Add(s);
            return res;
        }
    }
}
