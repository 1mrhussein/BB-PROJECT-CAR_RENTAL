using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.TransactionModels
{
    public class ModelTransactionEdit
    {
        public DateTimeOffset TransDate { get; set; }

        [Required]
        public DateTimeOffset PickUpDate { get; set; }

        [Required]
        public DateTimeOffset RetunrDate { get; set; }

        public decimal RentalAmount { get; set; }

        public int CarID { get; set; }
        public int CustomerID { get; set; }

    }
}
