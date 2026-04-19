using SM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User GetUserByUsername(string username);
        Task AddUserAsync(User user);


    }
}
