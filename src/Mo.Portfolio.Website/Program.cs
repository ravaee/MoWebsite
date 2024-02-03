using Mo.Portfolio.Website.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureAspNetServices()
    .ConfigureDbContext(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();