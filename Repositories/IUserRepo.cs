﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservationServices.Entities;

namespace AirLineReservationServices.Repositories
{
    public interface IUserRepo
    {
        string LoginCheck(string Username, string Password);
    }
}
