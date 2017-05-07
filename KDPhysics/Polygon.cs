using System.Collections.Generic;

namespace KDPhysics
{
    /// <summary>
    /// Represents a 2D rigid body convex polygon.
    /// </summary>
    public class Polygon
    {
        /// <summary>
        /// Creates a new instance of Polygon.
        /// </summary>
        /// <param name="vertices">The vertices of the polygon that makes up its shape.</param>
        public Polygon(List<Vect2> vertices)
        {
            Vertices = vertices;

            BuildEdges();
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
        public List<Vect2> Vertices { get; } = new List<Vect2>();

        /// <summary>
        /// The center of the polygon.
        /// </summary>
        public Vect2 Center
        {
            get
            {
                float totalX = 0;
                float totalY = 0;

                foreach (var p in Vertices)
                {
                    totalX += p.X;
                    totalY += p.Y;
                }

                return new Vect2(totalX / Vertices.Count, totalY / Vertices.Count);
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