using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CWS.SimpleBank.Data;

namespace CWS.SimpleBank
{
    public class BankService
    {
        public int AddAccount(int customerNumber, String typeCode)
        {
            using (CWS.SimpleBank.Data.Interview101Entities1 db = new Interview101Entities1())
            {
                var customer = db.Customers.Where(c => c.CustomerNumber == customerNumber).FirstOrDefault();
                if (customer == null)
                    return 0;

                Account a = new Account
                {
                    Balance = 0M,
                    TypeCode = typeCode
                };

                customer.Accounts.Add(a);
                db.SaveChanges();

                return a.AccountNumber;
            }
        }
        /// <summary>Add a customer
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>customer number of newly added record</returns>
        public int AddCustomer(String firstName, String lastName)
        {
            using (CWS.SimpleBank.Data.Interview101Entities1 db = new Interview101Entities1())
            {
                Customer customer = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName
                };
                db.Customers.Add(customer);

                db.SaveChanges();
                return customer.CustomerNumber;
            }
        }
    }
}