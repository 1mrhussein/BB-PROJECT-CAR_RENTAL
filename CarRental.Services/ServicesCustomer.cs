using CarRental.Data;
using CarRental.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services
{
    public class ServicesCustomer
    {
        public bool SCustomerCreate(ModelCustomerCreate model)
        {
            var custCreate = new DataCustomer()
            {
                CustomerID = model.CustomerID,
                CustomerName = model.CustomerName,
                CustomerPhone = model.CustomerPhone,
                CustomerAddress = model.CustomerAddress,
                CustomerLiscenceNo = model.CustomerLiscenceNo,
                CustomerDOB = model.CustomerDOB,
                CustomerRegistredDate = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.DataCustomers.Add(custCreate);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ModelCustomerList> SGetListCustomer()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.DataCustomers.Select(c => new ModelCustomerList
                {
                    CustomerID = c.CustomerID,
                    CustomerName = c.CustomerName,
                    CustomerPhone = c.CustomerPhone,
                    CustomerAddress = c.CustomerAddress,
                    CustomerLiscenceNo = c.CustomerLiscenceNo,
                    CustomerDOB = c.CustomerDOB,
                    CustomerRegistredDate = c.CustomerRegistredDate
                }
                );
                return query.ToArray();
            }
        }

        public ModelCustomerDetails SGetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .DataCustomers
                    .FirstOrDefault(c => c.CustomerID == id);

                var model = new ModelCustomerDetails()
                {
                    CustomerID=entity.CustomerID,
                    CustomerName=entity.CustomerName,
                    CustomerPhone=entity.CustomerPhone,
                    CustomerAddress=entity.CustomerAddress, 
                    CustomerLiscenceNo=entity.CustomerLiscenceNo,
                    CustomerDOB=entity.CustomerDOB
                };

                return model;
            }
        }

        public bool SCustomerUpdate(ModelCustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .DataCustomers
                    .FirstOrDefault(c => c.CustomerID == model.CustomerID);

                entity.CustomerID = model.CustomerID;
                entity.CustomerName = model.CustomerName;
                entity.CustomerPhone = model.CustomerPhone;
                entity.CustomerAddress = model.CustomerAddress;
                entity.CustomerLiscenceNo = model.CustomerLiscenceNo;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool SCustomerDelete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                    .DataCustomers
                    .Single(c => c.CustomerID == id);

                ctx.DataCustomers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
