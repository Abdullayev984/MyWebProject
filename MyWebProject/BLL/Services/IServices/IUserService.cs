using MyWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.BLL.Services.IServices
{
   public interface IUserService
    {
        Task Add(UserToAddorUpdateDTO userToAddorUpdateDTO);
        Task Update(UserToAddorUpdateDTO userToAddorUpdateDTO);
        Task<List<UserToListDTO>> Get();
        Task<UserToListDTO> Get(int id);
        Task Delete(string userName);

    }
}
