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
        public decimal CalculateInterest(Account account, int days)
        {
            if (account == null)
                throw new Exception("Account is null");

            if (account.GetType() == typeof(CreditCardAccount)) {
                var a = account as CreditCardAccount;
                return a.Balance * a.PurchaseAPR / 365.0M * (decimal)days;
            }

            throw new NotImplementedException();
        }
    }
}