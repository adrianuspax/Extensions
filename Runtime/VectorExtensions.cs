using UnityEngine;

namespace ASP.Extensions
{
    /// <summary>
    /// Extension methods for Vectors
    /// </summary>
    public static class VectorExtensions
    {
        /// <summary>
        /// Checks if any component of the vector - x, y or z - returns IsNaN
        /// </summary>
        /// <param name="vector">Three-dimensional vector</param>
        /// <returns>Returns true if any component of the vector - x, y or z - returns IsNaN as true</returns>
        public static bool IsNaN(this Vector3 vector)
        {
            bool x, y, z;
            x = float.IsNaN(vector.x);
            y = float.IsNaN(vector.y);
            z = float.IsNaN(vector.z);
            return x || y || z;
        }
        /// <summary>
        /// Checks if any component of the vector - x or y - returns IsNaN
        /// </summary>
        /// <param name="vector">Two-dimensional vector</param>
        /// <returns>Returns true if any component of the vector - x or y - returns IsNaN as true</returns>
        public static bool IsNaN(this Vector2 vector)
        {
            bool x, y;
            x = float.IsNaN(vector.x);
            y = float.IsNaN(vector.y);
            return x || y;
        }
        /// <summary>
        /// Checks if the vector is Null
        /// </summary>
        /// <param name="vector">Three-dimensional vector</param>
        /// <returns>Returns true if the Vector is Null</returns>
        public static bool IsNull(this Vector3 vector)
        {
            return vector == null;
        }
        /// <summary>
        /// Checks if the vector is Null
        /// </summary>
        /// <param name="vector">Two-dimensional vector</param>
        /// <returns>Returns true if the Vector is Null</returns>
        public static bool IsNull(this Vector2 vector)
        {
            return vector == null;
        }
        /// <summary>
        /// Checks if the vector is Null or checks if any component of the vector - x, y or z - returns IsNaN
        /// </summary>
        /// <param name="vector">Three-dimensional vector</param>
        /// <returns>Returns true if the Vector is Null or if any component of the vector - x, y or z - returns IsNaN as true</returns>
        public static bool IsNullOrNaN(this Vector3 vector)
        {
            return vector.IsNull() || vector.IsNaN();
        }
        /// <summary>
        /// Checks if the vector is Null or checks if any component of the vector - x or y - returns IsNaN
        /// </summary>
        /// <param name="vector">Three-dimensional vector</param>
        /// <returns>Returns true if the Vector is Null or if any component of the vector - x or y - returns IsNaN as true</returns>
        public static bool IsNullOrNaN(this Vector2 vector)
        {
            return vector.IsNull() || vector.IsNaN();
        }
    }
}
