﻿using System;
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
    /// Draws a thin rectangle that represents and axis line.
    /// </summary>
    public class Axis
    {
        private Texture2D _texture;
        private SpriteFont _font;
        private Vector2 _labelPosition;



        /// <summary>
        /// Creates a new instance of Axis.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device to use to render the PhysObj.</param>
        /// <param name="content">The content manager used to load the content.</param>
        /// <param name="type">The type of axis.</param>
        /// <param name="position">The position to draw the axis.</param>
        /// <param name="length">The length in pixels of the axis.</param>
        /// <param name="label">The label of the axis.</param>
        /// <param name="axisColor">The color of the axis.</param>
        /// <param name="labelColor">The color of the axis label.</param>
        public Axis(GraphicsDevice graphicsDevice, ContentManager content, AxisType type, Vector2 position, int length, string label, Color axisColor, Color labelColor)
        {
            _font = content.Load<SpriteFont>("Font/arial-36");

            switch (type)
            {
                case AxisType.XAxis:
                    _texture = new Texture2D(graphicsDevice, length, 2);
                    _texture.SetAsSolid(length, 2, axisColor);
                    _labelPosition = new Vector2(length / 2 + position.X - _font.MeasureString(label).X / 2, position.Y + 5);
                    break;
                case AxisType.YAxis:
                    _texture = new Texture2D(graphicsDevice, 2, length);
                    _texture.SetAsSolid(2, length, axisColor);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            Position = position;
            Label = label;
            AxisColor = axisColor;
            LabelColor = labelColor;
        }

        /// <summary>
        /// The type of axis.
        /// </summary>
        public AxisType Type { get; set; }

        /// <summary>
        /// The position of the axis to be rendered.
        /// </summary>
        public Vector2 Position { get; }

        /// <summary>
        /// The label of the axis.
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// The color of the axis.
        /// </summary>
        public Color AxisColor { get; }

        /// <summary>
        /// The color of the label.
        /// </summary>
        public Color LabelColor { get; }

        /// <summary>
        /// Renders the axis.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Render(SpriteBatch spriteBatch)
        {
            //Render the axis
            spriteBatch.Draw(_texture, Position, AxisColor);

            //Render the label text
            spriteBatch.DrawString(_font, Label, _labelPosition, LabelColor);
        }
    }
}
