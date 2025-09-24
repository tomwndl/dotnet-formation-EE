namespace SfeirAPI.Domain.Todos;

public interface ITodoService
{
    IEnumerable<Todo> AllOpen();
    IEnumerable<Todo> AllDone();
    void Add(Todo todo);
    Todo? Get(Guid id);
    Todo? SetDone(Guid id);
    void Remove(Guid id);
}

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public IEnumerable<Todo> AllOpen() 
        => _todoRepository.GetAllTodos()
            .Where(t => !t.IsDone);
    
    public IEnumerable<Todo> AllDone()
        => _todoRepository.GetAllTodos()
            .Where(t => t.IsDone);

    public void Add(Todo todo)
        => _todoRepository.Add(todo);

    public Todo? Get(Guid id) 
        => _todoRepository.Find(id);

    public Todo? SetDone(Guid id) 
        => _todoRepository.SetDone(id);

    public void Remove(Guid id) 
        => _todoRepository.Remove(id);
}

