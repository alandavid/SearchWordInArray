using Business.Interfaces;
using Common.Entities;
using DataAccess.Concrete;
using DataAccess.Concrete.ADO;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace Business.Managers
{
    public class AuditManager : IAuditManager
    {
        private IRepository<Audit> _respository;
        public AuditManager()
        {
            _respository = new RepositoryAudit();
        }
        public void SaveAudit(string result, string usuario, string word)
        {
            _respository.Save(new Audit { InitialDate = DateTime.Now, Usuario = usuario, Result = result, Word = word });
        }

        public IList<Audit> GetAllAudit()
        {
            return _respository.GetAll();
        }
    }
}
