using Business.Concrete;
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

        GetByColorId();

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