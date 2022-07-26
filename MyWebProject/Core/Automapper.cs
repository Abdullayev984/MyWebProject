using AutoMapper;
using MyWebProject.Entities;
using MyWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.Core
{
    public class Automapper:Profile
    {
        public Automapper()
        {


            CreateMap<EmployeeToAddOrUpdateDTO, Employee>();
           
            CreateMap<Employee, EmployeeToListDTO>();
            CreateMap<SectorToAddOrUpdateDTO, Sector>();
            
            CreateMap<Sector, SectorToListDTO>();
            CreateMap<DepartmentToAddOrUpdateDTO, Department>();
            
            CreateMap<Department, DepartmentToListDTO>();
            CreateMap<UserToAddorUpdateDTO, User>();
            CreateMap<User, UserToListDTO>();
      



        }

    }
}
