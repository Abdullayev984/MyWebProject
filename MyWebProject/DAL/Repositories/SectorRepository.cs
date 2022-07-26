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
    public class SectorRepository : ISectorRepository
    {
        private readonly DatabaseContext _dataContext;
        public SectorRepository(DatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Sector> Add(Sector sector)
        {
            await _dataContext.AddAsync(sector);
            await _dataContext.SaveChangesAsync();
            return sector;
        }

        public async Task Delete(int SectorId)
        {
            Sector sector = await _dataContext.Sectors.FindAsync(SectorId);
            sector.IsDeleted = true;
            foreach (var item in sector.Employees)
            {
                
                item.IsDeleted = true;
                
            }
            _dataContext.Update(sector);
            await _dataContext.SaveChangesAsync();
        }
       
        public async Task<Sector> Get(int SectorId)
        {
            Sector sector = await _dataContext.Sectors.FindAsync(SectorId);
            return sector;
        }

        public async Task<List<Sector>> Get()
        {


        var  sectors=   await   _dataContext.Sectors.ToListAsync();
           
            return sectors;
            
        }

      

        public async Task<Sector> Update(Sector sector)
        {
            _dataContext.Update(sector);
            await _dataContext.SaveChangesAsync();
            return sector;
        }
    }
}
