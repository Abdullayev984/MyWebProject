using MyWebProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.DAL.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> Get();
        Task<User> Get(int UserId);
        Task<User> Get(string UserName);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task Delete(string userName);
       
    }
}
