using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KDPhysics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KDPhysicsTestGame
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Sets the Texture2D as a solid with the given width, height, and color.
        /// </summary>
        /// <param name="texture">The Texture2D to set as a solid.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <param name="color">The color of the texture.</param>
        public static void SetAsSolid(this Texture2D texture, int width, int height, Color color)
        {
            var colorData = new Color[width * height];

            for (var i = 0; i < colorData.Length; i++)
            {
                colorData[i] = color;
            }

            texture.SetData(colorData);
        }

        /// <summary>
        /// Converts the given Vect2 to a Vector2.
        /// </summary>
        /// <param name="vect2">The Vect2 type to convert.</param>
        /// <returns></returns>
        public static Vector2 ToVector2(this Vect2 vect2)
        {
            return new Vector2(vect2.X, vect2.Y);
        }

        /// <summary>
        /// Converts the given Vector2 to a Vect2.
        /// </summary>
        /// <param name="vect2">The Vector2 type to convert.</param>
        /// <returns></returns>
        public static Vect2 ToVect2(this Vector2 vect2)
        {
            return new Vect2(vect2.X, vect2.Y);
        }

        /// <summary>
        /// Offsets all of the vertices by the given vector amount.
        /// </summary>
        /// <param name="vertices">The vertices to offset.</param>
        /// <param name="offsetVector">The vector amount to offset the vertices.</param>
        public static void Offset(this List<Vect2> vertices, Vect2 offsetVector)
        {
            for (var i = 0; i < vertices.Count; i++)
            {
                var p = vertices[i];
                vertices[i] = new Vect2(p.X + offsetVector.X, p.Y + offsetVector.Y);
            }
        }

        /// <summary>
        /// Renders the string to the screen using the given sprite batch, font, position, and color.
        /// </summary>
        /// <param name="thisString">The string being rendered.</param>
        /// <param name="spriteBatch">The sprite batch rendering the text.</param>
        /// <param name="font">The font of the string.</param>
        /// <param name="position">The position to render the text.</param>
        /// <param name="color">The color of the text.</param>
        public static void Render(this string thisString, SpriteBatch spriteBatch, SpriteFont font, Vector2 position, Color color)
        {
            spriteBatch.DrawString(font, thisString, position, color);
        }

        /// <summary>
        /// Returns the string representation of the Vector2.
        /// </summary>
        /// <param name="vector">The vector to represent.</param>
        /// <returns></returns>
        public static string ConvertToString(this Vector2 vector)
        {
            const char LEFT_BRACE = '{';
            const char RIGHT_BRACE = '}';

            return $"{LEFT_BRACE} X: {Math.Round(vector.X, 1)} : Y: {Math.Round(vector.Y, 1)} {RIGHT_BRACE}";
        }
    }
}