using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Domain.Commands.Requests;
using Todo.API.Models;

namespace Todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        [HttpGet]
        [Produces(typeof(List<TodoModel>))]
        public async Task<IActionResult> Get([FromServices] IMediator handler)
        {
            var result = await handler.Send(new TodoGetModel());
            return result.TodoList.Any() ? Ok(result.TodoList) : NoContent();
        }

        [HttpPost]
        [Produces(typeof(TodoModel))]
        public async Task<IActionResult> Create([FromServices] IMediator handler,
            [FromBody] TodoCreateModel request)
        {
            var response = await handler.Send(request);
            return Ok(response.Todo);
        }

        [HttpGet("{todoid}")]
        [Produces(typeof(TodoModel))]
        public async Task<IActionResult> Get(int todoid, [FromServices] IMediator handler)
        {
            var result = await handler.Send(new TodoGetModel(todoid)); ;
            return result.Todo != null ? Ok(result.Todo) : NotFound();
        }

        [HttpDelete("{todoid}")]
        [Produces(typeof(TodoModel))]
        public async Task<IActionResult> Delete(int todoid, [FromServices] IMediator handler)
        {
            var response = await handler.Send(new TodoDeleteModel(todoid));
            return NoContent();
        }

        [HttpPut("{todoid}")]
        [Produces(typeof(TodoModel))]
        public async Task<IActionResult> Put(int todoid, [FromServices] IMediator handler,
            [FromBody] TodoUpdateModel request)
        {
            request.Id = todoid;
            var response = await handler.Send(request);
            return Ok(response.Todo);
        }
    }
}
