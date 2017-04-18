using System;

namespace NovaPoshta.Core.Entities
{
    public class ContactPerson
    {
        public string Description { get; set; }
        public Guid? Ref { get; set; }
        public string Phones { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Guid? CounterpartyRef { get; set; }
        public string Phone { get; set; }
    }
}
