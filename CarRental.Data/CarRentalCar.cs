using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data
{
    //enum CarSize        // Not now, but may be will add
    //{
    //    Small,
    //    Meddium,
    //    Big
    //};

    public class CarRentalCar
    {
        [Key]
        public int CarID { get; set; }
        [Required]
        public string CarModel { get; set; } // Camery, Crolla, etc
        [Required]
        public int CarSize { get; set; }    // No of seats: 2, 4, 7
        public bool CarIsAvailable { get; set; }
        public int CarYear { get; set; }
        public decimal CarPrice { get; set; }
    }
}
