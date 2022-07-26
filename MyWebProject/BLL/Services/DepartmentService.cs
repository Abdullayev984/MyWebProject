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
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepository,IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentToListDTO> Add(DepartmentToAddOrUpdateDTO departmentToAddOrUpdateDTO)
        {
            Department department =await _departmentRepository.Add(_mapper.Map<Department>(departmentToAddOrUpdateDTO));
            return _mapper.Map<DepartmentToListDTO>(department);
        }

        public async Task Delete(int id)
        {
          await  _departmentRepository.Delete(id);
        }

        public async Task<DepartmentToListDTO> Get(int id)
        {
            Department department =await _departmentRepository.Get(id);
            return _mapper.Map<DepartmentToListDTO>(department);
        }

        public async Task<List<DepartmentToListDTO>> Get()
        {
            List<Department> departments =await _departmentRepository.Get();
            return _mapper.Map<List<DepartmentToListDTO>>(departments);
        }

        public async Task<DepartmentToListDTO> Update(DepartmentToAddOrUpdateDTO departmentToAddOrUpdateDTO)
        {
            Department department =await _departmentRepository.Update(_mapper.Map<Department>(departmentToAddOrUpdateDTO));
            return _mapper.Map<DepartmentToListDTO>(department);
        }
    }
}
