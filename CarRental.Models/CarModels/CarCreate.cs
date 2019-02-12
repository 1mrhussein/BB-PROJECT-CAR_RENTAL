using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.CarModels
{
    public class CarCreate
    {
        [Required]
        public string CarMake { get; set; }

        [Required]
        public string CarModel { get; set; }

        [Required]
        public int CarSize { get; set; }

        [Required]
        public int CarYear { get; set; }

        [Required]
        public decimal CarPrice { get; set; }
    }
}
