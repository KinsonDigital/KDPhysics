using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KDPhysicsTestGame
{
    public static class ExtensionMethods
    {
        public static void SetAsSolid(this Texture2D texture, int width, int height, Color color)
        {
            var colorData = new Color[width * height];

            for (var i = 0; i < colorData.Length; i++)
            {
                colorData[i] = color;
            }

            texture.SetData(colorData);
        }
    }
}
