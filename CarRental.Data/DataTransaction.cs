using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data
{
    public class DataTransaction
    {
        [Key]
        public int TransID { get; set; }

        public DateTimeOffset TransDate { get; set; }

        [Required]
        public DateTimeOffset PickUpDate { get; set; }

        [Required]
        public DateTimeOffset RetunrDate { get; set; }
        [Required]
        public decimal RentalAmount { get; set; }

        public bool CarIsAvailable { get; set; }

        public bool CustomerIsRegistred { get; set; }

        public int CarID { get; set; }
        public int CustomerID { get; set; }

        public virtual DataCustomer DataCustomer { get; set; }
        public virtual DataCar DataCar { get; set; }
    }
}
