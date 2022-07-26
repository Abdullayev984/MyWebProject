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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _dataContext;
        public EmployeeRepository(DatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Employee> Add(Employee employee)
        {
            await _dataContext.AddAsync(employee);
            await _dataContext.SaveChangesAsync();
            return employee;
        }

        public async Task Delete(int EmpId)
        {
            Employee employee = await _dataContext.Employees.FindAsync(EmpId);
            employee.IsDeleted = true;
            _dataContext.Update(employee);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Employee> Get(int EmpId)
        {
            Employee employee = await _dataContext.Employees.FindAsync(EmpId);
            return employee;
        }

        public async Task<List<Employee>> Get()
        {
           var employees=await _dataContext.Employees.ToListAsync();
           
            return employees;
        }

        public async Task<Employee> Update(Employee employee)
        {
            _dataContext.Update(employee);
            await _dataContext.SaveChangesAsync();
            return employee;
        }
     
    }
}
