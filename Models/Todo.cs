using System;

namespace ReminderCLI;

public class Todo
{
    public int Id {get;set;}
    public string TodoName {get; set;}

    public DateTime Date {get; set;} = DateTime.Now;

    public string ReminderFrequency {get;set;} = "Daily";

    public Todo()
    {
        
    }
    public Todo(string todo,DateTime date, string reminderFrequency)
    {
        TodoName = todo;
        Date = date;
        ReminderFrequency = reminderFrequency;
    }
}
