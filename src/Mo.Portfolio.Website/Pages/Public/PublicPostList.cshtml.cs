using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mo.Portfolio.Website.Data.Entities;
using Mo.Portfolio.Website.Services.Abstractions;

namespace Mo.Portfolio.Website.Pages.Public;

public class PublicPostList(
    ILogger<PublicPostList> logger,
    IGroupService groupService,
    IPostService postService) : PageModel
{
    public List<PostViewModel> PostViewModel = [];

    public async Task OnGet()
    {
        var groups = await groupService.GetAllWithPosts();

        foreach (var group in groups)
        {
            var posts = await postService.GetLastInGroup(6, group.Id); 
            PostViewModel.Add(new PostViewModel(group, posts));
        }
    }

    public IActionResult OnPost()
    {
        return RedirectToPage();
    }
}

public record PostViewModel(Group Group, List<Post> Posts);