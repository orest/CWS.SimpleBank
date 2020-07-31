using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CWS.SimpleBank.Data;

namespace CWS.SimpleBank.Models
{
    public class CreditCard : Account
    {
        public System.DateTime ExpirationDate { get; set; }
        public decimal PurchaseAPR { get; set; }
        public decimal CashAPR { get; set; }

        public void To(CreditCardAccount account) 
        {
            if (account == null) account = new CreditCardAccount();

            account.AccountNumber = this.AccountNumber;
            account.CashAPR = this.CashAPR;
            account.PurchaseAPR = this.PurchaseAPR;
            account.ExpirationDate = this.ExpirationDate;
        }

        public void From(CreditCardAccount account)
        {
            ExpirationDate = account.ExpirationDate;
            PurchaseAPR = account.PurchaseAPR;
            CashAPR = account.CashAPR;
        }
    }
}