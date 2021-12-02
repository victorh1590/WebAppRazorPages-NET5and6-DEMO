using System;
using System.Linq;
using log4net.Filter;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Model;

namespace ToDoApp
{
    public class DbInitializer
    {
        public static void Initialize(ToDoContext context)
        {
            if (context.Todos.Any()) return;

            var todos = new[]
            {
                new ToDo {Date = DateTime.Now, Done = false, Title = "Testando1"},
                new ToDo {Date = DateTime.Now, Done = false, Title = "Testando2"},
                new ToDo {Date = DateTime.Now, Done = false, Title = "Testando3"}
            };
            
            context.Todos.AddRange(todos);
            context.SaveChanges();
        }
        
    }
}