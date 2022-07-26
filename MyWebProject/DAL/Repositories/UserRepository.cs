
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
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dataContext;
        public UserRepository(DatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<User> Add(User user)
        {
            await _dataContext.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }

        public async Task Delete(string userName)
        {
            User user = await _dataContext.Users.FindAsync(userName);
            _dataContext.Users.Remove(user);
        
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<User>> Get()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<User> Get(int UserId)
        {
            User user = await _dataContext.Users.FindAsync(UserId);
            return user;
        }

        public async Task<User> Get(string UserName)
        {
            User user = await _dataContext.Users.FindAsync(UserName);
            return user;
        }

        public async Task<User> Update(User user)
        {
            _dataContext.Update(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }
    }
}
