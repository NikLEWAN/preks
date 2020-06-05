using System;

namespace FupLib
{
    public class TransportCalc
    {
        public static double Average(int antalKm, double antalLiter)
        {
            if (antalKm < 0)
                throw new ArgumentOutOfRangeException("antalKm", "antalKm is under 0");
            if (antalKm > 2000)
                throw new ArgumentOutOfRangeException("antalKm", "antalKm is above 2000");
            else
                return (antalKm / antalLiter) * 100;
        }
        public static int Total(string transporter)
        {
            string[] numbers = transporter.Split(' ');
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += int.Parse(number);
            }

            return sum;
        }
    }
}
