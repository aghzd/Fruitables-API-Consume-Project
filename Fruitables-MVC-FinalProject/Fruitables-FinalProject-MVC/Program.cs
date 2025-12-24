using Fruitables_FinalProject_MVC.Helpers.Handlers;
using Fruitables_FinalProject_MVC.Services;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddSingleton(new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
});

builder.Services.AddScoped<ISliderImageService, SliderImageService>();
builder.Services.AddScoped<ISliderInfoService, SliderInfoService>();
builder.Services.AddScoped<IStoreFeatureService, StoreFeatureService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStatsCardService, StatsCardService>();
builder.Services.AddScoped<IProductOfferService, ProductOfferService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IContactAdminService, ContactAdminService>();
builder.Services.AddScoped<IContactService, ContactService>();


builder.Services.AddHttpClient<BasketService>(client =>
{
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/Login";
    });

builder.Services.AddAuthorization();


builder.Services.AddHttpContextAccessor();



builder.Services.AddTransient<JwtHandler>();

builder.Services.AddHttpClient<IStatsCardService, StatsCardService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7178/");
})
.AddHttpMessageHandler<JwtHandler>();

builder.Services.AddHttpClient<ICategoryService, CategoryService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7178/");
})
.AddHttpMessageHandler<JwtHandler>();

builder.Services.AddHttpClient<IProductService, ProductService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7178/");
})
.AddHttpMessageHandler<JwtHandler>();

builder.Services.AddHttpClient<IProductImageService, ProductImageService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7178/");
})
.AddHttpMessageHandler<JwtHandler>();

builder.Services.AddHttpClient<IProductOfferService, ProductOfferService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7178/");
})
.AddHttpMessageHandler<JwtHandler>();

builder.Services.AddHttpClient<ISliderImageService, SliderImageService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7178/");
})
.AddHttpMessageHandler<JwtHandler>();

builder.Services.AddHttpClient<ISliderInfoService, SliderInfoService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7178/");
})
.AddHttpMessageHandler<JwtHandler>();

builder.Services.AddHttpClient<IStoreFeatureService, StoreFeatureService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7178/");
})
.AddHttpMessageHandler<JwtHandler>();

builder.Services.AddHttpClient<IContactService, ContactService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7178/api/");
});

builder.Services.AddHttpClient<IContactAdminService, ContactAdminService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7178/api");
})
.AddHttpMessageHandler<JwtHandler>();

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
            name: "areas",
            pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
          );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
