using AutoMapper;
using MyWebProject.BLL.Services.IServices;
using MyWebProject.DAL.Repositories.IRepositories;

using MyWebProject.Entities;
using MyWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.BLL.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
 
        public readonly IMapper _mapper;
        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;

        }

        public async Task<EmployeeToListDTO> Add(EmployeeToAddOrUpdateDTO employeeToAddOrUpdateDTO)
        {
            Employee employee =await _employeeRepository.Add(_mapper.Map<Employee>(employeeToAddOrUpdateDTO));
            return _mapper.Map<EmployeeToListDTO>(employee);
        }

        public async Task<EmployeeToListDTO> Update(EmployeeToAddOrUpdateDTO employeeToAddOrUpdateDTO)
        {
            Employee employee = await _employeeRepository.Update(_mapper.Map<Employee>(employeeToAddOrUpdateDTO));
            return _mapper.Map<EmployeeToListDTO>(employee);
          
        }

        public async Task<List<EmployeeToListDTO>> Get()
        {
            List<Employee> employees =await _employeeRepository.Get();
            return _mapper.Map<List<EmployeeToListDTO>>(employees);
        }

        public async Task<EmployeeToListDTO> Get(int id)
        {
            Employee employee =await _employeeRepository.Get(id);
            return _mapper.Map<EmployeeToListDTO>(employee);
        }

        public async Task Delete(int id)
        {
           await _employeeRepository.Delete(id);
        }
    }
}


