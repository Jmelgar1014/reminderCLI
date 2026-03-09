using System;
using Spectre.Console;

namespace ReminderCLI;

public class MenuHandler
{
    private TodoHandler _handler = new();
    
    private bool _running = true;
    public void Run()
    {
        
       while(_running)
        {
            string choice = GetChoice();
            
            switch(choice)
            {
                case "Exit":
                _running = false;
                break;

                case "Add Todo":
                _handler.AddTodo();
                break;


            }

        } 
    }

    private string GetChoice()
    {
        return AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Select from any of the options below:").AddChoices(StateOptions.MainOptions.Keys));
    }

}
