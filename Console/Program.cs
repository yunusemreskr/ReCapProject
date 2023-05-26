using Business.Concrete;
using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        //CarManager productManager = new CarManager(new EfCarDal());
        //foreach (var item in productManager.GetAll())
        //{
        //    Console.WriteLine(item.Description + " : " + item.DailyPrice + " TL");
        //}

        //ICarDal carDal = new EfCarDal();

        //Console.WriteLine("----------------------------------------------------");

        //carDal.GetAll().ForEach(car => Console.WriteLine("Marka : " + car.Description + "   " + "Model Yılı: " + car.ModelYear));

        //Console.WriteLine("----------------------------------------------------");


        //DetailTest();
        //GetAll();
        //GetByColorId();
        //Add();
        //GetCarsByColorId();


        BrandAdd();

    }

    private static void BrandAdd()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        var result2 = brandManager.Add(new Brand { BrandId = 10, BrandName = "Honda" });
        if (result2.Success == false)
        {
            Console.WriteLine(result2.Message);
        }
        else
        {
            Console.WriteLine(result2.Message);
        }
    }

    private static void GetCarsByColorId()
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());
        foreach (var color in colorManager.GetCarsByColorId(3))
        {
            Console.WriteLine(color.ColorName);
        }
    }

    private static void Add()
    {
        CarManager carManager = new CarManager(new EfCarDal()); 
        var result = carManager.Add(new Car { Id = 7, BrandId = 3, ColorId = 4, DailyPrice = 0, ModelYear = 2023, Description = "Sssss" });

        if (result.Success == false)
        {
            Console.WriteLine(result.Message);

        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }

    private static void GetByColorId()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var car in carManager.GetCarsByColorId(2))
        {
            Console.WriteLine(car.Description);
        }
    }

    private static void GetAll()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var car in carManager.GetAll())
        {
            Console.WriteLine(car.Description);
        }
    }

    private static void DetailTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var car in carManager.GetCarDetails())
        {
            Console.WriteLine("Marka : " + car.CarName + "-" + car.BrandName + "  " + "Renk : " + car.ColorName + "  " + "Fiyat : " + car.DailyPrice);
        }
    }
}