using LineDrawer.Enums;
using LineDrawer.Extensions;
using LineDrawer.Model;
using LineDrawer.Services.Interfaces;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace LineDrawer.Services
{
    public class LineDrawerService : ILineDrawerService
    {
        private readonly IMathOperationService mathOperationService;

        List<CurveFunction> curveFunctionList = new List<CurveFunction>();

        BezierPoint bezierPoint = new BezierPoint();
        Pen pen = new Pen(Color.Black, 3);
        Pen littlePen = new Pen(Color.Cyan, 1);      
        OperationState operationState = OperationState.Init;
        Random random = new Random();

        public LineDrawerService(IMathOperationService _mathOperationService)
        {
            mathOperationService = _mathOperationService;
        }
       

        public void DrawLine(Graphics g, int x, int y)
        {
            if (operationState == OperationState.Init || operationState == OperationState.Finish)
            {
                bezierPoint.FirstPoint = PointExtensions.CreateRescaledPoint(x, y);
                operationState = OperationState.FirstPointSetted;
            }
            else
            {
                bezierPoint.SecondPoint = PointExtensions.CreateRescaledPoint(x, y);

                bezierPoint.C0 = PointExtensions.CreateRescaledPoint(bezierPoint.FirstPoint.X, bezierPoint.FirstPoint.Y);
                bezierPoint.C1 = PointExtensions.CreateRescaledPoint(bezierPoint.SecondPoint.X, bezierPoint.SecondPoint.Y);

                var curveFunction = mathOperationService.CreateCurveFunctionFromBezierPoint(bezierPoint);

                bool isGood = true;
                while (operationState != OperationState.LineCanBeDrawed)
                {
                    foreach (var curveFunctionFromList in curveFunctionList)
                    {
                        for (double i = 0; i < 2; i = i += 0.0000001)
                        {
                            var det = mathOperationService.CountDeterminantFromTwoCurveFunction(i, curveFunctionFromList, curveFunction);
                            if ( det < 2)   //it should be equal to zero
                            {
                                isGood = false;
                                break;
                            }
                        }
                        if (isGood == false)
                            break;
                        isGood = true;
                    }
                    if (isGood == true)
                    {
                        operationState = OperationState.LineCanBeDrawed;
                    }
                    else
                    {
                        bezierPoint.C0.RandomlyMovePoint();
                        bezierPoint.C1.RandomlyMovePoint();

                        curveFunction = mathOperationService.CreateCurveFunctionFromBezierPoint(bezierPoint);

                        DrawBezierFromBezierModel(g, bezierPoint);

                        isGood = true;
                    }
                }

                if (operationState == OperationState.LineCanBeDrawed)
                {
                    DrawBezierFromBezierModel(g, bezierPoint);
                    curveFunctionList.Add(curveFunction);
                }

                operationState = OperationState.Finish;
            }
        }
        private void DrawBezierFromBezierModel(Graphics g, BezierPoint bezierPoint)
        {
            g.DrawBezier(littlePen, bezierPoint.FirstPoint, bezierPoint.C0, bezierPoint.C1, bezierPoint.SecondPoint);
        }
    }
}