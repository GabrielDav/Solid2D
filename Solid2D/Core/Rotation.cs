// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rotation.cs" company="GPL">
//   Gabriel Davidian
// </copyright>
// <summary>
//   Defines the immutable Rotation type.
//   Rotation type helps to more easily control rotatio value, because it has fixed range and additional properties
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using FarseerPhysics.Common;

using Microsoft.Xna.Framework;

namespace Core
{
    /// <summary>
    /// Structure for rotation type
    /// </summary>
    public struct Rotation
    {
        /// <summary>
        /// Default value for zero rotation
        /// </summary>
        public static Rotation Zero = new Rotation(0);

        /// <summary>
        /// Default value for 90 degrees rotation
        /// </summary>
        public static Rotation PiOverTwo = new Rotation(90);

        /// <summary>
        /// default value for 180 degrees rotation
        /// </summary>
        public static Rotation Pi = new Rotation(180);

        private readonly float _degrees;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rotation"/> struct
        /// </summary>
        /// <param name="degrees">Rotation value in degrees</param>
        public Rotation(float degrees)
        {
            _degrees = degrees % 360;
            if (_degrees < 0)
                _degrees = 360 + degrees;
        }

        /// <summary>
        /// Gets rotation value in radians [0 - 2Pi]
        /// </summary>
        public float Radians
        {
            get
            {
                return MathHelper.ToRadians(_degrees);
            }
        }

        /// <summary>
        /// Gets inverted value in radians [0 - 2Pi]
        /// </summary>
        public float InvertedRadians
        {
            get
            {
                return MathHelper.ToRadians(InvertedValue);
            }
        }

        /// <summary>
        /// Gets rotation value in degrees [0 - 360]
        /// </summary>
        public float Value
        {
            get
            {
                return _degrees;
            }
        }

        /// <summary>
        /// Gets inverted value in degrees [0 - 360]
        /// </summary>
        public float InvertedValue
        {
            get
            {
                if (_degrees >= 180)
                    return _degrees - 180;
                return 360 - (180 - _degrees);
            }
        }

        /// <summary>
        /// Adds degrees to rotation
        /// </summary>
        /// <param name="degrees">Value in degrees</param>
        /// <returns>Result rotation</returns>
        public Rotation Add(float degrees)
        {
            return new Rotation(_degrees + degrees);
        }

        /// <summary>
        /// Adds new rotation to current rotation
        /// </summary>
        /// <param name="rotation">Rotation to add</param>
        /// <returns>Result rotation</returns>
        public Rotation Add(Rotation rotation)
        {
            return new Rotation(_degrees + rotation.Value);
        }

        /// <summary>
        /// Adds radians to rotation
        /// </summary>
        /// <param name="radians">Value in radians</param>
        /// <returns>Result rotation</returns>
        public Rotation AddRadians(float radians)
        {
            return Add(MathHelper.ToDegrees(radians));
        }

        /// <summary>
        /// Provides friendly string value
        /// </summary>
        /// <returns>Degrees value as string</returns>
        public override string ToString()
        {
            return _degrees.ToString();
        }

        /// <summary>
        /// Checks if current rotation is equal to other rotation
        /// </summary>
        /// <param name="other">Other rotation</param>
        /// <returns>True if equals, otherwise false</returns>
        public bool Equals(Rotation other)
        {
            return this == other;
        }

        /// <summary>
        /// Checks if current rotation is equal to object
        /// </summary>
        /// <param name="obj">target object</param>
        /// <returns>True if equals, otherwise false</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is Rotation && Equals((Rotation)obj);
        }

