using MyWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.BLL.Services.IServices
{
   public interface IDepartmentService
    {
        Task<DepartmentToListDTO> Add(DepartmentToAddOrUpdateDTO departmentToAddOrUpdateDTO);
        Task<DepartmentToListDTO> Update(DepartmentToAddOrUpdateDTO departmentToAddOrUpdateDTO);
        Task<DepartmentToListDTO> Get(int id);
        Task<List<DepartmentToListDTO>> Get();
        Task Delete(int id);



       
    }
}
