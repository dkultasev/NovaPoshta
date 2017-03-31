using System;
using System.Linq;
using NovaPoshta.Core;
using NovaPoshta.Entity;
using NUnit.Framework;

namespace NovaPoshta.Tests
{
    internal class DocumentTest
    {
        [Test]
        public void Test()
        {
            var counterPartyLogic = new CounterPartyLogic();

            var cpaties = counterPartyLogic.GetCounterpartiesByCity(new Guid("8D5A980D-391C-11DD-90D9-001A92567626"));

            int a = 0;
        }

        [Test]
        public void CreateNewDocumentTest()
        {
            var counterPartyLogic = new CounterPartyLogic();
            var cityLogic = new CityLogic();
            var documentLogic = new DocumentLogic();
            var senderCityRef = cityLogic.GetCityByName("Одесса").Ref;
            var senderRef = counterPartyLogic.GetSenderCounterpartyRef();
            var senderContact = counterPartyLogic.GetCounterpartyFirstContactWithEmail(senderRef).Ref;

            var recipientCityRef = cityLogic.GetCityByName("Киев").Ref;
            var recipientPhone = "0934502712";
            var recipientFirstName = "Вася";
            var recipientLastName = "Пупкин";

            var recipient = counterPartyLogic.CreateConterparty(new CounterParty()
            {
                FirstName = recipientFirstName,
                LastName = recipientLastName,
                Phone = recipientPhone,
                CityRef = recipientCityRef,
                CounterpartyType = "PrivatePerson",
                CounterpartyProperty = "Recipient"
            });

            var document = new Document()
            {
                Ref = null,
                SendersPhone = "380934502711",
                CitySender = senderCityRef,
                ContactSender = senderContact,
                ServiceType = "WarehouseDoors",
                PayerType = "Sender",
                PaymentMethod = "Cash",
                DateTime = DateTime.Now,
                CargoType = "Cargo",
                SeatsAmount = 1,
                Weight = 0.3,
                VolumeGeneral = 0.001,
                Description = "аксесуари до мобільних пристроїв",
                Cost = 123,
                Sender = senderRef.Value,
                SenderAddress = new Guid("5A39E590-E1C2-11E3-8C4A-0050568002CF"),
                CityRecipient = recipientCityRef,
                Recipient = recipient.Ref.Value,
                RecipientAddress = new Guid("7B422FA4-E1B8-11E3-8C4A-0050568002CF"),
                ContactRecipient = recipient.ContactPerson.data[0].Ref.Value,
                RecipientsPhone = recipientPhone
            };
            var result = documentLogic.CreateInternetDocument(document);
            Assert.Greater(result.CostOnSite, 1);
        }

        [Test]
        public void GetDocumentByTTNTest()
        {
            var documentLogic = new DocumentLogic();
            var ttn = "20450037372708";
            var result = documentLogic.GetDocumentByTTN(ttn);

            Assert.AreEqual(result.IntDocNumber, ttn);
        }
    }
}