        /// <summary>
        /// Gets hash code of the rotation
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return _degrees.GetHashCode();
        }

        /// <summary>
        /// Creates the rotation from degrees
        /// </summary>
        /// <param name="degrees">Value in degrees</param>
        /// <returns>New rotation</returns>
        public static Rotation Create(float degrees)
        {
            return new Rotation(degrees);
        }

        /// <summary>
        /// Creates the rotation from radians
        /// </summary>
        /// <param name="radians">Value in radians</param>
        /// <returns>New rotation</returns>
        public static Rotation FromRadians(float radians)
        {
            return new Rotation(MathHelper.ToDegrees(radians));
        }

        /// <summary>
        /// Creates the rotation from vector
        /// </summary>
        /// <param name="vector">Vector value</param>
        /// <returns>New rotation</returns>
        public static Rotation FromVector(Vector2 vector)
        {
            return new Rotation(MathHelper.ToDegrees((float)Math.Atan2(vector.Y, vector.X)));
        }

        /// <summary>
        /// Rotation operator +
        /// </summary>
        /// <param name="rotation1">Left-hand rotation value</param>
        /// <param name="rotation2">Right-hand rotation value</param>
        /// <returns>Result rotation</returns>
        public static Rotation operator +(Rotation rotation1, Rotation rotation2)
        {
            return rotation1.Add(rotation2);
        }

        /// <summary>
        /// Rotation operator +
        /// </summary>
        /// <param name="rotation">Left-hand rotation value</param>
        /// <param name="degrees">Right-hand float rotation value in degrees</param>
        /// <returns>Result rotation</returns>
        public static Rotation operator +(Rotation rotation, float degrees)
        {
            return rotation.Add(degrees);
        }

        /// <summary>
        /// Rotation operator -
        /// </summary>
        /// <param name="rotation1">Left-hand rotation value</param>
        /// <param name="rotation2">Right-hand rotation value</param>
        /// <returns>Result rotation</returns>
        public static Rotation operator -(Rotation rotation1, Rotation rotation2)
        {
            return rotation1.Add(-rotation2.Value);
        }

        /// <summary>
        /// Rotation operator -
        /// </summary>
        /// <param name="rotation">Left-hand rotation value</param>
        /// <param name="degrees">Right-hand float rotation value in degrees</param>
        /// <returns>Result rotation</returns>
        public static Rotation operator -(Rotation rotation, float degrees)
        {
            return rotation.Add(-degrees);
        }

        /// <summary>
        /// Rotation operator *
        /// </summary>
        /// <param name="rotation1">Left-hand rotation value</param>
        /// <param name="multiplier">Right-hand multiplier value</param>
        /// <returns>Result rotation</returns>
        public static Rotation operator *(Rotation rotation1, float multiplier)
        {
            return new Rotation(rotation1.Value * multiplier);
        }

        /// <summary>
        /// Rotation operator /
        /// </summary>
        /// <param name="rotation1">Left-hand rotation value</param>
        /// <param name="divider">Right-hand divider value</param>
        /// <returns>Result rotation</returns>
        public static Rotation operator /(Rotation rotation1, float divider)
        {
            return new Rotation(rotation1.Value / divider);
        }

        /// <summary>
        /// Explicit rotation from float in degrees
        /// </summary>
        /// <param name="degrees">Degrees value</param>
        /// <returns>Result rotation</returns>
        public static explicit operator Rotation(float degrees)
        {
            return new Rotation(degrees);
        }

        /// <summary>
        /// Implicit float in degrees from rotation
        /// </summary>
        /// <param name="rotation">Rotation value</param>
        /// <returns>Result degrees</returns>
        public static implicit operator float(Rotation rotation)
        {
            return rotation.Value;
        }

        /// <summary>
        /// Rotation operator ==
        /// </summary>
        /// <param name="rotation1">Left-hand rotation value</param>
        /// <param name="rotation2">Right-hand multiplier value</param>
        /// <returns>True if values is equal, otherwise false</returns>
        public static bool operator ==(Rotation rotation1, Rotation rotation2)
        {
            return Math.Abs(rotation1.Value - rotation2.Value) <= float.Epsilon;
        }

        /// <summary>
        /// Rotation operator !=
        /// </summary>
        /// <param name="rotation1">Left-hand rotation value</param>
        /// <param name="rotation2">Right-hand multiplier value</param>
        /// <returns>True if values is not equal, otherwise false</returns>
        public static bool operator !=(Rotation rotation1, Rotation rotation2)
        {
            return Math.Abs(rotation1.Value - rotation2.Value) > float.Epsilon;
        }
    }
}
