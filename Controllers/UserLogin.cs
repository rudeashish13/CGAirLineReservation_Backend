using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservationServices.Entities;

namespace AirLineReservationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogin : ControllerBase
    {

        private AirLineDbContext d = new AirLineDbContext();
        [HttpGet]
        [Route("Username/Password")]
        public IActionResult Login(string Username,string Password)
        {
            var res = d.Users.Where(x => x.Username == Username && x.Password == Password).ToList();
            if (res != null & res.Count > 0)
                return Ok("Logged In");
            else
                return Ok("Login Unsuccesfull");
        }


    }
}
