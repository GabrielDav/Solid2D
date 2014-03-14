// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Matrix2D.cs" company="GPL">
// Gabriel Davidian
// </copyright>
// <summary>
// Defines the immutable Matrix2D type.
// Matrix2D is used for objects transformation in 2D space.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Core
{
    public struct Matrix2D
    {
        private static readonly Matrix2D _identity = new Matrix2D(1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f);

        public readonly float M11;

        public readonly float M12;

        public readonly float M13;

        public readonly float M21;

        public readonly float M22;

        public readonly float M23;

        public readonly float M31;

        public readonly float M32;

        public readonly float M33;

        /// <summary>
        /// Returns an instance of the identity matrix2D.
        /// </summary>
        public static Matrix2D Identity
        {
            get
            {
                return _identity;
            }
        }

        /// <summary>
        /// Gets the up vector of the Matrix2D.
        /// </summary>
        public Vector2 Up
        {
            get
            {
                Vector2 v;
                v.X = -M21;
                v.Y = -M22;
                return v;
            }
        }

        /// <summary>
        /// Gets the down vector of the Matrix2D.
        /// </summary>
        public Vector2 Down
        {
            get
            {
                Vector2 v;
                v.X = M21;
                v.Y = M22;
                return v;
            }
        }

        /// <summary>
        /// Gets the left vector of the Matrix2D.
        /// </summary>
        public Vector2 Left
        {
            get
            {
                Vector2 v;
                v.X = -M11;
                v.Y = -M12;
                return v;
            }
        }

        /// <summary>
        /// Gets the right vector of the Matrix2D.
        /// </summary>
        public Vector2 Right
        {
            get
            {
                Vector2 v;
                v.X = M11;
                v.Y = M12;
                return v;
            }
        }

        /// <summary>
        /// Gets the translation vector of the Matrix2D.
        /// </summary>
        public Vector2 Translation
        {
            get
            {
                Vector2 v;
                v.X = M31;
                v.Y = M32;
                return v;
            }
        }

        static Matrix2D()
        {
        }

        /// <summary>
        /// Initializes a new instance of Matrix2D.
        /// </summary>
        public Matrix2D(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M31 = m31;
            M32 = m32;
            M33 = m33;
        }

        /// <summary>
        /// Retrieves a string representation of the current object.
        /// </summary>
        /// <returns>Matrix value as string</returns>
        public override string ToString()
        {
            return "{ " + string.Format("{{M11:{0} M12:{1} M13{2}}} {{M21:{3} M22:{4} M23:{5}}} {{M31:{6} M32:{7} M33:{8}}}", M11, M12, M13, M21, M22, M23, M31, M32, M33) + " }";
        }

        /// <summary>
        /// Returns a value that indicates whether the current instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">Object with which to make the comparison.</param>
        /// <returns>True if object is equal to current matrix, otherwise false</returns>
        public override bool Equals(object obj)
        {
            var flag = false;
            if (obj is Matrix2D)
                flag = this == (Matrix2D)obj;
            return flag;
        }

        /// <summary>
        /// Gets the hash code of this object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // ReSharper disable NonReadonlyFieldInGetHashCode
            return M11.GetHashCode() + M12.GetHashCode() + M13.GetHashCode() + M21.GetHashCode() +
                M22.GetHashCode() + M23.GetHashCode() + M31.GetHashCode() + M32.GetHashCode() + M33.GetHashCode();
            // ReSharper restore NonReadonlyFieldInGetHashCode
        }

        /// <summary>
        /// Negates individual elements of a matrix.
        /// </summary>
        /// <param name="source">Source matrix.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D operator -(Matrix2D source)
        {
            return new Matrix2D(-source.M11, -source.M12, - source.M13, -source.M21, -source.M22, -source.M23, -source.M31, -source.M32, -source.M33);
        }

        /// <summary>
        /// Compares a matrix for equality with another matrix.
        /// </summary>
        /// <param name="matrix1">Left-hand value.</param>
        /// <param name="matrix2">Right-hand value.</param>
        /// <returns>Result matrix</returns>
        public static bool operator ==(Matrix2D matrix1, Matrix2D matrix2)
        {
            // ReSharper disable CompareOfFloatsByEqualityOperator
            if (matrix1.M11 == matrix2.M11 && matrix1.M12 == matrix2.M12 && matrix1.M13 == matrix2.M13 &&
                matrix1.M21 == matrix2.M21 && matrix1.M22 == matrix2.M22 && matrix1.M23 == matrix2.M23 &&
                matrix1.M31 == matrix2.M31 && matrix1.M32 == matrix2.M32) 
                return matrix1.M33 == matrix2.M33;
            return false;
            // ReSharper restore CompareOfFloatsByEqualityOperator
        }

        /// <summary>
        /// Tests a matrix for inequality with another matrix.
        /// </summary>
        /// <param name="matrix1">Left-hand value.</param>
        /// <param name="matrix2">Right-hand value.</param>
        /// <returns>Result matrix</returns>
        public static bool operator !=(Matrix2D matrix1, Matrix2D matrix2)
        {
            // ReSharper disable CompareOfFloatsByEqualityOperator
            if (matrix1.M11 == matrix2.M11 && matrix1.M12 == matrix2.M12 && matrix1.M13 == matrix2.M13 && matrix1.M21 == matrix2.M21 &&
                matrix1.M22 == matrix2.M22 && matrix1.M23 == matrix2.M23
                && matrix1.M31 == matrix2.M31 && matrix1.M32 == matrix2.M32)
                return matrix1.M33 != matrix2.M33;
            return true;
            // ReSharper restore CompareOfFloatsByEqualityOperator
        }

        /// <summary>
        /// Adds a matrix to another matrix.
        /// </summary>
        /// <param name="matrix1">Left-hand value.</param>
        /// <param name="matrix2">Right-hand value.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D operator +(Matrix2D matrix1, Matrix2D matrix2)
        {
            return new Matrix2D(matrix1.M11 + matrix2.M11, matrix1.M12 + matrix2.M12, matrix1.M13 + matrix2.M13,
                matrix1.M21 + matrix2.M21, matrix1.M22 + matrix2.M22, matrix1.M23 + matrix2.M23,
                matrix1.M31 + matrix2.M31, matrix1.M32 + matrix2.M32, matrix1.M33 + matrix2.M33);
        }

        /// <summary>
        /// Subtracts matrices.
        /// </summary>
        /// <param name="matrix1">Left-hand value</param>
        /// <param name="matrix2">Right-hand value.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D operator -(Matrix2D matrix1, Matrix2D matrix2)
        {
            return new Matrix2D(matrix1.M11 - matrix2.M11, matrix1.M12 - matrix2.M12, matrix1.M13 - matrix2.M13,
                matrix1.M21 - matrix2.M21, matrix1.M22 - matrix2.M22, matrix1.M23 - matrix2.M23,
                matrix1.M31 - matrix2.M31, matrix1.M32 - matrix2.M32, matrix1.M33 - matrix2.M33);
        }

        /// <summary>
        /// Multiplies a matrix by another matrix.
        /// </summary>
        /// <param name="matrix1">Left-hand value</param>
        /// <param name="matrix2">Right-hand value.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D operator *(Matrix2D matrix1, Matrix2D matrix2)
        {
            return new Matrix2D(
                (float)(matrix1.M11 * (double)matrix2.M11 + matrix1.M12 * (double)matrix2.M21 + matrix1.M13 * (double)matrix2.M31),
                (float)(matrix1.M11 * (double)matrix2.M12 + matrix1.M12 * (double)matrix2.M22 + matrix1.M13 * (double)matrix2.M32),
                (float)(matrix1.M11 * (double)matrix2.M13 + matrix1.M12 * (double)matrix2.M23 + matrix1.M13 * (double)matrix2.M33),
                (float)(matrix1.M21 * (double)matrix2.M11 + matrix1.M22 * (double)matrix2.M21 + matrix1.M23 * (double)matrix2.M31),
                (float)(matrix1.M21 * (double)matrix2.M12 + matrix1.M22 * (double)matrix2.M22 + matrix1.M23 * (double)matrix2.M32),
                (float)(matrix1.M21 * (double)matrix2.M13 + matrix1.M22 * (double)matrix2.M23 + matrix1.M23 * (double)matrix2.M33),
                (float)(matrix1.M31 * (double)matrix2.M11 + matrix1.M32 * (double)matrix2.M21 + matrix1.M33 * (double)matrix2.M31),
                (float)(matrix1.M31 * (double)matrix2.M12 + matrix1.M32 * (double)matrix2.M22 + matrix1.M33 * (double)matrix2.M32),
                (float)(matrix1.M31 * (double)matrix2.M13 + matrix1.M32 * (double)matrix2.M23 + matrix1.M33 * (double)matrix2.M33));
        }

        /// <summary>
        /// Multiplies a matrix by a scalar value.
        /// </summary>
        /// <param name="matrix">Source matrix.</param>
        /// <param name="scaleFactor">Scalar value.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D operator *(Matrix2D matrix, float scaleFactor)
        {
            return new Matrix2D(matrix.M11 * scaleFactor, matrix.M12 * scaleFactor, matrix.M13 * scaleFactor,
                matrix.M21 * scaleFactor, matrix.M22 * scaleFactor, matrix.M23 * scaleFactor,
                matrix.M31 * scaleFactor, matrix.M32 * scaleFactor, matrix.M33 * scaleFactor);
        }

        /// <summary>
        /// Multiplies a matrix by a scalar value.
        /// </summary>
        /// <param name="scaleFactor">Scalar value.</param><param name="matrix">Source matrix.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D operator *(float scaleFactor, Matrix2D matrix)
        {
            return matrix * scaleFactor;
        }

        /// <summary>
        /// Divides the components of a matrix by the corresponding components of another matrix.
        /// </summary>
        /// <param name="matrix1">Source matrix.</param>
        /// <param name="matrix2">The division matrix.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D operator /(Matrix2D matrix1, Matrix2D matrix2)
        {
            return new Matrix2D(matrix1.M11 / matrix2.M11, matrix1.M12 / matrix2.M12, matrix1.M13 / matrix2.M13,
                matrix1.M21 / matrix2.M21, matrix1.M22 / matrix2.M22, matrix1.M23 / matrix2.M23,
                matrix1.M31 / matrix2.M31, matrix1.M32 / matrix2.M32, matrix1.M33 / matrix2.M33);
        }

        /// <summary>
        /// Divides the components of a matrix by a scalar.
        /// </summary>
        /// <param name="matrix">Source matrix.</param>
        /// <param name="divider">The divisor.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D operator /(Matrix2D matrix, float divider)
        {
            float num = 1f / divider;
            return new Matrix2D(matrix.M11 * num, matrix.M12 * num, matrix.M13 * num,
                matrix.M21 * num, matrix.M22 * num, matrix.M23 * num,
                matrix.M31 * num, matrix.M32 * num, matrix.M33 * num);
        }

        /// <summary>
        /// Creates a translation Matrix.
        /// </summary>
        /// <param name="position">Amounts to translate by on the x, and y axes.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D CreateTranslation(Vector2 position)
        {
            return new Matrix2D(1f, 0f, 0f, 0f, 1f, 0f, position.X, position.Y, 1f);
        }


        /// <summary>
        /// Creates a translation Matrix.
        /// </summary>
        /// <param name="x">Value to translate by on the x-axis.</param>
        /// <param name="y">Value to translate by on the y-axis.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D CreateTranslation(float x, float y)
        {
            return CreateTranslation(new Vector2(x, y));
        }

        /// <summary>
        /// Creates a scaling Matrix.
        /// </summary>
        /// <param name="scale">Scale vector.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D CreateScale(Vector2 scale)
        {
            return new Matrix2D(scale.X, 0f, 0f, 0f, scale.Y, 0f, 0f, 0f, 1f);
        }

        /// <summary>
        /// Creates a scaling Matrix.
        /// </summary>
        /// <param name="scaleX">Value to scale by on the x-axis.</param>
        /// <param name="scaleY">Value to scale by on the y-axis.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D CreateScale(float scaleX, float scaleY)
        {
            return CreateScale(new Vector2(scaleX, scaleY));
        }

        /// <summary>
        /// Creates a scaling Matrix.
        /// </summary>
        /// <param name="scale">Amount to scale by.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D CreateScale(float scale)
        {
            return CreateScale(new Vector2(scale, scale));
        }

        /// <summary>
        /// Returns a matrix that can be used to rotate a set of vertices around the z-axis.
        /// </summary>
        /// <param name="radians">The amount, in radians, in which to rotate. Note that you can use ToRadians to convert degrees to radians.</param>
        /// <returns>Result matrix</returns>
        public static Matrix2D CreateRotation(float radians)
        {
            var num1 = (float)Math.Cos(radians);
            var num2 = (float)Math.Sin(radians);
            return new Matrix2D(num1, num2, 0f, -num2, num1, 0f, 0f, 0f, 1f);
        }
    }
}
