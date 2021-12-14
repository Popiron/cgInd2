using Indiv2.logi;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media.Media3D;

namespace Indiv2.models.figures
{
    public class Figure
    {
        public List<Face> faces = new List<Face>();
        public Material material;
        public List<Vector3D> vertices = new List<Vector3D>();
        
        
        public Vector3D Center {
            get
            {
                Vector3D res = new Vector3D(0, 0, 0);
                foreach (Vector3D point in vertices)
                {
                    res.X += point.X;
                    res.Y += point.Y;
                    res.Z += point.Z;

                }
                res.X /= vertices.Count();
                res.Y /= vertices.Count();
                res.Z /= vertices.Count();
                return res;
            }
        }

        public List<Matrix3D> Matrices
        {
            get
            {
                List<Matrix3D> matrices = new List<Matrix3D>();
                for (int i = 0; i < vertices.Count; i++)
                {
                    var point = new Matrix3D(
                        (float)vertices[i].X, (float)vertices[i].Y, (float)vertices[i].Z, 1,
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
                foreach (Face s in faces)
                    s.pen = value;
            }
        }

        public Figure() { }

        public Figure(Figure f)
        {
            foreach (var point in f.vertices)
                vertices.Add(new Vector3D(point.X,point.Y,point.Z));

            foreach (Face s in f.faces)
            {
                faces.Add(new Face(s));
                faces.Last().owner = this;
            }
        }

        // пересечение луча с фигурой
        public virtual bool intersection(Ray ray, out float interValue, out Vector3D normal)
        {
            interValue = 0;
            normal = new Vector3D();
            Face face = null;
            int wallId = -1;

            for (int i = 0; i <  faces.Count; ++i)
            {

                if ( faces[i].vertices.Count == 3)
                {
                    if (RayTracing.ray_intersects_triangle(ray,  faces[i].pointByIndex(0),  faces[i].pointByIndex(1),  faces[i].pointByIndex(2), out float t) && (interValue == 0 || t < interValue))
                    {
                        interValue = t;
                        face =  faces[i];
                    }
                }
                else if ( faces[i].vertices.Count == 4)
                {
                    if (RayTracing.ray_intersects_triangle(ray,  faces[i].pointByIndex(0),  faces[i].pointByIndex(1),  faces[i].pointByIndex(3), out float t) && (interValue == 0 || t < interValue))
                    {
                        wallId = i;
                        interValue = t;
                        face =  faces[i];
                    }
                    else if (RayTracing.ray_intersects_triangle(ray,  faces[i].pointByIndex(1),  faces[i].pointByIndex(2),  faces[i].pointByIndex(3), out t) && (interValue == 0 || t < interValue))
                    {
                        wallId = i;
                        interValue = t;
                        face =  faces[i];
                    }
                }
            }

            if (interValue != 0)
            {
                normal = face.Normal;
                material.color = new Vector3D(face.pen.Color.R / 255f, face.pen.Color.G / 255f, face.pen.Color.B / 255f);
                return true;
            }

            return false;
        }

    }
}
