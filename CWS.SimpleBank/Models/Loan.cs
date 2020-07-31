using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CWS.SimpleBank.Data;

namespace CWS.SimpleBank.Models
{
    public class Loan : Account
    {
        public decimal OriginalLoanAmount { get; set; }
        public int Term { get; set; }
        public System.DateTime MaturityDate { get; set; }
        public decimal APR { get; set; }

        public void To(LoanAccount account)
        {
            if (account == null) account = new LoanAccount();

            account.AccountNumber = this.AccountNumber;
            account.OriginalLoanAmount = this.OriginalLoanAmount;
            account.MaturityDate = this.MaturityDate;
            account.APR = this.APR;
        }

        public void From(LoanAccount account)
        {
            OriginalLoanAmount = account.OriginalLoanAmount;
            MaturityDate = account.MaturityDate;
            APR = account.APR;
        }
    }
}