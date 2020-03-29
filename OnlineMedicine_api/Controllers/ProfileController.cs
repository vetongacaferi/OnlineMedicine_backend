using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineMedicine_api.DTOs;
using OnlineMedicine_api.Identity;
using OnlineMedicine_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicine_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private IProfileRepository _profileRepository;
        private UserManager<ApplicationUser> _userManager;

        public ProfileController(IProfileRepository profileRepository, UserManager<ApplicationUser> userManager)
        {
            _profileRepository = profileRepository;
            _userManager = userManager;
        }

        [HttpPost("GetProfile/{id}")]
        public async Task<IActionResult> GetProfile(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            ProfileDto profile = new ProfileDto()
            {
            };

            return Ok();
        }

        [HttpPost("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile([FromBody]ProfileDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            return Ok();

        }
    }
}
