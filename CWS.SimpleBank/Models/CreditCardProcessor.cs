using CWS.SimpleBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CWS.SimpleBank.Models
{
    public class CreditCardProcessor : IAccountProcessor
    {
        /// <summary>
        /// Calculate credit card interest
        /// </summary>
        /// <param name="presentValue"></param>
        /// <param name="rate"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        /// <remarks>Credit Card interest is simple interest based on average balance; average balance would not change in this case, therefore, the presentValue is the current balance. 
        /// Calculate daily rate based on 365 days a year, interest amount would be presentValue * dailyRate * days </remarks>
        public decimal CalculateInterest(Account account, int days)
        {
            throw new NotImplementedException();
        }
    }
}