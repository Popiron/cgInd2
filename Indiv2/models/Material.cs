﻿using System;
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
        public Vector3D clr;         // цвет материала

        public Material(float refl, float refr, float amb, float dif, float env = 1)
        {
            reflection = refl;
            refraction = refr;
            ambient = amb;
            diffuse = dif;
            environment = env;
        }

        public Material(Material m)
        {
            reflection = m.reflection;
            refraction = m.refraction;
            environment = m.environment;
            ambient = m.ambient;
            diffuse = m.diffuse;
            clr = new Vector3D(m.clr.X,m.clr.Y,m.clr.Z);
        }

        public Material() { }
    }
}
