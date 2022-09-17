using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerServiceExample.Config
{
    public class EmployeeConfig
    {
        public int StartTimeInMinutes { get; set; }
        public int WorkTimeInMinutes { get; set; }
        public int EndTimeInMinutes { get; set; }
        public int FinishingTimeInMinutes { get; set; }
        public string Task { get; set; }
    }
}
