using System;
using Spectre.Console;

namespace ReminderCLI;

public class TodoHandler
{

    private TodoService _service = new();


    public void GetAllTodos()
    {
        List<Todo> items = _service.GetAllTodos();

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


    private bool AddTodoPrompt()
    {

        string todo = AnsiConsole.Ask<string>("Enter a Todo:");

        DateTime dueDate = AnsiConsole.Ask<DateTime>("Enter Todo Date:");

        string reminderFreq = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices("Daily", "Weekly","Monthly"));


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
