
using AloKaza.Data;
using AloKaza.Service.Abstract;
using AloKaza.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient(typeof(IService<>), typeof(Service<>)); // Gerekti�inde enjekte edilebilmesi i�in Service container'�ndan yararlan�ld�...

builder.Services.AddTransient<IReportService, ReportService>();

builder.Services.AddTransient<IAppUserService, AppUserService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login"; // oturum a�mayan kullan�c�lar�n giri� i�in g�nderilece�i adres
    x.LogoutPath = "/Admin/Logout";
    x.AccessDeniedPath = "/AccessDenied"; // yetkilendirme ile ekrana eri�im hakk� olmayan kullan�c�lar�n g�nderilece�i sayfa
    x.Cookie.Name = "Administrator"; // Olu�acak kukinin ismi
    x.Cookie.MaxAge = TimeSpan.FromDays(1); // Olu�acak kukinin ya�am s�resi(1 g�n)
});

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminPolicy", p => p.RequireClaim("Role", "Admin")); // admin paneline giri� yapma yetkisine sahip olanlar� bu kuralla kontrol edece�iz
    x.AddPolicy("UserPolicy", p => p.RequireClaim("Role", "User")); // admin d���nda yetkilendirme kullan�rsak bu kural� kullanabiliriz(siteye �ye giri�i yapanlar� �n y�zde bir panele eri�tirme gibi)
});

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
app.UseSession(); // session i�in

app.UseAuthentication(); // Dikkat! �nce UseAuthentication sat�r� gelmeli sonra UseAuthorization

app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
