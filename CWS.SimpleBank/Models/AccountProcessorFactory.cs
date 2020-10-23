using CWS.SimpleBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CWS.SimpleBank.Models
{
    public static class AccountProcessorFactory
    {
        public static IAccountProcessor GetAccountProcessor(Account account)
        {
            var accountType = account.GetType();
            if (accountType == typeof(CertificateDeposit))
                return new DepositProcessor();
            else if (accountType == typeof(CreditCardAccount))
                return new CreditCardProcessor();
            else if (accountType == typeof(LoanAccount))
                return new LoanProcessor();
            else
                return new AccountProcessor();
        }
    }
}