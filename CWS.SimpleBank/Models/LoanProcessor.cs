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
        /// <param name="account"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public decimal CalculateInterest(Account account, int days)
        {
            if (account == null)
                throw new Exception("Account is null");

            if (account.GetType() == typeof(LoanAccount))
            {
                var a = account as LoanAccount;
                return a.Balance * a.APR / 365.0M * (decimal)days;
            }

            throw new NotImplementedException();
        }
    }
}