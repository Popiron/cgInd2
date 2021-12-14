using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;

namespace Indiv2.models
{
    public class Material
    {
        public float reflection;    // коэффициент отражения
        public float refraction;    // коэффициент преломления
        public float environment;   // коэффициент преломления среды
        public float ambient;       // коэффициент принятия фонового освещения
        public float diffuse;       // коэффициент принятия диффузного освещения
        public Vector3D color;         // цвет материала

        public Material(float reflection, float refraction, float ambient, float diffuse, float environment = 1)
        {
            this.reflection = reflection;
            this.refraction = refraction;
            this.ambient = ambient;
            this.diffuse = diffuse;
            this.environment = environment;
        }

        public Material(Material m)
        {
            reflection = m.reflection;
            refraction = m.refraction;
            environment = m.environment;
            ambient = m.ambient;
            diffuse = m.diffuse;
            color = new Vector3D(m.color.X,m.color.Y,m.color.Z);
        }

        public Material() { }
    }
}
