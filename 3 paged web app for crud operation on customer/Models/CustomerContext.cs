using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagmentSystem.Models
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
    public class DBInitializer : DropCreateDatabaseAlways<CustomerContext>
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