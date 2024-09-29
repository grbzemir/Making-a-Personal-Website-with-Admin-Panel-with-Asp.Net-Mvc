using Admin.Models.S�n�flar;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Ba�lant� dizesini kullanarak DbContext'i ekle
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Kontrolc�ler ve g�r�n�mler i�in hizmetleri ekle
builder.Services.AddControllersWithViews();

// Kimlik do�rulama i�in Cookie ekle
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // Oturum a�ma sayfas�
    });

// Oturum deste�i ekle
builder.Services.AddSession();

var app = builder.Build();

// HTTP istek boru hatt�n� yap�land�r
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Kimlik do�rulama ve oturum y�netimini ekleyin
app.UseAuthentication();
app.UseAuthorization();
app.UseSession(); // Oturum y�netimi

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
