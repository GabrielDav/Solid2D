using System;

using Core;

using Microsoft.Xna.Framework;

namespace BoxStruct
{
    public enum Anchor { Center = 0, Top = 1, Right = 2, Bottom = 4, Left = 8, TopLeft = 9, TopRight = 10, BottomLeft = 11, BottomRight = 12}

    public struct Box
    {
        private Vector2 _pos;
        private Size _size;
        private float _rotation;
        private Matrix2D _matrix;

        /// <summary>
        /// Gets or Sets center position of box
        /// </summary>
        public Vector2 Pos
        {
            get
            {
                return _pos;
            }
            set
            {
                _pos = value;
                _matrix.M31 = _pos.X;
                _matrix.M32 = _pos.Y;
            }
        }

        /// <summary>
        /// Gets or Sets Pos.X of box
        /// </summary>
        public float X
        {
            get
            {
                return _pos.X;
            }
            set
            {
                _pos.X = value;
                _matrix.M31 = value;
            }
        }

        /// <summary>
        /// Gets or Sets Pos.Y of box
        /// </summary>
        public float Y
        {
            get
            {
                return _pos.Y;
            }
            set
            {
                _pos.Y = value;
                _matrix.M32 = value;
            }
        }

        /// <summary>
        /// Gets or Sets size of a box. Setting causes tranformation
        /// </summary>
        public Size Size
        {
            get { return _size; }
            set
            {
                _size = value;
                Transform();
            }
        }

        /// <summary>
        /// Gets or Sets Size.Width. Setting causes tranformation
        /// </summary>
        public float Width
        {
            get { return _size.Width; }
            set
            {
                _size.Width = value;
                Transform();
            }
        }

        /// <summary>
        /// Gets or Sets Size.Height. Setting causes tranformation
        /// </summary>
        public float Height
        {
            get { return _size.Height; }
            set
            {
                _size.Height = value;
                Transform();
            }
        }

        public float Rotation
        {
            get { return _rotation; }
            set
            {
                _rotation = value;
                Transform();
            }
        }

        public Matrix2D Matrix
        {
            get { return _matrix; }
        }

        public Vector2 TopRight
        {
            get
            {
                return new Vector2(_pos.X, _pos.Y) + _matrix.Right - _matrix.Down;
            }
        }

        public Vector2 TopLeft
        {
            get
            {
                return new Vector2(_pos.X, _pos.Y) - _matrix.Right - _matrix.Down;
            }
        }

        public Vector2 BottomRight
        {
            get
            {
                return new Vector2(_pos.X, _pos.Y) + _matrix.Right + _matrix.Down;
            }
        }

        public Vector2 BottomLeft
        {
            get
            {
                return new Vector2(_pos.X, _pos.Y) - _matrix.Right + _matrix.Down;
            }
        }

        public Vector2 CenterTop
        {
            get
            {
                return new Vector2(_pos.X, _pos.Y) - _matrix.Down;
            }
        }

        public Vector2 CenterRight
        {
            get
            {
                return new Vector2(_pos.X, _pos.Y) + _matrix.Right;
            }
        }

        public Vector2 CenterBottom
        {
            get
            {
                return new Vector2(_pos.X, _pos.Y) + _matrix.Down;
            }
        }

        public Vector2 CenterLeft
        {
            get
            {
                return new Vector2(_pos.X, _pos.Y) - _matrix.Right;
            }
        }

        public Vector2 AlignedTopLeft
        {
            get
            {
                return new Vector2(_pos.X - (_size.Width/2), _pos.Y - (_size.Height/2));
            }
            set
            {
                _matrix.M31 = _pos.X = value.X + (_size.Width / 2);
                _matrix.M32 = _pos.Y = value.Y + (_size.Height / 2);
            }
        }

        public Box(Vector2 pos, Size size, float rotation)
        {
            _pos = pos;
            _size = size;
            _rotation = rotation;
            _matrix = new Matrix2D();
            Transform();
        }

        public Box(Vector2 pos, Size size) : this(pos, size, 0)
        {
        }

        public Box(float x, float y, float width, float height) : this(new Vector2(x, y), new Size(width, height), 0)
        {
        }

