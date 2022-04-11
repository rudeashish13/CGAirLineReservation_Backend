using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservationServices.Entities;

namespace AirLineReservationServices.Repositories
{
    public class UserRepo: IUserRepo
    {
        private readonly AirLineDbContext d = new AirLineDbContext();

        //Checks if the admin is verified.
        //matching the provied id password with the existing database
        public string LoginCheck(string Username, string Password)
        {
            var res = d.Users.Where(x => x.Username == Username && x.Password == Password).ToList();
            if (res != null && res.Count == 1)
                return "Logged In";
            else
                return "LogIn Failed";
        }
    }
}
