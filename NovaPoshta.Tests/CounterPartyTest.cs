using System;
using System.Linq;
using NovaPoshta.Core;
using NovaPoshta.Entity;
using NovaPoshta.Json;
using NUnit.Framework;
using RestSharp;

namespace NovaPoshta.Tests
{
    public class CounterPartyTest
    {
        private readonly IJsonLogic _jsonLogic = new JsonLogic(new RestClient(), new NovaPoshtaConfig().GetCfg());

        [Test]
        public void GetSenderContactPersonsByRefTest()
        {
            var cl = new CounterPartyLogic(_jsonLogic);
            var result = cl.GetCounterpartyContactPersonsByCounterpartyRef(new Guid("361ce04b92c711e6a54a005056801333"));
            Assert.Greater(result.Count(), 0);
        }

        [Test]
        public void GetSenderRefTest()
        {
            var cl = new CounterPartyLogic(_jsonLogic);
            var result = cl.GetSenderCounterpartyRef();
            Assert.AreEqual(result, new Guid("361ce04b92c711e6a54a005056801333"));
        }

        [Test]
        public void GetRecipientCounterPartyTest()
        {
            var cl = new CounterPartyLogic(_jsonLogic);
            var result = cl.GetReciepentCounterParties();
            Assert.AreEqual(result.FirstOrDefault().OwnershipFormDescription, "Фізична особа");
        }

        [Test]
        public void GetCounterPartyContactPersonsTest()
        {
            var cl = new CounterPartyLogic(_jsonLogic);
            var result = cl.GetCounterpartyContactPersonsByCounterpartyRef(new Guid("f5cb6305-37a8-11e6-a54a-005056801333")).Count();
            Assert.Greater(result, 10);
        }

        [Test]
        public void CreateCounterPartyTest()
        {
            var cl = new CounterPartyLogic(_jsonLogic);
            var result = cl.CreateConterparty(new CounterParty()
            {
                CityRef = new Guid("db5c88d7-391c-11dd-90d9-001a92567626"),
                FirstName = "Фелікс",
                MiddleName = "Едуардович",
                LastName = "Яковлєв",
                Phone = "0997979789",
                Email = "",
                CounterpartyType = "PrivatePerson",
                CounterpartyProperty = "Recipient"
            });

            Assert.AreEqual(result.FirstName, "Фелікс");
        }

        [Test]
        public void UpdateCounterPartyTest()
        {
            var cl = new CounterPartyLogic(_jsonLogic);
            var insertedCounterParty = cl.CreateConterparty(new CounterParty()
            {
                CityRef = new Guid("db5c88d7-391c-11dd-90d9-001a92567626"),
                FirstName = "Фелікс",
                MiddleName = "Едуардович",
                LastName = "Яковлєв",
                Phone = "0997979789",
                Email = "",
                CounterpartyType = "PrivatePerson",
                CounterpartyProperty = "Recipient"
            });

            insertedCounterParty.FirstName = "Фелікс2";
            insertedCounterParty.CityRef = new Guid("db5c88d7-391c-11dd-90d9-001a92567626");
            insertedCounterParty.Phone = "0997979789";

            var result = cl.UpdateConterparty(insertedCounterParty);

            Assert.AreEqual(result.FirstName, "Фелікс2");
        }

        [Test]
        public void DeleteCounterPartyTest()
        {
            var cl = new CounterPartyLogic(_jsonLogic);
            var insertedCounterParty = cl.CreateConterparty(new CounterParty()
            {
                CityRef = new Guid("db5c88d7-391c-11dd-90d9-001a92567626"),
                FirstName = "Фелікс",
                MiddleName = "Едуардович",
                LastName = "Яковлєв",
                Phone = "0997979789",
                Email = "",
                CounterpartyType = "PrivatePerson",
                CounterpartyProperty = "Recipient"
            });

            insertedCounterParty.FirstName = "Фелікс2";
            insertedCounterParty.CityRef = new Guid("db5c88d7-391c-11dd-90d9-001a92567626");
            insertedCounterParty.Phone = "0997979789";
            var result = cl.DeleteConterparty(insertedCounterParty.Ref.Value);
            Assert.AreEqual(result.Ref.Value, insertedCounterParty.Ref.Value);
            Assert.AreEqual(result.FirstName, null);
        }

        [Test]
        public void DeleteNonExistingCounterPartyTest()
        {
            var cl = new CounterPartyLogic(_jsonLogic);
            Assert.That(() => cl.DeleteConterparty(new Guid("db5c88d7-391c-11dd-90d9-001a92567626")),
            Throws.TypeOf<ArgumentException>());
        }

    }
}
