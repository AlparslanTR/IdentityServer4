using AuthServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// ********************* //

// Identity Server Framework�ne kulland���m�z yap�y� veya izinleri belirtiyoruz ard�ndan bunun
// hangi s�n�fta yer ald���n� g�steriyoruz. En son ki kodumuz ise debug a�amas�nda bize ge�erli bir �ifreli token imzas� sa�l�yor.
// Ger�ek ortama g�nderirken developer yaz�s� yerine normal SigningCredential kullan�lmal�d�r.
builder.Services.AddIdentityServer() 
    .AddInMemoryApiResources(Config.GetApiResources())
    .AddInMemoryApiScopes(Config.GetApiScopes())
    .AddInMemoryClients(Config.GetClients())
    .AddDeveloperSigningCredential();

// ********************* //
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
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
