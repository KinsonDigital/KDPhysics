using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDPhysics;
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
        private List<Line> _lines = new List<Line>();

        private struct Line
        {
            public string Text;
            public Color TextColor;

            public Line(string text, Color textColor)
            {
                Text = text;
                TextColor = textColor;
            }
        }

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

            _lines.Clear();

            _lines.Add(new Line($"Obj Name: {physObj.Name}", Color.Black));
            _lines.Add(new Line($"{TAB}Angle: {physObj.Angle}", Color.Black));

            _lines.Add(new Line(physObj.GetVerticeToString(0), Color.Red));
            _lines.Add(new Line(physObj.GetVerticeToString(1), Color.Green));
            _lines.Add(new Line(physObj.GetVerticeToString(2), Color.White));
            _lines.Add(new Line(physObj.GetVerticeToString(3), Color.Yellow));

            _lines.Add(new Line($"Far Left Vertice: {physObj.FarthestLeftVertice.ConvertToString()}", Color.Black));
            _lines.Add(new Line($"Far Right Vertice: {physObj.FarthestRightVertice.ConvertToString()}", Color.Black));

            RenderLines(spriteBatch);
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
        private void RenderText(SpriteBatch spriteBatch, Vector2 pos, string text, Color color)
        {
            spriteBatch.DrawString(_font, text, pos, color);
        }

        private void RenderLines(SpriteBatch spriteBatch)
        {
            var position = Position;

            for (var i = 0; i < _lines.Count; i++)
            {
                if (i > 0)
                {
                    position.Y += _font.MeasureString(_lines[i].Text).Y;
                }

                RenderText(spriteBatch, position, _lines[i].Text, _lines[i].TextColor);
            }
        }
    }
}