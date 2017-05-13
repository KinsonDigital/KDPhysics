using System.Collections.Generic;
using System.Linq;

namespace KDPhysics
{
    /// <summary>
    /// Represents a 2D rigid body convex polygon.
    /// </summary>
    public class Polygon
    {
        private float _angle;//The angle of the polygon in radians
        private Vect2 _position;//The position of the polygon. This is the center of the polygon and origin of rotation

        /// <summary>
        /// Creates a new instance of Polygon.
        /// </summary>
        /// <param name="worldVertices">The world vertice locations of the polygon that makes up its shape. These are locations relative to the world top left corner origin.</param>
        /// <param name="worldPosition">The position of the center</param>
        public Polygon(List<Vect2> worldVertices, Vect2 worldPosition)
        {
            var startPosition = PMath.CalcPolyCenter(worldVertices);

            //Get the delta of the starting polygon center and the disired position.
            //This is the amount you want to move the vertices so the center world position
            //of the new polygon position lands on the given worldPosition param
            var deltaPosition = worldPosition - startPosition;

            Vertices = new List<Vect2>();

            //Adjust the incoming vertices that are relative to the world origin of 0,0
            //to end up with vertices where the polygon center lands on the worldPosition param
            foreach (var worldVert in worldVertices)
            {
                Vertices.Add(new Vect2(worldVert.X + deltaPosition.X, worldVert.Y + deltaPosition.Y));
            }

            _position = PMath.CalcPolyCenter(Vertices);

            BuildEdges();
        }

        #region Props
        /// <summary>
        /// The edges of the polygon.
        /// </summary>
        public List<Vect2> Edges { get; } = new List<Vect2>();

        /// <summary>
        /// The vertices of the polygon.
        /// </summary>
        public List<Vect2> Vertices { get; }

        /// <summary>
        /// Gets left side X location of the polygon bounding box.
        /// </summary>
        public float BoundingBoxLeft => Vertices.Min(v => v.X);

        /// <summary>
        /// Gets right side X location of the polygon bounding box.
        /// </summary>
        public float BoundingBoxRight => Vertices.Max(v => v.X);

        /// <summary>
        /// Gets top Y location of the polygon bounding box.
        /// </summary>
        public float BoundingBoxTop => Vertices.Min(v => v.Y);

        /// <summary>
        /// Gets bottom Y location of the polygon bounding box.
        /// </summary>
        public float BoundingBoxBottom => Vertices.Max(v => v.Y);

        /// <summary>
        /// The position of the polygon.  This is also the center of the polygon and the center of rotation.
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
        /// The angle of the polygon in radians.
        /// </summary>
        public float Angle
        {
            get => _angle;
            set
            {
                var angleDelta = value - _angle;

                _angle = value;
                RotateVertices(angleDelta);
            }
        }
        #endregion

        #region Public Methods
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
        #endregion

        /// <summary>
        /// Rotates the vertices by the given angle in radians.
        /// </summary>
        /// <param name="angle">The angle amount in radians.</param>
        private void RotateVertices(float angle)
        {
            for (var i = 0; i < Vertices.Count; i++)
            {
                var vert = Vertices[i];

                Vertices[i] = PMath.RotateVectorAround(vert, Position, angle);
            }

            BuildEdges();
        }
    }
}