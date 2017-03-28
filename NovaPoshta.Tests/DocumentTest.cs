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
            var cityLogic = new CityLogic();
            var senderCityRef = cityLogic.GetCityByName("Одесса");

            var recipientCityRef = cityLogic.GetCityByName("Киев").FirstOrDefault().Ref;
            var recipientPhone = "0934502712";
            var recipientFirstName = "Вася";
            var recipientLastName = "Пупкин";

            var recipient = new CounterPartyLogic().CreateConterparty(new CounterParty()
            {
                FirstName = recipientFirstName,
                LastName = recipientLastName,
                Phone = recipientPhone,
                CityRef = recipientCityRef,
                CounterpartyType = "PrivatePerson",
                CounterpartyProperty = "Recipient"
            });


            int a = 0;
        }
    }
}
