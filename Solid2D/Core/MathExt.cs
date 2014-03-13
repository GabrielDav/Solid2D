// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MathExt.cs" company="GPL">
//   Gabriel Davidian
// </copyright>
// <summary>
//   Math extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Xna.Framework;

namespace Core
{
    public static class MathExt
    {
        public static float Sign(this Vector2 vector, Vector2 p1, Vector2 p2)
        {
            return (vector.X - p2.X)*(p1.Y - p2.Y) - (p1.X - p2.X)*(vector.Y - p2.Y);
        }

        public static Vector2 Project(this Vector2 vector, Vector2 onVector)
        {
            return ((Vector2.Dot(vector, onVector)/Vector2.Dot(onVector, onVector))*onVector);
        }
    }
}
