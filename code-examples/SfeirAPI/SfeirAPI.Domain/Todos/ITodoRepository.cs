namespace SfeirAPI.Domain.Todos;

public interface ITodoRepository
{
    IList<Todo> GetAllTodos();
    void Add(Todo todo);
    Todo? Find(Guid id);
    Todo? SetDone(Guid id);
    void Remove(Guid id);
}

// Remark: this class should be in another "database" project
public class InMemoryTodoDatabase : ITodoRepository
{
    private static List<Todo> todos = [
        new(Guid.NewGuid(), "Créer le controler", true),
        new(Guid.NewGuid(), "Créer le service et le domain", true),
        new(Guid.NewGuid(), "Injecter les dépendances", false)
    ];

    public IList<Todo> GetAllTodos() 
        => todos;

    public void Add(Todo todo) 
        => todos.Add(todo);

    public Todo? Find(Guid id) 
        => todos.FirstOrDefault(t => t.Id == id);

    public Todo? SetDone(Guid id)
    {
        var todo = todos.FirstOrDefault(t => t.Id == id);
        if (todo is null)
            return null;

        var updatedTodo = todo with { IsDone = true };
        
        // As we use record, we cannot mutate the data.
        // we need to remove and add again the updated copy
        todos.Remove(todo);
        todos.Add(updatedTodo);
        
        return updatedTodo;
    }

    public void Remove(Guid id)
    {
        var todo = todos.FirstOrDefault(t => t.Id == id);
        if (todo is null)
            throw new KeyNotFoundException();

        todos.Remove(todo);
    }
}