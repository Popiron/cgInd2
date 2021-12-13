using Indiv2.logi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models.figures
{
    class Room : Figure
    {
        public Material front_wall_material;
        public Material back_wall_material;
        public Material left_wall_material;
        public Material right_wall_material;
        public Material up_wall_material;
        public Material down_wall_material;

        public Room():base()
        {}

        public Room(Figure figure):base(figure)
        {}
        
        // пересечение луча с фигурой
        public override bool figure_intersection(Ray r, out float intersect, out Vector3D normal)
        {
            intersect = 0;
            normal = new Vector3D();
            Side sd = null;
            int fm = -1;         // номер стены комнаты, которую пересек луч

            for (int i = 0; i < sides.Count; ++i)
            {

                if (sides[i].points.Count == 3)
                {
                    if (RayTracing.ray_intersects_triangle(r, sides[i].get_point(0), sides[i].get_point(1), sides[i].get_point(2), out float t) && (intersect == 0 || t < intersect))
                    {
                        intersect = t;
                        sd = sides[i];
                    }
                }
                else if (sides[i].points.Count == 4)
                {
                    if (RayTracing.ray_intersects_triangle(r, sides[i].get_point(0), sides[i].get_point(1), sides[i].get_point(3), out float t) && (intersect == 0 || t < intersect))
                    {
                        fm = i;
                        intersect = t;
                        sd = sides[i];
                    }
                    else if (RayTracing.ray_intersects_triangle(r, sides[i].get_point(1), sides[i].get_point(2), sides[i].get_point(3), out t) && (intersect == 0 || t < intersect))
                    {
                        fm = i;
                        intersect = t;
                        sd = sides[i];
                    }
                }
            }

            if (intersect != 0)
            {
                normal = sd.Normal;
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
    }
}
