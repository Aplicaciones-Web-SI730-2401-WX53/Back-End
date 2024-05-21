using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.API.Request;
using _1.API.Response;
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
        public async Task<IActionResult>  GetAsync()
        {
            //TutorialOracleData tutorialMySqlData = new TutorialOracleData();
            
            var data = await _tutorialData.getAllAsync();
            var result = _mapper.Map<List<Tutorial>,List<TutorialResponse>>(data);
            return Ok(result);
        }

        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _tutorialData.GetByIdAsync(id);
            var result = _mapper.Map<Tutorial,TutorialResponse>(data);
            return Ok(result);
        }

        // POST: api/Tutorial
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TutorialRequest  data)
        {
           /* var tutorial = new Tutorial()
            {
                Name = data.Name,
                Description = data.Description
            };*/

           var tutorial = _mapper.Map<TutorialRequest, Tutorial>(data);
           
           var result = await _tutorialDomain.SaveAsync(tutorial);

           return Ok(result);
        }

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public async Task<IActionResult>  Put(int id, [FromBody] TutorialRequest  data)
        {
            var tutorial = _mapper.Map<TutorialRequest, Tutorial>(data);
           
            var result = await _tutorialDomain.UpdateAsync(tutorial,id);

            return Ok(result);
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
