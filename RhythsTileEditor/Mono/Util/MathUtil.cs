namespace RhythsTileEditor.Mono.Util
{
    /// <summary>
    /// Helper class for math or boolean functions
    /// </summary>
    public static class MathUtil
    {
        /// <summary>
        /// Wheter a number is in range of specified min and max values.
        /// </summary>
        /// <param name="number">The number to be checked.</param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value.</param>
        /// <returns>If the number is higher or equal to min and lower or equal to max.</returns>
        public static bool InRangeInclusive(int number, int min, int max) => number >= min && number <= max;

        /// <summary>
        /// Wheter a number is in range of specified min and max values.
        /// </summary>
        /// <param name="number">The number to be checked.</param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value.</param>
        /// <returns>If the number is higher to min and lower to max.</returns>
        public static bool InRangeExclusive(int number, int min, int max) => number > min && number < max;
    }
}
