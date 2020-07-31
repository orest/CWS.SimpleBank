using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CWS.SimpleBank.Data;
using CWS.SimpleBank.Models;

namespace CWS.SimpleBank.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult GetAll()
        {
            BankService service = new BankService();
            return View("Customers", service.Customers());
        }

        public int Add(String firstName, String lastName)
        {
            BankService service = new BankService();
            return service.AddCustomer(firstName, lastName);
        }
   
        public int AddCreditCard(int customerNumber)
        {
            BankService service = new BankService();
            CreditCardAccount creditCard = new CreditCardAccount();
            return service.AddAccount(customerNumber, creditCard);
        }
        public int AddLoan(int customerNumber, int term, decimal amount)
        {
            BankService service = new BankService();
            LoanAccount loan = new LoanAccount
            {
                Term = term,
                OriginalLoanAmount = amount
            };
            return service.AddAccount(customerNumber, loan);
        }
        public int AddDeposit(int customerNumber, int term, decimal amount)
        {
            BankService service = new BankService();
            CertificateDeposit deposit = new CertificateDeposit
            {
                Term = term,
                Principal = amount
            };
            return service.AddAccount(customerNumber, deposit);
        }
        public ActionResult Accounts(int customerNumber)
        {
            BankService service = new BankService();
            return View(service.GetCustomer(customerNumber));
        }
    }
}