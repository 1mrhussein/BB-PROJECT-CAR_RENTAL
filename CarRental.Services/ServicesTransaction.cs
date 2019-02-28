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
        // Create Transaction 
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
                CarID = model.CarID, 
                
            };

            using (var ctx = new ApplicationDbContext())
            {
              //  Pull out the car In Transaction Process and Set Availablity to False afte transaction 
                var car = ctx.DataCars.FirstOrDefault(c => c.CarID == transactionCreate.CarID);

                car.CarIsAvailable = false;

                ctx.DataTransactions.Add(transactionCreate);
                return ctx.SaveChanges() == 2;
            }
        }

        // List All Transactions
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
                        //CustomerID=t.CustomerID,
                        //CarID=t.CarID,
                        CustomerName=t.DataCustomer.CustomerName,
                        CarModel = t.DataCar.CarModel
                    }
                    );
                return query.ToArray();
            }
        }

        // Get TransactionById-----Details
        public ModelTransactionDetails SGetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .DataTransactions
                    .FirstOrDefault(t => t.TransID == id);

                var model = new ModelTransactionDetails()
                {
                    TransID= entity.TransID,
                    PickUpDate = entity.PickUpDate,
                    RetunrDate = entity.RetunrDate,
                    CarID=entity.CarID,
                    RentalAmount = entity.RentalAmount,
                    CustomerID=entity.CustomerID,
                };

                return model;
            }
        }

        // Edit Transaction 
        public bool STransactionUpdate(ModelTransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.DataTransactions.FirstOrDefault(t => t.TransID == model.TransID);

                entity.PickUpDate = model.PickUpDate;
                entity.RetunrDate = model.RetunrDate;
                entity.CarID = model.CarID;

                entity.RentalAmount = CalculateRentAmount(model.RentalAmount, model.PickUpDate, model.RetunrDate);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool STransactionDelete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .DataTransactions
                    .Single(t => t.TransID == id);

                ctx.DataTransactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        // Calculate rent based on number of days and rental amount
        private decimal CalculateRentAmount(decimal RentPrice, DateTime dPickup, DateTime dReturn)
        {
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
