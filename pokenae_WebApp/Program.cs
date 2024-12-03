using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pokenae_WebApp.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<pokenae_WebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("pokenae_WebAppContext") ?? throw new InvalidOperationException("Connection string 'pokenae_WebAppContext' not found.")));

//GoogleSheetsServiceの登録
//builder.Services.AddHttpClient<GoogleSheetsService>(client =>
//{
//    client.BaseAddress = new Uri("https://script.google.com/macros/s/AKfycby0eB-AnstPy3b3m_ghF1rcZnNpUWqmuM4ZXWPY0-9n0iCqdoStfR0GBfgAIu3lMRP2/exec");
//});
builder.Services.AddSingleton("https://script.google.com/macros/s/AKfycby0eB-AnstPy3b3m_ghF1rcZnNpUWqmuM4ZXWPY0-9n0iCqdoStfR0GBfgAIu3lMRP2/exec");
builder.Services.AddHttpClient<GoogleSheetsService>();

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

//apiコントローラ使用のため
app.MapControllers();




app.Run();
