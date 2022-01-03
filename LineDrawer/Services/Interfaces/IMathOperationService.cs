using LineDrawer.Model;

namespace LineDrawer.Services.Interfaces
{
    public interface IMathOperationService
    {
        double CountDeterminantFromTwoCurveFunction(double k, CurveFunction firstCurveFunction, CurveFunction secondCurveFunction);
        Coefficient GetEquationFromPoints(int p0, int p1, int p2, int p3);
        CurveFunction CreateCurveFunctionFromBezierPoint(BezierPoint bezierPoint);
    }
}
