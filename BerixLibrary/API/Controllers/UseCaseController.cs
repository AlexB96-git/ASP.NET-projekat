using Application;
using Application.Commands.UseCases;
using Application.DTOs.UseCases;
using Application.Queries.UseCases;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public UseCaseController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }
        // GET: api/<UseCaseController>
        [HttpGet]
        public IActionResult Get([FromQuery] string searchTerm, [FromServices] IGetUseCasesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, searchTerm));
        }

        // GET api/<UseCaseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUseCaseQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<UseCaseController>
        [HttpPost]
        public IActionResult Post([FromBody] UseCaseDTO useCase, [FromServices] IAddUseCaseCommand command)
        {
            executor.ExecuteCommand(command, useCase);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<UseCaseController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UseCaseDTO dto, [FromServices] IEditUseCaseCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<UseCaseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUseCaseCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
