using LineDrawer.Model;
using LineDrawer.Services.Interfaces;
using System;

namespace LineDrawer.Services
{
    public class MathOperationService: IMathOperationService
    {
        public Coefficient GetEquationFromPoints(int p0, int p1, int p2, int p3)
        {
            return new Coefficient()
            {
                ThirdPower = (-p0 + 3 * p1 - 3 * p2 + p3),
                SecondPower = (3 * p0 - 6 * p1 + 3 * p2) ,
                FirstPower = (-3 * p0 + 3 * p1) ,
                NoPower = p0 
            };
        }


        public CurveFunction CreateCurveFunctionFromBezierPoint(BezierPoint bezierPoint)
        {
            var xCoefficents = GetEquationFromPoints(bezierPoint.FirstPoint.X, bezierPoint.C0.X, bezierPoint.C1.X, bezierPoint.SecondPoint.X);
            var yCoefficents = GetEquationFromPoints(bezierPoint.FirstPoint.Y, bezierPoint.C0.Y, bezierPoint.C1.Y, bezierPoint.SecondPoint.Y);

            return new CurveFunction()
            {
                X = xCoefficents,
                Y = yCoefficents
            };
        }

        public int CountFunctionValueFromT(Coefficient coefficient, double t)
        {
            return (int)Math.Floor(coefficient.ThirdPower * Math.Pow(t, 3) + coefficient.SecondPower * Math.Pow(t, 2) + coefficient.FirstPower * t + coefficient.NoPower);
        }
    }
}