﻿using LineDrawer.Model;
using LineDrawer.Services.Interfaces;
using MathNet.Numerics.LinearAlgebra.Double;
using System;

namespace LineDrawer.Services
{
    public class MathOperationService: IMathOperationService
    {
        public Coefficient GetEquationFromPoints(int p0, int p1, int p2, int p3)
        {
            return new Coefficient()
            {
                ThirdPower = (-p0 + 3 * p1 - 3 * p2 + p3) / 10,
                SecondPower = (3 * p0 - 6 * p1 + 3 * p2) / 10,
                FirstPower = (-3 * p0 + 3 * p1) / 10,
                NoPower = p0 / 10
            };
        }

        public double CountDeterminantFromTwoCurveFunction(double k, CurveFunction firstCurveFunction, CurveFunction secondCurveFunction)
        {
            var x1 = firstCurveFunction.X;
            var x2 = secondCurveFunction.X;
            var y1 = firstCurveFunction.Y;
            var y2 = secondCurveFunction.Y;

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

            return Math.Abs(m.Determinant());
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
    }
}