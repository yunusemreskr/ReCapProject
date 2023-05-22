using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        CarManager productManager = new CarManager(new EfCarDal());
        foreach (var item in productManager.GetAll())
        {
            Console.WriteLine(item.Description + " : " + item.DailyPrice + " TL");
        }

        ICarDal carDal = new EfCarDal();

        Console.WriteLine("----------------------------------------------------");

        carDal.GetAll().ForEach(car => Console.WriteLine("Model Açıklaması: " + car.Description));

        Console.WriteLine("----------------------------------------------------");

        carDal.GetAll().ForEach(car => Console.WriteLine(car.Description));

        //void GetAll(CarManager carManager1)
        //{
        //    foreach (var item in carManager1.GetAll())
        //    {
        //        Console.WriteLine(item.Description);
        //    }
        //}

        CarManager carManager = new CarManager(new EfCarDal());
        
        Car car = new Car {
            Id=10,
            BrandId = 3,
            ColorId = 2,
            ModelYear = 2023,
            DailyPrice = 452,
            Description = "Renault"
        };

        carManager.Add(car);
        
        



    }
}