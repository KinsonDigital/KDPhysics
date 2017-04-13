﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace KDPhysics
{
    /// <summary>
    /// Represents an Axis Aligned Bounding Box.  Main shape used to perform broad phase collision detection.
    /// </summary>
    public struct AABB
    {
        /// <summary>
        /// Represents the top left corner of the bounding rectangle.
        /// </summary>
        public Vect2 Min { get; set; }

        /// <summary>
        /// Represents the bottom right corner of the bounding rectangle.
        /// </summary>
        public Vect2 Max { get; set; }

        /// <summary>
        /// Represents the center location of the AABB rectangle.
        /// </summary>
        public Vect2 Center
        {
            get => new Vect2(Max.X - HalfWidth, Max.Y - HalfHeight);
            set
            {
                //Update the minimum vector
                Min = new Vect2(value.X - HalfWidth * 2, value.Y - HalfHeight * 2);

                //Update the maximum vector
                Max = new Vect2(value.X + HalfWidth * 2, value.Y + HalfHeight * 2);
            }
        }

        /// <summary>
        /// Gets the half width of the bounding box.
        /// </summary>
        public float HalfWidth => CalcHalfWidth();

        /// <summary>
        /// Gets the half height of the bounding box.
        /// </summary>
        public float HalfHeight => CalcHalfHeight();

        /// <summary>
        /// Calculates the half width of the bounding box.
        /// </summary>
        /// <returns>The width divided in half.</returns>
        private float CalcHalfWidth()
        {
            return (Max.X - Min.X) / 2;
        }

        /// <summary>
        /// Calculates the half height of the bounding box.
        /// </summary>
        /// <returns>The height divided in half.</returns>
        private float CalcHalfHeight()
        {
            return (Max.Y - Min.Y) / 2;
        }
    }
}