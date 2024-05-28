using _1.API.Request;
using _1.API.Response;
using _2._Domain;
using _3._Data;
using _3._Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _1.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TutorialController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ITutorialData _tutorialData;
    private readonly ITutorialDomain _tutorialDomain;

    public TutorialController(ITutorialData tutorialData, ITutorialDomain tutorialDomain, IMapper mapper)
    {
        _tutorialData = tutorialData;
        _tutorialDomain = tutorialDomain;
        _mapper = mapper;
    }

    // GET: api/Tutorial
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var data = await _tutorialData.getAllAsync();
        var result = _mapper.Map<List<Tutorial>, List<TutorialResponse>>(data);
        return Ok(result);
    }

    [HttpGet]
    [Route("Search")]
    public async Task<IActionResult> GetSearchAsync(string? name, string? description, int? year)
    {
        var data = await _tutorialData.getSearchedAsync(name, description, year);
        var result = _mapper.Map<List<Tutorial>, List<TutorialResponse>>(data);

        if (result.Count() == 0) return NotFound();

        return Ok(result);
    }

    // GET: api/Tutorial/5
    [HttpGet("{id}", Name = "Get")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var data = await _tutorialData.GetByIdAsync(id);
        var result = _mapper.Map<Tutorial, TutorialResponse>(data);

        if (result == null) return NotFound();

        return Ok(result);
    }

    // POST: api/Tutorial
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] TutorialRequest data)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest();

            var tutorial = _mapper.Map<TutorialRequest, Tutorial>(data);

            var result = await _tutorialDomain.SaveAsync(tutorial);

            return Created("api/Tutorial", result);
        }
        catch (Exception ex)
        {
            //loggear txt,base,cloud 
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    // PUT: api/Tutorial/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TutorialRequest data)
    {
        try
        {
            if (!ModelState.IsValid) throw new FormatException();

            var tutorial = _mapper.Map<TutorialRequest, Tutorial>(data);

            var result = await _tutorialDomain.UpdateAsync(tutorial, id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            //loggear txt,base,cloud 
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    // DELETE: api/Tutorial/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _tutorialDomain.DeleteAsync(id);

        return Ok();
    }
}