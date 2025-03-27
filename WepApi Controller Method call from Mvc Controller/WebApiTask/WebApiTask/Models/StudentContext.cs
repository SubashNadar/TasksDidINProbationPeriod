using FrstWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FrstWebApi.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) :base(options)
        {

        }
        public DbSet<Student> Students { get; set; } = null!;
    }
}
