using System;
using Spectre.Console;

namespace ReminderCLI;

public class TodoHandler
{

    private TodoService _service = new();


    public void GetAllTodos()
    {

        List<Todo> items = _service.GetAllTodos();

        if(items.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]\nThere are no todos[/]\n");
        }

        foreach(Todo item in items)
        {
            AnsiConsole.MarkupLine($"[blue]{item.TodoName} - {item.Date} - {item.ReminderFrequency}[/]\n");
        }
    }

    public void AddTodo()
    {
        if(!AddTodoPrompt())return;

        AnsiConsole.MarkupLine("\n[green]Todo has been successfully added.[/]\n");

        AddTodoChoice();

    }

    public int DeleteTodoSelection()
    {
        List<Todo> items = _service.GetAllTodos();

        if(items.Count == 0)
        {
            return -1;
        }

        // List<string> todos = new List<string>();

        var todoDetails = new Dictionary<int, string>();

        foreach(Todo item in items)
        {
            todoDetails.Add(item.Id,item.TodoName);
        }

        var todo = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Select a Todo to delete:").AddChoices(todoDetails.Values).HighlightStyle(new Style(Color.Black,Color.Green1,Decoration.Italic)));


        var key = todoDetails.FirstOrDefault(x => x.Value == todo).Key;

        return key;
    }
    public int EditTodoSelection()
    {
        List<Todo> items = _service.GetAllTodos();

        if(items.Count == 0)
        {
            return -1;
        }

        // List<string> todos = new List<string>();

        var todoDetails = new Dictionary<int, string>();

        foreach(Todo item in items)
        {
            todoDetails.Add(item.Id,item.TodoName);
        }

        var todo = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Select a Todo to Edit:").AddChoices(todoDetails.Values).HighlightStyle(new Style(Color.Black,Color.Green1,Decoration.Italic)));


        var key = todoDetails.FirstOrDefault(x => x.Value == todo).Key;

        return key;
    }

    public bool EditTodo()
    {
        int key = EditTodoSelection();

        string todo = AnsiConsole.Ask<string>("Enter a Todo:");

        DateTime dueDate = AnsiConsole.Ask<DateTime>("Enter Todo Date:");

        string reminderFreq = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices("Daily", "Weekly","Monthly").HighlightStyle(new Style(Color.Black,Color.Green1,Decoration.Italic)));

        if(!_service.EditTodo(key, todo,dueDate,reminderFreq))
        {
            AnsiConsole.MarkupLine("[red]Todo could not be updated[/]\n");
            return false;
        }
        else
        {
            AnsiConsole.MarkupLine("[green]Todo has been updated[/]\n");
            return true;
        }

        
    }

    public bool DeleteTodo()
    {

        int key = DeleteTodoSelection();
        
        if(!_service.DeleteTodo(key))
        {
            AnsiConsole.MarkupLine($"[red]Todos could not be found.[/]");
            return false;
        }
        else
        {

            AnsiConsole.MarkupLine($"[green]Todo has been successfully deleted[/]\n");
            
            DeleteTodoChoice();

            return true;
        }

    }

    private void DeleteTodoChoice()
    {
        while(true)
        {
            string choice = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices(StateOptions.DeleteOptions.Keys).HighlightStyle(new Style(Color.Black,Color.Green1,Decoration.Italic)));

            if(choice == "Back to Main Menu")
            {
                break;
            }

            if(choice == "Delete New Todo")
            {
                if(DeleteTodo())
                {
                    AnsiConsole.MarkupLine("[green]Todo has been successfully been deleted.[/]\n");
                    continue;
                }
            }
        }

        
    }




    private bool AddTodoPrompt()
    {

        string todo = AnsiConsole.Ask<string>("Enter a Todo:");

        DateTime dueDate = AnsiConsole.Ask<DateTime>("Enter Todo Date:");

        string reminderFreq = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices("Daily", "Weekly","Monthly").HighlightStyle(new Style(Color.Black,Color.Green1,Decoration.Italic)));


        Todo item = new Todo(todo, dueDate, reminderFreq);

        

        if(!_service.AddTodo(item))
        {
            AnsiConsole.MarkupLine("[red]Todo cannot be empty.[/]\n");
            return false;
        }
        return true;
    }

    private void AddTodoChoice()
    {

        while(true)
        {
            string choice = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices(StateOptions.AddOptions.Keys).HighlightStyle(new Style(Color.Black,Color.Green1,Decoration.Italic)));

            if(choice == "Back to Main Menu")
            {
                break;
            }

            if(choice == "Add New Todo")
            {
                if(AddTodoPrompt())
                {
                    AnsiConsole.MarkupLine("[green]Todo has been successfully added.[/]\n");
                    continue;
                }
            }
            
        }        
    }

    
}
