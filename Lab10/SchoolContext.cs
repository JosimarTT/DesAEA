﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Lab10.Models;

namespace Lab10
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name = MyContextDB")
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAsignments { get; set; }
        public DbSet<Person> People { get; set; }
    }
}