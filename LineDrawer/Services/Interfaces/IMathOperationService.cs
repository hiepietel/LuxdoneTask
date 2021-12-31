using LineDrawer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LineDrawer.Services.Interfaces
{
    interface IMathOperationService
    {
        bool CountDeterminantFromTwoFunctions(double k, CurveFunction curveFucntion1, CurveFunction curveFucntion2)
    }
}
