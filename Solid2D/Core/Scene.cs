using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Graphics;


namespace Core
{
    public class Scene
    {
        public static Scene CurrentScene { get; protected set; }

        public Batch2D Batch { get; protected set; }
    }
}
