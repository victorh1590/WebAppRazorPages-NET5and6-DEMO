using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToDoApp;
using ToDoApp.Model;
using ToDoApp.Services;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ToDoService _service;

    public IndexModel(ILogger<IndexModel> logger, ToDoService toDoService)
    {
        _logger = logger;
        _service = toDoService;
    }

    public List<ToDo> Todos { get; set; }
    public async Task<IActionResult> OnGetAsync()
    {
        Todos = await _service.GetAll();
        return Page();
    }
}
