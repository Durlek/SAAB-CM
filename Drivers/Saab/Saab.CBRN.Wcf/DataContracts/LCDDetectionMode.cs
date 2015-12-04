using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    public enum LCDDetectionMode
    {
        /// <summary>
        /// Chemical Warfare Agent
        /// </summary>
        CWA = 0,
        /// <summary>
        /// Toxic Industrial Chemical
        /// </summary>
        TIC = 1,
        /// <summary>
        /// Chemical Warfare Agent (Survery mode)
        /// </summary>
        Survey = 2,

        Ignore = 3 // Ignored by server (used in update logic)
    }
}
