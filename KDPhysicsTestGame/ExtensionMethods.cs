using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
