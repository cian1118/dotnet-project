using Microsoft.EntityFrameworkCore;
using RazorPagesToDo.Data;
using Microsoft.AspNetCore.Identity;
//using RazorPagesToDo.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// builder.Services.AddDbContextPool<RazorPagesToDoIdentityDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()  
               .AddEntityFrameworkStores<RazorPagesToDoIdentityDbContext>();
builder.Services.AddDbContext<RazorPagesToDoIdentityDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<RazorPagesToDoIdentityDbContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesToDoIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'RazorPagesToDoIdentityDbContext' not found.")));
builder.Services.AddDbContext<RazorPagesToDoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesToDoContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesToDoContext' not found.")));

// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<RazorPagesToDoIdentityDbContext>();
builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
