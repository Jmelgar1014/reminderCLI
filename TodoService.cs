using System;

namespace ReminderCLI;

public class TodoService
{

    public bool AddTodo(string todo)
    {
        if(string.IsNullOrWhiteSpace(todo))
        {
            return false;
        }

        using var context = new DbCon();

        var item = new Todo(todo);

        context.Add(item);
        context.SaveChanges();

        // Todo test = new Todo(todo);

        return true;

        
    }

}
