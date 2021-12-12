using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Media3D;
using Indiv2.models;
using Indiv2.models.figures;

namespace Indiv2.logi
{
    public class AphineTransforms
    {
        private static void apply_matrix(Figure figure, List<Matrix3D> matrices)
        {
            for (int i = 0; i < figure.points.Count; i++)
            {
                figure.points[i] = new Vector3D((double)matrices[i].M11 / (double)matrices[i].M14, (double)matrices[i].M12 / (double)matrices[i].M14, (double)matrices[i].M13 / (double)matrices[i].M14);
            }
        }
        public static void rotate_around_rad(Figure figure, float rangle, string type)
        {
            List<Matrix3D> mt = figure.Matrices;
            Vector3D center = figure.Center;
            switch (type)
            {
                case "CX":
                    mt = apply_offset(mt, (float)-center.X, (float)-center.Y, (float)-center.Z);
                    mt = apply_rotation_X(mt, rangle);
                    mt = apply_offset(mt, (float)center.X, (float)center.Y, (float)center.Z);
                    break;
                case "CY":
                    mt = apply_offset(mt, (float)-center.X, (float)-center.Y, (float)-center.Z);
                    mt = apply_rotation_Y(mt, rangle);
                    mt = apply_offset(mt, (float)center.X, (float)center.Y, (float)center.Z);
                    break;
                case "CZ":
                    mt = apply_offset(mt, (float)-center.X, (float)-center.Y, (float)-center.Z);
                    mt = apply_rotation_Z(mt, rangle);
                    mt = apply_offset(mt, (float)center.X, (float)center.Y, (float)center.Z);
                    break;
                case "X":
                    mt = apply_rotation_X(mt, rangle);
                    break;
                case "Y":
                    mt = apply_rotation_Y(mt, rangle);
                    break;
                case "Z":
                    mt = apply_rotation_Z(mt, rangle);
                    break;
                default:
                    break;
            }
            apply_matrix(figure, mt);
        }

        public static void rotate_around(Figure figure,float angle, string type)
        {
            rotate_around_rad(figure, angle * (float)Math.PI / 180, type);
        }

        public static void scale_axis(Figure figure, float xs, float ys, float zs)
        {
            List<Matrix3D> pnts = figure.Matrices;
            pnts = apply_scale(pnts, xs, ys, zs);
            apply_matrix(figure, pnts);
        }

        public static void offset(Figure figure, float xs, float ys, float zs)
        {
            apply_matrix(figure, apply_offset(figure.Matrices, xs, ys, zs));
        }

        public static void scale_around_center(Figure figure, float xs, float ys, float zs)
        {
            List<Matrix3D> pnts = figure.Matrices;
            Vector3D p = figure.Center;
            pnts = apply_offset(pnts, (float)-p.X, (float)-p.Y, (float)-p.Z);
            pnts = apply_scale(pnts, xs, ys, zs);
            pnts = apply_offset(pnts, (float)p.X, (float)p.Y, (float)p.Z);
            apply_matrix(figure, pnts);
        }

        public static void line_rotate_rad(Figure figure, float rang, Vector3D p1, Vector3D p2)
        {

            p2 = p2 - p1;
            p2.Normalize();

            List<Matrix3D> mt = figure.Matrices;
            apply_matrix(figure, rotate_around_line(mt, p1, p2, rang));
        }

        /// <summary>
        /// rotate figure line
        /// </summary>
        /// <param name="ang">angle in degrees</param>
        /// <param name="p1">line start</param>
        /// <param name="p2">line end</param>
        public static void line_rotate(Figure figure, float ang, Vector3D p1, Vector3D p2)
        {
            ang = ang * (float)Math.PI / 180;
            line_rotate_rad(figure, ang, p1, p2);
        }

        private static List<Matrix3D> rotate_around_line(List<Matrix3D> transform_matrix, Vector3D start, Vector3D dir, float angle)
        {
            float cos_angle = (float)Math.Cos(angle);
            float sin_angle = (float)Math.Sin(angle);
            float val00 = (float)(dir.X * dir.X + cos_angle * (1 - dir.X * dir.X));
            float val01 = (float)(dir.X * (1 - cos_angle) * dir.Y + dir.Z * sin_angle);
            float val02 = (float)(dir.X * (1 - cos_angle) * dir.Z - dir.Y * sin_angle);
            float val10 = (float)(dir.X * (1 - cos_angle) * dir.Y - dir.Z * sin_angle);
            float val11 = (float)(dir.Y * dir.Y + cos_angle * (1 - dir.Y * dir.Y));
            float val12 = (float)(dir.Y * (1 - cos_angle) * dir.Z + dir.X * sin_angle);
            float val20 = (float)(dir.X * (1 - cos_angle) * dir.Z + dir.Y * sin_angle);
            float val21 = (float)(dir.Y * (1 - cos_angle) * dir.Z - dir.X * sin_angle);
            float val22 = (float)(dir.Z * dir.Z + cos_angle * (1 - dir.Z * dir.Z));
            Matrix3D rotateMatrix = new Matrix3D(
                val00, val01, val02, 0,
                val10, val11, val12, 0,
                val20, val21, val22, 0,
                0, 0, 0, 1
            );
            return apply_offset(multiply_matrix(apply_offset(transform_matrix, (float)-start.X, (float)-start.Y, (float)-start.Z), rotateMatrix), (float)start.X, (float)start.Y, (float)start.Z);
        }

        private static List<Matrix3D> multiply_matrix(List<Matrix3D> m1, Matrix3D m2)
        {
            List<Matrix3D> m = new List<Matrix3D>();
            for (int i = 0; i < m1.Count; i++)
            {
                    m.Add(Matrix3D.Multiply(m1[i], m2));
            }
            return m;
        }

        private static List<Matrix3D> apply_offset(List<Matrix3D> transform_matrix, float offset_x, float offset_y, float offset_z)
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

        private static List<Matrix3D> apply_rotation_X(List<Matrix3D> transform_matrix, float angle)
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

        private static List<Matrix3D> apply_rotation_Y(List<Matrix3D> transform_matrix, float angle)
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

        private static List<Matrix3D> apply_rotation_Z(List<Matrix3D> transform_matrix, float angle)
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

        private static List<Matrix3D> apply_scale(List<Matrix3D> transform_matrix, float scale_x, float scale_y, float scale_z)
        {
            Matrix3D translationMatrix = new Matrix3D(
                scale_x, 0, 0, 0,
                0, scale_y, 0, 0,
                0, 0, scale_z, 0,
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
    }
}
