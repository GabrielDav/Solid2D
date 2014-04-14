using System;
using System.Collections.Generic;
using System.Reflection;

using BoxStruct;

using Core.Utility;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Solid2D.Core.Graphics;

namespace Core.Graphics
{
    public class Batch2D
    {
        protected const int InitialBatchSize = 256;

        protected readonly GraphicsDevice _graphicsDevice;

        protected bool _isBeginCalled;

        protected readonly Effect _spriteEffect;

        protected readonly EffectParameter _effectMatrix; 

        protected readonly EffectPass _spritePass;

        protected Matrix _transformMatrix;

        protected CacheQueue<BatchItem> _freeItems;

        protected List<BatchItem> _items;

        protected short[] _indices;

        protected VertexPositionColorTexture[] _vertexArray;

        /// <summary>
        /// Initializes a new instance of the <see cref="Batch2D"/> class
        /// </summary>
        /// <param name="graphicsDevice">The graphics device where graphics will be drawn</param>
        public Batch2D(GraphicsDevice graphicsDevice, Effect effect)
        {
            if (graphicsDevice == null)
                throw new ArgumentException("graphicsDevice");

            _graphicsDevice = graphicsDevice;
            _freeItems = new CacheQueue<BatchItem>();
            _items = new List<BatchItem>();

            // TODO: Add sprite effect loading
            //_spriteEffect = new Effect(graphicsDevice, new byte[0]);
            _spriteEffect = effect;

            var assembly = Assembly.GetExecutingAssembly().GetManifestResourceStream("BatchEffect.xnb");

            // ??
            _effectMatrix = _spriteEffect.Parameters["MatrixTransform"];
            _spritePass = _spriteEffect.CurrentTechnique.Passes[0];
            
            _isBeginCalled = false;

            CreateIndex(InitialBatchSize);
        }

        protected virtual void CreateIndex(int count)
        {
            var totalCount = count * 6;
            if (_indices != null && _indices.Length >= totalCount)
                return;
            var newIndices = new short[totalCount];
            var start = 0;
            if (_indices != null)
            {
                _indices.CopyTo(newIndices, 0);
                start = _indices.Length / 6;
            }

            for (var i = start; i < count; i++)
            {
                newIndices[i * 6] = (short)(i * 4);
                newIndices[(i * 6) + 1] = (short)((i * 4) + 1);
                newIndices[(i * 6) + 2] = (short)((i * 4) + 2);

                newIndices[(i * 6) + 3] = (short)((i * 4) + 1);
                newIndices[(i * 6) + 4] = (short)((i * 4) + 3);
                newIndices[(i * 6) + 5] = (short)((i * 4) + 2);
            }

            _indices = newIndices;
            _vertexArray = new VertexPositionColorTexture[4 * count];
        }

        public virtual void Begin(Matrix2D? transformMatrix = null)
        {
            if (_isBeginCalled)
                throw new InvalidOperationException(
                    "Begin cannot be called again until End has been successfully called.");

            _transformMatrix = transformMatrix.HasValue ? transformMatrix.Value.ToMatrix3D() : Matrix.Identity; 
            _isBeginCalled = true;
        }

        public virtual void Draw(Texture2D texture, Vector2 position)
        {
            if (texture == null)
                throw new ArgumentNullException("texture");
            if (!_isBeginCalled)
                throw new InvalidOperationException("Draw was called, but Begin has not yet been called. Begin must be called successfully before you can call Draw.");
            var item = _freeItems.Dequeue();
            _items.Add(item);
            item.Texture = texture;

            item.TopLeft = new VertexPositionColorTexture(new Vector3(position.X, position.Y, 0), Color.White, new Vector2(0,0));
            item.TopRight = new VertexPositionColorTexture(new Vector3(position.X + texture.Width, position.Y, 0), Color.White, new Vector2(1, 0));
            item.BottomLeft = new VertexPositionColorTexture(new Vector3(position.X, position.Y + texture.Height, 0), Color.White, new Vector2(0, 1));
            item.BottomRight = new VertexPositionColorTexture(new Vector3(position.X + texture.Width, position.Y + texture.Height, 0), Color.White, new Vector2(1, 1));
        }

