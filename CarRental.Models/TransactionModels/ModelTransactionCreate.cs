using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.TransactionModels
{
    public class ModelTransactionCreate
    {
        public int TransID { get; set; }

        public DateTimeOffset TransDate { get; set; }

        [Required]
        public DateTime PickUpDate { get; set; }

        [Required]
        public DateTime RetunrDate { get; set; }

        public decimal RentalAmount { get; set; }

        //public bool CarIsAvailable { get; set; }      // U just check, not create

        //public bool CustomerIsRegistred { get; set; } // U just check not create

        public int CarID { get; set; }
        public int CustomerID { get; set; }

    }
}
