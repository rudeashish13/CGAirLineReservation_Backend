using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservationServices.Entities;

namespace AirLineReservationServices.Repositories
{
    public class UserRepo: IUserRepo
    {
        //public AirLineDbContext d = new AirLineDbContext();

        //public UserRepo(AirLineDbContext d)
        //{
        //    this.d = d;
        //}

        public string Login(string Username, string Password)
        {
            throw new NotImplementedException();
        }
        
    }
}
