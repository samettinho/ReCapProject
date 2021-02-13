using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

        A:
            int istenenIslem = 0;
            Console.WriteLine("\n1-)Yeni bir araba ekleme" +
                              "\n2-)Bütün Arabaları Listeleme" +
                              "\n3-)RenkId'ye Göre Arabaları Listeleme" +
                              "\n4-)BrandId'ye Göre Arabaları Listeleme"+
                              "\n5-)Markaları Listeleme" +
                              "\n6-)Renkleri Listeleme"+
                              "\n7-)Yeni bir renk ekleme" +
                              "\n8-)Yeni bir marka ekleme" );
            Console.Write("Yapmak İstediğiniz İşlemin Numarasını Giriniz:");
            try
            {
                istenenIslem = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Lütfen belirtilenlerden başka bir şey girmeyin...");
                goto A;
            }

            switch (istenenIslem)
            {
                case 1:
                    {
                        Car addedCar = new Car();

                        Console.Write("\nBrandId giriniz:");
                        addedCar.BrandId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("RenkId giriniz:");
                        addedCar.ColorId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Günlük Fiyat giriniz:");
                        addedCar.DailyPrice = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Araba İsmi giriniz:");
                        addedCar.Description = (Console.ReadLine());

                        Console.Write("Model Yılı giriniz:");
                        addedCar.ModelYear = (short)Convert.ToUInt32(Console.ReadLine());

                        carManager.Add(addedCar);
                        break;
                    }

                case 2:
                    {
                        foreach (var car in carManager.GetCarDetails())
                        {
                            Console.WriteLine(car.BrandName+" "+ car.Description+" "+car.ColorName+" "+car.DailyPrice);
                        }
                        break;
                    }

                case 3:
                    {

                        Console.Write("RenkId giriniz:");

                        foreach (var car in carManager.GetCarsByColorId(Convert.ToInt32(Console.ReadLine())))
                        {
                            Console.WriteLine(car.Description);
                        }
                        break;
                    }

                case 4:
                    {
                        Console.Write("BrandId giriniz:");

                        foreach (var car in carManager.GetCarsByBrandId(Convert.ToInt32(Console.ReadLine())))
                        {
                            Console.WriteLine(car.Description);
                        }
                        break;
                    }
                case 5:
                    {
                        foreach (var brand in brandManager.GetAll())
                        {
                            Console.WriteLine(brand.BrandName);
                        }
                        break;
                    }
                case 6:
                    {
                        foreach (var color in colorManager.GetAll())
                        {
                            Console.WriteLine(color.ColorName);
                        }
                        break;
                    }
                case 7:
                    {
                        Color addedColor = new Color();

                        Console.Write("\n Renk adı giriniz:");
                        addedColor.ColorName = Console.ReadLine();

                        colorManager.Add(addedColor);
                        break;
                    }
                case 8:
                    {
                        Brand addedBrand = new Brand();

                        Console.Write("\n Marka adı giriniz:");
                        addedBrand.BrandName = Console.ReadLine();

                        brandManager.Add(addedBrand);
                        break;
                    }
                
               
            }

            Console.Write("\nDevam Etmek için 1'e çıkmak için 2'ye basınız:");
            istenenIslem = Convert.ToInt32(Console.ReadLine());
            switch (istenenIslem)
            {
                case 1:
                    {
                        goto A;
                    }
                case 2:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
        }
    }
}
