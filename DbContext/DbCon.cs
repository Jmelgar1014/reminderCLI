using System;
using Microsoft.EntityFrameworkCore;

namespace ReminderCLI;

public class DbCon : DbContext
{
    public DbSet<Todo> Todos{get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source = todos.db");

}
