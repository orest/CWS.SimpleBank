using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CWS.SimpleBank.Data;

namespace CWS.SimpleBank.Models
{
    public class AccountProcessor : IAccountProcessor
    {
        /// <summary>
        /// Default interest calculator for regular account
        /// </summary>
        /// <param name="presentValue"></param>
        /// <param name="rate"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        /// <remarks>Default interest is simple interest; calculate daily rate based 360 days/year; and days will need to converted to months then convert to 30 days/month.  
        /// Interest amount is presentValue * dailyRate * calculatedDays </remarks>
        public decimal CalculateInterest(Account account, int days)
        {
            throw new NotImplementedException();
        }
    }
}