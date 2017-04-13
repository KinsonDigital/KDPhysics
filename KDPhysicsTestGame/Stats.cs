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
        private readonly SpriteFont _font;

        /// <summary>
        /// Creates a new Stats object.
        /// </summary>
        /// <param name="content">The content manager to use to load the font content.</param>
        /// <param name="position">The position to render the stats.</param>
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
        /// <param name="spriteBatch">The sprite batch used to render the physObjects.</param>
        /// <param name="physObj">The physics object with the stats to render.</param>
        /// <param name="color">The color to render the text.</param>
        public void Render(SpriteBatch spriteBatch, PhysObj physObj, Color color)
        {
            const string TAB = "   ";
            var statsText = new StringBuilder();

            statsText.AppendLine($"Obj Name: {physObj.Name}");

            foreach (var vert in physObj.Vertices)
            {
                statsText.AppendLine($"{TAB}Vert 1: {vert.Position.X} , {vert.Position.Y}");
            }

            RenderText(spriteBatch, statsText.ToString(), color);
        }

        /// <summary>
        /// Renders the stats to the screen.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch used to render the physObjects.</param>
        /// <param name="physObjects">The array of physics objects with the stats to render.</param>
        /// <param name="colors">The colors to render each object text. The array index matches the object array index.</param>
        public void Render(SpriteBatch spriteBatch, PhysObj[] physObjects, Color[] colors)
        {
            if (physObjects.Length != colors.Length)
                throw new Exception("The object array param must have the same number of elements as the colors array.");

            for (var i = 0; i < physObjects.Length; i++)
            {
                Render(spriteBatch, physObjects[i], colors[i]);
            }
        }

        /// <summary>
        /// Renders the given text with the given color using the given sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch used to render the physObjects.</param>
        /// <param name="text">The text to render.</param>
        /// <param name="color">The color to render the text.</param>
        private void RenderText(SpriteBatch spriteBatch, string text, Color color)
        {
            spriteBatch.DrawString(_font, text, Position, color);
        }
    }
}