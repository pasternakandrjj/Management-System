using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace DataAccess.Repository.Interfaces
{
    public interface ILoginRepository
    {
        public Customer FindCustomer(Customer customer) { return customer; }

        public Customer FindCustomerByPass(Customer customer) { return customer; }
       
        public void AddCustomer(Customer customer) { }
    }
}