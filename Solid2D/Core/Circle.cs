// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Circle.cs" company="GPL">
//   Gabriel Davidian
// </copyright>
// <summary>
//   Defines the Circle type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using FarseerPhysics.Collision.Shapes;
using Microsoft.Xna.Framework;

namespace Core
{
    /// <summary>
    /// Defines the Circle type
    /// </summary>
    public struct Circle
    {
        private Vector2 _position;

        private float _r;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> struct
        /// </summary>
        /// <param name="position">Circle center position</param>
        /// <param name="r">Circle radius</param>
        public Circle(Vector2 position, float r)
        {
            _position = position;
            _r = r;
        }

        /// <summary>
        /// Gets or sets the circle position
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        /// <summary>
        /// Gets or sets the circle radius
        /// </summary>
        public float R
        {
            get
            {
                return _r;
            }
            set
            {
                _r = value;
            }
        }

        /// <summary>
        /// Checks if circle contains point
        /// </summary>
        /// <param name="point">Point value</param>
        /// <returns>True if point inside the circle, otherwise false</returns>
        public bool Contains(Vector2 point)
        {
            return Vector2.Distance(Position, point) <= R;
        }

        /// <summary>
        /// Converts circle to bounding box rectangle
        /// </summary>
        /// <returns>Result rectangle</returns>
        public Rectangle ToRectangle()
        {
            return new Rectangle((int)(Position.X - R), (int)(Position.Y - R), (int)(R * 2), (int)(R * 2));
        }

        /// <summary>
        /// Convert circle to <see cref="CircleShape"/>
        /// </summary>
        /// <returns>Result CircleShape</returns>
        public CircleShape ToCircleShape()
        {
            return new CircleShape(_r, 1) { Position = Position };
        }
    }
}
