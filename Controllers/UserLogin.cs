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
    public class UserLogin : ControllerBase
    {

        private readonly IUserRepo u;

        public UserLogin(IUserRepo u)
        {
            this.u = u;
        }


        [HttpGet]
        [Route ("Login")]
        public string Login(string Username,string Password)
        {
            return u.LoginCheck(Username, Password);
        }


    }
}
