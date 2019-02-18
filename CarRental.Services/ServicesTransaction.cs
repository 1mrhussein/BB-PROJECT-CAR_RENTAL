using CarRental.Data;
using CarRental.Models.CarModels;
using CarRental.Models.CustomerModels;
using CarRental.Models.TransactionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services
{
    public class ServicesTransaction
    {
        public bool STransactionCreate(ModelTransactionCreate model)
        {
            var transactionCreate = new DataTransaction()
            {
                TransID = model.TransID,
                TransDate = DateTime.Now,
                PickUpDate = model.PickUpDate,
                RetunrDate = model.RetunrDate,
                RentalAmount = CalculateRentAmount(model.RentalAmount, model.PickUpDate, model.RetunrDate), 
                //CustomerIsRegistred=true,
                //CarIsAvailable=true,
                CustomerID = model.CustomerID, // from the method
                CarID = model.CarID
            };

            using (var ctx = new ApplicationDbContext())
            {
              //  Check if car ID does not exist in DB, then give decision
                var car = ctx.DataCars.FirstOrDefault(c => c.CarID == transactionCreate.CarID);
                if (car == null) return false;

                car.CarIsAvailable = false;

                ctx.DataTransactions.Add(transactionCreate);
                return ctx.SaveChanges() == 2;
            }
        }

        public IEnumerable<ModelTransactionList> SGListTransaction()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .DataTransactions.Select(t => new ModelTransactionList
                    {
                        TransID=t.TransID,
                        TransDate=t.TransDate,
                        PickUpDate=t.PickUpDate,
                        RetunrDate=t.RetunrDate,
                        RentalAmount=t.RentalAmount,
                        CustomerID=t.CustomerID,
                        CarID=t.CarID
                    }
                    );
                return query.ToArray();
            }
        }

        // Calculate rent based on number of days and rental amount
        private decimal CalculateRentAmount(decimal RentPrice, DateTime dPickup, DateTime dReturn)
        {
            //var dt = new ModelTransactionCreate();

            //DateTime PickUp = (dt.PickUpDate);
            //DateTime Return = (dt.RetunrDate);

            TimeSpan TRDays = dReturn - dPickup;

            var days = Convert.ToDouble(TRDays.Days);
            var hours = Convert.ToDouble(TRDays.Hours) / 24;
            var minutes = Convert.ToDouble(TRDays.Minutes) / 1440;
            var seconds = Convert.ToDouble(TRDays.Seconds) / 86400;

            var TotalDay = days + hours + minutes + seconds;

            decimal Total = Convert.ToDecimal(TotalDay) * RentPrice;

            return Total;
        }
    }
}
