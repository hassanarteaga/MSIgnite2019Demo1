using System;
using System.Collections.Generic;

namespace LogProducerConsole.Models
{
    public class LogModel
    {
        public LogModel()
        {
        }
        public string id { get; set; }
        public string transaction_name { get; set; }
        public int severity { get; set; }
        public string log_date { get; set; }
        public long nlog_date { get; set; }

    }
}