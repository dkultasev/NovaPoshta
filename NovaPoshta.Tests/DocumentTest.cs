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
        public void CreateNewDocumentTest()
        {
            var counterPartyLogic = new CounterPartyLogic();
            var cityLogic = new CityLogic();
            var documentLogic = new DocumentLogic();
            var senderCityRef = cityLogic.GetCityByName("Одесса").Ref;
            var senderRef = counterPartyLogic.GetSenderCounterpartyRef();

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
                CitySender = senderCityRef, //new Guid("db5c88d0-391c-11dd-90d9-001a92567626"),
                ContactSender = senderRef,
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
                CityRecipient = new Guid("DB5C88D0-391C-11DD-90D9-001A92567626"),
                Recipient = recipient.Ref.Value,
                RecipientAddress = new Guid("7B422FA4-E1B8-11E3-8C4A-0050568002CF"),
                ContactRecipient = recipient.Ref.Value,
                RecipientsPhone = recipientPhone
            };
            var result = documentLogic.CreateInternetDocument(document);
            int a = 0;
        }
    }
}
