using CWS.SimpleBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CWS.SimpleBank.Controllers.API {
    public class AccountsApiController : ApiController {
        public IHttpActionResult Get(int id) {
            BankService service = new BankService();
            var accounts = service.GetCustomer(id).Accounts.ToList();
            return Ok(accounts);
        }
    }
}
