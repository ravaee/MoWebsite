using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mo.Portfolio.Website.Data.Entities;
using Mo.Portfolio.Website.Services.Abstractions;
using Mo.Portfolio.Website.Types;

namespace Mo.Portfolio.Website.Pages.Admin;

public class GroupPage(
    IGroupService groupService,
    ILogger<GroupPage> logger) : PageModel
{
    [BindProperty] public string Name { get; set; } = null!;
    [BindProperty] public GroupType GroupType { get; set; }

    public List<Group> Groups = new();

    public async Task OnGet()
    {
        Groups = await groupService.GetAll();
    }

    public async Task<IActionResult> OnPost(string action, Guid? groupId)
    {
        if (action == "create")
        {
            await groupService.Create(new Group
            {
                Name = Name,
                GroupType = GroupType
            });
        }
        else if (action == "delete" && groupId.HasValue)
        {
            await groupService.Delete(groupId.Value);
        }

        return RedirectToPage();
    }
}