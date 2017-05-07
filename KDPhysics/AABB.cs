using System.Collections.Generic;
using System.Linq;
// ReSharper disable InconsistentNaming

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

            SetupVertices(width, height, origin, out Vect2[] vertices, out Vect2[] edges);

            Vertices = vertices;
            Edges = edges;
        }

        /// <summary>
        /// Represents all of the points where the edges/sides of the AAABB intersect.
        /// </summary>
        public Vect2[] Vertices { get; private set; }

        /// <summary>
        /// Represents all of the edges/sides of the AABB.
        /// </summary>
        public Vect2[] Edges { get; private set; }

        /// <summary>
        /// Represents the center location of the AABB rectangle.
        /// </summary>
        public Vect2 Origin
        {
            get => _origin;
            set
            {
                _origin = value;

                SetupVertices(Width, Height, Origin, out Vect2[] vertices, out Vect2[] edges);
                Vertices = vertices;
                Edges = edges;

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

                // ReSharper disable once CompareOfFloatsByEqualityOperator
                return Vertices.Where(v => v.X == maxX).First();
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

                // ReSharper disable once CompareOfFloatsByEqualityOperator
                return Vertices.Where(v => v.X == minX).First();
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

        /// <summary>
        /// Sets up the given vertices and edges based on the given width, height, and origin.
        /// </summary>
        /// <param name="width">The width of the AABB.</param>
        /// <param name="height">The height of the AABB.</param>
        /// <param name="origin">The origin of the AABB.</param>
        /// <param name="vertices">The vertices variable to save the new vertice values to.</param>
        /// <param name="edges">The edges variable to save the new edge values to.</param>
        private static void SetupVertices(float width, float height, Vect2 origin, out Vect2[] vertices, out Vect2[] edges)
        {
            var halfWidth = width / 2;
            var halfHeight = height / 2;

            vertices = new Vect2[4];

            vertices[0] = new Vect2(origin.X - halfWidth, origin.Y - halfHeight) { Name = "V1" };
            vertices[1] = new Vect2(origin.X + halfWidth, origin.Y - halfHeight) { Name = "V2" };
            vertices[2] = new Vect2(origin.X + halfWidth, origin.Y + halfHeight) { Name = "V3" };
            vertices[3] = new Vect2(origin.X - halfWidth, origin.Y + halfHeight) { Name = "V4" };

            edges = new Vect2[vertices.Length];

            for (var i = 0; i < vertices.Length; i++)
            {
                var p1 = vertices[i];

                var p2 = i + 1 >= vertices.Length ? vertices[0] : vertices[i + 1];

                edges[i] = p2 - p1;
            }
        }

        private void UpdateVertices()
        {
            var names = new List<string>();
            names.Add(Vertices[0].Name);
            names.Add(Vertices[1].Name);
            names.Add(Vertices[2].Name);
            names.Add(Vertices[3].Name);

            Vertices = new Vect2[4];
            Vertices[0] = new Vect2(Origin.X - HalfWidth, Origin.Y - HalfHeight);
            Vertices[1] = new Vect2(Origin.X + HalfWidth, Origin.Y - HalfHeight);
            Vertices[2] = new Vect2(Origin.X + HalfWidth, Origin.Y + HalfHeight);
            Vertices[3] = new Vect2(Origin.X - HalfWidth, Origin.Y + HalfHeight);

            for (var i = 0; i < Vertices.Length; i++)
            {
                Vertices[i] = PMath.RotateVectorAround(Vertices[i], Origin, _angle);
            }

            Vertices[0].Name = names[0];
            Vertices[1].Name = names[1];
            Vertices[2].Name = names[2];
            Vertices[3].Name = names[3];
        }
    }
}