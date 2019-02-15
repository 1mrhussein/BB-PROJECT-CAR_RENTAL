using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.CarModels
{
    public class ModelCarList
    {
        [Display(Name = "ID")]
        public int CarID { get; set; }

        [Required]
        public string CarMake { get; set; } // ChevRollet, Tyota, Honda, etc

        [Display(Name ="MODEL")]
        public string CarModel { get; set; } // Camery, Crolla, etc

        [Display(Name = "SIZE")]
        public int CarSize { get; set; }    // No of seats: 2, 4, 7

        [Display(Name = "AVAILABLE")]
        public bool CarIsAvailable { get; set; }

        [Display(Name = "YEAR")]
        public int CarYear { get; set; }

        [Display(Name = "PRICE")]
        public decimal CarPrice { get; set; }


    }
}
