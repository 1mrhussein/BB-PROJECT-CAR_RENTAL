using CarRental.Data;
using CarRental.Models.CarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services
{
    public class ServicesCar
    {
        public bool SCarCreate(ModelCarCreate model)
        {
            var carRentalCar = new DataCar()
            {
                CarMake = model.CarMake,
                CarModel = model.CarModel,
                CarSize = model.CarSize,
                CarYear = model.CarYear,
                CarPrice = model.CarPrice,
                CarIsAvailable = true

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.DataCars.Add(carRentalCar);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ModelCarList> SGetListCar()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.DataCars
                    .Select(c => new ModelCarList
                    {
                        CarID = c.CarID,
                        CarMake = c.CarMake,
                        CarModel = c.CarModel,
                        CarSize = c.CarSize,
                        CarIsAvailable = c.CarIsAvailable,
                        CarYear = c.CarYear,
                        CarPrice = c.CarPrice,

                    }
                    );
                return query.ToArray();
            }
        }

        public ModelCarDetails SGetCarById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .DataCars
                    .FirstOrDefault(c => c.CarID == Id);

                var model = new ModelCarDetails()
                {
                    CarID = entity.CarID,
                    CarMake = entity.CarMake,
                    CarModel = entity.CarModel,
                    CarSize = entity.CarSize,
                    CarYear = entity.CarYear,
                    CarIsAvailable = entity.CarIsAvailable,
                    CarPrice = entity.CarPrice,
                };

                return model;
            }
        }

        public bool SCarUpdate(ModelCarEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .DataCars.FirstOrDefault(c => c.CarID == model.CarID);

                entity.CarMake = model.CarMake;
                entity.CarModel = model.CarModel;
                entity.CarSize = model.CarSize;
                entity.CarYear = model.CarYear;
                entity.CarPrice = model.CarPrice;
                entity.CarIsAvailable = model.CarIsAvailable;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool SCarDelete(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.DataCars.Single(c => c.CarID == Id);

                ctx.DataCars.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
