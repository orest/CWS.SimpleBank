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
            if (account == null)
                throw new Exception("Account should not be null");

            if (account.AccountType == null)
                return new AccountProcessor();

            if (account.AccountType.TypeCode == "D")
                return new DepositProcessor();
            else if (account.AccountType.TypeCode == "C")
                return new CreditCardProcessor();
            else if (account.AccountType.TypeCode == "L")
                return new LoanProcessor();
            else
                return new AccountProcessor();
        }
    }
}