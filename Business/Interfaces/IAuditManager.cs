using System.Collections.Generic;
using Common.Entities;

namespace Business.Interfaces
{
    public interface IAuditManager
    {
        IList<Audit> GetAllAudit();
        void SaveAudit(string result, string usuario, string word);
    }
}