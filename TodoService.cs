using System;

namespace ReminderCLI;

public class TodoService
{

    public bool AddTodo(Todo todo)
    {
        using var context = new DbCon();

        context.Add(todo);

        context.SaveChanges();

        // Todo test = new Todo(todo);

        return true;
    }

    public List<Todo> GetAllTodos()
    {
        using var context = new DbCon();

        return context.Todos.ToList();
    }

}
