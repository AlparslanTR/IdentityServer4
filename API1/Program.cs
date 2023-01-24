using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.Authority = "https://localhost:7142"; // Token sahibi kim ana serverimizi belirtiyoruz.
    opt.Audience = "resource_api1"; // Güvenlik Amaçlý Doðrulama.
});

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("ReadProduct", policy => // Þart Ekle
    {
        policy.RequireClaim("scope", "api1.read"); // Claim þartnamesi api1 okuma iþlemi yapabilir.
    });
    opt.AddPolicy("UpdateOrCreate", policy =>
    {
        policy.RequireClaim("scope", new[] { "api1.update", "api1.create" });
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Kimlik Doðrulama
app.UseAuthorization(); // Yetkilendirme

app.MapControllers();

app.Run();
