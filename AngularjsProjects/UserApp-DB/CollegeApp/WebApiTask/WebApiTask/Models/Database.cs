using System.Data.SqlClient;
using System.Data;
using WebApiTask.Models;

namespace FrstWebApi.Models
{
    public class Database
    {
        SqlConnection con=new SqlConnection("Data Source=.;Initial Catalog=project;Integrated Security=True");

        public string AddStudent(Student student)
        {
            string msg=string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("School", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId",student.StudentId);
                cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmd.Parameters.AddWithValue("@PhoneNo", student.PhoneNo);
                cmd.Parameters.AddWithValue("@Dob", student.Dob);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@type", student.type);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex )
            {
                msg=ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        public DataSet GetAllStudent(Student student,out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("School", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmd.Parameters.AddWithValue("@PhoneNo", student.PhoneNo);
                cmd.Parameters.AddWithValue("@Dob", student.Dob);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@type", student.type);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

        //public string castVote(StudentElection se)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("School", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@CandidateId", se.CandidateId);
        //        cmd.Parameters.AddWithValue("@Srno", se.Srno);
        //        cmd.Parameters.AddWithValue("@type", se.type);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        msg = "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //    }
        //    finally
        //    {
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return msg;
        //}

        //public DataSet GetResult(StudentElection se, out string msg)
        //{
        //    msg = string.Empty;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("School", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@CandidateId", se.CandidateId);
        //        cmd.Parameters.AddWithValue("@Srno", se.Srno);
        //        cmd.Parameters.AddWithValue("@type", se.type);
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(ds);
        //        msg = "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //    }
        //    return ds;
        //}
    }
}
