using System;

namespace ReminderCLI;

public class StateOptions
{

    public enum MenuOptions {
        ViewAll,
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

    public enum DeleteMenu
    {
        DeleteNewTodo,
        Back
    }

    public static Dictionary<string,AddMenu> AddOptions = new()
    {
        {"Add New Todo",AddMenu.AddNewTodo},
        {"Back to Main Menu", AddMenu.Back}
    };


    public static Dictionary<string, MenuOptions> MainOptions = new()
    {
        {"View Todos", MenuOptions.ViewAll},
        {"Add Todo", MenuOptions.AddTodo},
        {"Edit Todo", MenuOptions.EditTodo},
        {"Delete Todo", MenuOptions.DeleteTodo},
        {"Exit", MenuOptions.Exit}
    };

    public static Dictionary<string,DeleteMenu> DeleteOptions = new()
    {
        {"Delete New Todo", DeleteMenu.DeleteNewTodo},
        {"Back to Main Menu", DeleteMenu.Back}
    };
}
