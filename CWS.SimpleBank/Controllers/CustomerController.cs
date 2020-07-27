using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWS.SimpleBank.Controllers
{
    public class CustomerController : Controller
    {
        public int Add(String firstName, String lastName)
        {
            BankService service = new BankService();
            return service.AddCustomer(firstName, lastName);
        }
    
        public int AddAccount(int customerNumber, String accountType)
        {
            BankService service = new BankService();
            return service.AddAccount(customerNumber, accountType);
        }
    }
}