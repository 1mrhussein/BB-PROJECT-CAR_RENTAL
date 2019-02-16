using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.CustomerModels
{
    public class ModelCustomerCreate
    {
        [Required]
        [Display(Name = "ID")]
        public int CustomerID { get; set; }

        [Required]
        [Display(Name ="Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name ="Phone")]
        public int CustomerPhone { get; set; }

        [Required]
        [Display(Name ="Address")]
        public string CustomerAddress { get; set; }

        [Required]
        [Display(Name ="Liscence No")]
        public int CustomerLiscenceNo { get; set; }

        [Required]
        [Display(Name ="Date of Birth")]
        public DateTime CustomerDOB { get; set; }

       
        [Display(Name ="Registed Date")]
        public string CustomerRegistredDate { get; set; }

    }
}
