using Indiv2.logi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models.figures
{
    class Room : Figure
    {
        public Material front;
        public Material back;
        public Material left;
        public Material right;
        public Material ceiling;
        public Material floor;

        public Room():base()
        {}

        public Room(Figure figure):base(figure)
        {}
        
        public override bool intersection(Ray ray, out float interValue, out Vector3D normal)
        {
            interValue = 0;
            normal = new Vector3D();
            Face face = null;
            int wallId = -1;

            for (int i = 0; i < faces.Count; ++i)
            {

                if (faces[i].vertices.Count == 3)
                {
                    if (RayTracing.ray_intersects_triangle(ray, faces[i].get_point(0), faces[i].get_point(1), faces[i].get_point(2), out float t) && (interValue == 0 || t < interValue))
                    {
                        interValue = t;
                        face = faces[i];
                    }
                }
                else if (faces[i].vertices.Count == 4)
                {
                    if (RayTracing.ray_intersects_triangle(ray, faces[i].get_point(0), faces[i].get_point(1), faces[i].get_point(3), out float t) && (interValue == 0 || t < interValue))
                    {
                        wallId = i;
                        interValue = t;
                        face = faces[i];
                    }
                    else if (RayTracing.ray_intersects_triangle(ray, faces[i].get_point(1), faces[i].get_point(2), faces[i].get_point(3), out t) && (interValue == 0 || t < interValue))
                    {
                        wallId = i;
                        interValue = t;
                        face = faces[i];
                    }
                }
            }

            if (interValue != 0)
            {
                normal = face.Normal;
                    switch (wallId)
                    {
                        case 0:
                            material = new Material(back);
                            break;
                        case 1:
                            material = new Material(front);
                            break;
                        case 2:
                            material = new Material(right);
                            break;
                        case 3:
                            material = new Material(left);
                            break;
                        case 4:
                            material = new Material(ceiling);
                            break;
                        case 5:
                            material = new Material(floor);
                            break;
                        default:
                            break;
                    }
                material.color = new Vector3D(face.pen.Color.R / 255f, face.pen.Color.G / 255f, face.pen.Color.B / 255f);
                return true;
            }

            return false;
        }
    }
}
