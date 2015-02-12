namespace App
{
    public interface IRationalHelper
    {
        /// <summary>
        /// Greatest common divisor of two numbers
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        long Gcd(long x, long y);

        /// <summary>
        /// Least common multiple
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        int Lcm(int x, int y);
    }
}