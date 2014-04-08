using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Graphics
{
    public class SpriteRenderer : IDrawable, IUpdateable
    {
        public bool IsAnimated { get; set; }

        public Texture2D CurrentTexture { get; protected set; }

        public virtual void Draw()
        {
            if (!IsAnimated)
            {
                //Scene.CurrentScene.Batch
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!IsAnimated)
                return;
        }
    }
}
