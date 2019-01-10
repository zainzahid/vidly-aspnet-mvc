using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        [Authorize]
        public ActionResult Index()
        {
            var customers = _context.Customer.Include(b=>b.MembershipType).ToList();

            return View(customers);
        }

        [Authorize]
        [Route("customer/{detail}/{id}")]
        public ActionResult Detail(int id)
        {
            var customer = _context.Customer
                .Include(b => b.MembershipType)
                .SingleOrDefault(b=>b.Id==id);
            return View(customer);
        }

        [Authorize]
        [Route("customer/{edit}/{id}")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customer
                .Include(b => b.MembershipType)
                .SingleOrDefault(b => b.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [Authorize]
        public ActionResult Add()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var addCustomerViewModel = new CustomerFormViewModel()
            {   Customer = new Customer(),
                MembershipTypes = membershipTypes};

            return View("CustomerForm", addCustomerViewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customer.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customer
                                    .Single(b=>b.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                // ___OR___ Mapper.Map( customer, customerInDb )
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customer");
        }

        [Route("Customer/{Delete}/{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var customerInDb = _context.Customer.SingleOrDefault(b => b.Id == id);
            _context.Customer.Remove(customerInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

    }
}
