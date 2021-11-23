using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp1.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public string _url;

    public IActionResult OnGet(string? handler)
    {
        _url = Url.Page("Privacy");

        if (string.IsNullOrEmpty(handler)) return Page();
        else return StatusCode(404);
    }

    public void OnGetTest()
    {
        _url = "Test.";
    }
}
