using CWS.SimpleBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CWS.SimpleBank.Controllers.API
{
    public class AccountApiController : ApiController
    {
        public IHttpActionResult CalculateInterest(CalculationRequest calRequest)
        {

            BankService service = new BankService();
            var customer = service.GetCustomer(calRequest.CustomerNumber);
            if (customer != null && customer.Accounts != null)
            {
                var account = customer.Accounts.FirstOrDefault(a => a.AccountNumber == calRequest.AccountNumber);
                if (account != null)
                {
                    IAccountProcessor processor = AccountProcessorFactory.GetAccountProcessor(account);
                    return Ok(processor.CalculateInterest(account, calRequest.Days));
                }
            }
            return BadRequest();
        }

        public IHttpActionResult Calculator(CalculationRequest calRequest)
        {
            BankService service = new BankService();
            var customer = service.GetCustomer(calRequest.CustomerNumber);
            if (customer != null)
            {
                var account = customer.Accounts?.Where(c => c.AccountNumber == calRequest.AccountNumber).FirstOrDefault();
                return Ok(account);
            }

            return BadRequest();
        }
    }
}
