using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JqueryAjaxWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace JqueryAjaxWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeApp _context;
        string name = "";
        public EmployeeController(EmployeeApp context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Country> countryList = new List<Country>();
            countryList = (from c in _context.Country select c).ToList();
            countryList.Insert(0, new Country { cid = 0, cname = " --Select Country-- " });
            ViewBag.message = countryList;
            return View();
        }
        public IActionResult Create()
        {
            List<Country> countryList = new List<Country>();
            countryList = (from c in _context.Country select c).ToList();
            countryList.Insert(0, new Country { cid = 0, cname = " --Select Country-- " });
            ViewBag.message = countryList;
            
           
            return View();
        }
        [HttpPost]
        public  IActionResult Create(Employee emp)
        {
            //Console.WriteLine(emp.cStateName);
            string DOB = Convert.ToDateTime(emp.dob).ToString("yyyy-MM-dd");
            emp.dob = Convert.ToDateTime(DOB);
            _context.Add(emp);
            _context.SaveChanges();
            ViewData["empName"] =emp.empname;
            ViewData["Success"] = "The user " + emp.empname + " Saved Sucessfully ..!";
            
            return View();
             
        }

        public IActionResult Addjobdetail()
        {
            ViewBag.data = HttpContext.Session.GetString("EmployeeName");
            //var name= HttpContext.Session.GetString("EmployeeName");
            List<Manager> managerList = new List<Manager>();
            managerList = (from manager in _context.Manager select manager).ToList();
            managerList.Insert(0, new Manager { mid = 0, mname = " --Select Manager--" });
            ViewBag.message1 = managerList;
            List<RoleT> roleList = new List<RoleT>();
            roleList = (from r in _context.RoleT select r).ToList();
            roleList.Insert(0, new RoleT { rid = 0, rname = "--Select role--" });
            ViewBag.message2 = roleList;
            List<department> departmentList = new List<department>();
            departmentList = (from department in _context.Department select department).ToList();
            departmentList.Insert(0, new department { deptId = 0, deptName = "--Select Department--" });
            ViewBag.message3 = departmentList;
            return View();
        }
        [HttpPost]
        public IActionResult Addjobdetail(List<EmployeeJobDetails> eJobdetails)
        {
            //foreach (var e in eJobdetails)
            //{
            //    _context.Add(eJobdetails);
            //    _context.SaveChanges();
            //    ViewData["JobAdded"] = "The Job Details Adding Successful!";
            //}
            var usrName = HttpContext.Session.GetString("EmployeeName");
            var employees =(from Employee in _context.Employee select Employee ).Where(s=>s.empname==usrName);
            Console.WriteLine(employees);
            //foreach (var emp in employees)
            //{
            //    Console.WriteLine(emp.empId);
            //   employeeId = emp.empId;
            //}
            foreach (var item in eJobdetails)
            {
                item.employeeId = employees.SingleOrDefault().empId;
                _context.Add(item);
                _context.SaveChanges();
                ViewData["JobAdded"] = "The Job Details Adding Successful!";

            }
            
            Addjobdetail();
            return View();
        }


        //public IActionResult GetData()
        //{
        //    List<Employee> empList = _context.Employee.ToList();
        //    return View(new SelectList(empList, "empname", "email", "countryName", "phoneno"));
        //}

        public JsonResult IsUserNameAvailable(string UserName)
        {
            return Json(!_context.Employee.Any(u => u.empname == UserName), System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        public IActionResult GetEmpDetails()
        {
            List<Employee> empList =_context.Employee.ToList();
            return PartialView(empList);
        }
        [HttpGet]
        public List<CState> BindStateByCountryId(int countryId)
        {
            List<CState> cStateList = new List<CState>();
            cStateList = _context.CState.Where(a => a.cid == countryId).ToList();
            cStateList.Insert(0, new CState { csid = 0, sname = "--Select state--", cid = 1 });
            return cStateList;
        }
        [HttpGet]
        public List<department> BindDepartmentDropdownonPreviousSelction(int deptId)
        {
            List < department > dList=new List<department>();
            dList=_context.Department.Where(a=>a.deptId != deptId).ToList();
            Console.WriteLine(dList.Count);
            int r= dList.Count;
            dList.Insert(0, new department { deptId=0,deptName="--Select Department--"});
            return dList;
        }

        [HttpGet]
        public List<Manager> BindManagerDropdownonPreviousSelction(int mid)
        {
            List<Manager> dList = new List<Manager>();
            dList = _context.Manager.Where(a => a.mid != mid).ToList();
            Console.WriteLine(dList.Count);
            int r = dList.Count;
            dList.Insert(0, new Manager { mid = 0, mname = "--Select Manager--" });
            return dList;
        }

        [HttpGet]
        public List<RoleT> BindRoleDropdownonPreviousSelction(int roleid)
        {
            List<RoleT> dList = new List<RoleT>();
            dList = _context.RoleT.Where(a => a.rid != roleid).ToList();
            Console.WriteLine(dList.Count);
            int r = dList.Count;
            dList.Insert(0, new RoleT { rid = 0, rname = "--Select Role--" });
            return dList;
        }
        public IActionResult Login()
        {
            return View();
        }
        public ActionResult EmployeeLogin(Login login )
        {
            var employee = _context.Employee.Where(s=>s.empname.Equals(login.usrname));
            if (employee.Any())
            {
                if (employee.Where(s => s.usrpassword == login.password).Any())
                {
                    HttpContext.Session.SetString("EmployeeName", login.usrname);
                    //name = login.usrname;
                    //ViewData["Name"] = "WelCome Back " + name;
                    return Json(new { status = true, message = "Login Successfull!" });
                }
                else
                {
                    return Json(new { status = false, message = "User Name and Password Not Match!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "User NotFound!" });
            }
        }
    }
}