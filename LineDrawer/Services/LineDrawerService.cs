﻿using LineDrawer.Enums;
using LineDrawer.Extensions;
using LineDrawer.Model;
using LineDrawer.Services.Interfaces;
using System.Collections.Generic;
using System.Drawing;

namespace LineDrawer.Services
{
    public class LineDrawerService : ILineDrawerService
    {
        private readonly IMathOperationService mathOperationService;
        readonly List<CurveFunction> curveFunctionList = new List<CurveFunction>();
        readonly BezierPoint bezierPoint = new BezierPoint();
        readonly Pen littlePen = new Pen(Color.Cyan, 1);      
        readonly Pen pen = new Pen(Color.Black, 3);      
        OperationState operationState = OperationState.Init;

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
                        bezierPoint.C0.RandomlyMoveRescaledPoint();
                        bezierPoint.C1.RandomlyMoveRescaledPoint();

                        curveFunction = mathOperationService.CreateCurveFunctionFromBezierPoint(bezierPoint);

                        DrawBezierFromBezierModel(g, pen, bezierPoint);

                        isGood = true;
                    }
                }

                if (operationState == OperationState.LineCanBeDrawed)
                {
                    DrawBezierFromBezierModel(g, littlePen, bezierPoint);
                    curveFunctionList.Add(curveFunction);
                }

                operationState = OperationState.Finish;
            }
        }
        private void DrawBezierFromBezierModel(Graphics g, Pen pen, BezierPoint bezierPoint)
        {
            g.DrawBezier(pen, bezierPoint.FirstPoint, bezierPoint.C0, bezierPoint.C1, bezierPoint.SecondPoint);
        }
    }
}