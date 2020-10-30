using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CWS.SimpleBank.Data;
using CWS.SimpleBank.Models;

namespace CWS.SimpleBank {
    public class BankService {
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> Customers() {
            using (CWS.SimpleBank.Data.Interview101Entities1 db = new Interview101Entities1()) {
                return db.Customers.ToList();
            }
        }
        /// <summary>
        /// Add a account for a customer
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        public int AddAccount(int customerNumber, Account account) {
            using (CWS.SimpleBank.Data.Interview101Entities1 db = new Interview101Entities1()) {
                var customer = db.Customers.Where(c => c.CustomerNumber == customerNumber).FirstOrDefault();
                if (customer == null)
                    return 0;

                if (account == null) account = new Account();
                account.Balance = 0M;
                account.TypeCode = "U";
                account.OpenDate = DateTime.Today;

                if (account.GetType() == typeof(LoanAccount)) {
                    LoanAccount loan = account as LoanAccount;
                    loan.TypeCode = "L";
                    account.Balance = loan.OriginalLoanAmount;
                    loan.MaturityDate = DateTime.Today.AddMonths(loan.Term);
                    loan.APR = 9.99M;

                    customer.Accounts.Add(loan);
                } else if (account.GetType() == typeof(CreditCardAccount)) {
                    CreditCardAccount creditcard = account as CreditCardAccount;
                    creditcard.TypeCode = "C";
                    creditcard.ExpirationDate = DateTime.Today.AddYears(5);
                    creditcard.PurchaseAPR = 12.99M;
                    creditcard.CashAPR = 16.99M;

                    customer.Accounts.Add(creditcard);
                } else if (account.GetType() == typeof(CertificateDeposit)) {
                    CertificateDeposit deposit = account as CertificateDeposit;
                    deposit.TypeCode = "D";
                    deposit.MaturityDate = DateTime.Today.AddMonths(deposit.Term);
                    deposit.Balance = deposit.Principal;
                    deposit.APY = 3.99M;

                    customer.Accounts.Add(deposit);
                } else
                    customer.Accounts.Add(account);

                db.SaveChanges();

                return account.AccountNumber;
            }
        }
        /// <summary>Add a customer
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>customer number of newly added record</returns>
        public int AddCustomer(String firstName, String lastName) {
            using (CWS.SimpleBank.Data.Interview101Entities1 db = new Interview101Entities1()) {
                Customer customer = new Customer {
                    FirstName = firstName,
                    LastName = lastName
                };
                db.Customers.Add(customer);

                db.SaveChanges();
                return customer.CustomerNumber;
            }
        }
        /// <summary>
        /// Get a customer
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        public Customer GetCustomer(int customerNumber) {
            using (Interview101Entities1 db = new Interview101Entities1()) {
                Customer customer = db.Customers.Include("Accounts").Include("Accounts.AccountType").Include("Accounts.Customers").Where(c => c.CustomerNumber == customerNumber).FirstOrDefault();
                if (customer == null)
                    throw new KeyNotFoundException();

                return customer;
            }
        }


        public List<Account> GetCustomerAccounts(int customerNumber) {
            using (Interview101Entities1 db = new Interview101Entities1()) {
                Customer customer = db.Customers.Include("Accounts").FirstOrDefault(c => c.CustomerNumber == customerNumber);

                if (customer == null)
                    throw new KeyNotFoundException();

                var accounts = customer.Accounts.ToList();
                foreach (var account in accounts) {
                    account.Customers = null;
                }

                return accounts;
            }
        }


        public List<AccountType> GetAccountTypes() {
            using (CWS.SimpleBank.Data.Interview101Entities1 db = new Interview101Entities1()) {
                return db.AccountTypes.ToList();
            }
        }

    }
}