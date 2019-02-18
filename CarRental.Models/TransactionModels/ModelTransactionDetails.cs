using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// add customer name in the details
namespace CarRental.Models.TransactionModels
{
    public class ModelTransactionDetails
    {
        [Required]
        public int TransID { get; set; }

        public DateTimeOffset TransDate { get; set; }

        [Required]
        public DateTime PickUpDate { get; set; }

        [Required]
        public DateTime RetunrDate { get; set; }

        public decimal RentalAmount { get; set; }

        public int CarID { get; set; }
        public int CustomerID { get; set; }
    }
}
