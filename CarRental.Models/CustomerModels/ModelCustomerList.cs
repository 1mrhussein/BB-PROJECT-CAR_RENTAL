using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.CustomerModels
{
    public class ModelCustomerList
    {
        [Required]
        [Display(Name ="ID")]
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "NAME")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "PHONE")]
        public int CustomerPhone { get; set; }

        [Required]
        [Display(Name = "ADDRESS")]
        public string CustomerAddress { get; set; }

        [Required]
        [Display(Name = "LISCENCE NO")]
        public int CustomerLiscenceNo { get; set; }

        [Required]
        [Display(Name = "DATE OF BIRTH")]
        public DateTime CustomerDOB { get; set; }

        [Required]
        [Display(Name ="REG. DATE")]
        public DateTimeOffset CustomerRegistredDate { get; set; }

    }
}
