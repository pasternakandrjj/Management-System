using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace BusinessLogic
{
    public class DBInitializer : System.Data.Entity.DropCreateDatabaseAlways<CustomerContext>
    {
        protected override void Seed(CustomerContext context)
        {
            Role admin = new Role { Name = Roles.Administrator };
            context.Roles.Add(admin);

            context.Customers.Add(new Customer
            {
                FirstName = "Andrii",
                LastName = "Pasternak",
                Email = "admin@gmail.com",
                IsDisabled = false,
                Login = "malush",
                Password = "12345",
                PhoneNumber = "0934163908",
                RoleID = admin
            });

            base.Seed(context);
        }
    }
}