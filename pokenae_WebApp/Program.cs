using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pokenae_WebApp.Data;
using pokenae_WebApp.Services;
using pokenae_WebApp.Options;
using System.Configuration;
using pokenae_WebApp.Services.Impl;
using pokenae_WebApp.Pages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<pokenae_WebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("pokenae_WebAppContext") ?? throw new InvalidOperationException("Connection string 'pokenae_WebAppContext' not found.")));

// GoogleAppsScriptServiceの登録
builder.Services.AddControllers();
builder.Services.AddHttpClient<IGoogleSpreadSheetService, GoogleSpreadSheet_GoogleAppsScriptService>();
builder.Services.Configure<GoogleAppsScriptOptions>(builder.Configuration.GetSection("GoogleAppsScript"));

// HttpClientのベースアドレス設定
builder.Services.AddHttpClient("",client =>
{
    var baseAddress = builder.Configuration["BaseAddress"];
    if (!string.IsNullOrEmpty(baseAddress))
    {
        client.BaseAddress = new Uri(baseAddress);
    }
});

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

// apiコントローラ使用のため
app.MapControllers();

app.Run();
