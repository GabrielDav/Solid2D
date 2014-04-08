using System;

using Core;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoxStruct
{
    public enum Anchor
    {
        Center = 0,

        Top = 1,

        Right = 2,

        Bottom = 4,

        Left = 8
    }

    public class Box
    {
        protected Size _size;

        protected Vector2 _origin;

        protected Vector2 _scale;

        protected Vector2 _position;

        protected Rotation _rotation;

        protected Matrix2D _matrix;

        public Box(Size baseSize, Vector2 position, Vector2 scale, float rotation = 0, Vector2? origin = null)
        {
            _size = baseSize.Half;
            _position = position;
            _scale = scale;
            _rotation = new Rotation(rotation);
            _origin = origin ?? Vector2.Zero;
            Transform();
        }

        /// <summary>
        /// Gets or sets base size in pixels
        /// </summary>
        public Size Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value.Half;
                Transform();
            }
        }

        /// <summary>
        /// Gets or sets origin value
        /// </summary>
        public Vector2 Origin
        {
            get
            {
                return _origin;
            }
            set
            {
                _origin = value;
                Transform();
            }
        }

        /// <summary>
        /// Gets or sets scale value
        /// </summary>
        public Vector2 Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                Transform();
            }
        }

        /// <summary>
        /// Gets or sets rotation value
        /// </summary>
        public Rotation Rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                _rotation = value;
                Transform();
            }
        }

        /// <summary>
        /// Gets or sets center position value.
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
                Transform();
            }
        }

        /// <summary>
        /// Gets or sets X position value.
        /// </summary>
        public float X
        {
            get
            {
                return _position.X;
            }
            set
            {
                _position.X = value;
                Transform();
            }
        }

        /// <summary>
        /// Gets or sets Y Position value.
        /// </summary>
        public float Y
        {
            get
            {
                return _position.Y;
            }
            set
            {
                _position.Y = value;
                Transform();
            }
        }

        /// <summary>
        /// Gets current transformation matrix
        /// </summary>
        public Matrix2D Matrix
        {
            get
            {
                return _matrix;
            }
        }

        /// <summary>
        /// Gets the top right box point as vector
        /// </summary>
        public Vector2 TopRight
        {
            get
            {
                return _matrix.Translation + ((_matrix.Right * _size.Width) + (_matrix.Up * _size.Height));
            }
        }

        /// <summary>
        /// Gets the top left box point as vector
        /// </summary>
        public Vector2 TopLeft
        {
            get
            {
                return _matrix.Translation + ((_matrix.Left * _size.Width) + (_matrix.Up * _size.Height));
            }
        }

        /// <summary>
        /// Gets the bottom right box point as vector
        /// </summary>
        public Vector2 BottomRight
        {
            get
            {
                return _matrix.Translation + ((_matrix.Right * _size.Width) + (_matrix.Down * _size.Height));
            }
        }

        /// <summary>
        /// Gets the bottom left box point as vector
        /// </summary>
        public Vector2 BottomLeft
        {
            get
            {
                return _matrix.Translation + ((_matrix.Left * _size.Width) + (_matrix.Down * _size.Height));
            }
        }

        /// <summary>
        /// Gets the top center box point as vector
        /// </summary>
        public Vector2 CenterTop
        {
            get
            {
                return _matrix.Translation + (_matrix.Up * _size.Height);
            }
        }

        /// <summary>
        /// Gets the right center box point as vector
        /// </summary>
        public Vector2 CenterRight
        {
            get
            {
                return _matrix.Translation + (_matrix.Right * _size.Width);
            }
        }

        /// <summary>
        /// Gets the bottom center box point as vector
        /// </summary>
        public Vector2 CenterBottom
        {
            get
            {
                return _matrix.Translation + (_matrix.Up * _size.Height);
            }
        }

        /// <summary>
        /// Gets the left center box point as vector
        /// </summary>
        public Vector2 CenterLeft
        {
            get
            {
                return _matrix.Translation + (_matrix.Right * _size.Width);
            }
        }

        protected void Transform()
        {
            _matrix = Matrix2D.CreateTranslation(-_origin * _size.ToVector()) * Matrix2D.CreateScale(_scale)
                      * Matrix2D.CreateRotation(_rotation.Radians) * Matrix2D.CreateTranslation(_position);
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

        //public TextureBox Resize(Size fromSize, Vector2 resizeVector, Anchor anchor)
        //{
        //    switch (anchor)
        //    {
        //        case Anchor.Center:
        //            Size = fromSize + resizeVector;
        //            break;
        //        case Anchor.Top:
        //            Size += resizeVector;
        //            _pos = _pos + (resizeVector * Vector2.Normalize(_matrix.Up))/2f;
        //            break;
        //       /* case Anchor.Bottom:
        //            Size += resizeVector;
        //            _pos = _pos + (amount / 2f) * Vector2.Normalize(_matrix.Down);
        //            break;
        //        case Anchor.Top:
        //            Size += new Size(0, amount);
        //            _pos = _pos - (amount / 2f) * Vector2.Normalize(_matrix.Down);
        //            break;*/
        //        default:
        //            throw new ArgumentException(string.Format("Undefined anchor type '{0}'", anchor), "anchor");
        //    }
        //    return this;
        //}

        //public TextureBox Resize(Vector2 resizeVector, Anchor anchor)
        //{
        //    return Resize(_size, resizeVector, anchor);
        //}

        /*public TextureBox Scale(Vector2 scaleVector, Anchor anchor)
        {
            return Scale(_size, scaleVector, anchor);
        }

        public TextureBox Scale(float scale, Anchor anchor)
        {
            return Scale(new Vector2(scale, scale), anchor);
        }

        public TextureBox Scale(Size fromSize, Vector2 scaleVector, Anchor anchor)
        {
            var resizeVector = ((fromSize * scaleVector) - fromSize).ToVector();
            return Resize(fromSize, resizeVector, anchor);
        }

        public TextureBox Scale(Size fromSize, float factor, Anchor anchor)
        {
            return Scale(fromSize, new Vector2(factor, factor), anchor);
        }*/

        public Rectangle GetAlignedRectangle()
        {
            var rectangle = new Rectangle(
                (int)_position.X,
                (int)_position.Y,
                (int)(_size.Width * _scale.X),
                (int)(_size.Height * _scale.Y));
            return rectangle;
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
