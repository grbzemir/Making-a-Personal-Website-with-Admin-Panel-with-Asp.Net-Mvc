using Admin.Models.Sýnýflar;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Baðlantý dizesini kullanarak DbContext'i ekle
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Kontrolcüler ve görünümler için hizmetleri ekle
builder.Services.AddControllersWithViews();

// Kimlik doðrulama için Cookie ekle
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // Oturum açma sayfasý
    });

// Oturum desteði ekle
builder.Services.AddSession();

var app = builder.Build();

// HTTP istek boru hattýný yapýlandýr
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Kimlik doðrulama ve oturum yönetimini ekleyin
app.UseAuthentication();
app.UseAuthorization();
app.UseSession(); // Oturum yönetimi

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
