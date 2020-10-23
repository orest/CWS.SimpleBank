using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CWS.SimpleBank.Models
{
    public class CalculationRequest
    {
        public int CustomerNumber { get; set; }
        public int AccountNumber { get; set; }
        public int Days { get; set; }
    }
}