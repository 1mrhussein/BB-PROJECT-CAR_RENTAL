using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.TransactionModels
{
    public class ModelTransactionList
    {
        [Required]
        [Display(Name ="ID")]
        public int TransID { get; set; }

        [Required]
        [Display(Name ="Transaction Date")]
        public DateTimeOffset TransDate { get; set; }

        [Required]
        [Display(Name ="Pick Up Date")]
        public DateTimeOffset PickUpDate { get; set; }

        [Required]
        [Display(Name ="Return Date")]
        public DateTimeOffset RetunrDate { get; set; }

        [Required]
        [Display(Name ="Rental Amount")]
        public decimal RentalAmount { get; set; }

        [Display(Name ="Car ID")]
        public int CarID { get; set; }

        [Display(Name ="Customer ID")]
        public int CustomerID { get; set; }

            // Note necassery to have customer name in here
        //[Display(Name ="Customer Name")]
        //public string CustomerName { get; set; }

    }
}
