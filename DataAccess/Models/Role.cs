using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public enum Roles { Administrator, Customer, Operator, Manager }

    public class Role
    {
        [Key]
        public int Id { get; set; }
        public Roles Name { get; set; }
    }
}