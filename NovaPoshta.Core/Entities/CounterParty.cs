﻿using System;

namespace NovaPoshta.Core.Entities
{
    public class CounterParty
    {
        public string Description { get; set; }
        public Guid? Ref { get; set; }
        public Guid City { get; set; }
        public Guid CityRef { get; set; }
        public string CityName { get; set; }
        public object Counterparty { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string OwnershipFormRef { get; set; }
        public string OwnershipFormDescription { get; set; }
        public string EDRPOU { get; set; }
        public string CounterpartyType { get; set; }
        public string Phones { get; set; }
        public string FullName { get; set; }
        public string CounterpartyProperty { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public RootObject<ContactPerson> ContactPerson { get; set; }
    }
}
