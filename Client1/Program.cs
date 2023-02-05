var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(opts =>
{
    // Üyelik sistemlerin de 2 türlü üyelik vardýr biri kiþi diðer bayilik için bunu ayýrt etmek için þemalar kullanýlýyor.
    opts.DefaultScheme = "Cookies";
    opts.DefaultChallengeScheme = "oidc";
}).AddCookie("Cookies").AddOpenIdConnect("oidc", opts =>
{
    opts.SignInScheme = "Cookies";
    opts.Authority = "https://localhost:7142";
    opts.ClientId = "Client1-Mvc";
    opts.ClientSecret = "password123";
    opts.ResponseType = "code id_token";
    opts.GetClaimsFromUserInfoEndpoint = true;
    opts.SaveTokens=true;
    opts.Scope.Add("api1.read");
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