        public virtual void Draw(Texture2D texture, Box box, Color? color = null, float layerDepth = 0, Rectangle? sourceRectangle = null, SpriteEffects? spriteEffects = null)
        {
            if (texture == null)
                throw new ArgumentNullException("texture");
            if (!_isBeginCalled)
                throw new InvalidOperationException(
                    "Draw was called, but Begin has not yet been called. Begin must be called successfully before you can call Draw.");
            var item = _freeItems.Dequeue();
            _items.Add(item);

            var textureTopLeft = new Vector2(0, 0);
            var textureBottomRight = new Vector2(1, 1);

            if (sourceRectangle.HasValue)
            {
                textureTopLeft.X = sourceRectangle.Value.X / (float)texture.Width;
                textureTopLeft.Y = sourceRectangle.Value.Y / (float)texture.Height;
                textureBottomRight.X = (sourceRectangle.Value.X + sourceRectangle.Value.Width) / (float)texture.Width;
                textureBottomRight.Y = (sourceRectangle.Value.Y + sourceRectangle.Value.Height) / (float)texture.Height;
            }

            if (!color.HasValue)
            {
                color = Color.White;
            }

            if (spriteEffects.HasValue)
            {
                if (spriteEffects.Value == SpriteEffects.FlipHorizontally)
                {
                    var temp = textureBottomRight.X;
                    textureBottomRight.X = textureTopLeft.X;
                    textureTopLeft.X = temp;
                }
                else if (spriteEffects.Value == SpriteEffects.FlipVertically)
                {
                    var temp = textureBottomRight.Y;
                    textureBottomRight.Y = textureTopLeft.Y;
                    textureTopLeft.Y = temp;
                }
            }

            item.Texture = texture;
            
            item.TopLeft = new VertexPositionColorTexture(new Vector3(box.TopLeft, 0), color.Value, textureTopLeft);
            item.TopRight = new VertexPositionColorTexture(new Vector3(box.TopRight, 0), color.Value, new Vector2(textureBottomRight.X, textureTopLeft.Y));
            item.BottomLeft = new VertexPositionColorTexture(new Vector3(box.BottomLeft, 0), color.Value, new Vector2(textureTopLeft.X, textureBottomRight.Y));
            item.BottomRight = new VertexPositionColorTexture(new Vector3(box.BottomRight, 0), color.Value, textureBottomRight);

            item.LayerDepth = layerDepth;
        }

        static int CompareDepth(BatchItem item1, BatchItem item2)
        {
            return item2.LayerDepth.CompareTo(item1.LayerDepth);
        }

        public virtual void End()
        {
            _graphicsDevice.BlendState = BlendState.AlphaBlend;
            _graphicsDevice.DepthStencilState = DepthStencilState.Default;
            _graphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            _graphicsDevice.SamplerStates[0] = SamplerState.LinearClamp;

            // Setup the default sprite effect.
            var viewPort = _graphicsDevice.Viewport;

            Matrix projection;

            Matrix.CreateOrthographicOffCenter(0, viewPort.Width, viewPort.Height, 0, -1, 0, out projection);
            Matrix.Multiply(ref _transformMatrix, ref projection, out projection);

            _effectMatrix.SetValue(projection);
            _spritePass.Apply();

            if (_items.Count == 0)
                return;

            _items.Sort(CompareDepth);

            Texture currentTexture = null;
            var startIndex = 0;
            var index = 0;
            for (int i = 0; i < _items.Count; i++)
            {
                BatchItem item = _items[i];
                // if the texture changed, we need to flush and bind the new texture
                var shouldFlush = !ReferenceEquals(item.Texture, currentTexture);
                if (shouldFlush)
                {
                    FlushVertexArray(startIndex, index);

                    currentTexture = item.Texture;
                    startIndex = index = 0;
                    _graphicsDevice.Textures[0] = currentTexture;
                }

                // store the SpriteBatchItem data in our vertexArray
                _vertexArray[index++] = item.TopLeft;
                _vertexArray[index++] = item.TopRight;
                _vertexArray[index++] = item.BottomLeft;
                _vertexArray[index++] = item.BottomRight;

                // Release the texture and return the item to the queue.
                item.Texture = null;
                _freeItems.Enqueue(item);
            }
            // flush the remaining vertexArray data
            FlushVertexArray(startIndex, index);
            _items.Clear();
            _isBeginCalled = false;
        }

        private void FlushVertexArray(int start, int end)
        {
            if (start == end)
                return;

            var vertexCount = end - start;

            _graphicsDevice.DrawUserIndexedPrimitives(
                PrimitiveType.TriangleList,
                _vertexArray,
                0,
                vertexCount,
                _indices,
                0,
                (vertexCount / 4) * 2,
                VertexPositionColorTexture.VertexDeclaration);
        }

    }

}