using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mo.Portfolio.Website.Data.Entities;
using Mo.Portfolio.Website.Services.Abstractions;

namespace Mo.Portfolio.Website.Pages.Admin;

public class ReadPostModel(
    ILogger<ReadPostModel> logger,
    IGroupService groupService,
    IPostService postService) : PageModel
{
    public Post Post = new();

    public async Task<IActionResult> OnGet(Guid id)
    {
        var post = await postService.Get(id);

        if (post is null)
        {
            return RedirectToPage("/NotFound");
        }

        Post = post;
        return Page();
    }

    public IActionResult OnPost()
    {
        return RedirectToPage();
    }
}