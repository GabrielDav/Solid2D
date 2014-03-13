// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Size.cs" company="GPL">
//   Gabriel Davidian
// </copyright>
// <summary>
//   Defines the immutable Size type.
//   Size type is user friendly type for storing object width and height.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Microsoft.Xna.Framework;

namespace Core
{
    /// <summary>
    /// Structure for size type
    /// </summary>
    public struct Size
    {
       private readonly float _width;

        private readonly float _height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> struct
        /// </summary>
        /// <param name="width">Width value</param>
        /// <param name="height">Height value</param>
        public Size(float width, float height)
        {
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> struct
        /// </summary>
        /// <param name="size">Width and height value</param>
        public Size(float size)
        {
            _width = size;
            _height = size;
        }

        /// <summary>
        /// Gets the width value
        /// </summary>
        public float Width
        {
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// Gets the height value
        /// </summary>
        public float Height
        {
            get
            {
                return _height;
            }
        }

        /// <summary>
        /// Creates vector from current size
        /// </summary>
        /// <returns>Result vector</returns>
        public Vector2 ToVector()
        {
            return new Vector2(Width, Height);
        }

        /// <summary>
        /// Provides friendly string value
        /// </summary>
        /// <returns>Size value as string</returns>
        public override string ToString()
        {
            return string.Format("{{ Width: {0}; Height: {1} }}", _width, _height);
        }

        /// <summary>
        /// Checks if current size is equal to other size
        /// </summary>
        /// <param name="other">Other size</param>
        /// <returns>True if equals, otherwise false</returns>
        public bool Equals(Size other)
        {
            return Math.Abs(_width - other.Width) <= float.Epsilon &&
                Math.Abs(_height - other.Height) <= float.Epsilon;
        }

        /// <summary>
        /// Checks if current size is equal to other object
        /// </summary>
        /// <param name="obj">Other object</param>
        /// <returns>True if equals, otherwise false</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is Size && Equals((Size)obj);
        }

        /// <summary>
        /// Gets hash code of the size
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return _width.GetHashCode() + _height.GetHashCode();
            }
        }

        /// <summary>
        /// Size operator -
        /// </summary>
        /// <param name="size1">Left-hand value</param>
        /// <param name="size2">Right-hand value</param>
        /// <returns>Result size</returns>
        public static Size operator -(Size size1, Size size2)
        {
            return new Size(size1.Width - size2.Width, size1.Height - size2.Height);
        }

        /// <summary>
        /// Size operator +
        /// </summary>
        /// <param name="size1">Left-hand value</param>
        /// <param name="size2">Right-hand value</param>
        /// <returns>Result size</returns>
        public static Size operator +(Size size1, Size size2)
        {
            return new Size(size1.Width + size2.Width, size1.Height + size2.Height);
        }

        /// <summary>
        /// Size operator *
        /// </summary>
        /// <param name="size1">Left-hand value</param>
        /// <param name="size2">Right-hand value</param>
        /// <returns>Result size</returns>
        public static Size operator *(Size size1, Size size2)
        {
            return new Size(size1.Width * size2.Width, size1.Height * size2.Height);
        }

        /// <summary>
        /// Size operator /
        /// </summary>
        /// <param name="size1">Left-hand value</param>
        /// <param name="size2">Right-hand value</param>
        /// <returns>Result size</returns>
        public static Size operator /(Size size1, Size size2)
        {
            return new Size(size1.Width / size2.Width, size1.Height / size2.Height);
        }

        /// <summary>
        /// Size operator *
        /// </summary>
        /// <param name="size">Left-hand value</param>
        /// <param name="factor">Right-hand value</param>
        /// <returns>Result size</returns>
        public static Size operator *(Size size, float factor)
        {
            return new Size(size.Width * factor, size.Height * factor);
        }

        /// <summary>
        /// Size operator *
        /// </summary>
        /// <param name="factor">Left-hand value</param>
        /// <param name="size">Right-hand value</param>
        /// <returns>Result size</returns>
        public static Size operator *(float factor, Size size)
        {
            return new Size(size.Width * factor, size.Height * factor);
        }

        /// <summary>
        /// Size operator /
        /// </summary>
        /// <param name="size">Left-hand value</param>
        /// <param name="factor">Right-hand value</param>
        /// <returns>Result size</returns>
        public static Size operator /(Size size, float factor)
        {
            return new Size(size.Width / factor, size.Height / factor);
        }

        /// <summary>
        /// Size operator +
        /// </summary>
        /// <param name="size">Left-hand value</param>
        /// <param name="vector">Right-hand value</param>
        /// <returns>Result size</returns>
        public static Size operator +(Size size, Vector2 vector)
        {
            return new Size(size.Width + vector.X, size.Height + vector.Y);
        }

        /// <summary>
        /// Size operator 
        /// </summary>
        /// <param name="vector">Left-hand value</param>
        /// <param name="size">Right-hand value</param>
        /// <returns>Result vector</returns>
        public static Vector2 operator +(Vector2 vector, Size size)
        {
            return new Vector2(vector.X + size.Width, vector.Y + size.Height);
        }

        /// <summary>
        /// Size operator *
        /// </summary>
        /// <param name="size">Left-hand value</param>
        /// <param name="vector">Right-hand value</param>
        /// <returns>Result size</returns>
        public static Size operator *(Size size, Vector2 vector)
        {
            return new Size(size.Width * vector.X, size.Height * vector.Y);
        }

        /// <summary>
        /// Size operator *
        /// </summary>
        /// <param name="vector">Left-hand value</param>
        /// <param name="size">Right-hand value</param>
        /// <returns>Result vector</returns>
        public static Vector2 operator *(Vector2 vector, Size size)
        {
            return new Vector2(vector.X * size.Width, vector.Y * size.Height);
        }

        /// <summary>
        /// Size operator ==
        /// </summary>
        /// <param name="size1">Left-hand rotation value</param>
        /// <param name="size2">Right-hand multiplier value</param>
        /// <returns>True if values is equal, otherwise false</returns>
        public static bool operator ==(Size size1, Size size2)
        {
            return Math.Abs(size1.Width - size2.Width) <= float.Epsilon &&
                Math.Abs(size1.Height - size2.Height) <= float.Epsilon;
        }

        /// <summary>
        /// Size operator !=
        /// </summary>
        /// <param name="size1">Left-hand rotation value</param>
        /// <param name="size2">Right-hand multiplier value</param>
        /// <returns>True if values is equal, otherwise false</returns>
        public static bool operator !=(Size size1, Size size2)
        {
            return Math.Abs(size1.Width - size2.Width) > float.Epsilon ||
                Math.Abs(size1.Height - size2.Height) > float.Epsilon;
        }
    }
}
