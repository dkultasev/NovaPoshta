using System.Collections.Generic;
using NovaPoshta.Core.Entities;

namespace NovaPoshta.Reports
{
    public interface IReports
    {
        IEnumerable<Document> GetUnreceivedDocuments(int treshold);
    }
}