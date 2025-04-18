using UnityEngine;

namespace ASPax.Extensions
{
    /// <summary>
    /// Extension methods for Vectors
    /// </summary>
    public static class VectorExtensions
    {
        /// <summary>
        /// Checks if the vector is default
        /// </summary>
        public static bool IsDefault(this Vector3 vector)
        {
            return vector == default;
        }
        /// <summary>
        /// Checks if the vector array is null or empty
        /// </summary>
        /// <param name="vectors"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this Vector3[] vectors)
        {
            return vectors == null || vectors.Length == 0;
        }
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
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this Vector2 parameter, ref Vector2 globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this Vector2[] parameter, ref Vector2[] globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this Vector3 parameter, ref Vector3 globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this Vector3[] parameter, ref Vector3[] globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
    }
}
