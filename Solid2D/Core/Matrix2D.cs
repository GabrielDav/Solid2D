using System;

using Microsoft.Xna.Framework;

namespace Core
{
    public struct Matrix2D
    {
        private static readonly Matrix2D _identity = new Matrix2D(1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f);

        public float M11;
        public float M12;
        public float M13;
        public float M21;
        public float M22;
        public float M23;
        public float M31;
        public float M32;
        public float M33;

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
        /// Gets and sets the up vector of the Matrix2D.
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
            set
            {
                M21 = -value.X;
                M22 = -value.Y;
            }
        }

        /// <summary>
        /// Gets and sets the down vector of the Matrix2D.
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
            set
            {
                M21 = value.X;
                M22 = value.Y;
            }
        }

        /// <summary>
        /// Gets and sets the left vector of the Matrix2D.
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
            set
            {
                M11 = -value.X;
                M12 = -value.Y;
            }
        }

        /// <summary>
        /// Gets and sets the right vector of the Matrix2D.
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
            set
            {
                M11 = value.X;
                M12 = value.Y;
            }
        }

        /// <summary>
        /// Gets and sets the translation vector of the Matrix2D.
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
            set
            {
                M31 = value.X;
                M32 = value.Y;
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
        /// Negates individual elements of a matrix.
        /// </summary>
        /// <param name="matrix1">Source matrix.</param>
        public static Matrix2D operator -(Matrix2D matrix1)
        {
            Matrix2D matrix;
            matrix.M11 = -matrix1.M11;
            matrix.M12 = -matrix1.M12;
            matrix.M13 = -matrix1.M13;
            matrix.M21 = -matrix1.M21;
            matrix.M22 = -matrix1.M22;
            matrix.M23 = -matrix1.M23;
            matrix.M31 = -matrix1.M31;
            matrix.M32 = -matrix1.M32;
            matrix.M33 = -matrix1.M33;
            return matrix;
        }

        /// <summary>
        /// Compares a matrix for equality with another matrix.
        /// </summary>
        /// <param name="matrix1">Source matrix.</param><param name="matrix2">Source matrix.</param>
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
        /// <param name="matrix1">The matrix on the left of the equal sign.</param><param name="matrix2">The matrix on the right of the equal sign.</param>
        public static bool operator !=(Matrix2D matrix1, Matrix2D matrix2)
        {
            // ReSharper disable CompareOfFloatsByEqualityOperator
            if (matrix1.M11 == matrix2.M11 && matrix1.M12 == matrix2.M12 && matrix1.M13 == matrix2.M13 &&
                matrix1.M21 == matrix2.M21 && matrix1.M22 == matrix2.M22 && matrix1.M23 == matrix2.M23 &&
                matrix1.M31 == matrix2.M31 && matrix1.M32 == matrix2.M32)
                return matrix1.M33 != matrix2.M33;
            return true;
            // ReSharper restore CompareOfFloatsByEqualityOperator
        }

        /// <summary>
        /// Adds a matrix to another matrix.
        /// </summary>
        /// <param name="matrix1">Source matrix.</param><param name="matrix2">Source matrix.</param>
        public static Matrix2D operator +(Matrix2D matrix1, Matrix2D matrix2)
        {
            Matrix2D matrix;
            matrix.M11 = matrix1.M11 + matrix2.M11;
            matrix.M12 = matrix1.M12 + matrix2.M12;
            matrix.M13 = matrix1.M13 + matrix2.M13;
            matrix.M21 = matrix1.M21 + matrix2.M21;
            matrix.M22 = matrix1.M22 + matrix2.M22;
            matrix.M23 = matrix1.M23 + matrix2.M23;
            matrix.M31 = matrix1.M31 + matrix2.M31;
            matrix.M32 = matrix1.M32 + matrix2.M32;
            matrix.M33 = matrix1.M33 + matrix2.M33;
            return matrix;
        }

        /// <summary>
        /// Subtracts matrices.
        /// </summary>
        /// <param name="matrix1">Source matrix.</param><param name="matrix2">Source matrix.</param>
        public static Matrix2D operator -(Matrix2D matrix1, Matrix2D matrix2)
        {
            Matrix2D matrix;
            matrix.M11 = matrix1.M11 - matrix2.M11;
            matrix.M12 = matrix1.M12 - matrix2.M12;
            matrix.M13 = matrix1.M13 - matrix2.M13;
            matrix.M21 = matrix1.M21 - matrix2.M21;
            matrix.M22 = matrix1.M22 - matrix2.M22;
            matrix.M23 = matrix1.M23 - matrix2.M23;
            matrix.M31 = matrix1.M31 - matrix2.M31;
            matrix.M32 = matrix1.M32 - matrix2.M32; 
            matrix.M33 = matrix1.M33 - matrix2.M33;
            return matrix;
        }

        /// <summary>
        /// Multiplies a matrix by another matrix.
        /// </summary>
        /// <param name="matrix1">Source matrix.</param><param name="matrix2">Source matrix.</param>
        public static Matrix2D operator *(Matrix2D matrix1, Matrix2D matrix2)
        {
            Matrix2D matrix;
            matrix.M11 =(float)(matrix1.M11*(double) matrix2.M11 + matrix1.M12*(double) matrix2.M21 +
                     matrix1.M13*(double) matrix2.M31);
            matrix.M12 =(float)(matrix1.M11*(double) matrix2.M12 + matrix1.M12*(double) matrix2.M22 +
                     matrix1.M13*(double) matrix2.M32);
            matrix.M13 =(float)(matrix1.M11*(double) matrix2.M13 + matrix1.M12*(double) matrix2.M23 +
                     matrix1.M13*(double) matrix2.M33);
            matrix.M21 =(float)(matrix1.M21*(double) matrix2.M11 + matrix1.M22*(double) matrix2.M21 +
                     matrix1.M23*(double) matrix2.M31);
            matrix.M22 =(float)(matrix1.M21*(double) matrix2.M12 + matrix1.M22*(double) matrix2.M22 +
                     matrix1.M23*(double) matrix2.M32);
            matrix.M23 =(float)(matrix1.M21*(double) matrix2.M13 + matrix1.M22*(double) matrix2.M23 +
                     matrix1.M23*(double) matrix2.M33);
            matrix.M31 =(float)(matrix1.M31*(double) matrix2.M11 + matrix1.M32*(double) matrix2.M21 +
                     matrix1.M33*(double) matrix2.M31);
            matrix.M32 =(float)(matrix1.M31*(double) matrix2.M12 + matrix1.M32*(double) matrix2.M22 +
                     matrix1.M33*(double) matrix2.M32);
            matrix.M33 =(float)(matrix1.M31*(double) matrix2.M13 + matrix1.M32*(double) matrix2.M23 +
                     matrix1.M33*(double) matrix2.M33);
            return matrix;
        }

        /// <summary>
        /// Multiplies a matrix by a scalar value.
        /// </summary>
        /// <param name="matrix">Source matrix.</param><param name="scaleFactor">Scalar value.</param>
        public static Matrix2D operator *(Matrix2D matrix, float scaleFactor)
        {
            float num = scaleFactor;
            Matrix2D matrix1;
            matrix1.M11 = matrix.M11*num;
            matrix1.M12 = matrix.M12*num;
            matrix1.M13 = matrix.M13*num;
            matrix1.M21 = matrix.M21*num;
            matrix1.M22 = matrix.M22*num;
            matrix1.M23 = matrix.M23*num;
            matrix1.M31 = matrix.M31*num;
            matrix1.M32 = matrix.M32*num;
            matrix1.M33 = matrix.M33*num;
            return matrix1;
        }

        /// <summary>
        /// Multiplies a matrix by a scalar value.
        /// </summary>
        /// <param name="scaleFactor">Scalar value.</param><param name="matrix">Source matrix.</param>
        public static Matrix2D operator *(float scaleFactor, Matrix2D matrix)
        {
            float num = scaleFactor;
            Matrix2D matrix1;
            matrix1.M11 = matrix.M11 * num;
            matrix1.M12 = matrix.M12 * num;
            matrix1.M13 = matrix.M13 * num;
            matrix1.M21 = matrix.M21 * num;
            matrix1.M22 = matrix.M22 * num;
            matrix1.M23 = matrix.M23 * num;
            matrix1.M31 = matrix.M31 * num;
            matrix1.M32 = matrix.M32 * num;
            matrix1.M33 = matrix.M33 * num;
            return matrix1;
        }

        /// <summary>
        /// Divides the components of a matrix by the corresponding components of another matrix.
        /// </summary>
        /// <param name="matrix1">Source matrix.</param><param name="matrix2">The divisor.</param>
        public static Matrix2D operator /(Matrix2D matrix1, Matrix2D matrix2)
        {
            Matrix2D matrix;
            matrix.M11 = matrix1.M11/matrix2.M11;
            matrix.M12 = matrix1.M12/matrix2.M12;
            matrix.M13 = matrix1.M13/matrix2.M13;
            matrix.M21 = matrix1.M21/matrix2.M21;
            matrix.M22 = matrix1.M22/matrix2.M22;
            matrix.M23 = matrix1.M23/matrix2.M23;
            matrix.M31 = matrix1.M31/matrix2.M31;
            matrix.M32 = matrix1.M32/matrix2.M32;
            matrix.M33 = matrix1.M33/matrix2.M33;
            return matrix;
        }

        /// <summary>
        /// Divides the components of a matrix by a scalar.
        /// </summary>
        /// <param name="matrix1">Source matrix.</param><param name="divider">The divisor.</param>
        public static Matrix2D operator /(Matrix2D matrix1, float divider)
        {
            float num = 1f/divider;
            Matrix2D matrix;
            matrix.M11 = matrix1.M11*num;
            matrix.M12 = matrix1.M12*num;
            matrix.M13 = matrix1.M13*num;
            matrix.M21 = matrix1.M21*num;
            matrix.M22 = matrix1.M22*num;
            matrix.M23 = matrix1.M23*num;
            matrix.M31 = matrix1.M31*num;
            matrix.M32 = matrix1.M32*num;
            matrix.M33 = matrix1.M33*num;
            return matrix;
        }

        /// <summary>
        /// Creates a translation Matrix.
        /// </summary>
        /// <param name="position">Amounts to translate by on the x, and y axes.</param>
        public static Matrix2D CreateTranslation(Vector2 position)
        {
            Matrix2D matrix;
            matrix.M11 = 1f;
            matrix.M12 = 0.0f;
            matrix.M13 = 0.0f;
            matrix.M21 = 0.0f;
            matrix.M22 = 1f;
            matrix.M23 = 0.0f;
            matrix.M31 = position.X;
            matrix.M32 = position.Y;
            matrix.M33 = 1.0f;
            return matrix;
        }


        /// <summary>
        /// Creates a translation Matrix.
        /// </summary>
        /// <param name="xPosition">Value to translate by on the x-axis.</param>
        /// <param name="yPosition">Value to translate by on the y-axis.</param>
        public static Matrix2D CreateTranslation(float xPosition, float yPosition)
        {
            Matrix2D matrix;
            matrix.M11 = 1f;
            matrix.M12 = 0.0f;
            matrix.M13 = 0.0f;
            matrix.M21 = 0.0f;
            matrix.M22 = 1f;
            matrix.M23 = 0.0f;
            matrix.M31 = xPosition;
            matrix.M32 = yPosition;
            matrix.M33 = 1.0f;
            return matrix;
        }

        /// <summary>
        /// Creates a scaling Matrix.
        /// </summary>
        /// <param name="xScale">Value to scale by on the x-axis.</param>
        /// <param name="yScale">Value to scale by on the y-axis.</param>
        public static Matrix2D CreateScale(float xScale, float yScale)
        {
            float num1 = xScale;
            float num2 = yScale;
            Matrix2D matrix;
            matrix.M11 = num1;
            matrix.M12 = 0.0f;
            matrix.M13 = 0.0f;
            matrix.M21 = 0.0f;
            matrix.M22 = num2;
            matrix.M23 = 0.0f;
            matrix.M31 = 0.0f;
            matrix.M32 = 0.0f;
            matrix.M33 = 1f;
            return matrix;
        }

        /// <summary>
        /// Creates a scaling Matrix.
        /// </summary>
        /// <param name="scales">Amounts to scale by on the x and y axes.</param>
        public static Matrix2D CreateScale(Vector2 scales)
        {
            float num1 = scales.X;
            float num2 = scales.Y;
            Matrix2D matrix;
            matrix.M11 = num1;
            matrix.M12 = 0.0f;
            matrix.M13 = 0.0f;
            matrix.M21 = 0.0f;
            matrix.M22 = num2;
            matrix.M23 = 0.0f;
            matrix.M31 = 0.0f;
            matrix.M32 = 0.0f;
            matrix.M33 = 1f;
            return matrix;
        }

        /// <summary>
        /// Creates a scaling Matrix.
        /// </summary>
        /// <param name="scale">Amount to scale by.</param>
        public static Matrix2D CreateScale(float scale)
        {
            float num = scale;
            Matrix2D matrix;
            matrix.M11 = num;
            matrix.M12 = 0.0f;
            matrix.M13 = 0.0f;
            matrix.M21 = 0.0f;
            matrix.M22 = num;
            matrix.M23 = 0.0f;
            matrix.M31 = 0.0f;
            matrix.M32 = 0.0f;
            matrix.M33 = 1f;
            return matrix;
        }

        /// <summary>
        /// Returns a matrix that can be used to rotate a set of vertices around the z-axis.
        /// </summary>
        /// <param name="radians">The amount, in radians, in which to rotate. Note that you can use ToRadians to convert degrees to radians.</param>
        public static Matrix2D CreateRotation(float radians)
        {
            var num1 = (float)Math.Cos(radians);
            var num2 = (float)Math.Sin(radians);
            Matrix2D matrix;
            matrix.M11 = num1;
            matrix.M12 = num2;
            matrix.M13 = 0;
            matrix.M21 = -num2;
            matrix.M22 = num1;
            matrix.M23 = 0;
            matrix.M31 = 0.0f;
            matrix.M32 = 0.0f;
            matrix.M33 = 1;
            return matrix;
        }

        /// <summary>
        /// Creates a new Matrix from rectangle. Note that matrix will be created from rectangle center
        /// </summary>
        /// <param name="rectangle">Rectangle to use for matrix creation.</param>
        public static Matrix2D FromRectangle(Rectangle rectangle)
        {
            Matrix2D matrix = Identity;
            matrix.M11 = rectangle.Width/2f;
            matrix.M22 = rectangle.Height/2f;
            matrix.M31 = rectangle.X + matrix.M11;
            matrix.M32 = rectangle.Y + matrix.M22;
            return matrix;
        }

        /// <summary>
        /// Retrieves a string representation of the current object.
        /// </summary>
        public override string ToString()
        {
            return "{ " +
                   string.Format("{{M11:{0} M12:{1} M13{2}}} {{M21:{3} M22:{4} M23:{5}}} {{M31:{6} M32:{7} M33:{8}}}",
                       M11, M12, M13, M21, M22, M23, M31, M32, M33) + " }";
        }

        /// <summary>
        /// Returns a value that indicates whether the current instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">Object with which to make the comparison.</param>
        public override bool Equals(object obj)
        {
            var flag = false;
            if (obj is Matrix2D)
                flag = this == (Matrix2D) obj;
            return flag;
        }

        /// <summary>
        /// Gets the hash code of this object.
        /// </summary>
        public override int GetHashCode()
        {
            // ReSharper disable NonReadonlyFieldInGetHashCode
            return M11.GetHashCode() + M12.GetHashCode() + M13.GetHashCode() +
                   M21.GetHashCode() + M22.GetHashCode() + M23.GetHashCode() +
                   M31.GetHashCode() + M32.GetHashCode() + M33.GetHashCode();
            // ReSharper restore NonReadonlyFieldInGetHashCode
        }

    }
}
