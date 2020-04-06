using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OnlineMedicine_api.DTOs;
using OnlineMedicine_api.Identity;
using OnlineMedicine_api.Interfaces;
using OnlineMedicine_api.Services;
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
        private IFileUploadService _fileuploadService;

        public ProfileController(IProfileRepository profileRepository, UserManager<ApplicationUser> userManager, IFileUploadService fileuploadService)
        {
            _profileRepository = profileRepository;
            _userManager = userManager;
            _fileuploadService = fileuploadService;
        }

        [HttpPost("GetProfile")]
        public async Task<IActionResult> GetProfile([FromBody]UserProfile value)
        {
            var user = await _profileRepository.GetUserProfile(value.Id);

            if (user == null)
            {
                return NotFound();
            }

            ProfileDto profile = new ProfileDto()
            {
                username = user.UserName,
                firstname = user.FirstName,
                lastname = user.LastName,
                city = user.City,
                state = user.State,
                zipcode = user.ZipCode,
                file = user.Image
            };

            return Ok(profile);
        }

        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile([FromBody]ProfileUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await _profileRepository.GetUserProfile(model.id);

            if (user == null)
            {
                return BadRequest();
            }


            
            user.FirstName = model.firstname;
            user.LastName = model.lastname;
            user.UserName = model.username;
            user.City = model.city;
            user.State = model.state;
            user.ZipCode = model.zipcode;


            if (model.file.Length > 0)
            {
                string fileupload = _fileuploadService.FileUpload(model.file);
                if (fileupload != "")
                {
                    user.Image = fileupload;
                }
            }
            else
            {
                user.Image = "";
            }

          

            _profileRepository.UpdateUserProfile(user);

            if (_profileRepository.SaveChanges() > 0)
            {
                return Ok();
            }

            return BadRequest();

        }
    }
}
