using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mo.Portfolio.Website.Pages.Admin;

public class AdminIndexModel(ILogger<AdminIndexModel> logger) : PageModel
{
    private readonly ILogger<AdminIndexModel> _logger = logger;

    public void OnGet()
    {
    }
}