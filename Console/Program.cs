using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager productManager= new ProductManager(new InMemoryProductDal());
        foreach (Car car in productManager.GetAll())
        {
            Console.WriteLine(car.Description+ " : " +car.DailyPrice + " TL");
        }

        IProductDal productDal = new InMemoryProductDal();

        Console.WriteLine("----------------------------------------------------");

        productDal.GetById(3).ForEach(car => Console.WriteLine("Model Açıklaması: " + car.Description));

        Console.WriteLine("----------------------------------------------------");

        productDal.GetAll().ForEach(car => Console.WriteLine(car.Description));


    }
}