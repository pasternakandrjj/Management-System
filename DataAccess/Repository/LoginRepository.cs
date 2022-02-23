using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using System.Linq;

namespace DataAccess.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly CustomerContext _customerContext;

        public LoginRepository(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public Customer FindCustomer(Customer customer)
        {
            Customer user = _customerContext.Customers.FirstOrDefault(u => u.Email == customer.Email);
            return user;
        }

        public Customer FindCustomerByPass(Customer customer)
        {
            Customer user = _customerContext.Customers.Where(u => u.Email == customer.Email && u.Password == customer.Password).FirstOrDefault();
            return user;
        }

        public void AddCustomer(Customer customer)
        {
            Customer user = this.FindCustomer(customer);

            if (user == null)
            {
                _customerContext.Customers.Add(new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    IsDisabled = false,
                    Login = customer.Login,
                    Password = customer.Password,
                    PhoneNumber = customer.PhoneNumber
                });
                _customerContext.SaveChanges();
                customer = FindCustomerByPass(customer);
            }
        }
    }
}