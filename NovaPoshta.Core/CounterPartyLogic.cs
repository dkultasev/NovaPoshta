using System;
using System.Collections.Generic;
using System.Linq;
using NovaPoshta.Json;

namespace NovaPoshta.Core
{
    public class CounterPartyLogic
    {
        private readonly IJsonLogic _jsonLogic;


        public CounterPartyLogic(IJsonLogic jsonLogic)
        {
            if (jsonLogic == null) throw new ArgumentNullException(nameof(jsonLogic));
            _jsonLogic = jsonLogic;
        }

        public IEnumerable<ContactPerson> GetCounterpartyContactPersonsByCounterpartyRef(Guid? counterPartyRef)
        {
            var contacts = _jsonLogic.GetListOfObjects<ContactPerson>("Counterparty",
                "getCounterpartyContactPersons",
                new
                {
                    Ref = counterPartyRef.ToString()
                });

            return contacts;
        }
        public ContactPerson GetCounterpartyFirstContactWithEmail(Guid? counterPartyRef)
        {
            var contact = GetCounterpartyContactPersonsByCounterpartyRef(counterPartyRef);

            return contact.FirstOrDefault(con => !con.Email.Equals(""));
        }

        public Guid? GetSenderCounterpartyRef()
        {
            var counterParty = _jsonLogic.GetListOfObjects<CounterParty>("Counterparty", "getCounterparties",
                new
                {
                    CounterpartyProperty = "Sender",
                    Page = 1
                });
            return counterParty.FirstOrDefault()?.Ref;
        }

        public IEnumerable<CounterParty> GetCounterpartiesByCity(Guid cityRef)
        {
            return _jsonLogic.GetListOfObjects<CounterParty>("Counterparty", "getCounterparties",
                new
                {
                    CounterpartyProperty = "Recipient",
                    CityRef = cityRef.ToString()
                });
        }
        public IEnumerable<CounterParty> GetReciepentCounterParties(Guid? reciepentGuid = null, int page = 1)
        {
            dynamic prop;
            if (reciepentGuid == null)
                prop = new { CounterpartyProperty = "Recipient", Page = page };
            else prop = new { CounterpartyProperty = "Recipient", Ref = reciepentGuid, Page = page };

            return _jsonLogic.GetListOfObjects<CounterParty>("Counterparty", "getCounterparties",
                prop);
        }

        public CounterParty CreateConterparty(CounterParty counterparty)
        {
            counterparty.CounterpartyType = "PrivatePerson";
            counterparty.CounterpartyProperty = "Recipient";
            var result = _jsonLogic.ModifyObject<CounterParty>("Counterparty", "save",
                counterparty);
            return result;
        }
        public CounterParty UpdateConterparty(CounterParty counterparty)
        {
            counterparty.CounterpartyType = "PrivatePerson";
            counterparty.CounterpartyProperty = "Recipient";
            var result = _jsonLogic.ModifyObject<CounterParty>("Counterparty", "update",
                counterparty);
            return result;
        }
        public CounterParty DeleteConterparty(Guid counterPartyRef)
        {
            var result = _jsonLogic.ModifyObject<CounterParty>("Counterparty", "delete",
                new {Ref = counterPartyRef });
            return result;
        }
    }
}
