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
            var counterPartyLogic = new DictionaryLogic();

            var cpaties = counterPartyLogic.GetDictionary<Dictionary>("CargoTypes");

            int a = 0;
        }

        [Test]
        public void CreateNewDocumentTest()
        {
            var documentLogic = new DocumentLogic();
            var document = CreateSimpleDoument();
            var result = documentLogic.CreateInternetDocument(document);
            Assert.Greater(result.CostOnSite, 1);
        }

        [Test]
        public void CreateNewCashOnDeliveryDocumentTest()
        {
            var documentLogic = new DocumentLogic();
            var document = CreateSimpleDoument();

            var result = documentLogic.CreateInternetDocument(document);
            Assert.Greater(result.CostOnSite, 1);
        }

        private static Document CreateSimpleDoument()
        {
            var counterPartyLogic = new CounterPartyLogic();
            var cityLogic = new CityLogic();
            
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

            return document;
        }

        [Test]
        public void GetDocumentByTTNTest()
        {
            var documentLogic = new DocumentLogic();
            var ttn = "20450037372708";
            var result = documentLogic.GetDocumentByTTN(ttn);

            Assert.AreEqual(result.IntDocNumber, ttn);
        }

        [Test]
        public void UpdateTTNTest()
        {
            var documentLogic = new DocumentLogic();
            var ttn = "20450037372708";
            var document = documentLogic.GetDocumentByTTN(ttn);

            var cost = document.Cost;
            var rnd = new Random();
            var randomPrice = rnd.Next(1, 1000);
            if (cost == randomPrice) randomPrice = rnd.Next(1, 1000);

            document.Cost = randomPrice;
            document.DateTime = DateTime.Now;
            document.PreferredDeliveryDate = null;
            document.SendersPhone = "380934602822";
            document.RecipientsPhone = "380934602823";

            documentLogic.UpdateTTN(document);
            var updatedDocument = documentLogic.GetDocumentByTTN(ttn);

            Assert.AreEqual(updatedDocument.Cost, randomPrice);

        }
    }
}
