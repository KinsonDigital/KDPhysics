using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KDPhysicsTestGame
{
    /// <summary>
    /// Provides the ability to render stats to the screen.
    /// </summary>
    public class Stats
    {
        private SpriteFont _font;

        public Stats(ContentManager content, Vector2 position)
        {
            Position = position;
            _font = content.Load<SpriteFont>("Font/arial-36");
        }

        /// <summary>
        /// The top left corner of the stats.
        /// </summary>
        public Vector2 Position { get; set; }


        /// <summary>
        /// Renders the stats to the screen.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch used to render the physObj.</param>
        /// <param name="physObj">The physics object with the stats to render.</param>
        public void Render(SpriteBatch spriteBatch, PhysObj physObj)
        {
            const string TAB = "   ";
            var statsText = new StringBuilder();

            statsText.AppendLine($"Obj Name: {physObj.Name}");

            foreach (var vert in physObj.Vertices)
            {
                statsText.AppendLine($"{TAB}Vert 1: {vert.Position.X} , {vert.Position.Y}");
            }
            
            spriteBatch.DrawString(_font, statsText, Position, Color.Black);
        }

        /// <summary>
        /// Renders the stats to the screen.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch used to render the physObj.</param>
        /// <param name="physObj">The array of physics objects with the stats to render.</param>
        public void Render(SpriteBatch spriteBatch, PhysObj[] physObj)
        {
            foreach (var obj in physObj)
            {
                Render(spriteBatch, obj);
            }
        }
    }
}