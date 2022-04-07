using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AirLineReservationServices.Entities
{
    //User Class to store the login details of admins
    [Table("Users")]
    public class User
    {
        [Key] // for initialising as PK
        [Required]
        [Column(TypeName = "int")]
        public int Id { get; set; } //properties for ID

        //Username for admin login
        [Required]
        [StringLength(30)]
        [Column(TypeName = "Varchar")]
        public string Username { get; set; }


        //passowrd for admin login
        [Required]
        [StringLength(30)]
        [Column(TypeName = "Varchar")]
        public string Password { get; set; }

    }
}
