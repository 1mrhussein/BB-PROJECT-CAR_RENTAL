using CarRental.Data;
using CarRental.Models.CarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services
{
    public class CarServices
    {
        public bool CreateCarRentalCar(CarCreate model)
        {
            var carRentalCar = new CarRentalCar()
            {
                CarModel = model.CarModel,
                CarSize = model.CarSize,
                CarYear = model.CarYear,
                CarPrice = model.CarPrice,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CarRentalCars.Add(carRentalCar);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CarRentalList> GetCarList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.CarRentalCars
                    .Select(c=> new CarRentalList
                    {
                        CarID = c.CarID,
                        CarModel = c.CarModel,
                        CarSize = c.CarSize,
                        CarIsAvailable = c.CarIsAvailable,
                        CarYear = c.CarYear,
                        CarPrice = c.CarPrice
                    }
                    );
                return query.ToArray();
            }
        }

        public CarRentalDetails GetById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                    .CarRentalCars
                    .FirstOrDefault(c => c.CarID == Id);

                var model = new CarRentalDetails()
                {
                    CarID = entity.CarID,
                    CarModel= entity.CarModel,
                    CarSize = entity.CarSize,
                    CarYear = entity.CarYear,
                    CarIsAvailable = entity.CarIsAvailable,
                    CarPrice = entity.CarPrice
                };

                return model;
            }
        }

        public bool EditCarRentalCar(CarRentalCar model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .CarRentalCars.FirstOrDefault(c => c.CarID == model.CarID);
                {
                    entity.CarID = model.CarID;
                    entity.CarModel = model.CarModel;
                    entity.CarSize = model.CarSize;
                    entity.CarYear = model.CarYear;
                    entity.CarPrice = model.CarPrice;
                }

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCarRentalCar(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CarRentalCars.Single(c => c.CarID == Id);

                ctx.CarRentalCars.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
