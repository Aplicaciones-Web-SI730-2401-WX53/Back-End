using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2._Domain;
using _3._Data;
using _3._Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        private ITutorialData _tutorialData;
        private ITutorialDomain _tutorialDomain;
        
        public TutorialController(ITutorialData tutorialData,TutorialDomain tutorialDomain)
        {
            _tutorialData = tutorialData;
            _tutorialDomain = tutorialDomain;
        }
        
        // GET: api/Tutorial
        [HttpGet]
        public List<Tutorial> Get()
        {
            //TutorialOracleData tutorialMySqlData = new TutorialOracleData();
            return _tutorialData.getAll();
        }

        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tutorial
        [HttpPost]
        public Boolean Post([FromBody] Tutorial  data)
        {
           return _tutorialDomain.Save(data);
        }

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
