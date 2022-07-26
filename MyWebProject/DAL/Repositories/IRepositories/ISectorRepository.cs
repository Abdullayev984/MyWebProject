
using MyWebProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.DAL.Repositories.IRepositories
{
  public  interface ISectorRepository
    {
        Task<Sector> Get(int SectorId);
        Task <List<Sector>>Get();
       
        Task<Sector> Add(Sector sector);
        Task<Sector> Update(Sector sector);
        Task Delete(int SectorId);
       
    }
}
