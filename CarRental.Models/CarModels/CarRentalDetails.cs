using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.CarModels
{
    public class CarRentalDetails
    {
        [Required]
        public int CarID { get; set; }

        [Required]
        public string CarMake { get; set; } // ChevRollet, Tyota, Honda, etc

        [Required]
        public string CarModel { get; set; } // Camery, Crolla, etc

        [Required]
        public int CarSize { get; set; }    // No of seats: 2, 4, 7

        public int CarYear { get; set; }

        public bool CarIsAvailable { get; set; }

        public decimal CarPrice { get; set; }
    }
}
