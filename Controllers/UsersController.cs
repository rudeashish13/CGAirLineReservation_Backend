using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservationServices.Entities;
using AirLineReservationServices.Repositories;

namespace AirLineReservationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo u;

        public UsersController(IUserRepo u)
        {
            this.u = u;
        }


        [HttpGet]
        [Route("AdminLogin")]
        public string Login(string Username, string Password)
        {
            return u.LoginCheck(Username, Password);
        }



    }
}
