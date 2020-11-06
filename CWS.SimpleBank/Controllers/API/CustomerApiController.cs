using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CWS.SimpleBank.Controllers.API
{
    public class CustomerApiController : ApiController
    {
        public IHttpActionResult Get()
        {
            BankService service = new BankService();
            return Ok(service.Customers().Select(p=>new
            {
                p.CustomerNumber, p.FirstName, p.LastName
            }));
        }

        public IHttpActionResult Get(int id)
        {
            BankService service = new BankService();
            return Ok(service.GetCustomer(id));
        }
    }
}
