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
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;         

            _mapper = mapper;
        }

        public async Task Add(UserToAddorUpdateDTO userToAddorUpdateDTO)
        {
            User user = _mapper.Map<User>(userToAddorUpdateDTO);
            await _userRepository.Add(user);
            
        }

        public async  Task Delete(string userName)
        {
          await  _userRepository.Delete(userName);
        }

        public async Task<List<UserToListDTO>> Get()
        {
        return     _mapper.Map<List<UserToListDTO>>(await _userRepository.Get());
        }

        public async Task<UserToListDTO> Get(int id)
        {
            return _mapper.Map<UserToListDTO>(await _userRepository.Get(id));
        }

       

        public async Task Update(UserToAddorUpdateDTO userToAddorUpdateDTO)
        {
            User user = _mapper.Map<User>(userToAddorUpdateDTO);
            await _userRepository.Update(user);
        }
    }
}
