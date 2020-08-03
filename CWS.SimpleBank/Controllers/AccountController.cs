using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWS.SimpleBank.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Calculate interest amount
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        /// <remarks>Use the customerNumber and account number to get the account object. Instantiate a processor that implements IAccountProcessor to calculate interest </remarks>
        public decimal CalculateInterest(int customerNumber, int accountNumber, int days)
        {
            throw new NotImplementedException();
        }

        public ActionResult Calculator(int customerNumber, int accountNumber)
        {
            BankService service = new BankService();
            var customer = service.GetCustomer(customerNumber);
            if (customer != null)
            {
                var account = customer.Accounts.Where(c => c.AccountNumber == accountNumber).FirstOrDefault();
                return View(account);
            }

            throw new NullReferenceException();
        }
    }
}