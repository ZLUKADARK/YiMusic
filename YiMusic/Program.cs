using Microsoft.EntityFrameworkCore;
using YiMusic.BLL.Interfaces;
using YiMusic.BLL.Services;
using YiMusic.DAL.Data;
using YiMusic.DAL.Interfaces;
using YiMusic.DAL.Repositories;
using YiMusic.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepository<Music>, MusicRepositories>();
builder.Services.AddTransient<IMusicServices, MusicServices>();
builder.Services.AddControllersWithViews();

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<YiMusicDBContext>(option => option.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Music}/{action=Index}/{id?}");

app.Run();
