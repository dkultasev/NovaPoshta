using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data.Entity;
using System.Linq;
using Autofac;
using NovaPoshta.Core;
using NovaPoshta.EF;
using NovaPoshta.Json;
using System.Data.Linq;
using System.Linq.Expressions;

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
            Console.ReadLine();

        }


        public static void EFTest()
        {
            using (var db = GetDb())
            {
                string[] fullNames = { "Anne Williams", "John Fred Smith", "Sue Green" };

                var query = db.Cities.Join(db.Warehouses, c => c.Ref, w => w.CityRef,
                    (c, w) => new {CityName = c.Description, WarehouseName = w.Description}).OrderBy(c => c.CityName).ThenBy(w => w.WarehouseName);


                foreach (var name in query)
                    Console.WriteLine(name.CityName + " ---> " + name.WarehouseName);

            }
        }

        public static Expression<Func<City, bool>> HasWarehousesMoreThan4()
        {
            return p => p.Warehouses.Any() && p.Warehouses.Count > 4;
        }

        public static void AddWarehouse(Guid cityGuid)
        {
            using (var db = GetDb())
            {
                var city = db.Cities.Where(c => c.Ref.Equals(cityGuid)).First();
                new Warehouse()
                {
                    Ref = Guid.NewGuid(),
                    Description = new Random().Next() + "Warehouse",
                    DescriptionRu = new Random().Next() + "Warehouse",
                    Phone = "123",
                    Number = new Random().Next(),
                    City = city
                };


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
                    DescriptionRu = "Odessa2",
                    Area = Guid.NewGuid(),
                    CityId = 1,
                    Delivery1 = 1,
                    Delivery2 = 1,
                    Delivery3 = 1,
                    Delivery4 = 1,
                    Delivery5 = 1,
                    Delivery6 = 1,
                    Delivery7 = 1,
                    Description = "Odessa2"
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
