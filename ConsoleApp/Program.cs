using System;
using System.Linq;
using Autofac;
using NovaPoshta.Core;
using NovaPoshta.EF;
using NovaPoshta.Json;

namespace ConsoleApp
{
    class Program
    {
        private static NovaPoshtaContext context;
        static void Main(string[] args)
        {
            //var container = CompositionRoot.Init();
            //var jsonLogic = container.Resolve<IJsonLogic>();


            //AddCity();
            //AddWarehouse(GetCityGuid());
            EFTest();
        }


        public static void EFTest()
        {
            using (var db = GetDb())
            {
                var cities = db.Cities.First();
                foreach (var w in cities.Warehouses)
                {
                    Console.WriteLine(w.Description);
                }
            }
            Console.ReadLine();
        }

        public static void AddWarehouse(Guid cityGuid)
        {
            using (var db = GetDb())
            {
                db.Warehouses.Add(new Warehouse()
                {
                    Ref = Guid.NewGuid(),
                    FK_CityRef = cityGuid,
                    Description = new Random().Next() + "Warehouse",
                    DescriptionRu = new Random().Next() + "Warehouse",
                    Phone = "123",
                    Number = new Random().Next()
                });
                db.SaveChanges();
            }
        }

        public static Guid GetCityGuid()
        {
            using (var db = GetDb())
            {
                return db.Cities.Select(n => n.Ref).First();
            }
        }

        public static void AddCity()
        {
            using (var db = GetDb())
            {
                db.Cities.Add(new City()
                {
                    Ref = Guid.NewGuid(),
                    DescriptionRu = "Odessa",
                    Area = Guid.NewGuid(),
                    CityId = 1,
                    Delivery1 = 1,
                    Delivery2 = 1,
                    Delivery3 = 1,
                    Delivery4 = 1,
                    Delivery5 = 1,
                    Delivery6 = 1,
                    Delivery7 = 1,
                    Description = "Odessa"
                });
                db.SaveChanges();
            }
        }

        public static NovaPoshtaContext GetDb()
        {
            return new NovaPoshtaContext();
        }
    }
}
