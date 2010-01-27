using System;
using System.Collections.Generic;
using System.Text;
using ACOT.Infrastructure.Interface.Services;

namespace ACOT.Infrastructure.Shell
{
    public class PerfomanceService : IPerfomanceService
    {
        public PerfomanceService()
        {
            stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
        }


        #region IPerfomanceService Members

        public System.Diagnostics.Stopwatch stopwatch { get; set; }

        #endregion
    }
}
