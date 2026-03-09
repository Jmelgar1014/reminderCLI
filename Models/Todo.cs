using System;

namespace ReminderCLI;

public class Todo
{
    public string TodoName {get; set;}

    public DateTime Date {get; set;}

    public string ReminderFrequency {get;set;} = "Daily";


    public Todo(string todo)
    {
        TodoName = todo;
    }
}
