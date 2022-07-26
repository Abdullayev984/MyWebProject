using Microsoft.EntityFrameworkCore;
using MyWebProject.DAL.Context;
using MyWebProject.DAL.Repositories.IRepositories;
using MyWebProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DatabaseContext _dataContext;
        public DepartmentRepository(DatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Department> Add(Department department)
        {
           await _dataContext.AddAsync(department);
           await _dataContext.SaveChangesAsync();
            return department;
        }

        public async Task Delete(int DepartmentId)
        {
            Department department = await _dataContext.Departments.FindAsync(DepartmentId);
            department.IsDeleted = true;
            foreach (var item in department.Sectors)
            {
                item.IsDeleted = true;
                foreach (var item1 in item.Employees)
                {
                    item1.IsDeleted = true;
                }
            }
            _dataContext.Update(department);
          await  _dataContext.SaveChangesAsync();
        }

        public async Task<Department> Get(int DepartmentId)
        {
          Department department=  await _dataContext.Departments.FindAsync(DepartmentId);
            return department;
        }

        public async Task<List<Department>> Get()
        {
            
            return await _dataContext.Departments.ToListAsync();
        }

        public async Task<Department> Update(Department department)
        {
            _dataContext.Update(department);
            await _dataContext.SaveChangesAsync();
            return department;
        }

       
    }
}
