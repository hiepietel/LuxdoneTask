using LineDrawer.Model;
using LineDrawer.Services.Interfaces;
using MathNet.Numerics.LinearAlgebra.Double;
using System;

namespace LineDrawer.Services
{
    public class MathOperationService: IMathOperationService
    {
        public bool CountDeterminantFromTwoFunctions(double k, CurveFunction curveFucntion1, CurveFunction curveFucntion2)
        {
            var x1 = curveFucntion1.X;
            var x2 = curveFucntion2.X;
            var y1 = curveFucntion1.Y;
            var y2 = curveFucntion2.Y;


            var m = DenseMatrix.OfArray(new double[,]
            {
                {x1.ThirdPower - x2.ThirdPower * Math.Pow(k, 3), x1.SecondPower - x2.SecondPower * Math.Pow(k,2), x1.FirstPower - x2.FirstPower * k, x1.NoPower - x2.NoPower, 0, 0 },
                {0, x1.ThirdPower - x2.ThirdPower * Math.Pow(k, 3), x1.SecondPower - x2.SecondPower * Math.Pow(k,2), x1.FirstPower - x2.FirstPower * k, x1.NoPower - x2.NoPower, 0 },
                {0, 0, x1.ThirdPower - x2.ThirdPower * Math.Pow(k, 3), x1.SecondPower - x2.SecondPower * Math.Pow(k,2), x1.FirstPower - x2.FirstPower * k, x1.NoPower - x2.NoPower},
                {y1.ThirdPower - y2.ThirdPower * Math.Pow(k, 3), y1.SecondPower - y2.SecondPower * Math.Pow(k,2), y1.FirstPower - y2.FirstPower * k, y1.NoPower - y2.NoPower, 0, 0 },
                {0, y1.ThirdPower - y2.ThirdPower * Math.Pow(k, 3), y1.SecondPower - y2.SecondPower * Math.Pow(k,2), y1.FirstPower - y2.FirstPower * k, y1.NoPower - y2.NoPower, 0 },
                {0, 0, y1.ThirdPower - y2.ThirdPower * Math.Pow(k, 3), y1.SecondPower - y2.SecondPower * Math.Pow(k,2), y1.FirstPower - y2.FirstPower * k, y1.NoPower - y2.NoPower},
                }
            );

            //var det = m.Determinant();
            var det = Math.Abs(m.Determinant());
            if (det < 100000)
            {
                //return true;
                if (det < 10000)
                {
                    if (det < 1000)
                    {
                        if (det < 100)
                        {
                            if (det < 25)
                            {
                                return true;
                            }
                        }

                    }
                }
            }
            return det < 1;
        }
    }
}