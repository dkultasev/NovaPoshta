using System;
using System.Collections.Generic;
using System.Linq;
using NovaPoshta.Core;
using NovaPoshta.Json;
using NUnit.Framework;
using RestSharp;

namespace NovaPoshta.Tests
{
    internal class DocumentTest
    {
        private readonly IJsonLogic _jsonLogic = new JsonLogic(new RestClient(), new NovaPoshtaConfig().GetCfg());

        [Test]
        public void CreateNewDocumentTest()
        {
            var documentLogic = new DocumentLogic(_jsonLogic);
            var document = CreateSimpleDoument();
            var result = documentLogic.CreateInternetDocument(document);
            Assert.Greater(result.CostOnSite, 1);
        }

        [Test]
        public void CreateNewCashOnDeliveryDocumentTest()
        {
            var documentLogic = new DocumentLogic(_jsonLogic);
            var document = CreateSimpleDoument();


            var record = new BackwardDeliveryData()
            {
                PayerType = "Recipient",
                CargoType = "Money",
                RedeliveryString = document.Cost.ToString()
            };


            document.BackwardDeliveryData = new List<BackwardDeliveryData> {record};

            var result = documentLogic.CreateInternetDocument(document);
            Assert.Greater(result.CostOnSite, 1);
        }

        private Document CreateSimpleDoument()
        {
            var counterPartyLogic = new CounterPartyLogic(_jsonLogic);
            var cityLogic = new CityLogic(_jsonLogic);

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
            var documentLogic = new DocumentLogic(_jsonLogic);
            var ttn = "20450037372708";
            var result = documentLogic.GetDocumentByTTN(ttn);

            Assert.AreEqual(result.IntDocNumber, ttn);
        }

        [Test]
        public void UpdateTTNTest()
        {
            var documentLogic = new DocumentLogic(_jsonLogic);
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
