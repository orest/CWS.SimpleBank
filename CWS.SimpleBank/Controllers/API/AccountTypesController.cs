﻿using System.Linq;
using System.Web.Http;

namespace CWS.SimpleBank.Controllers.API {
    public class AccountTypesController : ApiController {
        public IHttpActionResult Get() {
            BankService service = new BankService();
            var types = service.GetAccountTypes().Where(p=>p.TypeCode!="U");
            return Ok(types);
        }
    }
}
