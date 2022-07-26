using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.BLL.Services.IServices;

using MyWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.Controllers
{ [AllowAnonymous]
    public class DepartmentController : Controller
    {
   
        public readonly IDepartmentService _departmentService;
       

        public DepartmentController(IDepartmentService departmentService)
        {
   
            _departmentService = departmentService;
           

        }
       
        public async Task<IActionResult> Index()
        {
           
            List<DepartmentToListDTO> departments = await _departmentService.Get();
            return View(departments);
        }
        public async Task<IActionResult> CreateDepartment(int? id)
        {

            List<DepartmentToListDTO> departments = await _departmentService.Get();
            var data = departments.FirstOrDefault(m => m.DepartmentId == Convert.ToInt32(id));
            return View(data);
        }
        public async Task<IActionResult> AddDepartment(DepartmentToAddOrUpdateDTO departmentToAddOrUpdateDTO)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateDepartment", departmentToAddOrUpdateDTO);
            }
            
            if (departmentToAddOrUpdateDTO.DepartmentId == null)
            {
                await _departmentService.Add(departmentToAddOrUpdateDTO);
            }
            else 
            {

                await _departmentService.Update(departmentToAddOrUpdateDTO);

            }

            return RedirectToAction("Index");
        }
        public async Task< IActionResult> Delete(int id )
        {
          
            await  _departmentService.Delete(Convert.ToInt32(id));
        
            return RedirectToAction("Index");
        }
    }
}
