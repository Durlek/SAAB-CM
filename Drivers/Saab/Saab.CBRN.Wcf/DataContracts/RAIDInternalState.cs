using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    public enum RAIDInternalState
    {
        stopped = 0,
        started = 1,
        cleaning = 2,
        startingwarmup = 3,
        startingselftest = 4,
        analytictest = 5,
        off = 6
    }
}
