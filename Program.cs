// See https://aka.ms/new-console-template for more information
using ReminderCLI;
using Spectre.Console;



AnsiConsole.MarkupLine("[green]Welcome to TodoReminder.[/]");

var menu = new MenuHandler();

menu.Run();

