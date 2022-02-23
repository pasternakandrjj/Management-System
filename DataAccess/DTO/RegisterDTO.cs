using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace DataAccess.DTO
{
    public class RegisterDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }//add hash

        public bool IsDisabled { get; set; }

        public Role RoleID { get; set; }
    }
}