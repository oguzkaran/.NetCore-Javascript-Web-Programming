using System;


namespace CSD.Util.Mathematics
{
    public class Complex
    {
        private static Complex add(double real1, double imag1, double real2, double imag2)
        {
            return new Complex { Real = real1 + real2, Imag = imag1 + imag2 };
        }

        public double Real { get; set; }
        public double Imag { get; set; }
        public double Norm => Math.Sqrt(Real * Real + Imag * Imag);
        public double Length => Norm;

        public static Complex operator +(Complex z1, Complex z2)
        {
            return add(z1.Real, z1.Imag, z2.Real, z2.Imag);
        }

        public static Complex operator +(Complex z, double val)
        {
            return add(z.Real, z.Imag, val, 0);
        }

        public static Complex operator +(double val, Complex z)
        {
            return add(val, 0, z.Real, z.Imag);
        }

        //...

        public override string ToString() => $"|{Real} + {Imag}i| = {Norm}";        
    }
}
