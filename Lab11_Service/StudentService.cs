﻿using Lab11_Domain;
using Lab11_Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_Service
{
    public class StudentService
    {
        public List<Student> Get()
        {
            List<Student> students = null;
            using(var context = new SchoolContext())
            {
                students = context.Students.ToList();
            }
            return students;
        }

        public Student GetById(int ID)
        {
            Student student = null;
            using(var context = new SchoolContext())
            {
                student = context.Students.Find(ID);
            }
            return student;
        }

        public void Insert(Student student)
        {
            using(var context = new SchoolContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public void Update(Student student, int ID)
        {
            using (var context = new SchoolContext())
            {
                var studentNew = context.Students.Find(ID);

                studentNew.studentName = student.studentName;
                studentNew.studentLastName = student.studentLastName;
                studentNew.studentAddress = student.studentAddress;

                context.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using(var context = new SchoolContext())
            {
                var student = context.Students.Find(ID);
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
