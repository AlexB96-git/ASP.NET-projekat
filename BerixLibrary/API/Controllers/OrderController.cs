using Application.Commands.Users;
using Application.DTOs.Users;
using Application.Queries.Users;
using Application;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.Orders;
using Application.DTOs.Orders;
using Application.Commands.Orders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public OrderController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetOrdersQuery query, [FromQuery] string? UserName = null)
        {
            return Ok(_executor.ExecuteQuery(query, UserName));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOrderQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }


        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderInsertDTO dto, [FromServices] IAddOrderCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
