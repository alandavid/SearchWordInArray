using Business;
using Business.Interfaces;
using Business.Managers;
using Common.Entities;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebApi.Controllers
{
    public class SearchController : ApiController
    {
        private IAuditManager _manager;
        private IManagerSearch _managerSearch;
        public SearchController()
        {
            _manager = new AuditManager();
            _managerSearch = new ManagerSearch();
        }
        // GET: api/Search
        public JsonResult<List<Audit>> Get()
        {
            return Json(_manager.GetAllAudit().ToList());
        }

        // GET: api/Search?word=java
        public JsonResult<string> Get(string word)
        {
            return Json(_managerSearch.findWord(MatrizHelper.matriz, word.ToUpper()));
        }

     
    }
}
