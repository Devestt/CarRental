using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            // Oracle , SQL vs den geliyor gibi.
            _cars = new List<Car> {
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear=2021, Description="BMW marka araba"},
                new Car{CarId=2, BrandId=1, ColorId=1, ModelYear=2020, Description="Audi marka araba"},
                new Car{CarId=3, BrandId=2, ColorId=2, ModelYear=2019, Description="Skoda marka araba"},
                new Car{CarId=4, BrandId=2, ColorId=1, ModelYear=2021, Description="Seat marka araba"},
                new Car{CarId=5, BrandId=2, ColorId=2, ModelYear=2018, Description="Mercedes marka araba"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            // Silerken primary key'i kullanırız id üzerinden
            //Car CarToDelete=null;
            //foreach (var c in _cars)
            //{
            //    if (car.CarId==c.CarId)
            //    {
            //        CarToDelete = c;
            //    }
            //}
            //_cars.Remove(CarToDelete);

            Car CarToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<DetailsDto> GetAllDto()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            CarToUpdate.CarId = car.CarId;
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.Description = car.Description;
        }
    }
}
