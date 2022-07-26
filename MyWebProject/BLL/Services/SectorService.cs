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
    public class SectorService : ISectorServices
    {
        public readonly ISectorRepository _sectorRepository;
        public readonly IMapper _mapper;
        public SectorService(ISectorRepository sectorRepository, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _sectorRepository = sectorRepository;
            _mapper = mapper;

        }

        public async Task<SectorToListDTO> Add(SectorToAddOrUpdateDTO sectorToAddOrUpdateDTO)
        {
            Sector sector = await _sectorRepository.Add(_mapper.Map<Sector>(sectorToAddOrUpdateDTO));
            return _mapper.Map<SectorToListDTO>(sector);
        }

        public async  Task Delete(int id)
        {
           await _sectorRepository.Delete(id);
        }

        public async Task<List<SectorToListDTO>> Get()
        {
            List<Sector> sectors = await _sectorRepository.Get();
            return _mapper.Map<List<SectorToListDTO>>(sectors);
        }

        public async Task<SectorToListDTO> Get(int id)
        {
            Sector sector =await _sectorRepository.Get(id);
            return _mapper.Map<SectorToListDTO>(sector);
        }

        public async Task<SectorToListDTO> Update(SectorToAddOrUpdateDTO sectorToAddOrUpdateDTO)
        {
            Sector sector =await  _sectorRepository.Update(_mapper.Map<Sector>(sectorToAddOrUpdateDTO));
            return _mapper.Map<SectorToListDTO>(sector);
          

        }
    }
}
