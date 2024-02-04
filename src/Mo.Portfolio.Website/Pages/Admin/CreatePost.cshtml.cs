using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mo.Portfolio.Website.Data.Entities;
using Mo.Portfolio.Website.Services.Abstractions;

namespace Mo.Portfolio.Website.Pages.Admin;

public class CreatePostModel(
    ILogger<CreatePostModel> logger,
    IGroupService groupService,
    IPostService postService) : PageModel
{
    [BindProperty] public Post Post { get; set; } = null!;

    public List<Group> Groups = new();

    public async Task OnGet()
    {
        Groups = await groupService.GetAll();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        Guid postId = await postService.Create(Post);

        return RedirectToPage($"./ReadPost", new { id = postId});
    }
}