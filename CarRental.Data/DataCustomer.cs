using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data
{
    public class DataCustomer
    {
        [Key]
        [Required]
        public int CustomerID { get; set; }

        [Required]
        public string  CustomerName { get; set; }

        [Required]
        public int CustomerPhone { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        public int CustomerLiscenceNo { get; set; }

        [Required]
        public DateTime CustomerDOB { get; set; }

        [Required]
        public DateTimeOffset CustomerRegistredDate { get; set; }
    }
}
