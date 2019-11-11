using AutoMapper;
using Lab11_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab13_WebAPI.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource: class where TDestination: class
    {
        public EntityMapper()
        {
            Mapper.CreateMap<Models.StudentModel, Student>();
            Mapper.CreateMap<Student, Models.StudentModel>();
        }

        public TDestination translate(TSource obj)
        {
            return Mapper.Map(TDestination(obj));
        }
    }
}