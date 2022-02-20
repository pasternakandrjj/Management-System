using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagmentSystem.Models
{
    public enum Roles { Administrator, Customer, Operator, Manager }

    public class Role
    {
        public int Id { get; set; }
        public Roles Name { get; set; }
    }
}