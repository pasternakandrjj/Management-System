using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Repository.Interfaces;
using DataAccess;

namespace BusinessLogic.Services
{
    public class LoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public void Register(Register model)
        {
            //if (ModelState.IsValid)
            //{
            Customer user = model.ConvertToDto();
            using (CustomerContext db = new CustomerContext())
            {
                user = _loginRepository.FindCustomer(user);//.
                                                           //db.Customers.FirstOrDefault(u => u.Email == model.Email);
            }
            if (user == null)
            {
                _loginRepository.AddCustomer(user);
                //using (CustomerContext db = new CustomerContext())
                //{
                //    db.Customers.Add(new Customer
                //    {
                //        FirstName = model.FirstName,
                //        LastName = model.LastName,
                //        Email = model.Email,
                //        IsDisabled = false,
                //        Login = model.Login,
                //        Password = model.Password,
                //        PhoneNumber = model.PhoneNumber
                //    });
                //    db.SaveChanges();

                //    user = db.Customers.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                //}
                //        if (user != null)
                //        {
                //            FormsAuthentication.SetAuthCookie(model.Email, true);
                //            return RedirectToAction("Index", "Home");
                //        }
                //    }
                //    else
                //    {
                //        ModelState.AddModelError("", "User already exist!");
                //    }
                //}

                //return View(model);
            }
        }
    }
}