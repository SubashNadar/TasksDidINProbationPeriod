using Microsoft.AspNetCore.Mvc;
using MvcForFrstApi.Models;

namespace MvcForFrstApi.Controllers
{
    public class CollegeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View(SearchStudents(""));
        }
        [HttpGet]
        public List<Student> SearchStudents(string name)
        {
            int MaxRows = 10;
            IEnumerable<Student>? student = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7295/api/");
                var responseTask = client.GetAsync("student");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readdb = result.Content.ReadAsAsync<IList<Student>>();
                    readdb.Wait();
                    student = readdb.Result;
                }
                else
                {
                    student = Enumerable.Empty<Student>();
                    ModelState.AddModelError(string.Empty, "Plese Retry After SomeTime!!");
                }
            }
            List<Student> students = student.ToList();
            List<Student> FilteredStudents = new List<Student>();
            if (string.IsNullOrEmpty(name))
            {
                //Paging paging = new Paging();
                //paging.Students = students.Skip((currentPage - 1) * MaxRows).Take(MaxRows).ToList();
                //double Pagecounts = (double)(student.ToList().Count() / Convert.ToDecimal(MaxRows));

                //paging.PageCount = (int)Math.Ceiling(Pagecounts);
                //paging.PageIndex = currentPage;
                //Console.WriteLine(paging.PageCount + "---" + paging.PageIndex);
                return students;
            }
            else
            {
                foreach (var s in students)
                {
                    if (s.StudentName.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                    {
                        FilteredStudents.Add(s);
                    }
                }
                //Console.WriteLine(FilteredStudents.Count + " total Number of values");
                //Paging paging = new Paging();
                //paging.Students = FilteredStudents.Skip((currentPage - 1) * MaxRows).Take(MaxRows).ToList();
                //double Pagecounts = (double)(student.ToList().Count() / Convert.ToDecimal(MaxRows));

                //paging.PageCount = (int)Math.Ceiling(Pagecounts);
                //paging.PageIndex = currentPage;
                //Console.WriteLine(paging.PageCount + "---" + paging.PageIndex);
                return FilteredStudents;
            }

        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7295/api/");
                var deleteJo = client.DeleteAsync("student/" + id.ToString());
                var result = deleteJo.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7295/api/Student");
                var postJob = client.PostAsJsonAsync<Student>("student", student);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Plese Retry After SomeTime!!");
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(string name)
        {
            IEnumerable<Student>? student = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7295/api/");
                var deleteJo = client.GetAsync("student");
                var result = deleteJo.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readdb = result.Content.ReadAsAsync<IList<Student>>();
                    readdb.Wait();
                    student = readdb.Result;
                    Console.WriteLine(student);
                }
                else
                {
                    student = Enumerable.Empty<Student>();
                    ModelState.AddModelError(string.Empty, "Plese Retry After SomeTime!!");
                }

            }
            List<Student> students = student.ToList();
            List<Student> Filteredstudent = new List<Student>();
            foreach (var i in students)
            {
                if (i.StudentName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Filteredstudent.Add(i);
                }
            }
            return View(Filteredstudent.FirstOrDefault());
        }
        public IActionResult Edit(string name,string updatedname,string mobileno)
        {
            IEnumerable<Student>? student = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7295/api/");
                var deleteJo = client.GetAsync("student");
                var result = deleteJo.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readdb = result.Content.ReadAsAsync<IList<Student>>();
                    readdb.Wait();
                    student = readdb.Result;
                    Console.WriteLine(student);
                }
                else
                {
                    student = Enumerable.Empty<Student>();
                    ModelState.AddModelError(string.Empty, "Plese Retry After SomeTime!!");
                }

            }
            List<Student> students = student.ToList();
            Student stud=new Student();
            List<Student> Filteredstudent = new List<Student>();
            foreach (var i in students)
            {
                if (i.StudentName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Filteredstudent.Add(i);
                    i.StudentName = updatedname;
                    i.PhoneNo = mobileno;
                    stud = i;
                    Delete(i.StudentId);
                }
            }
            Create(stud);
            return View(stud);
        }
        }
}
