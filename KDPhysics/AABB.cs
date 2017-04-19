﻿using System.Linq;

namespace KDPhysics
{
    /// <summary>
    /// Represents an Axis Aligned Bounding Box.  Main shape used to perform broad phase collision detection.
    /// </summary>
    public struct AABB
    {
        private Vect2 _origin;
        private float _angle;

        public AABB(float width, float height, Vect2 origin)
        {
            _angle = 0f;
            _origin = origin;
            Width = width;
            Height = height;
            var halfWidth = width / 2;
            var halfHeight = height / 2;

            Vertices = new Vect2[4];

            Vertices[0] = new Vect2(origin.X - halfWidth, origin.Y - halfHeight);
            Vertices[1] = new Vect2(origin.X + halfWidth, origin.Y - halfHeight);
            Vertices[2] = new Vect2(origin.X + halfWidth, origin.Y + halfHeight);
            Vertices[3] = new Vect2(origin.X - halfWidth, origin.Y + halfHeight);
        }

        public Vect2[] Vertices { get; private set; }

        /// <summary>
        /// Represents the center location of the AABB rectangle.
        /// </summary>
        public Vect2 Origin
        {
            get => _origin;
            set
            {
                _origin = value;

                UpdateVertices();
            }
        }

        /// <summary>
        /// The width of the AABB.
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// The height of the AABB.
        /// </summary>
        public float Height { get; }


        /// <summary>
        /// Gets the vertice that is farthest to the right then the rest of the vertices.
        /// </summary>
        public Vect2 FarthestRightVertice
        {
            get
            {
                var maxX = Vertices.Max(v => v.X);

                return Vertices.Where(v => v.X <= maxX).First();
            }
        }


        /// <summary>
        /// Gets the vertice that is farthest to the left then the rest of the vertices.
        /// </summary>
        public Vect2 FarthestLeftVertice
        {
            get
            {
                var minX = Vertices.Min(v => v.X);

                return Vertices.Where(v => v.X <= minX).First();
            }
        }


        /// <summary>
        /// Gets the half width of the bounding box.
        /// </summary>
        public float HalfWidth => Width / 2;

        /// <summary>
        /// Gets the half height of the bounding box.
        /// </summary>
        public float HalfHeight => Height / 2;

        /// <summary>
        /// The angle of the AABB in radians.
        /// </summary>
        public float Angle
        {
            get => _angle;
            set
            {
                var degrees = PMath.RadianToDegree(value);

                //If the value to set the angle is greater then 360 degrees, set it back to 0.
                if (degrees > 360)
                {
                    value = PMath.DegreeToRadian(degrees - 360);
                }

                _angle = value;
                UpdateVertices();
            }
        }

        private void UpdateVertices()
        {
            Vertices = new Vect2[4];
            Vertices[0] = new Vect2(Origin.X - HalfWidth, Origin.Y - HalfHeight);
            Vertices[1] = new Vect2(Origin.X + HalfWidth, Origin.Y - HalfHeight);
            Vertices[2] = new Vect2(Origin.X + HalfWidth, Origin.Y + HalfHeight);
            Vertices[3] = new Vect2(Origin.X - HalfWidth, Origin.Y + HalfHeight);

            for (var i = 0; i < Vertices.Length; i++)
            {
                Vertices[i] = PMath.RotateVectorAround(Vertices[i], Origin, _angle);
            }
        }
    }
}