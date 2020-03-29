using OnlineMedicine_api.Interfaces;
using OnlineMedicine_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private dbOnlineMedicineContext _context;

        public ProfileRepository(dbOnlineMedicineContext context)
        {
            _context = context;
        }

        public async Task<AspNetUsers> GetUserProfile(string userId)
        {
            return await _context.AspNetUsers.FindAsync(userId);

        }


        public void UpdateUserProfile(AspNetUsers model)
        {
             _context.AspNetUsers.Update(model);
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
