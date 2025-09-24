using Microsoft.AspNetCore.Mvc;
using SfeirAPI.Domain.Todos;
using SfeirAPI.WebApi.DTOs;

namespace SfeirAPI.WebApi.Controllers;

[ApiController]
[Route("todos")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todos;

    public TodosController(ITodoService todos)
    {
        _todos = todos;
    }
    
    [HttpGet("open")]
    public ActionResult<IList<Todo>> GetOpenTodos()
    {
        var openTodos = _todos.AllOpen();
        return Ok(openTodos);
    }

    [HttpGet("done")]
    public ActionResult<IList<Todo>> GetDoneTodos()
    {
        var doneTodos = _todos.AllDone();
        return Ok(doneTodos);
    }
    
    [HttpGet("{id:guid}")]
    public ActionResult<Todo> GetTodo(Guid id)
    {
        var todo = _todos.Get(id);
        if (todo is null)
        {
            return NotFound();
        }
        
        return Ok(todo);
    }

    [HttpPost("add")]
    public ActionResult<Todo> AddTodos(TodoInput todoInput)
    {
        var newTodo = todoInput.ToNewTodo();
        _todos.Add(newTodo);
        return Created($"todos/{newTodo.Id}", newTodo);
    }
    
    [HttpPut("set-done/{id:guid}")]
    public ActionResult<Todo> UpdateTodo(Guid id)
    {
        var updatedTodo = _todos.SetDone(id);
        if (updatedTodo is null)
            return NotFound();
        
        return Ok(updatedTodo);
    }

    [HttpDelete("remove/{id:guid}")]
    public IActionResult DeleteTodo(Guid id)
    {
        _todos.Remove(id);
        return Ok();
    }
}