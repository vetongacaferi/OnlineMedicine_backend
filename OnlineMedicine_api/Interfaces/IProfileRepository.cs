using OnlineMedicine_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.Interfaces
{
    public interface IProfileRepository
    {
        Task<AspNetUsers> GetUserProfile(string userId);

        void UpdateUserProfile(AspNetUsers model);

        int SaveChanges();

    }
}
