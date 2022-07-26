using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebProject.BLL.Services.IServices;

using MyWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.Controllers
{
   [AllowAnonymous]
    public class SectorController : Controller
    {

       
        public readonly ISectorServices _sectorServices;
        public readonly IDepartmentService _departmentService;
    

        public SectorController( ISectorServices sectorServices,
            IDepartmentService departmentService)
        {
          
            _sectorServices = sectorServices;
            _departmentService = departmentService;
            

        }
        public async Task<IActionResult> Index()
        {

            List<SectorToListDTO> sectors = await _sectorServices.Get();
          
          
            List<DepartmentToListDTO> departments = await _departmentService.Get();
            List<SelectListItem> selectListItems1 = (from i in departments
                                                     select new SelectListItem
                                                     {

                                                         Text = i.DepartmentName,
                                                         Value = i.DepartmentId.ToString()

                                                     }


                                     ).ToList();
//            foreach (var sector in sectors)
//            {
//if(sector.Department.IsDeleted==true)
//                {
//                    sector.IsDeleted = true;
//                }
//            }
            ViewBag.dgr1 = selectListItems1;


            return View(sectors);
        }
        public async Task<IActionResult> CreateSector(int? id)
        {
            List<SectorToListDTO> sectors = await _sectorServices.Get();

            var sector = sectors.FirstOrDefault(m => m.SectorId == Convert.ToInt32(id));
            List<DepartmentToListDTO> departments = await _departmentService.Get();
            List<SelectListItem> selectListItems1 = (from i in departments
                                                     select new SelectListItem
                                                     {

                                                         Text = i.DepartmentName,
                                                         Value = i.DepartmentId.ToString()

                                                     }


                                                ).ToList();
            ViewBag.dgr1 = selectListItems1;
            
          
           
           
            return View(sector);
        }
       
             public async Task<IActionResult> AddSector(SectorToAddOrUpdateDTO sectorToAddOrUpdateDTO) { 
        

          

            if (sectorToAddOrUpdateDTO.SectorId==null)
            {

              
                await _sectorServices.Add(sectorToAddOrUpdateDTO);
            }
       
          else
            {
                await _sectorServices.Update(sectorToAddOrUpdateDTO);
            }
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _sectorServices.Delete(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }

       
    }
}
