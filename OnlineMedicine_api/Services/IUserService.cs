using OnlineMedicine_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);

    }
}
