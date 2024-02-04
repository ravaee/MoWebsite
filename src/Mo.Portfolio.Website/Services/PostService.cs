using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Mo.Portfolio.Website.Data;
using Mo.Portfolio.Website.Data.Entities;
using Mo.Portfolio.Website.Services.Abstractions;

namespace Mo.Portfolio.Website.Services;

public class PostService(ApplicationDbContext context) : IPostService
{
    public async Task<Guid> Create(Post post)
    {
        post.CreateDate = DateTime.Today;
        
        post.Summary = ExtractPreviewText(post.Body);
        post.ImageUrl = ExtractFirstImageUrl(post.Body);
        
        await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        
        return post.Id;
    }

    public async Task<Post?> Get(Guid id)
    {
        var post = await context.Posts
            .Include(p => p.Group)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        return post;
    }

    public async Task<List<Post>> GetAll()
    {
        var posts = await context.Posts
            .Include(p => p.Group)
            .AsNoTracking()
            .ToListAsync();
        
        return posts;
    }
    
    public async Task<List<Post>> GetLastInGroup(int count, Guid groupId)
    {
        var posts = await context.Posts
            .Include(p => p.Group)
            .AsNoTracking()
            .Where(p => p.GroupId == groupId)
            .Take(count)
            .ToListAsync();
        
        return posts;
    }
    
    public async Task<List<Post>> GetAllInGroup(Guid groupId)
    {
        var posts = await context.Posts
            .Include(p => p.Group)
            .AsNoTracking()
            .Where(p => p.GroupId == groupId)
            .ToListAsync();
        
        return posts;
    }
    
    private string ExtractPreviewText(string htmlBody)
    {
        var plainText = Regex.Replace(htmlBody, "<.*?>", String.Empty);
        return plainText.Length <= 200 ? plainText : plainText.Substring(0, 200) + "...";
    }

    private string ExtractFirstImageUrl(string htmlBody)
    {
        var match = Regex.Match(htmlBody, "<img.*?src=\"(.*?)\".*?>");
        
        if (match.Success)
        {
            return match.Groups[1].Value;
        }
        
        return ""; 
    }
}