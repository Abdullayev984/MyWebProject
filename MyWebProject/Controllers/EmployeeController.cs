using Microsoft.AspNetCore.Mvc;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using MyWebProject.BLL.Services.IServices;

namespace MyWebProject.Controllers
{
   [AllowAnonymous]
    public class EmployeeController : Controller
    {
        public readonly IEmployeeService _employeeService;
        public readonly ISectorServices _sectorServices;
      

        public EmployeeController(IEmployeeService employeeService, ISectorServices sectorServices) 
           
        {
            _employeeService = employeeService;
            _sectorServices = sectorServices;
            

        }
        public async Task<IActionResult> Index()
        {
            var employees =await _employeeService.Get();
            List<SectorToListDTO> sectors = await _sectorServices.Get();
           


                                            
            List<SelectListItem> selectListItems = (from i in sectors 
                                                    select new SelectListItem
                                                    {

                                                        Text = i.SectorName,
                                                        Value = i.SectorId.ToString()

                                                    }


                                                ).ToList();
            ViewBag.dgr = selectListItems;
           
         
            
            return View(employees);
        }
        public async Task<IActionResult> CreateEmployee(int? id)
        {
            List<EmployeeToListDTO> employees = await _employeeService.Get();
            List<SectorToListDTO> sectors = await _sectorServices.Get();
       
            var data = employees.FirstOrDefault(m => m.EmpId == Convert.ToInt32(id));
            List<SelectListItem> selectListItems = (from i in sectors
                                                    select new SelectListItem
                                                    {

                                                        Text = i.SectorName,
                                                        Value = i.SectorId.ToString()

                                                    }


                                                  ).ToList();
            ViewBag.dgr = selectListItems;
           
            
            return View(data);
        }
        public async Task< IActionResult> AddEmployee(EmployeeToAddOrUpdateDTO employeeToAddOrUpdateDTO)
        {
         
        
            if (employeeToAddOrUpdateDTO.EmpId == null)
            {
               await _employeeService.Add(employeeToAddOrUpdateDTO);
            }
           else
            {
                await _employeeService.Update(employeeToAddOrUpdateDTO);
            }
           
               
          
            return RedirectToAction("Index");
        }
        public async Task< IActionResult> Delete(int id)
        {
           
          await _employeeService.Delete(id);
          
            return RedirectToAction("Index");
        }
    }
}
