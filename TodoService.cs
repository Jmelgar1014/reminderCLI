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

    public bool DeleteTodo(int id)
    {

        if(id == -1)
        {
            return false;
        }
        using var context = new DbCon();

        var item = context.Todos.Find(id);

        // var item = items.FirstOrDefault();
        if(item != null)
        {
            
         context.Todos.Remove(item);
         context.SaveChanges();
         return true;
        }

        return false;

    }

}
