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
        CarManager productManager= new CarManager(new EfCarDal());
        foreach (var car in productManager.GetAll())
        {
            Console.WriteLine(car.Description+ " : " +car.DailyPrice + " TL");
        }

        //ICarDal carDal = new EfCarDal();

        Console.WriteLine("----------------------------------------------------");

        //productDal.GetById(3).ForEach(car => Console.WriteLine("Model Açıklaması: " + car.Description));

        Console.WriteLine("----------------------------------------------------");

        //carDal.GetAll().ForEach(car => Console.WriteLine(car.Description));


    }
}