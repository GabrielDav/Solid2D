// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUpdateable.cs" company="GPL">
//   Gabriel Davidian
// </copyright>
// <summary>
//   Defines the IUpdateable interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using Microsoft.Xna.Framework;

namespace Core
{
    /// <summary>
    /// The Updateable interface. Used for objects that can be updated.
    /// </summary>
    interface IUpdateable
    {
        /// <summary>
        /// Executes update.
        /// </summary>
        /// <param name="gameTime">Current game time</param>
        void Update(GameTime gameTime);
    }
}
