using MyWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.BLL.Services.IServices
{
   public interface ISectorServices
    {
        Task<SectorToListDTO> Add(SectorToAddOrUpdateDTO sectorToAddOrUpdateDTO);
        Task<SectorToListDTO> Update(SectorToAddOrUpdateDTO sectorToAddOrUpdateDTO);
        Task<List<SectorToListDTO>> Get();
   
        Task<SectorToListDTO> Get(int id);
        Task Delete(int id);

       
    }
}
