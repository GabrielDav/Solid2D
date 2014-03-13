using Microsoft.Xna.Framework;

namespace Core
{
    public struct Triangle
    {
        public Vector2 Point1;
        public Vector2 Point2;
        public Vector2 Point3;

        public Triangle(Vector2 point1, Vector2 point2, Vector2 point3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        public bool Contains(Vector2 point)
        {
            var b1 = point.Sign(Point1, Point2) < 0.0f;
            var b2 = point.Sign(Point2, Point3) < 0.0f;
            var b3 = point.Sign(Point3, Point1) < 0.0f;

            return ((b1 == b2) && (b2 == b3));
        }
    }
}
