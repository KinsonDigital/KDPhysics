using System;
using System.Collections.Generic;

namespace KDPhysics
{
    /// <summary>
    /// Represents a 2D rigid body convex polygon.
    /// </summary>
    public class Polygon
    {
        private float _angle;
        private Vect2 _position;

        /// <summary>
        /// Creates a new instance of Polygon.
        /// </summary>
        /// <param name="vertices">The directional vertices of the polygon that makes up its shape. These are positive/negative values relative to the postion/center of the polygon.</param>
        public Polygon(List<Vect2> vertices)
        {
            _position = PMath.CalcPolyCenter(vertices);

            BuildVertices(vertices);

            BuildEdges();
        }

        /// <summary>
        /// Builds the vertices based off of the center.
        /// </summary>
        /// <param name="directionalVertices">The directional vertices to use to build the new vertices.</param>
        public void BuildVertices(List<Vect2> directionalVertices)
        {
            Vertices = new List<Vect2>();

            foreach (var vert in directionalVertices)
            {
                Vertices.Add(new Vect2(Position.X + vert.X, Position.Y + vert.Y));
            }
        }

        /// <summary>
        /// Builds the edges of the polygon using its vertices.
        /// </summary>
        public void BuildEdges()
        {
            Edges.Clear();

            for (var i = 0; i < Vertices.Count; i++)
            {
                var p1 = Vertices[i];

                var p2 = i + 1 >= Vertices.Count ? Vertices[0] : Vertices[i + 1];

                Edges.Add(p2 - p1);
            }
        }

        /// <summary>
        /// The edges of the polygon.
        /// </summary>
        public List<Vect2> Edges { get; } = new List<Vect2>();

        /// <summary>
        /// The vertices of the polygon.
        /// </summary>
        public List<Vect2> Vertices { get; private set; }

        /// <summary>
        /// The center of the polygon.
        /// </summary>
        public Vect2 Position
        {
            get => _position;
            set
            {
                var delta = value - _position;

                //Offset all of the vertices
                for (var i = 0; i < Vertices.Count; i++)
                {
                    Vertices[i] += delta;
                }

                _position = value;
            }
        }

        /// <summary>
        /// Offsets the polygon by the given vector amount.
        /// </summary>
        /// <param name="vector">The vector to offset the polygon with.</param>
        public void Offset(Vect2 vector)
        {
            Offset(vector.X, vector.Y);
        }

        /// <summary>
        /// Offsets the polygon by the amount of the given X and Y.
        /// </summary>
        /// <param name="x">The x amount to offset.</param>
        /// <param name="y">The y amount to offset.</param>
        public void Offset(float x, float y)
        {
            for (var i = 0; i < Vertices.Count; i++)
            {
                var p = Vertices[i];

                Vertices[i] = new Vect2(p.X + x, p.Y + y);
            }
        }

        /// <summary>
        /// The angle of the polygon in radians.
        /// </summary>
        public float Angle
        {
            get => _angle;
            set
            {
                var angleDelta = Math.Abs(_angle - value);

                _angle = value;
                RotateVertices(angleDelta);
            }
        }

        /// <summary>
        /// Rotates the vertices by the given angle amount in radians.
        /// </summary>
        /// <param name="angle">The angle amount in radians.</param>
        private void RotateVertices(float angle)
        {
            for (var i = 0; i < Vertices.Count; i++)
            {
                var vert = Vertices[i];

                Vertices[i] = PMath.RotateVectorAround(vert, Position, angle);
            }
        }

        /// <summary>
        /// Gets the string representation of the polygon.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = "";

            foreach (var p in Vertices)
            {
                if (result != "") result += " ";

                result += "{" + p + "}";
            }

            return result;
        }
    }
}