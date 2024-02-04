using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mo.Portfolio.Website.Data.Entities;
using Mo.Portfolio.Website.Services.Abstractions;

namespace Mo.Portfolio.Website.Pages.Admin;

public class PostList(
    ILogger<PostList> logger,
    IGroupService groupService,
    IPostService postService) : PageModel
{
    public List<Post> Posts = new();

    public async Task OnGet(Guid id)
    {
        Posts = await postService.GetAll();
    }

    public IActionResult OnPost()
    {
        return RedirectToPage();
    }
}