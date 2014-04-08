using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Graphics
{
    public class BatchItem
    {
        public Texture2D Texture;

        public VertexPositionColorTexture TL;

        public VertexPositionColorTexture TR;

        public VertexPositionColorTexture BL;

        public VertexPositionColorTexture BR;

        public Vector4 DestinationRectangle;

        public Vector2 TextureTopLeft;

        public Vector2 TextureBottomRight;
    }
}
