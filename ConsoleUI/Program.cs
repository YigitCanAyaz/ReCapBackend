using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class Program
    {
        private static Car car = new Car();
        private static Brand brand = new Brand();
        private static Color color = new Color();

        private static CarManager carManager = new CarManager(new EfCarDal());
        private static BrandManager brandManager = new BrandManager(new EfBrandDal());
        private static ColorManager colorManager = new ColorManager(new EfColorDal());
        static void Main(string[] args)
        {
            Brand brand1 = new Brand() { Name = "BMW" };
            Brand brand2 = new Brand() { Name = "Nissan" };
            Brand brand3 = new Brand() { Name = "Ferrari" };

            Color color1 = new Color() { Name = "Beyaz" };
            Color color2 = new Color() { Name = "Siyah" };
            Color color3 = new Color() { Name = "Gri" };

            Car car1 = new Car() { BrandId = 3, ColorId = 2, ModelYear = 2017, DailyPrice = 50350.30, Description = "S" };
            Car car2 = new Car() { BrandId = 1, ColorId = 1, ModelYear = 2011, DailyPrice = 0, Description = "Gıcır Gıcır Araba" };
            Car car3 = new Car() { BrandId = 2, ColorId = 3, ModelYear = 2008, DailyPrice = 40103.35, Description = "Tertemiz" };
            Car car4 = new Car() { Id = 4, BrandId = 2, ColorId = 1, ModelYear = 2019, DailyPrice = 100000.90, Description = "Garantisi Var" };
            Car car5 = new Car() { Id = 5, BrandId = 3, ColorId = 4, ModelYear = 2022, DailyPrice = 685330, Description = "Airbag Açılmıştır" };
            Car car6 = new Car() { Id = 6, BrandId = 1, ColorId = 6, ModelYear = 2014, DailyPrice = 50500, Description = "Yerli Araba" };

            Brand updatedBrand1 = new Brand() { Id = 1, Name = "Bmw" };

            //brandManager.Add(brand1);
            //brandManager.Add(brand2);
            //brandManager.Add(brand3);
            //brandManager.Update(updatedBrand1);

            //colorManager.Add(color1);
            //colorManager.Add(color2);
            //colorManager.Add(color3);

            //carManager.Add(car1);
            //carManager.Add(car2);
            //carManager.Add(car3);

            //var cars = carManager.GetCarsByBrandId(2);

            //PrintCars(cars);


            //Console.WriteLine(carManager.GetAll());
            //Console.WriteLine(carManager.GetById());
            //carManager.Add();
            //carManager.Update();
            //carManager.Delete();

            // Car updatedCar = new Car() { Id = 2, BrandId = 1, ColorId = 5, ModelYear = 2011, DailyPrice = 87000.10, Description = "Gıcır Gıcır Araba" };

            //PrintCars(carManager.GetAll());
            //PrintCar(carManager.GetById(1));
            //carManager.Add(car1);
            //carManager.Add(car2);
            //PrintCars(carManager.GetAll());
            //PrintCar(carManager.GetById(1));
            //carManager.Delete(car1);
            //PrintCars(carManager.GetAll());
            //PrintCars(carManager.GetAll());
            //carManager.Update(updatedCar);
            //PrintCar(carManager.GetById(1));
            //PrintCar(carManager.GetById(2));

            PrintCarDetails(carManager.GetCarDetails());


            //Car newCar = new Car() { BrandId = 1, ColorId = 3, Name = "Viviano", ModelYear = 2011, DailyPrice = 87000.10, Description = "Gıcır Gıcır Araba" };
            //carManager.Add(newCar);

        }

        // Car Test

        private static void PrintCars(List<Car> listOfCars)
        {
            foreach (var car in listOfCars)
            {
                PrintCar(car);
            }
        }

        private static void PrintCar(Car singleCar)
        {
            Console.WriteLine("Car Id: " + singleCar?.Id);
            Console.WriteLine("Car Brand Id: " + singleCar?.BrandId);
            Console.WriteLine("Car Color Id: " + singleCar?.ColorId);
            Console.WriteLine("Car Model Year: " + singleCar?.ModelYear);
            Console.WriteLine("Car Daily Price: " + singleCar?.DailyPrice);
            Console.WriteLine("Car Description: " + singleCar?.Description);
            Console.WriteLine("***********************************");
        }

        private static void PrintCarDetails(List<CarDetailDto> listOfCarDetails)
        {
            foreach (var carDetail in listOfCarDetails)
            {
                PrintCarDetail(carDetail);
            }
        }

        private static void PrintCarDetail(CarDetailDto singleCarDetail)
        {
            Console.WriteLine("CarDetail Id: " + singleCarDetail.CarId);
            Console.WriteLine("CarDetail Name: " + singleCarDetail.Name);
            Console.WriteLine("CarDetail Description: " + singleCarDetail.Description);
            Console.WriteLine("CarDetail Model Year: " + singleCarDetail.ModelYear);
            Console.WriteLine("CarDetail Daily Price: " + singleCarDetail.DailyPrice);
            Console.WriteLine("CarDetail Brand Name: " + singleCarDetail.BrandName);
            Console.WriteLine("CarDetail Color Name: " + singleCarDetail.ColorName);
            Console.WriteLine("***********************************");
        }

    }


}
