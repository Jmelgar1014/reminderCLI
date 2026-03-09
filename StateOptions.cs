using System;

namespace ReminderCLI;

public class StateOptions
{

    public enum MenuOptions {
        AddTodo,
        EditTodo,
        DeleteTodo,
        Exit
    }

    public enum AddMenu
    {
        AddNewTodo,
        Back
    }

    public static Dictionary<string,AddMenu> AddOptions = new()
    {
        {"Add New Todo",AddMenu.AddNewTodo},
        {"Back to Main Menu", AddMenu.Back}
    };


    public static Dictionary<string, MenuOptions> MainOptions = new()
    {
        {"Add Todo", MenuOptions.AddTodo},
        {"Edit Todo", MenuOptions.EditTodo},
        {"Delete Todo", MenuOptions.DeleteTodo},
        {"Exit", MenuOptions.Exit}
    };
}
