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

        public float Width { get; }

        public float Height { get; }

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
            get
            {
                return _angle; 
            }
            set
            {
                //If the new angle is more then the current angle
                if (value > _angle)
                {
                    for (var i = 0; i < Vertices.Length; i++)
                    {
                        Vertices[i] = PMath.RotateVectorAround(Vertices[i], Origin, value - _angle);
                    }
                }
                else if(value < _angle)
                {

                }

                _angle = value;
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