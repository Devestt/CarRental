using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tests();
            //AddedCar();
            //DeletedCar();
            //AddedBrand();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAllDto())
            {
                Console.WriteLine(car.CarId + "\t" + car.BrandName + "\t" + car.ColorName);
            }

            CarManager carManager1 = new CarManager(new EfCarDal());
            
            Console.WriteLine(carManager1.GetById(1).Description);
            


        }

        private static void AddedBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 5, BrandName = "yeni brand" });
        }

        private static void DeletedCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { CarId = 6, ColorId = 1, BrandId = 2, DailyPrice = 1500, Description = "Harika araba", ModelYear = 2021 });
        }

        private static void AddedCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { CarId = 6, ColorId = 1, BrandId = 2, DailyPrice = 1500, Description = "Harika araba", ModelYear = 2021 });
        }

        private static void Tests()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " " + car.Description);
            }
            Console.WriteLine("-----------------------------------");

            CarManager carManager1 = new CarManager(new EfCarDal());
            foreach (var car in carManager1.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.CarId + " " + car.Description);
            }
            Console.WriteLine("-----------------------------------");

            CarManager carManager3 = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                //Console.WriteLine("Id= " + car.CarId);
                Console.WriteLine(car.Description + car.ColorId);
            }
            Console.WriteLine("-----------------------------------");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                //Console.WriteLine("Id= " + car.CarId);
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
            Console.WriteLine("-----------------------------------");
            CarManager carManager4 = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                //Console.WriteLine("Id= " + car.CarId);
                Console.WriteLine(car.CarId + " " + car.BrandName);
            }
            Console.WriteLine("-----------------------------------");
        }
    }
}