        public Box(float x, float y, float width, float height, float rotation)
            : this(new Vector2(x, y), new Size(width, height), rotation)
        {
        }

        public Box(float width, float height) : this(new Vector2(0, 0), new Size(width, height), 0)
        {}

        private void Transform()
        {
            _matrix = Matrix2D.CreateScale(_size.ToVector()/2f)*Matrix2D.CreateRotation(_rotation)*
                      Matrix2D.CreateTranslation(_pos);
        }

       /* /// <summary>
        /// Resizes to new size
        /// </summary>
        /// <param name="sizeVector">Scale size</param>
        /// <param name="anchor">Wall(s) from which to res.</param>
        public Box Resize(Vector2 sizeVector, Anchor anchor)
        {
            switch (anchor)
            {
                case Anchor.Center:
                    Size += amount;
                    break;
                case Anchor.Bottom:
                    Size += new Size(0, amount);
                    _pos = _pos + (amount/2f)*Vector2.Normalize(_matrix.Down);
                    break;
                case Anchor.Top:
                    Size += new Size(0, amount);
                    _pos = _pos - (amount / 2f) * Vector2.Normalize(_matrix.Down);
                    break;
                default:
                    throw new ArgumentException(string.Format("Undefined anchor type '{0}'", anchor), "anchor");
            }
            return this;
        }*/

        public Box Resize(Size fromSize, Vector2 resizeVector, Anchor anchor)
        {
            switch (anchor)
            {
                case Anchor.Center:
                    Size = fromSize + resizeVector;
                    break;
                case Anchor.Top:
                    Size += resizeVector;
                    _pos = _pos + (resizeVector * Vector2.Normalize(_matrix.Up))/2f;
                    break;
               /* case Anchor.Bottom:
                    Size += resizeVector;
                    _pos = _pos + (amount / 2f) * Vector2.Normalize(_matrix.Down);
                    break;
                case Anchor.Top:
                    Size += new Size(0, amount);
                    _pos = _pos - (amount / 2f) * Vector2.Normalize(_matrix.Down);
                    break;*/
                default:
                    throw new ArgumentException(string.Format("Undefined anchor type '{0}'", anchor), "anchor");
            }
            return this;
        }

        public Box Resize(Vector2 resizeVector, Anchor anchor)
        {
            return Resize(_size, resizeVector, anchor);
        }

        public Box Scale(Vector2 scaleVector, Anchor anchor)
        {
            return Scale(_size, scaleVector, anchor);
        }

        public Box Scale(float scale, Anchor anchor)
        {
            return Scale(new Vector2(scale, scale), anchor);
        }

        public Box Scale(Size fromSize, Vector2 scaleVector, Anchor anchor)
        {
            var resizeVector = ((fromSize * scaleVector) - fromSize).ToVector();
            return Resize(fromSize, resizeVector, anchor);
        }

        public Box Scale(Size fromSize, float factor, Anchor anchor)
        {
            return Scale(fromSize, new Vector2(factor, factor), anchor);
        }

        public Rectangle GetAlignedRectangle()
        {
            var rectangle = new Rectangle((int) (_pos.X), (int) (_pos.Y),
                (int) _size.Width, (int)_size.Height);
            return rectangle;
        }

        public Box Rotate(float angle)
        {
            Rotation = angle;
            return this;
        }

        public Box SetPos(Vector2 newPos)
        {
            Pos = newPos;
            return this;
        }

        public Box Move(Vector2 moveVector)
        {
            Pos += moveVector;
            return this;
        }

        public bool Contains(float x, float y)
        {
            return Contains(new Vector2(x, y));
        }

        public bool Contains(Vector2 point)
        {
            var p1 = TopLeft;
            var p2 = TopRight;
            var p3 = BottomRight;
            var p4 = BottomLeft;

            var b1 = point.Sign(p1, p2) < 0.0f;
            var b2 = point.Sign(p2, p3) < 0.0f;
            var b3 = point.Sign(p3, p4) < 0.0f;
            var b4 = point.Sign(p4, p1) < 0.0f;

            return ((b1 == b2) && (b2 == b3) && (b3 == b4));
        }

    }
}
