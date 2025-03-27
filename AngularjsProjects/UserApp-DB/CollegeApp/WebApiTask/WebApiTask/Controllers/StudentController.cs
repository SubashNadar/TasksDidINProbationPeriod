using Microsoft.AspNetCore.Mvc;
using FrstWebApi.Models;
using System.Data;
using WebApiTask.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        Database db=new Database(); 
        string mssg=string.Empty;
        // GET: api/<StudentController>
        [Route("GetStudents")]
        [HttpGet]
        public List<Student> Get()
        {
            Student student=new Student();
            student.type = "get";
            DataSet ds =db.GetAllStudent(student,out mssg);
            List<Student> students = new List<Student>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                students.Add(new Student
                {
                    StudentId=Convert.ToInt32(item["StudentId"]),
                    StudentName = item["StudentName"].ToString()!,
                    Dob=Convert.ToDateTime(item["Dob"]),
                    PhoneNo=item["PhoneNo"].ToString()!,
                    Gender=Convert.ToChar(item["Gender"])
                });
            }
            return students;
        }
        //[Route("vuResult")]
        //[HttpGet]
        //public List<StudentElection> GetResult()
        //{
        //    StudentElection student = new StudentElection();
        //    student.type = "getVoteResult";
        //    DataSet ds = db.GetResult(student, out mssg);
        //    List<StudentElection> students = new List<StudentElection>();
        //    foreach (DataRow item in ds.Tables[0].Rows)
        //    {
        //        students.Add(new StudentElection
        //        {
        //            Srno = Convert.ToInt32(item["Srno"]),
        //            CandidateId = Convert.ToInt32(item["CandidateId"])
        //        });
        //    }
        //    return students;
        //}


        [HttpGet("{name}")]
        public Student GetByName(string name)
        {
            Student student = new Student();
            student.StudentName = name;
            student.type = "getname";
            DataSet ds = db.GetAllStudent(student, out mssg);
            List<Student> students = new List<Student>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                students.Add(new Student
                {
                    StudentId = Convert.ToInt32(item["StudentId"]),
                    StudentName = item["StudentName"].ToString()!,
                    Dob = Convert.ToDateTime(item["Dob"]),
                    PhoneNo = item["PhoneNo"].ToString()!,
                    Gender = char.Parse((string)item["Gender"])
                });
            }
            Student Foundstudent = students.FirstOrDefault();
            return Foundstudent;
        }

        // POST api/<StudentController>
        [Route("AddStudent")]
        [HttpPost]
        public string Post([FromBody] Student student)
        {
            string mssg = string.Empty;
            try
            {
                student.type = "insert";
                mssg= db.AddStudent(student);
            }
            catch (Exception ex)
            {

                mssg=ex.Message;
            }
            return mssg;
        }

        //[Route("CastVote")]
        //[HttpPost]
        //public string addVote([FromBody] StudentElection student)
        //{
        //    string mssg = string.Empty;
        //    try
        //    {
        //        student.type = "castVote";
        //        mssg = db.castVote(student);
        //    }
        //    catch (Exception ex)
        //    {

        //        mssg = ex.Message;
        //    }
        //    return mssg;
        //}

        // PUT api/<StudentController>/5
        //[Route("UpdateStudent")]
        [HttpPut("{id}")]
        public string Put(int id,[FromBody] Student student)
        {
            string mssg = string.Empty;
            try
            {
                student.StudentId = id;
                student.type = "update";
                mssg = db.AddStudent(student);
            }
            catch (Exception ex)
            {

                mssg = ex.Message;
            }
            return mssg;
        }

        // DELETE api/<StudentController>/5
        //[Route("DeleteStudent")]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string mssg = string.Empty;
            try
            {
                Student student=new Student();
                student.StudentId= id; 
                student.type = "delete";
                mssg = db.AddStudent(student);
            }
            catch (Exception ex)
            {

                mssg = ex.Message;
            }
            return mssg;
        }
    }
}
