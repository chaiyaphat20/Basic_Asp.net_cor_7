using BasicASPTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicASPTutorial.Data
{
    public class ApplicationDBContext:DbContext  //ตัวแทน ฐานข้อมูล 
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {


        }

        public DbSet<Student> Students { get; set; }  //Students คือตัวแทน table:Studen
    }
}
