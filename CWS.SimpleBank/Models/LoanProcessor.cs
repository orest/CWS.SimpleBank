using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CWS.SimpleBank.Data;

namespace CWS.SimpleBank.Models
{
    public class LoanProcessor : IAccountProcessor
    {
        /// <summary>
        /// Calculate loan interest
        /// </summary>
        /// <param name="presentValue"></param>
        /// <param name="rate"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        /// <remarks>loan interest is simple interest; calculate daily rate based on 365 days a year, interest amount would be presentValue * dailyRate * days </remarks>
        public decimal CalculateInterest(Account account, int days)
        {
            throw new NotImplementedException();
        }
    }
}