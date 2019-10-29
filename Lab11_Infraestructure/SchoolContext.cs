using Lab11_Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_Infraestructure
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name = MyContextDB")
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
