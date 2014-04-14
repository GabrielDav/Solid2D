using Microsoft.Xna.Framework.Graphics;

namespace Solid2D.Core.Graphics
{
    public class BatchItem
    {
        public Texture2D Texture;

        public VertexPositionColorTexture TopLeft;

        public VertexPositionColorTexture TopRight;

        public VertexPositionColorTexture BottomLeft;

        public VertexPositionColorTexture BottomRight;

        public float LayerDepth;
    }
}
