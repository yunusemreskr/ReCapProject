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


        DetailTest();
        //GetAll();
        //GetByColorId();
        //Add();
        //GetCarsByColorId();
        //BrandAdd();
        //ColorAdd();


        //BrandManager brandManager = new BrandManager(new EfBrandDal());
        //var result = brandManager.GetCarsByBrandId(1);
        //Console.WriteLine(result.Data.BrandName);

        //UserManager userManager = new UserManager(new EfUserDal());
        //userManager.Add(new User {Id=1, FirstName="Yunus Emre" , LastName="Şeker", Email="123yunusemre@gmail.com" , Password="123456789" });
        //var result =userManager.Add(new User {Id=2, FirstName = "İrem", LastName = "Çoban", Email = "merirem123@gmail.com", Password = "987654321" });
        //Console.WriteLine(result.Message);


        //CostumerManager costumerManager = new CostumerManager(new EfCostumerDal());
        //costumerManager.Add(new Costumer{UserId=1 , CompanyName="No211" });

        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        //rentalManager.Add(new Rental {CarId=2, CostumerId=1, Id=1 , RentDate=DateTime.Now, ReturnDate=new DateTime(2023,06,05) });

        var result =rentalManager.GetRentDetails();
        foreach (var rental in result.Data)
        {
            Console.WriteLine(rental.CarId + " / " + rental.BrandName + " / " + rental.FirstName + " / " + rental.LastName + " / " +
                rental.CompanyName + " / " +  rental.ReturnDate);
        }

    }

    private static void ColorAdd()
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());
        var result3 = colorManager.Add(new Color { ColorId = 3, ColorName = "Mavi" });
        if (result3 == null)
        {
            Console.WriteLine(result3);
        }
        else
        {
            Console.WriteLine(result3.Message);
        }
    }

    private static void BrandAdd()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        var result2 = brandManager.Add(new Brand { BrandId = 4, BrandName = "Mercedes" });
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
        foreach (var color in colorManager.GetCarsByColorId(3).Data)
        {
            Console.WriteLine(color.ColorName);
        }
    }

    private static void Add()
    {
        CarManager carManager = new CarManager(new EfCarDal()); 
        var result = carManager.Add(new Car { Id = 7, BrandId = 3, ColorId = 4, DailyPrice = 100000, ModelYear = 2023, Description = "S" });

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
        foreach (var car in carManager.GetCarsByColorId(2).Data)
        {
            Console.WriteLine(car.Description);
        }
    }

    private static void GetAll()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var car in carManager.GetAll().Data)
        {
            Console.WriteLine(car.Description);
        }
    }

    private static void DetailTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var car in carManager.GetCarDetails().Data)
        {
            Console.WriteLine("Marka : " + car.CarName + "-" + car.BrandName + "  " + "Renk : " + car.ColorName + "  " + "Fiyat : " + car.DailyPrice);
        }
    }
}