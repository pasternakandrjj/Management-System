using ManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ManagmentSystem.Controllers
{
    public class HomeController : Controller
    {
        CustomerContext customerContext = new CustomerContext();
        public ActionResult Index(int page = 1)
        {
            int pageSize = 4;
            IEnumerable<Customer> phonesPerPages = customerContext.Customers
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = customerContext.Customers.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Customers = phonesPerPages };
            return View(ivm);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                Customer user = null;
                using (CustomerContext db = new CustomerContext())
                {
                    user = db.Customers.FirstOrDefault(u => u.Email == model.Email);
                }
                if (user == null)
                {
                    using (CustomerContext db = new CustomerContext())
                    {
                        db.Customers.Add(new Customer
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Email = model.Email,
                            IsDisabled = false,
                            Login = model.Login,
                            Password = model.Password,
                            PhoneNumber = model.PhoneNumber
                        });
                        db.SaveChanges();

                        user = db.Customers.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                    }
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User already exist!");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                Customer user = null;
                using (CustomerContext db = new CustomerContext())
                {
                    user = db.Customers.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User is not real!");
                }
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddCustomer(Customer customer)
        {
            customerContext.Customers.Add(customer);
            customerContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var toupdate = customerContext.Customers.Find(id);
            if (toupdate == null)
            {
                return HttpNotFound();
            }
            return View(toupdate);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult EditCustomer(int id, Customer customer)
        {
            customerContext.Customers.Find(id).FirstName = customer.FirstName;
            customerContext.Customers.Find(id).Email = customer.Email;
            customerContext.Customers.Find(id).Password = customer.Password;

            customerContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteGoods(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer todelete = customerContext.Customers.Find(id);
            if (todelete == null)
            {
                return HttpNotFound();
            }
            return View(todelete);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteGoods(int id)
        {
            Customer todelete = customerContext.Customers.Find(id);
            customerContext.Customers.Remove(todelete);
            customerContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}