using Microsoft.AspNetCore.Mvc;
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
        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpGet("GetProfile")]
        public async Task<IActionResult> GetProfile()
        {
            return Ok();
        }
    }
}
