using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.API.Request;
using _2._Domain;
using _3._Data;
using _3._Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        private readonly ITutorialData _tutorialData;
        private readonly ITutorialDomain _tutorialDomain;
        private readonly IMapper _mapper;
        
        public TutorialController(ITutorialData tutorialData,ITutorialDomain tutorialDomain,IMapper mapper)
        {
            _tutorialData = tutorialData;
            _tutorialDomain = tutorialDomain;
            _mapper = mapper;
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
        public Boolean Post([FromBody] TutorialRequest  data)
        {
           /* var tutorial = new Tutorial()
            {
                Name = data.Name,
                Description = data.Description
            };*/

           var tutorial = _mapper.Map<TutorialRequest, Tutorial>(data);
           
           return _tutorialDomain.Save(tutorial);
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
