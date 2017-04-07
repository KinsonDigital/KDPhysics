using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDPhysics
{
    /// <summary>
    /// Provides utility methods for physics calculations.
    /// </summary>
    public static class PMath
    {
        public static decimal CalcDotProduct(Vect2 v1, Vect2 v2)
        {
            return (v1.X * v2.X) + (v1.Y * v2.Y);
        }
    }
}
