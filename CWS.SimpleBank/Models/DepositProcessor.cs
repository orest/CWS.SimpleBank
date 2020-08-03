using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CWS.SimpleBank.Data;

namespace CWS.SimpleBank.Models
{
    public class DepositProcessor : IAccountProcessor
    {
        /// <summary>
        /// Calculate deposit interest
        /// </summary>
        /// <param name="presentValue"></param>
        /// <param name="annualRate"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        /// <remarks>Deposit interest is compound interest; calculate daily rate based on 365 a year.  Interest Amount is presentValue * (1 + daily rate) ** days  - presentValue</remarks>
        public decimal CalculateInterest(Account account, int days)
        {
            throw new NotImplementedException();
        }
    }
}