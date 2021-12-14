using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Media3D;
using Indiv2.models;
using Indiv2.models.figures;

namespace Indiv2.logi
{
    public enum Axis
    {
        X,Y,Z
    }
    public class AphineTransforms
    {
        private static void matrix(Figure figure, List<Matrix3D> matrices)
        {
            for (int i = 0; i < figure.vertices.Count; i++)
            {
                figure.vertices[i] = new Vector3D((double)matrices[i].M11 / (double)matrices[i].M14, (double)matrices[i].M12 / (double)matrices[i].M14, (double)matrices[i].M13 / (double)matrices[i].M14);
            }
        }
        public static void rotateAround(Figure figure, float angle, Axis type)
        {
            float rangle = angle * (float)Math.PI / 180;
            List<Matrix3D> mt = figure.Matrices;
            Vector3D center = figure.Center;
            switch (type)
            {
                case Axis.X:
                    mt = offset(mt, (float)-center.X, (float)-center.Y, (float)-center.Z);
                    mt = rotateX(mt, rangle);
                    mt = offset(mt, (float)center.X, (float)center.Y, (float)center.Z);
                    break;
                case Axis.Y:
                    mt = offset(mt, (float)-center.X, (float)-center.Y, (float)-center.Z);
                    mt = rotateY(mt, rangle);
                    mt = offset(mt, (float)center.X, (float)center.Y, (float)center.Z);
                    break;
                case Axis.Z:
                    mt = offset(mt, (float)-center.X, (float)-center.Y, (float)-center.Z);
                    mt = rotateZ(mt, rangle);
                    mt = offset(mt, (float)center.X, (float)center.Y, (float)center.Z);
                    break;
                default:
                    break;
            }
            matrix(figure, mt);
        }

        public static void offset(Figure figure, float xs, float ys, float zs)
        {
            matrix(figure, offset(figure.Matrices, xs, ys, zs));
        }

        private static List<Matrix3D> offset(List<Matrix3D> transform_matrix, float offset_x, float offset_y, float offset_z)
        {
            Matrix3D translationMatrix = new Matrix3D(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                offset_x, offset_y, offset_z, 1
            );

            List<Matrix3D> trasformedPoints = new List<Matrix3D>();
            for (int i = 0; i < transform_matrix.Count; i++)
            {
                var matr = new Matrix3D(
                    transform_matrix[i].M11, transform_matrix[i].M12, transform_matrix[i].M13, transform_matrix[i].M14,
                    1, 1, 1, 1,
                    1, 1, 1, 1,
                    1, 1, 1, 1
                    );
                trasformedPoints.Add(matr);
            }

            for (int i = 0; i < trasformedPoints.Count; i++)
            {
                trasformedPoints[i] = Matrix3D.Multiply(trasformedPoints[i], translationMatrix);
            }


            return trasformedPoints;
        }

        private static List<Matrix3D> rotateX(List<Matrix3D> transform_matrix, float angle)
        {
            Matrix3D translationMatrix = new Matrix3D(
                1, 0, 0, 0,
                0, (float)Math.Cos(angle), (float)Math.Sin(angle), 0,
                0, -(float)Math.Sin(angle), (float)Math.Cos(angle), 0,
                0, 0, 0, 1
                );

            List<Matrix3D> trasformedPoints = new List<Matrix3D>();
            for (int i = 0; i < transform_matrix.Count; i++)
            {
                var matr = new Matrix3D(
                    transform_matrix[i].M11, transform_matrix[i].M12, transform_matrix[i].M13, transform_matrix[i].M14,
                    1, 1, 1, 1,
                    1, 1, 1, 1,
                    1, 1, 1, 1
                    );
                trasformedPoints.Add(matr);
            }

            for (int i = 0; i < trasformedPoints.Count; i++)
            {
                trasformedPoints[i] = Matrix3D.Multiply(trasformedPoints[i], translationMatrix);
            }


            return trasformedPoints;
        }

        private static List<Matrix3D> rotateY(List<Matrix3D> transform_matrix, float angle)
        {
            Matrix3D translationMatrix = new Matrix3D(
                 (float)Math.Cos(angle), 0, -(float)Math.Sin(angle), 0,
                 0, 1, 0, 0,
                 (float)Math.Sin(angle), 0, (float)Math.Cos(angle), 0,
                 0, 0, 0, 1
            );
            List<Matrix3D> trasformedPoints = new List<Matrix3D>();
            for (int i = 0; i < transform_matrix.Count; i++)
            {
                var matr = new Matrix3D(
                    transform_matrix[i].M11, transform_matrix[i].M12, transform_matrix[i].M13, transform_matrix[i].M14,
                    1, 1, 1, 1,
                    1, 1, 1, 1,
                    1, 1, 1, 1
                    );
                trasformedPoints.Add(matr);
            }

            for (int i = 0; i < trasformedPoints.Count; i++)
            {
                trasformedPoints[i] = Matrix3D.Multiply(trasformedPoints[i], translationMatrix);
            }


            return trasformedPoints;
        }

        private static List<Matrix3D> rotateZ(List<Matrix3D> transform_matrix, float angle)
        {
            Matrix3D translationMatrix = new Matrix3D(
                (float)Math.Cos(angle), (float)Math.Sin(angle), 0, 0,
                -(float)Math.Sin(angle), (float)Math.Cos(angle), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
            List<Matrix3D> trasformedPoints = new List<Matrix3D>();
            for (int i = 0; i < transform_matrix.Count; i++)
            {
                var matr = new Matrix3D(
                    transform_matrix[i].M11, transform_matrix[i].M12, transform_matrix[i].M13, transform_matrix[i].M14,
                    1, 1, 1, 1,
                    1, 1, 1, 1,
                    1, 1, 1, 1
                    );
                trasformedPoints.Add(matr);
            }

            for (int i = 0; i < trasformedPoints.Count; i++)
            {
                trasformedPoints[i] = Matrix3D.Multiply(trasformedPoints[i], translationMatrix);
            }


            return trasformedPoints;
        }
    }
}
