using SfeirAPI.Domain.Todos;

namespace SfeirAPI.WebApi.DTOs;

public record TodoInput(string Text)
{
    public Todo ToNewTodo()
        => new(Guid.NewGuid(), Text, false);
}