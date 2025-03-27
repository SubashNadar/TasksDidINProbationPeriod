using Microsoft.AspNetCore.Mvc;
using MvcForFrstApi.Models;
using System.Net.Http;

namespace MvcForFrstApi.Controllers
{
    public class SchoolController : Controller
    {
        public ActionResult Index()
        { 
            return View(this.GetStudents(1));  
        }
        [HttpPost]
        public ActionResult Index(int PageIndex)
        {
            
            return View(this.GetStudents(PageIndex));
        }

        public Paging GetStudents(int CurrentPage)
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
            ViewBag.message3 = student.ToList();
            Paging paging = new Paging();
            paging.Students = student.Skip((CurrentPage - 1) * MaxRows).Take(MaxRows).ToList();
            double Pagecounts = (double)(student.ToList().Count() / Convert.ToDecimal(MaxRows));
            
            paging.PageCount = (int)Math.Ceiling(Pagecounts);
            paging.PageIndex = CurrentPage;
            Console.WriteLine(paging.PageCount + "---" + paging.PageIndex);
            return paging;
        }

        //public ActionResult Search(string name)
        //{
        //    List<Student> students = SearchStudents(name);
        //    return View(students);
        //}
        [HttpGet]
        public List<Student> SearchStudents(string name)
        {
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
                Console.WriteLine(FilteredStudents.Count + " total Number of values");
                return FilteredStudents;
            }
            
            
            //ViewBag.message3 = FilteredStudents;
            //return View();
            
        }

        public ActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            using (var client =new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7295/api/Student");
                var postJob = client.PostAsJsonAsync<Student>("student", student);
                postJob.Wait();

                var postResult=postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Plese Retry After SomeTime!!");
            return View();
        }

        //public ActionResult Delete()
        //{
        //    return View();
        //}
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7295/api/");
                var deleteJo = client.DeleteAsync("student/" + id.ToString());
                var result=deleteJo.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult Details(string id)
        //{
        //    IEnumerable< Student>? student = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7295/api/");
        //        var deleteJo = client.GetAsync("student/" + id);
        //        var result = deleteJo.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readdb = result.Content.ReadAsAsync<IList<Student>>();   
        //            readdb.Wait();
        //            student = readdb.Result;
        //            Console.WriteLine(student);
        //        }
        //        else
        //        {
        //            student = Enumerable.Empty<Student>();
        //            ModelState.AddModelError(string.Empty, "Plese Retry After SomeTime!!");
        //        }

        //    }

        //    return View(student.FirstOrDefault());
        //}
        [HttpGet]
        public ActionResult Details(string id)
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
            List<Student> Filteredstudent =new List<Student>();
            foreach (var i in students)
            {
                if (i.StudentName.Equals(id,StringComparison.OrdinalIgnoreCase))
                {
                    Filteredstudent.Add(i);
                }
            }
            return View(Filteredstudent.FirstOrDefault());
        }

        [HttpGet]
        public ActionResult Edit(string name)
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
                    Delete(i.StudentId);
                }
            }
            //return RedirectToAction("School/Edit", new { student = Filteredstudent.FirstOrDefault() });
                //Edit(Filteredstudent.FirstOrDefault());
            return View(Filteredstudent.FirstOrDefault());
        }
        [HttpPost]
        public IActionResult Edit(Student student)
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
        //[HttpPost]
        //public ActionResult Update(string name)
        //{
        //    IEnumerable<Student>? student = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7295/api/");
        //        var deleteJo = client.GetAsync("student");
        //        var result = deleteJo.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readdb = result.Content.ReadAsAsync<IList<Student>>();
        //            readdb.Wait();
        //            student = readdb.Result;
        //            Console.WriteLine(student);
        //        }
        //        else
        //        {
        //            student = Enumerable.Empty<Student>();
        //            ModelState.AddModelError(string.Empty, "Plese Retry After SomeTime!!");
        //        }

        //    }
        //    List<Student> students = student.ToList();
        //    List<Student> Filteredstudent = new List<Student>();
        //    foreach (var i in students)
        //    {
        //        if (i.StudentName.Equals(name, StringComparison.OrdinalIgnoreCase))
        //        {
        //            Filteredstudent.Add(i);
        //            Delete(i.StudentId);
        //        }
        //    }
        //    return Edit(Filteredstudent.FirstOrDefault());
        //    //Edit(Filteredstudent.FirstOrDefault());
        //    //return View(Filteredstudent.FirstOrDefault());
        //}
    }
}
