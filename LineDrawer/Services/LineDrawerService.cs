using LineDrawer.Enums;
using LineDrawer.Extensions;
using LineDrawer.Model;
using LineDrawer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace LineDrawer.Services
{
    public class LineDrawerService : ILineDrawerService
    {
        private readonly IMathOperationService mathOperationService;
        readonly BezierPoint bezierPoint = new BezierPoint();
        readonly Pen littlePen = new Pen(Color.Blue, 2);
        readonly Pen morePen = new Pen(Color.Black, 1);
        OperationState operationState = OperationState.Init;

        List<Tuple<int, int, bool>> board = new List<Tuple<int, int, bool>>();

        public LineDrawerService(IMathOperationService _mathOperationService)
        {
            mathOperationService = _mathOperationService;
        }

        public void CleanLinesFromBoard(Graphics g)
        {
            g.Clear(Color.White);
            board = new List<Tuple<int, int, bool>>();
            operationState = OperationState.Init;

        }

        public void DrawLine(Graphics g, int x, int y, bool debug = false)
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
                var rectanglePosition = RectanglePosition.TopLeft;
                int move = 5;
                while (operationState != OperationState.LineCanBeDrawed)
                {
                    for (double i = 0.02; i < 0.98; i += 0.0002)
                    {
                        int xp = mathOperationService.CountFunctionValueFromT(curveFunction.X, i);
                        int yp = mathOperationService.CountFunctionValueFromT(curveFunction.Y, i);
                        if (board.Exists(x => x.Item1 > (xp - 1) && x.Item1 < (xp + 1) && x.Item2 > (yp - 1) && x.Item2 < (yp + 1) && x.Item3 == true))
                        {
                            isGood = false;
                            break;
                        }
                    }

                    if (isGood == true)
                    {
                        operationState = OperationState.LineCanBeDrawed;
                    }
                    else
                    {
                        var x_dir = GetDirectionWidth(rectanglePosition) * move;
                        var y_dir = GetDirectionHeight(rectanglePosition) * move;

                        bezierPoint.C0 = bezierPoint.C0.MoveRescaledPoint(x_dir, y_dir);
                        bezierPoint.C1 = bezierPoint.C1.MoveRescaledPoint(x_dir, y_dir);

                        curveFunction = mathOperationService.CreateCurveFunctionFromBezierPoint(bezierPoint);
                        
                        if(debug == true)
                            DrawBezierFromBezierModel(g, morePen, bezierPoint);

                        move += 50;
                        rectanglePosition = NextRectanglePositon(rectanglePosition);
                        isGood = true;
                    }
                }

                if (operationState == OperationState.LineCanBeDrawed)
                {
                    for (double i = 0; i < 1; i = i += 0.0002)
                    {
                        int xp = mathOperationService.CountFunctionValueFromT(curveFunction.X, i);
                        int yp = mathOperationService.CountFunctionValueFromT(curveFunction.Y, i);
                        if (board.Exists(x => x.Item1 == xp && x.Item2 == yp) == false)
                        {
                            board.Add(new Tuple<int, int, bool>(xp, yp, true));
                        }
                    }

                    DrawBezierFromBezierModel(g, littlePen, bezierPoint);
                }
                operationState = OperationState.Finish;
            }
        }

        private int GetDirectionWidth(RectanglePosition rectanglePosition)
        {
            return rectanglePosition switch
            {
                RectanglePosition.TopLeft => 1,
                RectanglePosition.BottomLeft => 1,
                RectanglePosition.TopRight => -1,
                RectanglePosition.BottomRight => -1,
                _ => 0,
            };
        }

        private int GetDirectionHeight(RectanglePosition rectanglePosition)
        {
            return rectanglePosition switch
            {
                RectanglePosition.TopLeft => -1,
                RectanglePosition.TopRight => -1,
                RectanglePosition.BottomLeft => 1,
                RectanglePosition.BottomRight => 1,
                _ => 0,
            };
        }

        private RectanglePosition NextRectanglePositon(RectanglePosition rectanglePosition)
        {
            return rectanglePosition switch
            {
                RectanglePosition.TopLeft => RectanglePosition.TopRight,
                RectanglePosition.TopRight => RectanglePosition.BottomLeft,
                RectanglePosition.BottomLeft => RectanglePosition.BottomRight,
                RectanglePosition.BottomRight => RectanglePosition.TopLeft,
                _ => rectanglePosition,
            };
        }

        private void DrawBezierFromBezierModel(Graphics g, Pen pen, BezierPoint bezierPoint)
        {
            g.DrawBezier(pen, bezierPoint.FirstPoint, bezierPoint.C0, bezierPoint.C1, bezierPoint.SecondPoint);
        }
    }
}