using System;
using System.Collections.Generic;
using NovaPoshta.Core.Entities;

namespace NovaPoshta.Reports
{
    public interface IReport
    {
        IEnumerable<Document> GetUnreceivedDocuments(IEnumerable<Document> documents);
    }
}