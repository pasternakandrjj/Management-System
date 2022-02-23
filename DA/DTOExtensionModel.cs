using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using DataAccess.DTO;
using System.Linq;

namespace DataAccess
{
    public static class DTOExtensionModel
    {
        public static Customer ConvertToDto(this Register register)
        {
            return new Customer()
            {
                Email = register.Email,
                FirstName = register.FirstName,
                IsDisabled = false,
                LastName = register.LastName,
                Login = register.Login,
                Password = register.Password,
                PhoneNumber = register.PhoneNumber
            };
        }

        public static Register ConvertToDto(this Customer register)
        {
            return new Register()
            {
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Login = register.Login,
                Password = register.Password,
                PhoneNumber = register.PhoneNumber
            };
        }

        public static List<Customer> ConvertToDto(this List<Register> register)
        {
            return register.Select(q => new Customer
            {
                Email = q.Email,
                FirstName = q.FirstName,
                IsDisabled = false,
                LastName = q.LastName,
                Login = q.Login,
                Password = q.Password,
                PhoneNumber = q.PhoneNumber
            }).ToList();
        }

        public static List<Register> ConvertToDto(this List<Customer> register)
        {
            return register.Select(q => new Register
            {
                Email = q.Email,
                FirstName = q.FirstName,
                LastName = q.LastName,
                Login = q.Login,
                Password = q.Password,
                PhoneNumber = q.PhoneNumber
            }).ToList();
        }
    }
}