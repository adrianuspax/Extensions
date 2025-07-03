using System;
using System.Linq;
using UnityEngine;

namespace ASPax.Extensions
{
    /// <summary>
    /// Primitives Extensions
    /// </summary>
    public static class PrimitivesExtensions
    {
        /// <summary>
        /// Converts a boolean into an integer (0 or 1)
        /// </summary>
        /// <param name="bool">boolean value</param>
        /// <returns>return 0 to false or 1 to true</returns>
        public static int ToInt(this bool @bool)
        {
            return @bool ? 1 : 0;
        }
        /// <summary>
        /// Converts a boolean into an integer (0 or 1)
        /// </summary>
        /// <param name="bool">boolean value</param>
        /// <returns>return 0 to false or 1 to true</returns>
        public static int? ToInt(this bool? @bool)
        {
            if (@bool == null) return null;
            else return @bool.Value ? 1 : 0;
        }
        /// <summary>
        /// Converts a integer number into an boolean (false or true)
        /// </summary>
        /// <param name="int">integer value</param>
        /// <returns>
        /// If integer number is greater to 0, return true. <br/>
        /// If integer number is less or equal than 0, return false.
        /// </returns>
        public static bool ToBool(this int @int)
        {
            @int = Mathf.Clamp(@int, 0, 1);
            return @int == 1;
        }
        /// <summary>
        /// Converts a integer number into an boolean (false or true)
        /// </summary>
        /// <param name="int">integer value</param>
        /// <returns>
        /// If integer number is greater to 0, return true. <br/>
        /// If integer number is less or equal than 0, return false.
        /// </returns>
        public static bool? ToBool(this int? @int)
        {
            if (@int == null) return null;
            else @int = Mathf.Clamp(@int.Value, 0, 1);

            return @int == 1;
        }
        /// <summary>
        /// Checks if the nulable integer is null
        /// </summary>
        public static bool IsNull(this int? @int)
        {
            return @int == null;
        }
        /// <summary>
        /// Checks if all the elements in the array are null or if the array is empty
        /// </summary>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsNullOrEmpty(this int[] @int)
        {
            return @int == null || @int.Length == 0;
        }
        /// <summary>
        /// Checks if all the elements in the array are null or if the array is empty
        /// </summary>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsNullOrEmpty(this int?[] @int)
        {
            if (@int == null || @int.Length == 0) return true;
            else return @int.All(obj => obj == null);
        }
        /// <summary>
        /// Checks if the nulable float is null
        /// </summary>
        public static bool IsNull(this float? @float)
        {
            return @float == null;
        }
        /// <summary>
        /// Checks if all the elements in the array are null or if the array is empty
        /// </summary>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsNullOrEmpty(this float[] @float)
        {
            return @float == null || @float.Length == 0;
        }
        /// <summary>
        /// Checks if all the elements in the array are null or if the array is empty
        /// </summary>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsNullOrEmpty(this float?[] @float)
        {
            if (@float == null || @float.Length == 0) return true;
            else return @float.All(obj => obj == null);
        }
        /// <summary>
        /// Checks if the nulable boolean is null
        /// </summary>
        public static bool IsNull(this bool? @bool)
        {
            return @bool == null;
        }
        /// <summary>
        /// Checks if all the elements in the array are null or if the array is empty
        /// </summary>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsNullOrEmpty(this bool[] @bool)
        {
            return @bool == null || @bool.Length == 0;
        }
        /// <summary>
        /// Checks if all the elements in the array are null or if the array is empty
        /// </summary>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsNullOrEmpty(this bool?[] @bool)
        {
            if (@bool == null || @bool.Length == 0) return true;
            else return @bool.All(obj => obj == null);
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this int parameter, ref int globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this int[] parameter, ref int[] globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this int? parameter, ref int? globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this int?[] parameter, ref int?[] globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this float parameter, ref float globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this float[] parameter, ref float[] globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this float? parameter, ref float? globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this float?[] parameter, ref float?[] globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this bool parameter, ref bool globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this bool[] parameter, ref bool[] globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this string parameter, ref string globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this string[] parameter, ref string[] globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this bool? parameter, ref bool? globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this bool?[] parameter, ref bool?[] globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Truncates the float value to the desired number of decimal places
        /// </summary>
        /// <param name="float">floater</param>
        /// <param name="digits">Number of digits after the decimal point, so the value must be positive</param>
        /// <returns>Round, Floor, Ceil or (int)float</returns>
        public static (float Round, float Floor, float Ceil, float Integer) Truncation(this float @float, int digits)
        {
            float a, b;

            b = Mathf.Pow(10f, digits);
            a = @float * b;

            return (_round(), _floor(), _ceil(), _integer());

            float _round() => (float)Math.Round(@float, digits);
            float _floor() => Mathf.Floor(a) / b;
            float _ceil() => Mathf.Ceil(a) / b;
            float _integer() => (int)a / b;
        }
        /// <summary>
        /// Checks if the string is null or empty
        /// </summary>
        /// <param name="string">string</param>
        /// <returns>Is the string null or empty?</returns>
        public static bool IsNullOrEmpty(this string @string)
        {
            return string.IsNullOrEmpty(@string);
        }
        /// <summary>
        /// Checks if the string array is null or empty
        /// </summary>
        public static bool IsNullOrEmpty(this string[] @string)
        {
            if (@string == null || @string.Length == 0)
                return true;
            foreach (var str in @string)
                if (string.IsNullOrEmpty(str))
                    return true;
            return false;
        }
        /// <summary>
        /// Return <see cref="Animator.StringToHash(string)"/>.
        /// </summary>
        /// <param name="string"></param>
        /// <returns>Hash Code from <see cref="Animator"/></returns>
        public static int GetAnimatorHash(this string @string)
        {
            return Animator.StringToHash(@string);
        }
    }
}