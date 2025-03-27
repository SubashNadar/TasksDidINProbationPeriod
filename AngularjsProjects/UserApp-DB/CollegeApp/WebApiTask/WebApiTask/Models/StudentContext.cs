using FrstWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WebApiTask.Models;

namespace FrstWebApi.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) :base(options)
        {

        }
        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<StudentElection> StudentElection { get; set; } = null!;
    }
}
