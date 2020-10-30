using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CWS.SimpleBank.Data;

namespace CWS.SimpleBank.Controllers.API {
    public class CustomerAccountsController : ApiController {

        public IHttpActionResult Get(int id) {
            BankService service = new BankService();
            var accounts = service.GetCustomer(id).Accounts.ToList();
            var customerAccounts = accounts.Select(p => new
            {
                p.AccountNumber,
                p.TypeCode
            });
            return Ok(customerAccounts);
        }

        public IHttpActionResult GetByType(int id, string accountType) {
            BankService service = new BankService();
            var accounts = service.GetCustomerAccounts(id);
            if (string.IsNullOrEmpty(accountType)) {
                return BadRequest("Invalid account type");
            }

            accountType = accountType.ToUpper();

            switch (accountType) {
                case "C":
                    var ccAccounts = accounts.OfType<CreditCardAccount>().ToList();
                    return Ok(ccAccounts);

                case "D":
                    return Ok(accounts.OfType<CertificateDeposit>().ToList());

                case "L":
                    return Ok(accounts.OfType<LoanAccount>().ToList());
                default:
                    return Ok(accounts.ToList());

            }
        }

    }
}
