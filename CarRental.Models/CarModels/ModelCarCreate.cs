using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.CarModels
{
    public class ModelCarCreate
    {
        [Required]
        [Display(Name ="Model")]
        public string CarModel { get; set; }

        [Required]
        public string CarMake { get; set; }

        [Required]
        [Display(Name = "Size")]
        public int CarSize { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int CarYear { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal CarPrice { get; set; }

        public bool CarIsAvailable { get; set; }

    }
}
