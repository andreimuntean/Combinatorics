using System.Collections.Generic;
using System;

namespace AndreiMuntean
{
    public static class Combinatorics
    {
        static double g = 7; // Gamma function precision.

        static double[] p = new double[] {
            0.99999999999980993, 676.5203681218851, -1259.1392167224028,
            771.32342877765313, -176.61502916214059, 12.507343278686905,
            -0.13857109526572012, 9.9843695780195716e-6, 1.5056327351493116e-7
        };

		// Arrangements.
        public static double A(double n, double k)
        {
            return Factorial(n) / Factorial(n - k);
        }

        // Combinations.
        public static double C(double n, double k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        // Factorial, Permutations.
        // Incorporates the gamma function.
        public static double Factorial(double x)
        {
            if (x < 0) throw new InvalidOperationException();
            else if (Math.Floor(x) == x) // x is an integer.
            {
                double result = 1;
                for (double i = 2; i <= x; ++i)
                    result *= i;
                return result;
            }
            else // Call the gamma function.
            {
                x += 1;
                if (x < 0.5) return Math.PI / (Math.Sin(Math.PI * x) * Factorial(1 - x));
                else
                {
                    x -= 1;
                    var y = p[0];
                    var t = x + g + 0.5;

                    for (var i = 1; i < g + 2; ++i)
                        y += p[i] / (x + i);

                    return Math.Sqrt(2 * Math.PI) * Math.Pow(t, (x + 0.5)) * Math.Exp(-t) * y;
                }
            }
        }
    }
}
