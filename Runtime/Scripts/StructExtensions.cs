namespace ASPax.Extensions
{
    using System;
    /// <summary>
    /// Generic Extensions
    /// </summary>
    public static class StructExtensions
    {
        /// <summary>
        /// Checks if all the elements in the array are null or if the array is empty
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="objects">Generic Type Array</param>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsNullOrEmpty<T>(this T[] objects) where T : struct, Enum
        {
            return objects == null || objects.Length == 0;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment<T>(this T parameter, ref T globalVariable) where T : struct, Enum
        {
            if (parameter.Equals(globalVariable))
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
        public static bool ComparativeAssignment<T>(this T[] parameter, ref T[] globalVariable) where T : struct, Enum
        {
            if (parameter.Equals(globalVariable))
                return false;

            globalVariable = parameter;
            return true;
        }
    }
}