using NSubstitute;
using SfeirAPI.Domain.Todos;

namespace SfeirAPI.Domain.UnitTests.Todos;

public class TodoServiceUnitTests
{
    [Fact]
    public void AllDone_AllStatusOfTodos_ReturnsOnlyDone()
    {
        // Arrange
        var fakeDatabase = Substitute.For<ITodoRepository>();
        var todoService = new TodoService(fakeDatabase);

        var t1 = new Todo(Guid.Empty, "Todo1", false);
        var t2 = new Todo(Guid.Empty, "Todo2", true);
        fakeDatabase
            .GetAllTodos()
            .Returns([t1, t2]);

        // Act
        var doneTodos = todoService.AllDone();

        // Assert
        Assert.Contains(t2, doneTodos);
    }
    
    [Fact]
    public void AllOpen_AllStatusOfTodos_ReturnsOnlyOpen()
    {
        // Arrange
        var fakeDatabase = Substitute.For<ITodoRepository>();
        var todoService = new TodoService(fakeDatabase);

        var t1 = new Todo(Guid.Empty, "Todo1", false);
        var t2 = new Todo(Guid.Empty, "Todo2", true);
        fakeDatabase
            .GetAllTodos()
            .Returns([t1, t2]);

        // Act
        var openTodos = todoService.AllOpen();

        // Assert
        Assert.Contains(t1, openTodos);
    }
}