using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Model;

namespace ToDoApp.Services
{
    public class ToDoService
    {
        private readonly ToDoContext _context;

        public ToDoService(ToDoContext context)
        {
            _context = context;
        }

        // public async Task<ToDo> Create()
        // {
        //     // ToDo obj = new ToDo();
        //     // obj.Done = false;
        //     // obj.Date = DateTime.Now;
        //     // obj.Title = "Testando1";
        //
        //     _context.Todos.Add(obj);
        //     await _context.SaveChangesAsync();
        //
        //     return obj;
        // }

        public async Task<List<ToDo>> GetAll()
        {
            List<ToDo> todos = await _context.Todos.AsNoTracking().Select(todo => new ToDo()
            {
                Date = todo.Date,
                Done = todo.Done,
                Title = todo.Title,
                Id = todo.Id
            }).ToListAsync();

            return todos;
        }
    }   
}