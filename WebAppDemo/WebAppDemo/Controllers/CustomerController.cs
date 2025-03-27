using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;
using WebAppDemo.Models;

namespace WebAppDemo.Controllers
{
    public class CustomerController : Microsoft.AspNetCore.Mvc.Controller
    {
        public AppDbContext _context;
       // public ICustomerRepository _customerRepository;
        public CustomerController(AppDbContext context) { //, ICustomerRepository _customerRepository) {
            _context = context;
            //_customerRepository = _customerRepository;
        }
        public IActionResult Index()
        {
            var displayData = _context.Customer.ToList().Distinct();
           return View(displayData);
        }
        //public viewresult index()
        //{
         //   var customers = _customerrepository.getallcustomer();
         //   return view(customers);
       // }
       

        public IActionResult Create()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Create(Customer customer) {
            if (ModelState.IsValid)
            {
                string? filepath = customer.dp;
                var dppath = Path.GetFileName(filepath);
                customer.dp=dppath;
                _context.Add(customer);
                await _context.SaveChangesAsync();
                ViewData["Message"] = "User Data " + customer.userName + " Saved Sucessufully !";
                return View();
                //return RedirectToAction("Index");
            }
            return View(customer);
        }

        public async Task<IActionResult> Edit(string? userNAme) { 
        
            if(userNAme == null)
            {
                return RedirectToAction("Index");
            }
            var ctdetails=await _context.Customer.FindAsync(userNAme);
            return View(ctdetails);
        
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Update(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //[HttpGet][HttpPost]
        //public async Task<IActionResult> IsUserNameAvailable(string userName)
        //{
        //       Customer customer = await _context.Customer.FindAsync(userName);

        // }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public Microsoft.AspNetCore.Mvc.JsonResult IsUserNameAvailable(string UserName)
        {
            //Customer? customer =_context.Customer.Find(UserName);
            using(var db = _context)
            {
                var result = db.Customer.Any(x => x.userName == UserName);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            
        }

    }
}
