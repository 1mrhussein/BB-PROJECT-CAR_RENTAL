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
                RentalAmount = model.RentalAmount, // Calculate in a method later
                CustomerIsRegistred=true,
                CarIsAvailable=true,
                CustomerID = model.CustomerID, // from the method
                CarID = model.CarID
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.DataTransactions.Add(transactionCreate);
                return ctx.SaveChanges() == 1;
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
    }
}
