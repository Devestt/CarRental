using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;
        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length>2 && car.DailyPrice>0)
                {
                    _iCarDal.Add(car);
                    Console.WriteLine("Araba başarıyla eklendi" + " " + car.Description);
                }
            else
                {
                    Console.WriteLine("Araba ekleme işlemi başarısız.");
                }
            
        }

        public void Delete(Car car)
        {
            _iCarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            // Bir iş sınıfı başka sınıfı newlemez.
            // Buralarda if kodları vs vs olur.

            return _iCarDal.GetAll();
            
        }

        public List<DetailsDto> GetAllDto()
        {
            return _iCarDal.GetAllDto();
        }

        public Car GetById(int carId)
        {
            return _iCarDal.Get(p => p.CarId == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _iCarDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _iCarDal.GetAll(p => p.CarId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _iCarDal.GetAll(p => p.CarId == id);
        }

        public void Update(Car car)
        {
             _iCarDal.Update(car);
        }
    }
}
