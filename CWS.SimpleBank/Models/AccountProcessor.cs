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
        public decimal CalculateInterest(Account account, int days)
        {
            return account.Balance;
        }
    }
}