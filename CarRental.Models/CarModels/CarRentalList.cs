using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.CarModels
{
    public class CarRentalList
    {
        public int CarID { get; set; }

        public string CarModel { get; set; } // Camery, Crolla, etc

        public int CarSize { get; set; }    // No of seats: 2, 4, 7

        public bool CarIsAvailable { get; set; }

        public int CarYear { get; set; }

        public decimal CarPrice { get; set; }
    }
}
