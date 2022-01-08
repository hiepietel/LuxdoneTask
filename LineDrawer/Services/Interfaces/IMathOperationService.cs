using LineDrawer.Model;

namespace LineDrawer.Services.Interfaces
{
    public interface IMathOperationService
    {
        Coefficient GetEquationFromPoints(int p0, int p1, int p2, int p3);
        CurveFunction CreateCurveFunctionFromBezierPoint(BezierPoint bezierPoint);
        int CountFunctionValueFromT(Coefficient coefficient, double t);
    }
}
