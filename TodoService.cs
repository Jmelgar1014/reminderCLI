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
        Todo test = new Todo(todo);

        return true;

        
    }

}
