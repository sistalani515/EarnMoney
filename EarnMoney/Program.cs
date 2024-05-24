using EarnMoney.Data;
using EarnMoney.Helpers.Database;
using EarnMoney.Models.Databases;
using EarnMoney.Services.Implements;
using EarnMoney.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<DatabaseInitializer>();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IDanaService, DanaServices>();
builder.Services.AddScoped<IEarnMoneyUserService, EarnMoneyUserService>();
builder.Services.AddScoped<IEarnMoneyService, EarnMoneyService>();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();
var dbInit = new DatabaseInitializer(app.Services);
dbInit.Initialize();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();
